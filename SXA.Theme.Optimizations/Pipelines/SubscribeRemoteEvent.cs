using Sitecore.Diagnostics;
using Sitecore.Eventing;
using Sitecore.Events;
using Sitecore.Pipelines;
using SXA.Theme.Optimizations.Constants;
using SXA.Theme.Optimizations.Events;
using SXA.Theme.Optimizations.Events.Args;
using System;

namespace SXA.Theme.Optimizations.Pipelines
{
    /// <summary>
    /// A pipeline that runs on the CD servers during startup that subscribes the server to the custom remote event.
    /// </summary>
    public class SubscribeRemoteEvent
    {
        public void Process(PipelineArgs args)
        {
            try
            {
                Log.Info(LogMessages.Info.SubscribeRemoteEvent, this);
                EventManager.Subscribe(new Action<OptimizeRemoteEvent>(RaiseRemoteEvent));
            }
            catch (Exception e)
            {
                Log.Error(string.Format(LogMessages.Error.SubscribeRemoteEvent, e.Message), e, this);
            }
        }

        private void RaiseRemoteEvent(OptimizeRemoteEvent optimizeEvent)
        {
            Log.Warn(LogMessages.Warn.SubscribeRemoteEvent, this);
            Event.RaiseEvent(CustomEvents.OptimizeScriptsRemote, new object[] { new OptimizeRemoteArgs(optimizeEvent) });
        }
    }
}