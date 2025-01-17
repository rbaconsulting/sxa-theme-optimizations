using Sitecore.Configuration;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using SXA.Theme.Optimizations.Constants;
using SXA.Theme.Optimizations.Enums;
using System;
using System.IO;
using System.Linq;
using Templates = SXA.Theme.Optimizations.Constants.Templates;

namespace SXA.Theme.Optimizations.Models
{
    public class ThemeOptimizationSettings
    {
        public ScriptAttributes RenderScriptsAs { get; set; } = ScriptAttributes.Async;
        public ScriptLocations ScriptsLocation { get; set; } = ScriptLocations.Top;
        public bool DeferCss { get; set; } = true;
        public string ScriptUrl { get; set; } = string.Empty;

        public ThemeOptimizationSettings(Item themeItem)
        {
            var themeOptimizationSettingsItem = themeItem.Children.FirstOrDefault(c => c.TemplateID == Templates.ThemeOptimizationSettings.ID);
            if (themeOptimizationSettingsItem?.TemplateID == Templates.ThemeOptimizationSettings.ID)
            {
                var parseResult = Enum.TryParse(themeOptimizationSettingsItem[Templates.ThemeOptimizationSettings.Fields.RenderScriptsAs], out ScriptAttributes _renderScriptsAs);
                RenderScriptsAs = parseResult ? _renderScriptsAs : ScriptAttributes.Async;

                parseResult = Enum.TryParse(themeOptimizationSettingsItem[Templates.ThemeOptimizationSettings.Fields.ScriptsLocation], out ScriptLocations _scriptsLocation);
                ScriptsLocation = parseResult ? _scriptsLocation : ScriptLocations.Top;

                CheckboxField deferCssField = themeOptimizationSettingsItem.Fields[Templates.ThemeOptimizationSettings.Fields.DeferCSS];
                DeferCss = deferCssField?.Checked ?? true;
            }

            if (!string.IsNullOrWhiteSpace(themeItem?.Name) && !string.IsNullOrWhiteSpace(themeItem?.Database?.Name))
            {
                var alwaysIncludeServerUrl = Settings.GetBoolSetting(SitecoreSettings.AlwaysIncludeServerUrl, false);
                var alwaysAppednRevision = Settings.GetBoolSetting(SitecoreSettings.AlwaysAppendRevision, false);
                var mediaLinkServerUrl = Settings.GetSetting(SitecoreSettings.MediaLinkServerUrl, string.Empty);

                var scriptUrlBase = alwaysIncludeServerUrl ? mediaLinkServerUrl : string.Empty;
                var scriptUrlFilePathAndName = string.Format(FileNames.NewlyOptimizedMin, themeItem.Name.Replace(" ", "-").ToLower(), themeItem.Database.Name.ToLower());
                var scriptUrlRevision = alwaysAppednRevision ? $"{scriptUrlFilePathAndName}?rev={File.GetLastWriteTimeUtc(scriptUrlFilePathAndName):MMddHHmmss}" : string.Empty;

                ScriptUrl = Path.Combine(scriptUrlBase, scriptUrlFilePathAndName, scriptUrlRevision);
            }
        }
    }
}