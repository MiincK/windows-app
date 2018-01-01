namespace ListenMoeClient
{
	public static class Localisation
	{
		public static LanguageBase Current { get; private set; }

		internal static void SetLanguage(string langName)
		{
			if (string.IsNullOrWhiteSpace(langName))
				langName = System.Globalization.CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
			switch (langName)
			{
				case "ru":
					Current = new Russian();
					break;
				case "en":
				default:
					Current = new English();
					break;
			}
		}
	}
}
