using System;
using System.Text;

using NUnit.Framework;

using SimpleConfigSections.Tests.Configuration;
using SimpleConfigSections.Tests.BusinessLogic;

namespace SimpleConfigSections.NUnitTests
{
	[TestFixture]
	public class ConfigBuilderTests
	{
		[Test]
		public void ParseEncodingConfig_AValueDefinedAtConfig_BValueWithDefaultValue()
		{
			var testConfig = Configuration.Get<TestConfig>();

			Assert.AreEqual(testConfig.Encodings.CodificationA, Encoding.UTF8, "#1");
			Assert.AreEqual(testConfig.Encodings.CodificationB, Encoding.GetEncoding("ISO-8859-1"), "#2");
		}

		[Test]
		public void ParseTimeSpanConfig_AValueDefinedAtConfig_BValueWithDefaultValue()
		{
			var testConfig = Configuration.Get<TestConfig>();

			Assert.AreEqual(testConfig.TimeSpans.TimeSpanA, TimeSpan.FromMinutes(10), "#1");
			Assert.AreEqual(testConfig.TimeSpans.TimeSpanB, TimeSpan.FromMinutes(1), "#2");
		}

		[Test]
		public void ParseCultureInfoConfig_AValueDefinedAtConfig_BValueWithDefaultValue()
		{
			var testConfig = Configuration.Get<TestConfig>();

			Assert.AreEqual(testConfig.CultureInfos.CultureInfoA, new System.Globalization.CultureInfo("fr-FR"), "#1");
			Assert.AreEqual(testConfig.CultureInfos.CultureInfoB, new System.Globalization.CultureInfo("es-ES"), "#2");
		}

		[Test]
		public void ParseCustomTypeConfig_AValueDefinedAtConfig_BValueWithDefaultValue()
		{
			var testConfig = Configuration.Get<TestConfig>();

			Assert.AreEqual(testConfig.CustomTypes.TypeA, new CustomTypeC(), "#1");
			Assert.AreEqual(testConfig.CustomTypes.TypeB, new CustomTypeA(), "#2");
		}
	}
}