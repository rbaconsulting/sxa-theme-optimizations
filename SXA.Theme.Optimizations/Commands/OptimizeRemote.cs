using Sitecore;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using SXA.Theme.Optimizations.Core.Constants;
using SXA.Theme.Optimizations.Core.Events;

namespace SXA.Theme.Optimizations.Commands
{
    /// <summary>
    /// A command for a content editor ribbon button to optimize scripts on the Content Delivery server(s).
    /// </summary>
    public class OptimizeRemote : Command
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
                        var database = Sitecore.Configuration.Factory.GetDatabase(Databases.Web);
                        var eventQueue = database.RemoteEvents.EventQueue;
                        eventQueue.QueueEvent(new OptimizeRemoteEvent());

                        Context.ClientPage.ClientResponse.Alert(CommandMessages.OptimizeDialog.Alert);
                        break;
                    case CommandMessages.OptimizeDialog.No:
                        args.AbortPipeline();
                        break;
                }
            }
            else
            {
                Context.ClientPage.ClientResponse.Confirm(CommandMessages.OptimizeDialog.ConfirmRemote);
                args.WaitForPostBack();
            }
        }
    }
}