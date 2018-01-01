namespace ListenMoeClient
{
	public class LanguageBase
	{
		public string tPause { get; protected set; }
		public string tPlay { get; protected set; }
		public string tShow { get; protected set; }
		public string tResetLocation { get; protected set; }
		public string tExit { get; protected set; }

		public string rCopySongInfo { get; protected set; }

		public string mReqestedBy { get; protected set; }
		public string mUpdateAvailable { get; protected set; }
		public string mUpdateDialogCaption { get; protected set; }

		public string sSettings { get; protected set; }
		public string sGeneral { get; protected set; }
		public string sThemeLayout { get; protected set; }
		public string sAccount { get; protected set; }

		public string sRequiesRestart { get; protected set; }
		public string sRequiesRestartSplit { get; protected set; }

		public string sgAudioDevice { get; protected set; }
		public string sgRefresh { get; protected set; }
		public string sgKeepTopMost { get; protected set; }
		public string sgCloseToTray { get; protected set; }
		public string sgThumbnailToolbarButton { get; protected set; }
		public string sgHideFromAltTab { get; protected set; }
		public string sgFixedSize { get; protected set; }

		public string slLanguage { get; protected set; }
		public string slSystemDefault { get; protected set; }

		public string suUpdates { get; protected set; }
		public string suCheckForUpdatesEvery { get; protected set; }
		public string suMins { get; protected set; }

		public string stLayout { get; protected set; }
		public string stResolutionScale { get; protected set; }
		public string stOpacity { get; protected set; }
		public string stBaseColor { get; protected set; }
		public string stAccentColor { get; protected set; }
		public string stHeartFav { get; protected set; }

		public string svVisualiser { get; protected set; }
		public string svEnable { get; protected set; }
		public string svUseBars { get; protected set; }
		public string svFadeEdges { get; protected set; }
		public string svVisualiserColor { get; protected set; }
		public string svVisualiserOpacity { get; protected set; }

		public string saUsername { get; protected set; }
		public string saPassword { get; protected set; }
		public string saLogin { get; protected set; }
		public string saLoggedInAs { get; protected set; }
		public string saLogout { get; protected set; }

		public LanguageBase()
		{
			tPause = "Pause";
			tPlay = "Play";
			tShow = "Show";
			tResetLocation = "Reset Location";
			tExit = "Exit";

			rCopySongInfo = "Copy song info";

			mReqestedBy = "Requseted by {0}";
			mUpdateAvailable = "An update is available for the Listen.moe player. Do you want to update and restart the application now?";
			mUpdateDialogCaption = "Listen.moe client - Update available - current version {0}";

			sSettings = "Settings";
			sGeneral = "General";
			sThemeLayout = "Theme & Layout";
			sAccount = "Account";
			sRequiesRestart = "(requies restart)";
			sRequiesRestartSplit = "(requies\nrestart)";

			sgAudioDevice = "Audio device:";
			sgRefresh = "Refresh";
			sgKeepTopMost = "Keep from top most";
			sgCloseToTray = "Close to tray";
			sgThumbnailToolbarButton = "Thumbnail toolbar button";
			sgHideFromAltTab = "Hide from Alt-Tab menu\nand taskbar (show tray only)";
			sgFixedSize = "Disallow resizing";

			slLanguage = "Language";
			slSystemDefault = "System Default";

			suUpdates = "Updates";
			suCheckForUpdatesEvery = "Check for updates every:";
			suMins = "mins";

			stLayout = "Layout";
			stResolutionScale = "Resolution scale";
			stOpacity = "Opacity";
			stBaseColor = "Base color";
			stAccentColor = "Accent color";
			stHeartFav = "Use heart icon\nfor favourite";

			svVisualiser = "Visualiser";
			svEnable = "Enable";
			svUseBars = "Use bars";
			svFadeEdges = "Fade edges";
			svVisualiserColor = "Color";
			svVisualiserOpacity = "Opacity";

			saUsername = "Username";
			saPassword = "Password";
			saLogin = "Login";
			saLoggedInAs = "Logged in as {0}";
			saLogout = "Logout";
		}
	}
}
