using SXA.Theme.Optimizations.Constants;
using SXA.Theme.Optimizations.Interfaces;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.IO;
using System.Linq;
using Sitecore.Diagnostics;
using System.Web;
using Sitecore.Data;
using System.Collections.Generic;

namespace SXA.Theme.Optimizations.Services
{
	public class ScriptOptimizer : IScriptOptimizer
	{
		public void OptimizeScriptsForAllThemes(Database database)
		{
            if(database != null)
            {
                var themesFolder = database.GetItem(ItemPaths.ThemesFolder);

                if(themesFolder != null)
                {
                    foreach (var theme in themesFolder.Axes.GetDescendants().Where(d => d.TemplateID.Equals(Templates.Theme.ID)))
                    {
                        if (theme != null)
                        {
                            OptimizeScriptsForTheme(theme);
                        }
                    }
                }
            }
        }

        public void OptimizeScriptsForTheme(Item targetThemeItem)
        {
            try
			{
                if (targetThemeItem != null)
				{
                    var newlyOptimizedMin = string.Empty;

                    var myThemeList = GetThemeWithBaseThemes(targetThemeItem);

                    foreach (var themeItem in myThemeList)
                    {
                        if (themeItem != null)
                        {
                            var themeScriptsFolder = themeItem.Children.FirstOrDefault(c => c.TemplateID.Equals(Templates.ScriptsFolder.ID) || c.Name.Equals("scripts", StringComparison.OrdinalIgnoreCase));

                            if (themeScriptsFolder != null)
                            {
                                var optimizedScript = themeScriptsFolder.Children.FirstOrDefault(c => c.TemplateID.Equals(Templates.OptimizedMin.ID) || c.Name.Equals(FileNames.PreOptimizedMin));

                                if (optimizedScript != null)
                                {
                                    newlyOptimizedMin = ConcatenateScript(optimizedScript, newlyOptimizedMin);
                                }
                                else
                                {
                                    if (themeScriptsFolder != null)
                                    {
                                        foreach (Item script in themeScriptsFolder.Children)
                                        {
                                            if (script != null && script.TemplateID.Equals(Templates.File.ID))
                                            {
                                                newlyOptimizedMin = ConcatenateScript(script, newlyOptimizedMin);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(newlyOptimizedMin))
                    {
                        var filename = $"{HttpRuntime.AppDomainAppPath}{string.Format(FileNames.NewlyOptimizedMin.TrimStart('/').Replace("/", "\\"), targetThemeItem.Name.Replace(" ", "-").ToLower(), targetThemeItem.Database.Name.ToLower())}";
                        File.WriteAllText(filename, newlyOptimizedMin);
                    }
                }
			}
			catch (Exception e)
			{
                Log.Error(string.Format(LogMessages.Error.ScriptOptimization, e.Message), e, this);
			}
		}

        /// <summary>
        /// Gets all base themes and the base themes of the base themes... in the proper order with the theme item provided at the end of the list.
        /// </summary>
        /// <param name="themeItem"></param>
        /// <returns></returns>
        private List<Item> GetThemeWithBaseThemes(Item themeItem)
        {
            var list = new List<Item>();

            //This is the line that is different from SXA's OOTB GetThemeWithBaseThemes(). Without it, only base themes directly linked are pulled and not base themes of base themes.
            var baseThemesFieldId = themeItem.TemplateID == Templates.BaseTheme.ID ? Templates.BaseTheme.Fields.BaseLayout : Templates.Theme.Fields.BaseLayout;

            foreach (var item in ((MultilistField)themeItem.Fields[baseThemesFieldId]).GetItems())
            {
                foreach (var theme in GetThemeWithBaseThemes(item))
                {
                    if (!list.Any(t => t.ID == theme.ID))
                    {
                        list.Add(theme);
                    }
                }
            }

            if (!list.Any(t => t.ID == themeItem.ID))
            {
                list.Add(themeItem);
            }

            return list;
        }

        private string ConcatenateScript(Item fileItem, string newlyOptimizedMin)
		{
			FileField scriptField = fileItem.Fields[Templates.File.Fields.Blob];
			Stream myBlobStream = scriptField.InnerField.GetBlobStream();

			using (StreamReader reader = new StreamReader(myBlobStream))
			{
				var script = reader.ReadToEnd();

				if (!string.IsNullOrWhiteSpace(script) && !newlyOptimizedMin.Contains(script))
				{
                    newlyOptimizedMin += script + ";\n\n";
				}
			}

			return newlyOptimizedMin;
		}
	}
}