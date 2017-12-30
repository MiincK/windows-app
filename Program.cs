﻿using System;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ListenMoeClient
{
	static class Program
	{
		static Mutex mutex = new Mutex(true, "{6431a734-2693-40d4-8dff-ea662d8777d7}");

		public const int HWND_BROADCAST = 0xffff;
		public static readonly UInt32 WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
		[DllImport("user32")]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32")]
		static extern uint RegisterWindowMessage(string lpString);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (mutex.WaitOne(TimeSpan.Zero, true))
			{
				Localisation.SetLanguage(CultureInfo.InstalledUICulture.TwoLetterISOLanguageName);
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				Environment.SetEnvironmentVariable("LANG", "ja_JP.utf-8");
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			else
			{
				SendMessage((IntPtr)HWND_BROADCAST, WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
			}
		}
	}
}
