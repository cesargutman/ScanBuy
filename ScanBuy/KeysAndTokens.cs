using System;

namespace ScanBuy
{
	public static class KeysAndTokens
	{

		#warning "Paste here your credentials"
		public static class ScanditApi
		{
			// Paste here your Scandit API key. If you don't have any key yet, go to http://www.scandit.com/pricing/
			public static string ScanditKey { get { return "pXXetPEqEeOMt51CkYn1t4ave+cxqKv6yAM+ZdtUfjc"; } }
		}

		public static class TwitterApi
		{
			// Paste here your Twitter API keys. If you don't have any keys yet, go to https://apps.twitter.com/
			public static string User { get { return ""; } }
			public static uint UserID { get { return 0; } }
			public static string ApiKey { get { return ""; } }
			public static string ApiSecret { get { return ""; } }
			public static string AccessToken { get { return ""; } }
			public static string AccessTokenSecret { get { return ""; } }
		}
	}
}

