using System;
using System.Text;

using NUnit.Framework;

using SimpleConfigSections.Tests.Configuration;

namespace SimpleConfigSections.NUnitTests
{
	[TestFixture]
	public class ConfigBuilderTests
	{
		[Test]
		public void ParseEncodingConfig_AValueDefinedAtConfig_BValueWithDefaultValue()
		{
			var testConfig = Configuration.Get<TestConfig>();

			Assert.AreEqual(testConfig.Encodings.CodificationA, Encoding.UTF8);
			Assert.AreEqual(testConfig.Encodings.CodificationB, Encoding.GetEncoding("ISO-8859-1"));
		}

		[Test]
		public void ParseTimeSpanConfig_AValueDefinedAtConfig_BValueWithDefaultValue()
		{
			var testConfig = Configuration.Get<TestConfig>();

			Assert.AreEqual(testConfig.TimeSpans.TimeSpanA, TimeSpan.FromMinutes(10));
			Assert.AreEqual(testConfig.TimeSpans.TimeSpanB, TimeSpan.FromMinutes(1));
		}

		[Test]
		public void ParseCultureInfoConfig_AValueDefinedAtConfig_BValueWithDefaultValue()
		{
			var testConfig = Configuration.Get<TestConfig>();

			Assert.AreEqual(testConfig.CultureInfos.CultureInfoA, new System.Globalization.CultureInfo("fr-FR"));
			Assert.AreEqual(testConfig.CultureInfos.CultureInfoB, new System.Globalization.CultureInfo("es-ES"));
		}
	}
}