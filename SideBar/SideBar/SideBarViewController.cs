using System;
using System.Drawing;

using MonoTouch.UIKit;

namespace SideBar
{
	public class SideBarViewController : UIViewController
	{
		private UITableView _table;
		private SideBarSource _source;

		public SideBarViewController ()
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_source = new SideBarSource ();

			_table = new UITableView ();
			_table.ScrollEnabled = false;
			_table.Source = _source;
			_table.TableFooterView = new UIView (new RectangleF ());

			View.AddSubview (_table);
			_table.Frame = _table.Superview.Bounds;

		}
	}
}

