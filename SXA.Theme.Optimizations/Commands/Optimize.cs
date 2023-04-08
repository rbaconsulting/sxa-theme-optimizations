using Sitecore;
using Sitecore.Events;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using SXA.Theme.Optimizations.Constants;

namespace SXA.Theme.Optimizations.Commands
{
    /// <summary>
    /// A command for a content editor ribbon button to optimize scripts on the Content Management or Standalone servers.
    /// </summary>
    public class Optimize : Command
    {
        public override void Execute(CommandContext context)
        {
            Context.ClientPage.Start(this, CommandMessages.ProcessorMethod, new ClientPipelineArgs());
        }

        protected void Processor(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
            {
                switch (args.Result)
                {
                    case CommandMessages.OptimizeDialog.Yes:
                        Event.RaiseEvent(CustomEvents.OptimizeScripts, new object[] { });

                        Context.ClientPage.ClientResponse.Alert(CommandMessages.OptimizeDialog.Alert);
                        break;
                    case CommandMessages.OptimizeDialog.No:
                        args.AbortPipeline();
                        break;
                }
            }
            else
            {
                Context.ClientPage.ClientResponse.Confirm(CommandMessages.OptimizeDialog.Confirm);
                args.WaitForPostBack();
            }
        }
    }
}