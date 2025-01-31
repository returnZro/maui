﻿using Microsoft.Maui.Graphics;
using Flex = Microsoft.Maui.Layouts.Flex;
using Microsoft.Maui.Layouts;

namespace Microsoft.Maui.Controls
{
	static class FlexExtensions
	{
		public static int IndexOf(this Flex.Item parent, Flex.Item child)
		{
			var index = -1;
			foreach (var it in parent)
			{
				index++;
				if (it == child)
					return index;
			}
			return -1;
		}

		public static void Remove(this Flex.Item parent, Flex.Item child)
		{
			var index = parent.IndexOf(child);
			if (index < 0)
				return;
			parent.RemoveAt((uint)index);
		}

		public static Rectangle GetFrame(this Flex.Item item)
		{
			return new Rectangle(item.Frame[0], item.Frame[1], item.Frame[2], item.Frame[3]);
		}

		public static Size GetConstraints(this Flex.Item item)
		{
			var widthConstraint = -1d;
			var heightConstraint = -1d;
			var parent = item.Parent;
			do
			{
				if (parent == null)
					break;
				if (widthConstraint < 0 && !float.IsNaN(parent.Width))
					widthConstraint = (double)parent.Width;
				if (heightConstraint < 0 && !float.IsNaN(parent.Height))
					heightConstraint = (double)parent.Height;
				parent = parent.Parent;
			} while (widthConstraint < 0 || heightConstraint < 0);
			return new Size(widthConstraint, heightConstraint);
		}

		public static Flex.Basis ToFlexBasis(this FlexBasis basis)
		{
			if (basis.IsAuto)
				return Flex.Basis.Auto;
			if (basis.IsRelative)
				return new Flex.Basis(basis.Length, isRelative: true);
			return new Flex.Basis(basis.Length, isRelative: false);
		}
	}
}
