﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace ListenMoeClient
{
	/// <summary>
	/// Audio Output Device Object
	/// </summary>
	public class AudioDevice
	{
		public DirectSoundDeviceInfo DeviceInfo;
		public string Name;

		public AudioDevice(DirectSoundDeviceInfo deviceInfo, string name)
		{
			this.DeviceInfo = deviceInfo;
			this.Name = name;
		}

		public override string ToString()
		{
			return this.Name;
		}
	}

	public class AudioPlayer : IDisposable
	{
		BufferedWaveProvider provider;
		DirectSoundOut directOut;
		SampleChannel volumeChannel;
		public Guid CurrentDeviceGuid { get; private set; } = Guid.NewGuid();

		Queue<short[]> samplesToPlay = new Queue<short[]>();

		bool firstPacket;
		bool playing;

		public AudioPlayer()
		{
			WaveFormat format = new WaveFormat(Globals.SAMPLE_RATE, 2);
			provider = new BufferedWaveProvider(format)
			{
				BufferDuration = TimeSpan.FromSeconds(10)
			};

			volumeChannel = new SampleChannel(provider) { Volume = Settings.Get<float>(Setting.Volume) };

			bool success = Guid.TryParse(Settings.Get<string>(Setting.OutputDeviceGuid), out Guid deviceGuid);

			SetAudioOutputDevice(success ? deviceGuid : DirectSoundOut.DSDEVID_DefaultPlayback);
		}

		/// <summary>
		/// Intialize the WaveOut Device and set Volume
		/// </summary>
		public void Initialize(Guid deviceGuid)
		{
			directOut = new DirectSoundOut(deviceGuid);
			CurrentDeviceGuid = deviceGuid;
			directOut.Init(volumeChannel);

			Settings.Set(Setting.OutputDeviceGuid, deviceGuid.ToString());
			Settings.WriteSettings();
		}

		public void Play()
		{
			provider.ClearBuffer();
			directOut.Play();
			playing = true;
		}

		public void Stop()
		{
			directOut.Stop();
			provider.ClearBuffer();
			playing = false;
		}

		public void Dispose()
		{
			if (directOut != null)
			{
				directOut.Stop();
				directOut.Dispose();
			}

			if (provider != null)
				provider.ClearBuffer();
		}

		public void QueueBuffer(short[] samples)
		{
			byte[] bytes = new byte[samples.Length * 2];
			Buffer.BlockCopy(samples, 0, bytes, 0, bytes.Length);
			try
			{
				provider.AddSamples(bytes, 0, bytes.Length);
			}
			catch
			{
				provider.ClearBuffer();
				provider.AddSamples(bytes, 0, bytes.Length);
			}

			if (!firstPacket)
				new Thread(delegate ()
				{
					firstPacket = true;
					Thread.Sleep(1000);
					while (playing)
					{
						if (provider.BufferedDuration.TotalMilliseconds < 1500)
						{
							Globals.InternetDisconnected();
							break;
						}
						Thread.Sleep(50);
					}
					firstPacket = false;
				})
				{ Name = "InternetCheck", IsBackground = true }.Start();
		}

		private float BoundVolume(float vol)
		{
			//Cap between 0 and 1
			vol = Math.Max(0, vol);
			vol = Math.Min(1, vol);
			return vol;
		}

		public float AddVolume(float vol)
		{
			SetVolume(volumeChannel.Volume + vol);
			return volumeChannel.Volume;
		}

		public void SetVolume(float vol)
		{
			volumeChannel.Volume = BoundVolume(vol);
		}

		/// <summary>
		/// Get an array of the available audio output devices.
		/// <para>Because of a limitation of WaveOut, device's names will be cut if they are too long.</para>
		/// </summary>
		public AudioDevice[] GetAudioOutputDevices()
		{
			return DirectSoundOut.Devices.Select(d => new AudioDevice(d, d.Description)).ToArray();
		}

		/// <summary>
		/// Set the audio output device (if available); Returns current audio device (desired if valid).
		/// </summary>
		/// <param name="deviceNumber">Device ID</param>
		/// <returns></returns>
		public void SetAudioOutputDevice(Guid deviceGuid)
		{
			if (deviceGuid == CurrentDeviceGuid)
				return;

			PlaybackState prevState = directOut?.PlaybackState ?? PlaybackState.Playing;

			if (directOut != null)
			{
				directOut.Stop();
				directOut.Dispose();
			}

			Initialize(deviceGuid);

			if (prevState == PlaybackState.Playing)
				directOut.Play();
		}
	}
}
