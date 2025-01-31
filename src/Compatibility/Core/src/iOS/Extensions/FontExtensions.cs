using Microsoft.Maui.Controls.Internals;
using UIKit;
using Microsoft.Maui.Controls;

namespace Microsoft.Maui.Controls.Compatibility.Platform.iOS
{
	public static partial class FontExtensions
	{
		public static UIFont ToUIFont(this Font self)
			=> CompatServiceProvider.FontManager.GetFont(self);

		internal static UIFont ToUIFont(this IFontElement self)
			=> CompatServiceProvider.FontManager.GetFont(self.ToFont());

		internal static bool IsDefault(this IFontElement self)
			=> self.FontFamily == null && self.FontSize == Device.GetNamedSize(NamedSize.Default, typeof(Label), true) && self.FontAttributes == FontAttributes.None;
	}
}