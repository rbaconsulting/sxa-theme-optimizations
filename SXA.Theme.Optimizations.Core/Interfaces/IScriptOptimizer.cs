using Sitecore.Data;
using Sitecore.Data.Items;

namespace SXA.Theme.Optimizations.Core.Interfaces
{
	/// <summary>
	/// Interface for optimizing SXA themes by bundling all required scripts into one minified file.
	/// </summary>
    public interface IScriptOptimizer
    {
        /// <summary>
		/// Bundles all scripts from base themes and current theme, in order, into one minified file. This is run for every valid SXA site theme.
        /// </summary>
        /// <param name="database"></param>
        void OptimizeScriptsForAllThemes(Database database);

        /// <summary>
        /// Bundles all scripts from base themes and current theme, in order, into one minified file.
        /// </summary>
        /// <param name="targetThemeItem"></param>
        void OptimizeScriptsForTheme(Item targetThemeItem);
	}
}