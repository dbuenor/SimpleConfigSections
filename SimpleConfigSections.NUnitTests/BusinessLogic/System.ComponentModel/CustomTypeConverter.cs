using SimpleConfigSections.Tests.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
	public class CustomTypeConverter : TypeConverter
	{
		private CustomType GetCustomType(ITypeDescriptorContext context, string value)
		{
			return CustomType.GetCustomTypes().First(x => x.Name == value);
		}
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || typeof(CustomType).IsAssignableFrom(sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || typeof(CustomType).IsAssignableFrom(destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			return value is CustomType ? value : GetCustomType(context, value as string);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			var customType = value as CustomType;
			if (customType != null)
			{
				return destinationType == typeof(string) ? (object)customType.Name : customType;
			}

			var name = value as string;
			if (name != null)
			{
				return destinationType == typeof(string) ? value : GetCustomType(context, name);
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
