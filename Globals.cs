using System;
using System.Drawing;
using System.Windows.Forms;

namespace ListenMoeClient
{
	static class Globals
	{
		public static string VERSION = Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf('.')); //Strip build number
		public static string USER_AGENT = "LISTEN.moe Desktop Client v" + VERSION + " [Fork] (https://github.com/MiincK/ListenMoeClient)";
		public static int SAMPLE_RATE = 48000;

		public delegate void ZeroHandler();
		public static event ZeroHandler OnInternetDisconnected;

		public static void InternetDisconnected()
		{
			OnInternetDisconnected?.Invoke();
		}


		public static Point Subtract(this Point a, Point b)
		{
			return new Point(a.X - b.X, a.Y - b.Y);
		}

		public static float Bound(this float f, float min, float max)
		{
			return Math.Max(Math.Min(f, max), min);
		}
	}
}
