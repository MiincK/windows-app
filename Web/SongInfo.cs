﻿using System;
using System.Threading.Tasks;
using WebSocketSharp;

namespace ListenMoeClient
{
	public class SongInfo
	{
		public int song_id { get; set; }
		public string requested_by { get; set; }
		public string listeners { get; set; }
		public string song_name { get; set; }
		public string artist_name { get; set; }
		public string anime_name { get; set; }

		public PreviousSongInfo last { get; set; }
		public PreviousSongInfo second_last { get; set; }

		public ExtendedSongInfo extended { get; set; }
	}

	public class PreviousSongInfo
	{
		public string song_name { get; set; }
		public string artist_name { get; set; }
	}

	public class ExtendedSongInfo
	{
		public bool favorite { get; set; }
	}

	public class SongQueue
	{
		public int songsInQueue { get; set; }
		public bool hasSongInQueue { get; set; }
		public int inQueueBeforeUserSong { get; set; }
		public int userSongsInQueue { get; set; }
	}

	public class SongInfoStream
	{
		private WebSocket socket;
		private TaskFactory factory;
		public delegate void StatsReceived(SongInfo info);
		public event StatsReceived OnSongInfoReceived = (info) => { };
		public SongInfo currentInfo;

		private const string SOCKET_ADDR = "wss://listen.moe/api/v2/socket";

		public SongInfoStream(TaskFactory factory)
		{
			this.factory = factory;
			Globals.OnInternetDisconnected += Reconnection;
			Reconnect();
		}

		public void Reconnect()
		{
			socket = new WebSocket(SOCKET_ADDR);

			socket.OnMessage += (sender, e) => ParseSongInfo(e.Data);
			socket.OnError += (sender, e) => { throw e.Exception; };
			socket.OnClose += (sender, e) =>
			{
				System.Threading.Thread.Sleep(250);
				Connect();
			};

			socket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
			Connect();
		}

		public void Reconnection()
		{
			socket.Close();
		}

		private void Connect()
		{
			try
			{
				socket.Connect();

				if (User.LoggedIn)
					Authenticate();
			}
			catch (Exception) { }
		}

		public void Authenticate()
		{
			try
			{
				socket.Send("{ \"token\": \"" + Settings.Get<string>(Setting.Token) + "\" }");
			} catch (Exception) { }
		}

		private void ParseSongInfo(string data)
		{
			if (data.Trim() == "{\"reason\":\"MALFORMED-JSON\"}" || data.Trim() == "{\"reason\":\"CLEANUP\"}" || data.Trim() == "")
				return;

			try
			{
				currentInfo = Json.Parse<SongInfo>(data);
				currentInfo.anime_name = currentInfo.anime_name.Trim().Replace('\n', ' ');
				currentInfo.artist_name = currentInfo.artist_name.Trim().Replace('\n', ' ');
				currentInfo.song_name = currentInfo.song_name.Trim().Replace('\n', ' ');
				currentInfo.requested_by = currentInfo.requested_by.Trim().Replace('\n', ' ');

				factory.StartNew(() =>
				{
					OnSongInfoReceived(currentInfo);
				});
			} catch (Exception) { }
		}
	}
}
