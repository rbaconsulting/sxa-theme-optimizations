using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.Theming;
using SXA.Theme.Optimizations.Models;
using System.Collections.Generic;
using System.Web;

namespace SXA.Theme.Optimizations.Services
{
    public static class CachingService
    {
        public const string CacheKey = "SXA.Theme.Optimizations.{0}";
        private static List<string> _cacheKeys { get; set; } = new List<string>();

        public static ThemeOptimizationSettings GetThemeOptimizationsSettings()
        {
            var themeItem = ServiceLocator.ServiceProvider?.GetService<IThemingContext>()?.ThemeItem ?? default;

            var optimizationSettingsCacheKey = string.Format(CacheKey, themeItem.ID);
            var optimizationSettings = HttpRuntime.Cache.Get(optimizationSettingsCacheKey) as ThemeOptimizationSettings;
            if (optimizationSettings == null)
            {
                optimizationSettings = new ThemeOptimizationSettings(themeItem);
                HttpRuntime.Cache.Insert(optimizationSettingsCacheKey, optimizationSettings);
                if (!_cacheKeys.Contains(optimizationSettingsCacheKey))
                {
                    _cacheKeys.Add(optimizationSettingsCacheKey);
                }
            }

            return optimizationSettings;
        }

        public static void ClearCache()
        {
            foreach (var cacheKey in _cacheKeys)
            {
                HttpRuntime.Cache.Remove(cacheKey);
            }

            _cacheKeys = new List<string>();
        }
    }
}