using System;
using System.Drawing;

using MonoTouch.UIKit;

using Touch.Common;

namespace SideBar
{
	public class SideBarViewController : UIViewController
	{
		public event Action<SideBarItemModel> SideBarItemSelected;

		private UITableView _table;
		private SideBarSource _source;

		public SideBarViewController ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;

			_source = new SideBarSource ();
			_source.RowSelectedEvent += HandleRowSelectedEvent;

			_table = new UITableView ();
			_table.ScrollEnabled = false;
			_table.Source = _source;
			_table.TableFooterView = new UIView (new RectangleF ());

			View.AddSubview (_table);
			_table.Frame = _table.Superview.Bounds;
			_table.MoveVertically(10f);
		}

		void HandleRowSelectedEvent(SideBarItemModel selectedItem)
		{
			var handler = SideBarItemSelected;
			if (handler != null)
			{
				handler(selectedItem);
			}
		}
	}
}

