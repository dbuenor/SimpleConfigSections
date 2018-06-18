using SimpleConfigSections.Tests.BusinessLogic;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace SimpleConfigSections.Tests.Configuration
{
	#region Interfaces
	public interface EncodingConfig
	{
		[DefaultValue("ISO-8859-1")]
		[TypeConverter(typeof(EncodingConverter))]
		Encoding CodificationA { get; set; }

		[DefaultValue("ISO-8859-1")]
		[TypeConverter(typeof(EncodingConverter))]
		Encoding CodificationB { get; set; }
	}

	public interface TimeSpanConfig
	{
		[DefaultValue("00:01:00")]
		[TypeConverter(typeof(TimeSpanConverter))]
		TimeSpan TimeSpanA { get; set; }

		[DefaultValue("00:01:00")]
		[TypeConverter(typeof(TimeSpanConverter))]
		TimeSpan TimeSpanB { get; set; }
	}

	public interface CultureInfoConfig
	{
		[DefaultValue("es-ES")]
		[TypeConverter(typeof(CultureInfoConverter))]
		CultureInfo CultureInfoA { get; set; }

		[DefaultValue("es-ES")]
		[TypeConverter(typeof(CultureInfoConverter))]
		CultureInfo CultureInfoB { get; set; }
	}

	public interface CustomTypeConfig
	{
		[DefaultValue("A")]
		[TypeConverter(typeof(CustomTypeConverter))]
		CustomType TypeA { get; set; }

		[DefaultValue("A")]
		[TypeConverter(typeof(CustomTypeConverter))]
		CustomType TypeB { get; set; }
	}

	public interface TestConfig
	{
		EncodingConfig Encodings { get; set; }
		TimeSpanConfig TimeSpans { get; set; }
		CultureInfoConfig CultureInfos { get; set; }
		CustomTypeConfig CustomTypes { get; set; }
	}
	#endregion

	public class TestConfigSection : ConfigurationSection<TestConfig>
	{
	}
}
