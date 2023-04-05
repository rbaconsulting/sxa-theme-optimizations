namespace SXA.Theme.Optimizations.Core.Constants
{
    public struct LogMessages
    {
        public struct Error
        {
            public const string SubscribeRemoteEvent = "SXAThemeOptimizations: There was an error subscribing the remote event! {0}";
            public const string StartupEvent = "SXAThemeOptimizations: Error raising {0} event on publish! {1}";
            public const string ScriptOptimization = "SXAThemeOptimizations: There was an error optimizing the scripts! {0}";
        }

        public struct Warn
        {
            public const string SubscribeRemoteEvent = "SXAThemeOptimizations: Optimize scripts remote event fired!";
        }

        public struct Info
        {
            public const string SubscribeRemoteEvent = "SXAThemeOptimizations: Subscribing the remote event!";
        }
    }
}