using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace Microsoft.Maui.DeviceTests.Stubs
{
	public class LayoutStub : StubBase, ILayout
	{
		ILayoutManager _layoutManager;
		IList<IView> _children = new List<IView>();

		public ILayoutHandler LayoutHandler => Handler as ILayoutHandler;

		public void Add(IView child)
		{
			_children.Add(child);
		}

		public bool Remove(IView child)
		{
			return _children.Remove(child);
		}

		public int IndexOf(IView item)
		{
			return _children.IndexOf(item);
		}

		public void Insert(int index, IView item)
		{
			_children.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			_children.RemoveAt(index);
		}

		public void Clear()
		{
			_children.Clear();
		}

		public bool Contains(IView item)
		{
			return _children.Contains(item);
		}

		public void CopyTo(IView[] array, int arrayIndex)
		{
			_children.CopyTo(array, arrayIndex);
		}

		public IEnumerator<IView> GetEnumerator()
		{
			return _children.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _children.GetEnumerator();
		}

		public Thickness Padding { get; set; }
		public int Count => _children.Count;
		public bool IsReadOnly => _children.IsReadOnly;

		public ILayoutManager LayoutManager => _layoutManager ??= new LayoutManagerStub();

		public IView this[int index] { get => _children[index]; set => _children[index] = value; }
	}
}
