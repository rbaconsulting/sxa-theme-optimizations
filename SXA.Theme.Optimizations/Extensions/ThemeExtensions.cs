using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.Theming;
using SXA.Theme.Optimizations.Constants;

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
            var themingContext = ServiceLocator.ServiceProvider.GetService<IThemingContext>();

            return string.Format(FileNames.NewlyOptimizedMin, themingContext?.ThemeItem?.Name.Replace(" ", "-").ToLower(), themingContext?.ThemeItem?.Database?.Name.ToLower());
        }
    }
}