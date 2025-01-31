using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Microsoft.Maui.Controls
{
	[Xaml.TypeConversion(typeof(RowDefinitionCollection))]
	public class RowDefinitionCollectionTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
			=> sourceType == typeof(string);

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			=> true;

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			var strValue = value?.ToString();

			if (strValue != null)
			{
				var lengths = strValue.Split(',');
				var coldefs = new RowDefinitionCollection();
				var converter = new GridLengthTypeConverter();
				foreach (var length in lengths)
					coldefs.Add(new RowDefinition { Height = (GridLength)converter.ConvertFromInvariantString(length) });
				return coldefs;
			}

			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", strValue, typeof(RowDefinitionCollection)));
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value is not RowDefinitionCollection rdc)
				throw new NotSupportedException();
			var converter = new GridLengthTypeConverter();
			return string.Join(", ", rdc.Select(rd => converter.ConvertToInvariantString(rd.Height)));
		}
	}
}