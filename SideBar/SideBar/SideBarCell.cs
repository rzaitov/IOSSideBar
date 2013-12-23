using System;
using System.Drawing;

using MonoTouch.UIKit;

namespace SideBar
{
	public class SideBarCell : UITableViewCell
	{
		private readonly UIImageView _imageView;
		private readonly UILabel _title;

		public SideBarCell ()
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;

			_imageView = new UIImageView ();
			_imageView.Frame = new RectangleF (5f, 5f, 35f, 35f);

			_title = new UILabel ();
			_title.Frame = new RectangleF (45f, 5f, 320f - 50f, 35f);

			ContentView.AddSubview (_imageView);
			ContentView.AddSubview (_title);
		}

		public void InitWithModel(SideBarItemModel model)
		{
			UIImage image = UIImage.FromFile (model.IconPath);
			_imageView.Image = image;

			_title.Text = model.Title;
		}
	}
}

