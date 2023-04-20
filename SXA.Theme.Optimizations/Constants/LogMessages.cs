namespace SXA.Theme.Optimizations.Constants
{
    public struct LogMessages
    {
		public struct Error
        {
            public const string SubscribeRemoteEvent = "SXAThemeOptimizations: There was an error subscribing the remote event! {0}";
            public const string StartupEvent = "SXAThemeOptimizations: Error raising {0} event on server startup! {1}";
            public const string ScriptOptimization = "SXAThemeOptimizations: There was an error generating a JavaScript file! Error: {0}";
			public const string ScriptOptimizationEmptyValue = "SXAThemeOptimizations: A JavaScript file could not be generated due to an empty value! Theme Name: {0}, Target Database Name: {1}";
		}

        public struct Warn
        {
			public const string ScriptOptimization = "SXAThemeOptimizations: A JavaScript file was generated! Theme Name: {0}, Target Database Name: {1}";
			public const string NullThemeItem = "SXAThemeOptimizations: A JavaScript file could not be generated due to a null theme item!";
			public const string SubscribeRemoteEvent = "SXAThemeOptimizations: Optimize scripts remote event fired!";
        }

        public struct Info
        {
            public const string SubscribeRemoteEvent = "SXAThemeOptimizations: Subscribing the remote event!";
        }
    }
}