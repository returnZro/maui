using System;
using System.ComponentModel;
using System.Globalization;

namespace Microsoft.Maui.Controls
{
	[Xaml.TypeConversion(typeof(LinearItemsLayout))]
	public class CarouselLayoutTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
			=> sourceType == typeof(string);

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			=> destinationType == typeof(string);

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			var strValue = value?.ToString();

			if (strValue == "HorizontalList")
				return LinearItemsLayout.CarouselDefault;

			if (strValue == "VerticalList")
				return LinearItemsLayout.CarouselVertical;

			throw new InvalidOperationException($"Cannot convert \"{strValue}\" into {typeof(LinearItemsLayout)}");
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value is not LinearItemsLayout lil)
				throw new NotSupportedException();

			if (lil == LinearItemsLayout.CarouselDefault)
				return "HorizontalList";

			if (lil == LinearItemsLayout.CarouselVertical)
				return "VerticalList";

			throw new NotSupportedException();
		}
	}
}