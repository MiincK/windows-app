﻿using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ListenMoeClient
{
	public partial class MainForm : Form
	{
		#region Magical form stuff
		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr window, int index, int value);
		[DllImport("user32.dll")]
		public static extern int GetWindowLong(IntPtr window, int index);
		const int GWL_EXSTYLE = -20;
		const int WS_EX_TOOLWINDOW = 0x00000080;
		const int WS_EX_APPWINDOW = 0x00040000;

		Point originalLocation;
		Point preMoveCursorLocation;
		int cursorLeftDiff, cursorRightDiff, cursorTopDiff, cursorBottomDiff;
		bool moving = false;

		//Screen edge snapping
		private const int snapDistance = 10;
		private bool CloseToEdge(int pos, int edge)
		{
			return Math.Abs(pos - edge) <= snapDistance;
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				preMoveCursorLocation = Cursor.Position;
				originalLocation = this.Location;
				moving = true;

				cursorLeftDiff = preMoveCursorLocation.X - this.Left;
				cursorRightDiff = this.Right - preMoveCursorLocation.X;
				cursorTopDiff = preMoveCursorLocation.Y - this.Top;
				cursorBottomDiff = this.Bottom - preMoveCursorLocation.Y;
			}
			else if (e.Button == MouseButtons.Right)
			{
				contextMenu1.Show(this, e.Location);
			}
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (moving)
			{
				Point cursorDiff = new Point(Cursor.Position.X - preMoveCursorLocation.X, Cursor.Position.Y - preMoveCursorLocation.Y);
				Point newLocation = new Point(originalLocation.X + cursorDiff.X, originalLocation.Y + cursorDiff.Y);

				if (RawInput.IsPressed(VirtualKeys.Shift))
				{
					this.Location = newLocation;
				}
				else
				{
					Screen s = Screen.FromPoint(newLocation);

					bool hSnapped = false;
					bool vSnapped = false;

					SnapToRectangle(s.WorkingArea, ref hSnapped, ref vSnapped, newLocation);
					SnapToRectangle(s.Bounds, ref hSnapped, ref vSnapped, newLocation);

					int finalX = newLocation.X;
					int finalY = newLocation.Y;
					if (hSnapped)
						finalX = this.Location.X;
					if (vSnapped)
						finalY = this.Location.Y;

					this.Location = new Point(finalX, finalY);

					Settings.Set(Setting.LocationX, this.Location.X);
					Settings.Set(Setting.LocationY, this.Location.Y);
					Settings.WriteSettings();
				}
			}
		}

		private void SnapToRectangle(Rectangle rect, ref bool hSnappedRef, ref bool vSnappedRef, Point newLocation)
		{
			bool hSnapped, vSnapped;
			if ((hSnapped = CloseToEdge(rect.Left, newLocation.X))) this.Left = rect.Left;
			if ((vSnapped = CloseToEdge(rect.Top, newLocation.Y))) this.Top = rect.Top;
			if (!hSnapped && (hSnapped = CloseToEdge(rect.Right, newLocation.X + Width))) this.Left = rect.Right - this.Width;
			if (!vSnapped && (vSnapped = CloseToEdge(rect.Bottom, newLocation.Y + Height))) this.Top = rect.Bottom - this.Height;

			hSnappedRef |= hSnapped;
			vSnappedRef |= vSnapped;
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			if (moving)
				moving = false;
		}

		#endregion

		WebStreamPlayer player;
		SongInfoStream songInfoStream;

		Font titleFont;
		Font artistFont;
		Font volumeFont;

		public FormSettings SettingsForm;

		Sprite favSprite;
		Sprite lightFavSprite;
		Sprite darkFavSprite;
		Sprite fadedFavSprite;
		bool heartFav = false;

		private ThumbnailToolBarButton button;

		CancellationTokenSource cts;
		CancellationToken ct;
		Task updaterTask;
		Task renderLoop;

		Rectangle gripRect = new Rectangle();
		Rectangle rightEdgeRect = new Rectangle();
		Rectangle leftEdgeRect = new Rectangle();

		bool spriteColorInverted = false; //Excluding play/pause icon
		bool playPauseInverted = false;

		public MainForm()
		{
			InitializeComponent();
			this.MinimumSize = new Size(Settings.DEFAULT_WIDTH, Settings.DEFAULT_HEIGHT);

			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

			centerPanel.MouseDown += Form1_MouseDown;
			centerPanel.MouseMove += Form1_MouseMove;
			centerPanel.MouseUp += Form1_MouseUp;
			panelRight.MouseDown += Form1_MouseDown;
			panelRight.MouseMove += Form1_MouseMove;
			panelRight.MouseUp += Form1_MouseUp;

			contextMenu1.MenuItems.Add(new MenuItem("LISTEN.moe Desktop Client v" + Globals.VERSION.ToString()) { Enabled = false });
			Settings.LoadSettings();
			//Write immediately after loading to flush any new default settings
			Settings.WriteSettings();

			cts = new CancellationTokenSource();
			ct = cts.Token;
#pragma warning disable CS4014
			CheckForUpdates(new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext()));
#pragma warning restore CS4014
			StartUpdateAutochecker();

			this.MouseWheel += Form1_MouseWheel;
			this.Icon = Properties.Resources.icon;

			trayIcon.ContextMenu = contextMenu2;
			trayIcon.Icon = Properties.Resources.icon;

			LoadFavSprite(heartFav);

			if (Settings.Get<bool>(Setting.ThumbnailButton))
			{
				button = new ThumbnailToolBarButton(Properties.Resources.pause_ico, "Pause");
				button.Click += async (_, __) => await TogglePlayback();
				TaskbarManager.Instance.ThumbnailToolBars.AddButtons(this.Handle, button);
			}

			Connect();

			player = new WebStreamPlayer("https://listen.moe/stream");
			player.Play();

			renderLoop = Task.Run(() =>
			{
				while (!ct.IsCancellationRequested)
				{
					centerPanel.Invalidate();
					Thread.Sleep(33);
				}
			});

			ReloadScale();
			ReloadSettings();

			this.SizeChanged += MainForm_SizeChanged;
			UpdatePanelExcludedRegions();
		}

		private async void LoadFavSprite(bool heart)
		{
			await Task.Run(() =>
			{
				Bitmap spritesheet = heart ? Properties.Resources.heart_sprite : Properties.Resources.fav_sprite;
				int frameSize = heart ? 400 : 256;
				lightFavSprite = SpriteLoader.LoadFavSprite(spritesheet, frameSize);
				fadedFavSprite = SpriteLoader.LoadFadedFavSprite(spritesheet, frameSize);
				darkFavSprite = SpriteLoader.LoadDarkFavSprite(spritesheet, frameSize);
				favSprite = lightFavSprite;
			});

			picFavourite.ResetScale();
			if (heart)
				picFavourite.Size = new Size(48, 48);
			else
				picFavourite.Size = new Size(32, 32);

			picFavourite.SizeChanged += PicFavourite_SizeChanged;

			bool favourite = songInfoStream?.currentInfo.extended?.favorite ?? false;
			picFavourite.Image = favourite ? favSprite.Frames[favSprite.Frames.Length - 1] : favSprite.Frames[0];

			ReloadScale();
		}

		private void PicFavourite_SizeChanged(object sender, EventArgs e)
		{

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			e.Graphics.DrawImage(spriteColorInverted ? Properties.Resources.gripper_inverted : Properties.Resources.gripper, gripRect);

			//Expose 2px on the left for resizing, so we paint it the same colour so it's not noticeable
			e.Graphics.FillRectangle(new SolidBrush(Settings.Get<Color>(Setting.AccentColor)), new Rectangle(0, 0, 2, this.ClientRectangle.Height));
		}

		private void UpdatePanelExcludedRegions()
		{
			int width = this.ClientRectangle.Width;
			int height = this.ClientRectangle.Height;
			GraphicsPath path = new GraphicsPath();

			float scale = Settings.Get<float>(Setting.Scale);
			int gripSize = (int)(Properties.Resources.gripper.Width * scale);
			int padding = (int)scale;

			path.AddPolygon(new[] { new Point(width - gripSize * 2 - padding, height), new Point(width, height - gripSize * 2 - padding), new Point(width, height) });
			gripRect = new Rectangle(width - gripSize - padding, height - gripSize - padding, gripSize, gripSize);
			rightEdgeRect = new Rectangle(width - 2, 0, 2, height);
			leftEdgeRect = new Rectangle(0, 0, 2, height);

			var region = new Region(new Rectangle(0, 0, width, height));
			region.Exclude(path);
			region.Exclude(rightEdgeRect);
			region.Exclude(leftEdgeRect);
			gridPanel.Region = region;
			panelRight.Region = region;
		}

		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			UpdatePanelExcludedRegions();
			centerPanel.ReloadVisualiser();
			this.Invalidate();

			//wow such performance
			//TODO: don't make this write to disk on every resize event
			//Settings buffering would be nice
			Settings.Set(Setting.SizeX, Width);
			Settings.Set(Setting.SizeY, Height);
			Settings.WriteSettings();
		}

		protected override void WndProc(ref Message m)
		{
			WM message = (WM)m.Msg;
			if (message == WM.INPUT)
				RawInput.ProcessMessage(m.LParam);
			else if (message == WM.NCHITTEST)
			{
				Point pos = new Point(m.LParam.ToInt32());
				pos = this.PointToClient(pos);
				if (gripRect.Contains(pos))
					m.Result = (IntPtr)17;
				else if (rightEdgeRect.Contains(pos))
					m.Result = (IntPtr)11;
				else if (leftEdgeRect.Contains(pos))
					m.Result = (IntPtr)10;
				return;
			}
			if (m.Msg == Program.WM_SHOWME)
			{
				Restore();
			}
			base.WndProc(ref m);
		}

		public void ReloadScale()
		{
			this.Width = Settings.DEFAULT_WIDTH;
			this.Height = Settings.DEFAULT_HEIGHT;
			float scaleFactor = Settings.Get<float>(Setting.Scale);
			this.BetterScale(scaleFactor);

			gridPanel.SetRows("100%");
			int playPauseWidth = (int)(Settings.DEFAULT_HEIGHT * scaleFactor);
			int rightPanelWidth = (int)(Settings.DEFAULT_RIGHT_PANEL_WIDTH * scaleFactor);
			gridPanel.SetColumns($"{playPauseWidth}px auto {rightPanelWidth}px");
			gridPanel.DefineAreas("playPause centerPanel rightPanel");

			//Reload fonts to get newly scaled font sizes
			LoadFonts();
			SetPlayPauseSize(false);
		}

		public void ReloadSettings()
		{
			this.TopMost = Settings.Get<bool>(Setting.TopMost);

			this.Location = new Point(Settings.Get<int>(Setting.LocationX), Settings.Get<int>(Setting.LocationY));
			this.Size = new Size(Settings.Get<int>(Setting.SizeX), Settings.Get<int>(Setting.SizeY));

			if (Settings.Get<bool>(Setting.EnableVisualiser))
				centerPanel.StartVisualiser(player);
			else
				centerPanel.StopVisualiser(player);
			centerPanel.ReloadVisualiser();

			float vol = Settings.Get<float>(Setting.Volume);
			Color accentColor = Settings.Get<Color>(Setting.AccentColor);
			panelPlayBtn.BackColor = accentColor;
			playPauseInverted = accentColor.R + accentColor.G + accentColor.B > 128 * 3;

			Color baseColor = Settings.Get<Color>(Setting.BaseColor);
			spriteColorInverted = baseColor.R + baseColor.G + baseColor.B > 128 * 3;
			centerPanel.BackColor = baseColor;
			panelRight.BackColor = baseColor.Scale(1.3f);

			//Set form colour to panel right colour so the correct colour shines through during region exclusion
			this.BackColor = panelRight.BackColor;
			ReloadSprites();

			SetVolumeLabel(vol);
			this.Opacity = Settings.Get<float>(Setting.FormOpacity);

			if (Settings.Get<bool>(Setting.HideFromAltTab))
			{
				this.ShowInTaskbar = false;
				int windowStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
				SetWindowLong(this.Handle, GWL_EXSTYLE, windowStyle | WS_EX_TOOLWINDOW);
			}
			else
			{
				this.ShowInTaskbar = true;
				int windowStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
				SetWindowLong(this.Handle, GWL_EXSTYLE, windowStyle & ~WS_EX_TOOLWINDOW);
			}

			RawInput.RegisterDevice(HIDUsagePage.Generic, HIDUsage.Keyboard, RawInputDeviceFlags.InputSink, this.Handle);
			RawInput.RegisterCallback(VirtualKeys.MediaPlayPause, async () => await TogglePlayback());
			RawInput.RegisterPassword(new[] {
				VirtualKeys.Up, VirtualKeys.Up,
				VirtualKeys.Down, VirtualKeys.Down,
				VirtualKeys.Left, VirtualKeys.Right,
				VirtualKeys.Left, VirtualKeys.Right,
				VirtualKeys.B, VirtualKeys.A,
				VirtualKeys.Return
			}, () => LoadFavSprite(heartFav = !heartFav));
			this.Invalidate();
		}

		private void LoadFonts()
		{
			var scaleFactor = Settings.Get<float>(Setting.Scale);
			titleFont = Meiryo.GetFont(13 * scaleFactor);
			artistFont = Meiryo.GetFont(8 * scaleFactor);
			volumeFont = Meiryo.GetFont(9 * scaleFactor);

			lblVol.Font = volumeFont;

			centerPanel.SetFonts(titleFont, artistFont);
		}

		private async void Connect()
		{
			var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
			await LoadWebSocket(scheduler);
		}

		private async Task LoadWebSocket(TaskScheduler scheduler)
		{
			await Task.Run(async () =>
			{
				TaskFactory factory = new TaskFactory(scheduler);
				songInfoStream = new SongInfoStream(factory);
				songInfoStream.OnSongInfoReceived += ProcessSongInfo;

				User.OnLoginComplete += () =>
				{
					factory.StartNew(() => picFavourite.Visible = true);
					songInfoStream.Authenticate();
				};
				User.OnLogout += async () =>
				{
					await factory.StartNew(() => picFavourite.Visible = false);
					await Task.Run(() => songInfoStream.Reconnect());
				};
				string savedToken = Settings.Get<string>(Setting.Token).Trim();
				if (savedToken != "")
					await User.Login(savedToken);
			});
		}

		private async Task CheckForUpdates(TaskFactory factory)
		{
			if (await Updater.CheckGithubVersion())
			{
				System.Media.SystemSounds.Beep.Play(); //DING
				DialogResult result = await factory.StartNew(() => MessageBox.Show(this, "An update is available for the Listen.moe player. Do you want to update and restart the application now?",
					"Listen.moe client - Update available - current version " + Globals.VERSION, MessageBoxButtons.YesNo));
				if (result == DialogResult.Yes)
				{
					centerPanel.SetUpdateState(UpdateState.InProgress);
					await Updater.UpdateToNewVersion(Wc_DownloadProgressChanged, Wc_DownloadFileCompleted);
				}
			}
		}

		private void StartUpdateAutochecker()
		{
			TaskFactory factory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
			updaterTask = Task.Run(async () =>
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				long last = stopwatch.ElapsedMilliseconds;
				while (!ct.IsCancellationRequested)
				{
					if (stopwatch.ElapsedMilliseconds - last > Settings.Get<int>(Setting.UpdateInterval) * 1000)
					{
						//We only check for the setting here, because I'm lazy to dispose/recreate this checker thread when they change the setting
						if (!Settings.Get<bool>(Setting.UpdateAutocheck))
						{
							last = stopwatch.ElapsedMilliseconds;
							continue;
						}

						await CheckForUpdates(factory);
						last = stopwatch.ElapsedMilliseconds;
					}
					else
					{
						Thread.Sleep(100);
					}
				}
			});
		}

		private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			centerPanel.SetUpdateState(UpdateState.Complete);
		}

		private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			centerPanel.SetUpdatePercent(e.BytesReceived / (float)e.TotalBytesToReceive);
		}

		private void Form1_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta != 0)
			{
				if (RawInput.IsPressed(VirtualKeys.Control))
				{
					centerPanel.Visualiser.IncreaseBarWidth(0.5f * e.Delta / (float)SystemInformation.MouseWheelScrollDelta);
				}
				else if (RawInput.IsPressed(VirtualKeys.Menu))
				{
					centerPanel.Visualiser.IncreaseResolution(e.Delta / SystemInformation.MouseWheelScrollDelta);
				}
				else
				{
					float delta = 0.05f;
					if (RawInput.IsPressed(VirtualKeys.Shift))
						delta = 0.01f;
					float volumeChange = (e.Delta / (float)SystemInformation.MouseWheelScrollDelta) * delta;
					float newVol = player.AddVolume(volumeChange);
					if (newVol >= 0)
					{
						Settings.Set(Setting.Volume, newVol);
						Settings.WriteSettings();
						SetVolumeLabel(newVol);
					}
				}
			}
		}

		private void SetVolumeLabel(float vol)
		{
			int newVol = (int)Math.Round(vol * 100);
			lblVol.Text = newVol.ToString() + "%";
		}

		private async void playPause_Click(object sender, EventArgs e)
		{
			await TogglePlayback();
		}

		private void ReloadSprites()
		{
			if (spriteColorInverted)
			{
				picSettings.Image = Properties.Resources.cog_inverted;
				picClose.Image = Properties.Resources.close_inverted;
				centerPanel.SetLabelBrush(Brushes.Black);
				lblVol.ForeColor = Color.Black;

				favSprite = darkFavSprite;
			}
			else
			{

				picSettings.Image = Properties.Resources.cog;
				picClose.Image = Properties.Resources.close;
				centerPanel.SetLabelBrush(Brushes.White);
				lblVol.ForeColor = Color.White;
				favSprite = lightFavSprite;
			}

			if (playPauseInverted)
			{
				if (player.IsPlaying())
					picPlayPause.Image = Properties.Resources.pause_inverted;
				else
					picPlayPause.Image = Properties.Resources.play;
			}
			else
			{
				if (player.IsPlaying())
					picPlayPause.Image = Properties.Resources.pause;
				else
					picPlayPause.Image = Properties.Resources.play;
			}

			if (songInfoStream?.currentInfo.extended?.favorite ?? false)
				picFavourite.Image = favSprite?.Frames[favSprite.Frames.Length - 1];
			else
				picFavourite.Image = favSprite?.Frames[0];
		}

		private async Task TogglePlayback()
		{
			if (player.IsPlaying())
			{
				Task stopTask = player.Stop();
				ReloadSprites();
				menuItemPlayPause.Text = "Play";
				if (Settings.Get<bool>(Setting.ThumbnailButton) && !Settings.Get<bool>(Setting.HideFromAltTab))
				{
					button.Icon = Properties.Resources.play_ico;
					button.Tooltip = "Play";
				}
				if (Settings.Get<bool>(Setting.EnableVisualiser))
					centerPanel.StopVisualiser(player);
				await stopTask;
			}
			else
			{
				player.Play();
				ReloadSprites();
				menuItemPlayPause.Text = "Pause";
				if (Settings.Get<bool>(Setting.ThumbnailButton) && !Settings.Get<bool>(Setting.HideFromAltTab))
				{
					button.Icon = Properties.Resources.pause_ico;
					button.Tooltip = "Pause";
				}
				if (Settings.Get<bool>(Setting.EnableVisualiser))
					centerPanel.StartVisualiser(player);
			}
		}

		private void picClose_Click(object sender, EventArgs e)
		{
			if (Settings.Get<bool>(Setting.CloseToTray))
			{
				this.Hide();
			}
			else
			{
				this.Close();
			}
		}

		void ProcessSongInfo(SongInfo songInfo)
		{
			centerPanel.SetLabelText(songInfo.song_name, songInfo.artist_name, songInfo.anime_name, "Requested by " + songInfo.requested_by, !string.IsNullOrWhiteSpace(songInfo.requested_by));

			if (songInfo.extended != null)
				SetFavouriteSprite(songInfo.extended.favorite);
			else
				picFavourite.Visible = false;
		}

		private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			await Exit();
		}

		private async Task Exit()
		{
			cts.Cancel();
			if (SettingsForm != null)
			{
				SettingsForm.Close();
			}
			this.Hide();
			trayIcon.Visible = false;
			await player.Dispose();
			Environment.Exit(0);
		}

		private void panelPlayBtn_MouseEnter(object sender, EventArgs e)
		{
			SetPlayPauseSize(true);
		}

		private void panelPlayBtn_MouseLeave(object sender, EventArgs e)
		{
			if (panelPlayBtn.ClientRectangle.Contains(PointToClient(Control.MousePosition)))
				return;
			SetPlayPauseSize(false);
		}

		private void SetPlayPauseSize(bool bigger)
		{
			var scale = Settings.Get<float>(Setting.Scale);
			var ppSize = Settings.DEFAULT_PLAY_PAUSE_SIZE;
			int playPauseSize = bigger ? ppSize + 2 : ppSize;

			picPlayPause.Size = new Size((int)(playPauseSize * scale), (int)(playPauseSize * scale));
			int y = (panelPlayBtn.Height / 2) - (picPlayPause.Height / 2);
			int x = (panelPlayBtn.Width / 2) - (picPlayPause.Width / 2);
			picPlayPause.Location = new Point(x, y);
		}

		private void menuItemCopySongInfo_Click(object sender, EventArgs e)
		{
			SongInfo info = songInfoStream.currentInfo;
			Clipboard.SetText(info.song_name + " \n" + info.artist_name + " \n" + info.anime_name);
		}

		private void picSettings_Click(object sender, EventArgs e)
		{
			if (SettingsForm == null)
			{
				SettingsForm = new FormSettings(this, player.BasePlayer);
				SettingsForm.StartPosition = FormStartPosition.CenterScreen;
				SettingsForm.Show();
			}
			else
			{
				SettingsForm.Activate();
			}
		}

		private async void menuItemExit_Click(object sender, EventArgs e)
		{
			await Exit();
		}

		private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				Restore();
		}

		private void menuItemShow_Click(object sender, EventArgs e)
		{
			Restore();
		}

		private void Restore()
		{
			WindowState = FormWindowState.Normal;
			this.Show();
			this.Activate();
		}

		int currentFrame = 0;
		bool isAnimating = false;

		object animationLock = new object();

		private void panelPlayBtn_Resize(object sender, EventArgs e)
		{
			SetPlayPauseSize(false);
		}

		private void centerPanel_Resize(object sender, EventArgs e)
		{
			float scale = Settings.Get<float>(Setting.Scale);
			picFavourite.Location = new Point((int)(centerPanel.Width - picFavourite.Width), (centerPanel.Height / 2) - (picFavourite.Height / 2));
		}

		private async void SetFavouriteSprite(bool favourited)
		{
			picFavourite.Visible = true;
			if (favourited)
			{
				lock (animationLock)
				{
					currentFrame = 0;
					//Reset animation and exit
					if (isAnimating)
						return;
					isAnimating = true;
				}

				//Animate.
				while (currentFrame < favSprite.Frames.Length)
				{
					lock (animationLock)
					{
						if (!isAnimating)
							break;
					}
					picFavourite.Image = favSprite.Frames[currentFrame++];
					await Task.Delay(16);
				}

				isAnimating = false;
				songInfoStream.currentInfo.extended.favorite = true;
			}
			else
			{
				lock (animationLock)
					isAnimating = false;
				picFavourite.Image = favSprite.Frames[0];
				songInfoStream.currentInfo.extended.favorite = false;
			}
		}

		private async void picFavourite_Click(object sender, EventArgs e)
		{
			bool currentStatus = songInfoStream.currentInfo.extended?.favorite ?? false;
			bool newStatus = !currentStatus;
			if (songInfoStream.currentInfo.extended == null)
				songInfoStream.currentInfo.extended = new ExtendedSongInfo();
			songInfoStream.currentInfo.extended.favorite = newStatus;

			SetFavouriteSprite(newStatus);

			string result = await WebHelper.Post("https://listen.moe/api/songs/favorite", Settings.Get<string>(Setting.Token), new Dictionary<string, string>() {
				["song"] = songInfoStream.currentInfo.song_id.ToString()
			});

			var response = Json.Parse<FavouritesResponse>(result);
			picFavourite.Image = response.favorite ? favSprite.Frames[favSprite.Frames.Length - 1] :
				spriteColorInverted ? darkFavSprite.Frames[0] : favSprite.Frames[0];
			songInfoStream.currentInfo.extended.favorite = response.favorite;
		}

		private void menuItemResetLocation_Click(object sender, EventArgs e)
		{
			Settings.Set(Setting.LocationX, 0);
			Settings.Set(Setting.LocationY, 0);
			Settings.WriteSettings();
			this.Location = new Point(0, 0);
		}
	}
}
