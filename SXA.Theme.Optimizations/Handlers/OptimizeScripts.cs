using Microsoft.Extensions.DependencyInjection;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Events;
using SXA.Theme.Optimizations.Constants;
using SXA.Theme.Optimizations.Interfaces;
using SXA.Theme.Optimizations.Services;
using System;
using System.Text.RegularExpressions;
using static SXA.Theme.Optimizations.Constants.Templates;
using Settings = Sitecore.Configuration.Settings;

namespace SXA.Theme.Optimizations.Handlers
{
    /// <summary>
    /// A handler for the optimization events.
    /// </summary>
    public class OptimizeScripts
    {
        private static readonly Regex _themeScriptPathRegex = new Regex("^/sitecore/media library/[^/]*/[^/]*/[s|S][c|C][r|R][i|I][p|P][t|T][s|S]/[^/]*$");

        /// <summary>
        /// Fires on the CM or Standalone server whenever a theme related item is saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnSaving(object sender, EventArgs args)
        {
            if (args != null)
            {
                var savedItem = Event.ExtractParameter(args, 0) as Item;
                if (Settings.GetBoolSetting(SitecoreSettings.DevelopmentMode, false) && savedItem?.Database.Name.Equals(Databases.Master, StringComparison.OrdinalIgnoreCase) == true)
                {
                    var itemPath = savedItem.Paths?.FullPath ?? string.Empty;
                    if (itemPath.StartsWith(ItemPaths.ThemesFolder) || itemPath.StartsWith(ItemPaths.BaseThemesFolder) || itemPath.StartsWith(ItemPaths.ExtensionThemesFolder))
                    {
                        if (savedItem.Parent.TemplateID == ScriptsFolder.ID || _themeScriptPathRegex.IsMatch(itemPath))
                        {
                            Event.RaiseEvent(CustomEvents.OptimizeScripts, new object[] { });
                        }
                    }
                }

                if (savedItem?.TemplateID == ThemeOptimizationSettings.ID)
                {
                    CachingService.ClearCache();
                }
            }
        }

        public void OnPublishEnd(object sender, EventArgs args)
        {
            if (args != null)
            {
                CachingService.ClearCache();
            }
        }

        /// <summary>
        /// Fires on the CM or Standalone server when the "sxathemeoptimizations:optimize" event is raised.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OptimizeEvent(object sender, EventArgs args)
        {
            var themeBundler = ServiceLocator.ServiceProvider?.GetService<IScriptOptimizer>() ?? default;
            if (themeBundler != null)
            {
                themeBundler.OptimizeScriptsForAllThemes(Factory.GetDatabase(Databases.Master));
                themeBundler.OptimizeScriptsForAllThemes(Factory.GetDatabase(Databases.Web));

                CachingService.ClearCache();
            }
        }

        /// <summary>
        /// Fires on the CD server when the "sxathemeoptimizations:optimize:remote" event is raised.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OptimizeEventRemote(object sender, EventArgs args)
        {
            var themeBundler = ServiceLocator.ServiceProvider?.GetService<IScriptOptimizer>() ?? default;
            if (themeBundler != null)
            {
                themeBundler.OptimizeScriptsForAllThemes(Factory.GetDatabase(Databases.Web));

                CachingService.ClearCache();
            }
        }
    }
}