using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Concentus.Structs;

namespace ListenMoeClient
{
	class WebStreamPlayer
	{
		public AudioPlayer BasePlayer { get; set; } = new AudioPlayer();

		Thread provideThread;

		Ogg ogg = new Ogg();
		OpusDecoder decoder = OpusDecoder.Create(Globals.SAMPLE_RATE, 2);

		bool playing = false;
		string url;

		AudioVisualiser visualiser;

		public WebStreamPlayer(string url)
		{
			Globals.OnInternetDisconnected += InternetDisconnected;
			this.url = url;
		}

		private async void InternetDisconnected()
		{
			if (!playing) return;
			await Stop(true);
			Thread.Sleep(100);
			Play();
		}

		public async Task Dispose()
		{
			await Stop(false);
		}

		public void SetVisualiser(AudioVisualiser visualiser)
		{
			this.visualiser = visualiser;
		}

		public void Play()
		{
			BasePlayer.Playing = true;
			playing = true;

			provideThread = new Thread(() =>
			{
				try
				{
					WebClient wc = new WebClient();
					wc.Headers[HttpRequestHeader.UserAgent] = Globals.USER_AGENT;
					
					using (var stream = wc.OpenRead(url))
					{
						var readFullyStream = new ReadFullyStream(stream);

						var pc = 0;

						while (playing)
						{
							byte[][] packets = ogg.GetAudioPackets(readFullyStream);

							if (++pc <= 5) continue;

							for (int i = 0; i < packets.Length; i++)
							{
								var streamBytes = packets[i];
								try
								{
									int frameSize = OpusPacketInfo.GetNumSamplesPerFrame(streamBytes, 0, Globals.SAMPLE_RATE); //Get frame size from opus packet
									short[] rawBuffer = new short[frameSize * 2]; //2 channels
									var buffer = decoder.Decode(streamBytes, 0, streamBytes.Length, rawBuffer, 0, frameSize, false);
									BasePlayer.QueueBuffer(rawBuffer);

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
				}
				catch (Exception)
				{

				}
			});
			provideThread.Start();
		}

		public float AddVolume(float vol)
		{
			return BasePlayer.AddVolume(vol);
		}

		public async Task Stop(bool isSoft)
		{
			if (playing)
			{
				playing = false;

				if (!isSoft) BasePlayer.Playing = false;

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
