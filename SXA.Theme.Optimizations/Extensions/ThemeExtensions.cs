using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.Theming;
using SXA.Theme.Optimizations.Constants;

namespace SXA.Theme.Optimizations.Extensions
{
    public static class ThemeExtensions
    {
        /// <summary>
        /// Returns the script src for the new optimized-min.
        /// </summary>
        /// <returns>A string for a html script tag's src attribute.</returns>
        public static string GetNewlyOptimizedScript()
        {
            var themingContext = ServiceLocator.ServiceProvider.GetService(typeof(IThemingContext)) as IThemingContext;

            return string.Format(FileNames.NewlyOptimizedMin, themingContext?.ThemeItem?.Name.Replace(" ", "-").ToLower(), themingContext?.ThemeItem?.Database?.Name.ToLower());
        }
    }
}