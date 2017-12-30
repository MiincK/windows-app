namespace ListenMoeClient
{
	public static class Localisation
	{
		public static LanguageBase Current { get; private set; }

		internal static void SetLanguage(string langName)
		{
			switch (langName)
			{
				case "ru":
					Current = new Russian();
					break;
				default:
					Current = new English();
					break;
			}
		}
	}
}
