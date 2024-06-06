using Sitecore.Data.Fields;
using System.Collections.Generic;
using Sitecore.Data.Items;
using System.Linq;
using Templates = SXA.Theme.Optimizations.Constants.Templates;

namespace SXA.Theme.Optimizations.Extensions
{
    public static class ThemeExtensions
    {
        /// <summary>
        /// Gets all base themes and the base themes of the base themes... in the proper order with the theme item provided at the end of the list.
        /// </summary>
        /// <param name="themeItem"></param>
        /// <returns></returns>
        public static List<Item> GetThemeWithBaseThemes(this Item themeItem)
        {
            var list = new List<Item>();
            if (themeItem?.TemplateID == Templates.BaseTheme.ID || themeItem?.TemplateID == Templates.Theme.ID)
            {
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
            }

            return list;
        }
    }
}