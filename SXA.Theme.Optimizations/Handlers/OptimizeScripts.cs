using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Events;
using SXA.Theme.Optimizations.Core.Constants;
using SXA.Theme.Optimizations.Core.Interfaces;
using System;

namespace SXA.Theme.Optimizations.Handlers
{
    /// <summary>
    /// A handler for the optimization events.
    /// </summary>
    public class OptimizeScripts
    {
        public void OnSaving(object sender, EventArgs args)
        {
            var savedItem = Event.ExtractParameter(args, 0) as Item;

            if (savedItem != null && savedItem.Database.Name.ToLower() == Databases.Master)
            {
                var itemPath = savedItem.Paths?.FullPath ?? string.Empty;

                if (itemPath.StartsWith(ItemPaths.ThemesFolder) || itemPath.StartsWith(ItemPaths.BaseThemesFolder) || itemPath.StartsWith(ItemPaths.ExtensionThemesFolder))
                {
                    Event.RaiseEvent(CustomEvents.OptimizeScripts, new object[] { });
                }
            }
        }

        /// <summary>
        /// Fires on the CM or Standalone server when the "sxathemeoptimizations:optimize" event is raised.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OptimizeEvent(object sender, EventArgs args)
        {
            var themeBundler = ServiceLocator.ServiceProvider.GetService(typeof(IScriptOptimizer)) as IScriptOptimizer;

            themeBundler.OptimizeScriptsForAllThemes(Factory.GetDatabase(Databases.Master));
            themeBundler.OptimizeScriptsForAllThemes(Factory.GetDatabase(Databases.Web));
        }

        /// <summary>
        /// Fires on the CD server when the "sxathemeoptimizations:optimize:remote" event is raised.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OptimizeEventRemote(object sender, EventArgs args)
        {
            var themeBundler = ServiceLocator.ServiceProvider.GetService(typeof(IScriptOptimizer)) as IScriptOptimizer;

            themeBundler.OptimizeScriptsForAllThemes(Factory.GetDatabase(Databases.Web));
        }
    }
}