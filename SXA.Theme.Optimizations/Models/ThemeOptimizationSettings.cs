using Sitecore.Configuration;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using SXA.Theme.Optimizations.Constants;
using SXA.Theme.Optimizations.Enums;
using System;
using System.IO;
using System.Linq;
using System.Web;
using Templates = SXA.Theme.Optimizations.Constants.Templates;

namespace SXA.Theme.Optimizations.Models
{
    public class ThemeOptimizationSettings
    {
        public ScriptAttributes RenderScriptsAs { get; set; } = ScriptAttributes.Async;
        public ScriptLocations ScriptsLocation { get; set; } = ScriptLocations.Top;
        public bool DeferCss { get; set; } = true;
        public string ScriptUrl { get; set; } = string.Empty;

        public ThemeOptimizationSettings(Item item)
        {
            if (item?.TemplateID == Templates.Theme.ID)
            {
                ScriptUrl = GetSXAThemeOptimizationsScript(item);
                item = item.Children.FirstOrDefault(c => c.TemplateID == Templates.ThemeOptimizationSettings.ID);
            }

            if (item?.TemplateID == Templates.ThemeOptimizationSettings.ID)
            {
                var parseResult = Enum.TryParse(item[Templates.ThemeOptimizationSettings.Fields.RenderScriptsAs], out ScriptAttributes _renderScriptsAs);
                RenderScriptsAs = parseResult ? _renderScriptsAs : ScriptAttributes.Async;

                parseResult = Enum.TryParse(item[Templates.ThemeOptimizationSettings.Fields.ScriptsLocation], out ScriptLocations _scriptsLocation);
                ScriptsLocation = parseResult ? _scriptsLocation : ScriptLocations.Top;

                CheckboxField deferCssField = item.Fields[Templates.ThemeOptimizationSettings.Fields.DeferCSS];
                DeferCss = deferCssField?.Checked ?? true;

                if (string.IsNullOrWhiteSpace(ScriptUrl) && item.Parent.TemplateID == Templates.Theme.ID)
                {
                    ScriptUrl = GetSXAThemeOptimizationsScript(item);
                }
            }
        }

        private string GetSXAThemeOptimizationsScript(Item item)
        {
            if (!string.IsNullOrWhiteSpace(item.Parent?.Name) && !string.IsNullOrWhiteSpace(item.Parent?.Database?.Name))
            {
                var alwaysIncludeServerUrl = Settings.GetBoolSetting(SitecoreSettings.AlwaysIncludeServerUrl, false);
                var scriptUrlBase = alwaysIncludeServerUrl ? Settings.GetSetting(SitecoreSettings.MediaLinkServerUrl, string.Empty) : string.Empty;

                var scriptUrl = $"{scriptUrlBase}{string.Format(FileNames.NewlyOptimizedMin, item.Parent.Name.Replace(" ", "-").ToLower(), item.Parent.Database.Name.ToLower())}";

                var alwaysAppednRevision = Settings.GetBoolSetting(SitecoreSettings.AlwaysAppendRevision, false);
                return alwaysAppednRevision ? $"{scriptUrl}?rev={File.GetLastWriteTimeUtc(scriptUrl):MMddHHmmss}" : scriptUrl;
            }

            return string.Empty;
        }
    }
}