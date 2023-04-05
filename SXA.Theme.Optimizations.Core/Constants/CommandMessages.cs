namespace SXA.Theme.Optimizations.Core.Constants
{
    public struct CommandMessages
    {
        public const string ProcessorMethod = "Processor";

        public struct OptimizeDialog
        {
            public const string Yes = "yes";
            public const string No = "no";
            public const string Confirm = "Are you sure you want to optimize the scripts on the Content Management (Standalone) server?";
            public const string ConfirmRemote = "Are you sure you want to optimize the scripts on the Content Delivery servers?";
            public const string Alert = "The optimize scripts event was raised.";
        }
    }
}