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
using SXA.Theme.Optimizations.Extensions;

namespace SXA.Theme.Optimizations.Services
{
    public class ScriptOptimizer : IScriptOptimizer
    {
        public void OptimizeScriptsForAllThemes(Database database)
        {
            if (database != null)
            {
                var themesFolder = database.GetItem(ItemPaths.ThemesFolder);

                if (themesFolder != null)
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

                    var myThemeList = targetThemeItem.GetThemeWithBaseThemes();

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

                    try
                    {
                        var themeName = targetThemeItem.Name?.ToLower() ?? string.Empty;
                        var targetDatabaseName = targetThemeItem.Database?.Name?.ToLower() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(newlyOptimizedMin) && !string.IsNullOrWhiteSpace(themeName) && !string.IsNullOrWhiteSpace(targetDatabaseName))
                        {
                            var filename = $"{HttpRuntime.AppDomainAppPath.TrimEnd('\\')}{string.Format(FileNames.NewlyOptimizedMin, themeName.Replace(" ", "-"), targetDatabaseName)}";
                            File.WriteAllText(filename, newlyOptimizedMin);
                            Log.Warn(string.Format(LogMessages.Warn.ScriptOptimization, themeName, targetDatabaseName), this);
                        }
                        else
                        {
                            Log.Error(string.Format(LogMessages.Error.ScriptOptimizationEmptyValue, themeName, targetDatabaseName), this);
                        }
                    }
                    catch (IOException)
                    {
                        //the file is unavailable because it is still being written to by another instance/thread with the same data
                    }
                }
                else
                {
                    Log.Warn(LogMessages.Warn.NullThemeItem, this);
                }
            }
            catch (Exception e)
            {
                Log.Error(string.Format(LogMessages.Error.ScriptOptimization, e.Message), e, this);
            }
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