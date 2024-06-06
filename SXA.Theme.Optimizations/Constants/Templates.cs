using Sitecore.Data;

namespace SXA.Theme.Optimizations.Constants
{
    /// <summary>
    /// Template and field IDs to avoid hardcoded, non-reusable strings.
    /// </summary>
    public readonly struct Templates
    {
        public readonly struct ThemeOptimizationSettings
        {
            public static readonly ID ID = new ID("{DF8A0FAE-6E6E-40D6-B4E2-D723E36DA3EF}");

            public readonly struct Fields
            {
                public static readonly ID RenderScriptsAs = new ID("{D5936AA4-F92E-4328-BF7C-625BB727D48C}");
                public static readonly ID ScriptsLocation = new ID("{C4AFAB2F-101A-4A13-9062-C0B8806C6685}");
                public static readonly ID DeferCSS = new ID("{22042BB0-7978-43A9-BA2A-F130DC8045D0}");
            }
        }

        public readonly struct Settings
        {
            public static readonly ID ID = new ID("{4E81145F-6C8F-46D7-B239-998EC24C8EF1}");

            public readonly struct Fields
            {
                public static readonly ID GridMapping = new ID("{AD84CC6B-32EF-49D8-9326-916976CB2520}");
            }
        }

        public readonly struct GridDefinition
        {
            public static readonly ID ID = new ID("{A12EF6DE-1E2A-4D9B-82B4-DFFB70189E52}");

            public readonly struct Fields
            {
                public static readonly ID GridTheme = new ID("{E0B0A836-40BD-4526-998A-649D3AF28AD5}");
            }
        }

        public readonly struct File
        {
            public static readonly ID ID = new ID("{962B53C4-F93B-4DF9-9821-415C867B8903}");

            public readonly struct Fields
            {
                public static readonly ID Blob = new ID("{40E50ED9-BA07-4702-992E-A912738D32DC}");
            }
        }

        public readonly struct OptimizedMin
        {
            public static readonly ID ID = new ID("{B43AB8D5-E123-42DD-8042-DE869CC98C4F}");
        }

        public readonly struct BaseTheme
        {
            public static readonly ID ID = new ID("{78086CA4-8985-45EB-8AA7-B2948D2A0E06}");

            public readonly struct Fields
            {
                public static readonly ID BaseLayout = new ID("{E0367CD6-E333-4625-9993-BAA4F1C0C92B}");
            }
        }

        public readonly struct Theme
        {
            public static readonly ID ID = new ID("{F7653F31-6F17-4DAA-9217-8E116BABC927}");

            public readonly struct Sections
            {
                public static readonly ID Theme = new ID("{B56EA06B-1703-4B55-981A-FE7FA8982502}");
            }

            public readonly struct Fields
            {
                public static readonly ID BaseLayout = new ID("{384C2D3C-3E34-4493-9CB2-ADE68CAF0DA2}");
            }

            public readonly struct FieldNames
            {
                public static readonly string DeferCss = "Defer Css";
            }
        }

        public readonly struct CommonFolder
        {
            public static readonly ID ID = new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}");
        }

        public readonly struct Command
        {
            public static readonly ID ID = new ID("{58119A3E-560E-4DA6-97C6-1ACE8A5B1219}");

            public readonly struct Fields
            {
                public static readonly ID Type = new ID("{752579A7-EF2F-45B7-B9D1-9B682308B7A5}");
                public static readonly ID Method = new ID("{4BC75539-D5C4-487B-AF35-FF13D62BD286}");
            }
        }

        public readonly struct Schedule
        {
            public static readonly ID ID = new ID("{70244923-FA84-477C-8CBD-62F39642C42B}");

            public readonly struct Fields
            {
                public static readonly ID Command = new ID("{62E64DBB-0A39-4DD7-BA05-7BD08C5404E0}");
                public static readonly ID Schedule = new ID("{50BE51F8-746D-4DC2-9C3B-B14ABC5CE9B7}");
            }
        }

        public readonly struct ScriptsFolder
        {
            public static readonly ID ID = new ID("{536EF8AE-E6DF-4AED-BD84-1F18DE8CEBF7}");
        }
    }
}