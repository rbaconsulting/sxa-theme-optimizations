using Sitecore.Data;

namespace SXA.Theme.Optimizations
{
	public struct Templates
	{
		public struct Settings
		{
			public static ID ID = new ID("{4E81145F-6C8F-46D7-B239-998EC24C8EF1}");

			public struct Fields
			{
				public static ID GridMapping = new ID("{AD84CC6B-32EF-49D8-9326-916976CB2520}");
			}
		}

		public struct GridDefinition
		{
			public static ID ID = new ID("{A12EF6DE-1E2A-4D9B-82B4-DFFB70189E52}");

			public struct Fields
			{
				public static ID GridTheme = new ID("{E0B0A836-40BD-4526-998A-649D3AF28AD5}");
			}
		}

		public struct File
		{
			public static ID ID = new ID("{962B53C4-F93B-4DF9-9821-415C867B8903}");

			public struct Fields
			{
				public static ID Blob = new ID("{40E50ED9-BA07-4702-992E-A912738D32DC}");
			}
		}

		public struct OptimizedMin
		{
			public static ID ID = new ID("{B43AB8D5-E123-42DD-8042-DE869CC98C4F}");
		}

		public struct BaseTheme
		{
			public static ID ID = new ID("{78086CA4-8985-45EB-8AA7-B2948D2A0E06}");

			public struct Fields
			{
				public static ID BaseLayout = new ID("{E0367CD6-E333-4625-9993-BAA4F1C0C92B}");
			}
		}

		public struct Theme
		{
			public static ID ID = new ID("{F7653F31-6F17-4DAA-9217-8E116BABC927}");

			public struct Sections
			{
				public static ID Theme = new ID("{B56EA06B-1703-4B55-981A-FE7FA8982502}");
			}

			public struct Fields
			{
				public static ID BaseLayout = new ID("{384C2D3C-3E34-4493-9CB2-ADE68CAF0DA2}");
			}

			public struct FieldNames
			{
				public static string DeferCss = "Defer Css";
			}
		}

		public struct CommonFolder
		{
			public static ID ID = new ID("{A87A00B1-E6DB-45AB-8B54-636FEC3B5523}");
		}

		public struct Command
		{
			public static ID ID = new ID("{58119A3E-560E-4DA6-97C6-1ACE8A5B1219}");

			public struct Fields
			{
				public static ID Type = new ID("{752579A7-EF2F-45B7-B9D1-9B682308B7A5}");
				public static ID Method = new ID("{4BC75539-D5C4-487B-AF35-FF13D62BD286}");
			}
		}

		public struct Schedule
		{
			public static ID ID = new ID("{70244923-FA84-477C-8CBD-62F39642C42B}");

			public struct Fields
			{
				public static ID Command = new ID("{62E64DBB-0A39-4DD7-BA05-7BD08C5404E0}");
				public static ID Schedule = new ID("{50BE51F8-746D-4DC2-9C3B-B14ABC5CE9B7}");
			}
		}

		public struct ScriptsFolder
		{
			public static ID ID = new ID("{536EF8AE-E6DF-4AED-BD84-1F18DE8CEBF7}");
		}
	}
}