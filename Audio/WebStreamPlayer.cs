using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Concentus.Structs;

namespace ListenMoeClient
{
	class WebStreamPlayer
	{
		AudioPlayer audioPlayer = new AudioPlayer();

		Thread provideThread;

		System.Timers.Timer tmrInternet;

		Ogg ogg = new Ogg();
		OpusDecoder decoder = OpusDecoder.Create(Globals.SAMPLE_RATE, 2);

		bool playing = false;
		string url;

		AudioVisualiser visualiser;

		public WebStreamPlayer(string url)
		{
			tmrInternet = new System.Timers.Timer(Settings.Get<int>("InternetDisconnectionTimer") * 1000);
			tmrInternet.Elapsed += InternetDisconnected;
			this.url = url;
		}

		private async void InternetDisconnected(object sender, System.Timers.ElapsedEventArgs e)
		{
			Globals.InternetDisconnected();
			await Stop();
			Thread.Sleep(100);
			Play();
		}

		public async Task Dispose()
		{
			await Stop();
		}

		public void SetVisualiser(AudioVisualiser visualiser)
		{
			this.visualiser = visualiser;
		}

		public void Play()
		{
			audioPlayer.Play();
			playing = true;

			provideThread = new Thread(() =>
			{
				try
				{
					HttpWebRequest req = WebRequest.CreateHttp(url);
					req.UserAgent = Globals.USER_AGENT;

					using (var stream = req.GetResponse().GetResponseStream())
					{
						var readFullyStream = new ReadFullyStream(stream);

						while (playing)
						{
							byte[][] packets = ogg.GetAudioPackets(readFullyStream);
							tmrInternet.Stop();
							tmrInternet.Start();

							for (int i = 0; i < packets.Length; i++)
							{
								var streamBytes = packets[i];
								try
								{
									int frameSize = OpusPacketInfo.GetNumSamplesPerFrame(streamBytes, 0, Globals.SAMPLE_RATE); //Get frame size from opus packet
									short[] rawBuffer = new short[frameSize * 2]; //2 channels
									var buffer = decoder.Decode(streamBytes, 0, streamBytes.Length, rawBuffer, 0, frameSize, false);
									audioPlayer.QueueBuffer(rawBuffer);

									if (visualiser != null)
										visualiser.AddSamples(rawBuffer);
								}
								catch (Concentus.OpusException)
								{
									//Skip this frame
								}
							}
						}
					}
				} catch (Exception)
				{

				}
			});
			provideThread.Start();
		}

		public float AddVolume(float vol)
		{
			return audioPlayer.AddVolume(vol);
		}

		public async Task Stop()
		{
			if (playing)
			{
				playing = false;
				tmrInternet.Stop();

				audioPlayer.Stop();

				if (provideThread != null)
				{
					provideThread.Abort();
					await Task.Run(() => provideThread.Join());
					provideThread = null;
				}

				decoder.ResetState();
			}
		}

		public bool IsPlaying()
		{
			return playing;
		}
	}
}
