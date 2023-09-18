using Microsoft.Extensions.DependencyInjection;
using Sitecore.Configuration;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.Theming;
using SXA.Theme.Optimizations.Constants;
using System.IO;
using System.Web;

namespace SXA.Theme.Optimizations.Extensions
{
    public static class ThemeExtensions
    {
        /// <summary>
        /// Returns the script src for SXA's Theme Optimization script.
        /// </summary>
        /// <returns>A string for a html script tag's src attribute.</returns>
        public static string GetSXAThemeOptimizationsScript()
        {
            var scriptUrl = GetWebModulesPath();

            if (Settings.GetBoolSetting(SitecoreSettings.AlwaysAppendRevision, false))
            {
                var updatedDate = File.GetLastWriteTimeUtc(GetFullFileSystemPath());

                scriptUrl = $"{scriptUrl}?rev={updatedDate:MMddHHmmss}";
            }

            if (Settings.GetBoolSetting(SitecoreSettings.AlwaysIncludeServerUrl, false))
            {
                scriptUrl = Settings.GetSetting(SitecoreSettings.MediaLinkServerUrl, string.Empty) + scriptUrl;
            }

            return scriptUrl;
        }

        public static string GetWebModulesPath()
        {
            var themingContext = ServiceLocator.ServiceProvider.GetService<IThemingContext>();

            var themeName = themingContext?.ThemeItem?.Name?.Replace(" ", "-").ToLower() ?? string.Empty;
            var databaseName = themingContext?.ThemeItem?.Database?.Name?.ToLower() ?? string.Empty;

            return string.Format(FileNames.NewlyOptimizedMin, themeName, databaseName) ?? string.Empty;
        }

        public static string GetFullFileSystemPath()
        {
            var scriptPath = GetWebModulesPath()?.TrimStart('/').Replace("/", "\\") ?? string.Empty;

            return $"{HttpRuntime.AppDomainAppPath}{scriptPath}" ?? string.Empty;
        }
    }
}