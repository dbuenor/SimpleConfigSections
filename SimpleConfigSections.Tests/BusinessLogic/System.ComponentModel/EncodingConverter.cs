using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
	public class EncodingConverter : TypeConverter
	{
		protected virtual Encoding GetEncoding(ITypeDescriptorContext context, string name)
		{
			return Encoding.GetEncoding(name);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || typeof(Encoding).IsAssignableFrom(sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || typeof(Encoding).IsAssignableFrom(destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			return value is Encoding ? value : GetEncoding(context, value as string);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			var encoding = value as Encoding;
			if (encoding != null)
			{
				return destinationType == typeof(string) ? (object)encoding.BodyName : encoding;
			}

			var name = value as string;
			if (name != null)
			{
				return destinationType == typeof(string) ? value : GetEncoding(context, name);
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}