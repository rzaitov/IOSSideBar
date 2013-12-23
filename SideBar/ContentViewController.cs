using System;
using System.Drawing;

using MonoTouch.UIKit;

namespace SideBar
{
	public class ContentViewController : UIViewController
	{
		protected UIView _container { get; set; }
		private UIImageView _imageView { get; set; }

		public ContentViewController ()
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_container = new UIView ();
			View.AddSubview (_container);
			_container.Frame = _container.Superview.Bounds;

			_imageView = new UIImageView ();
			_container.AddSubview (_imageView);

			SetImage(UIImage.FromFile("wishlist.png"));
		}

		public void SetImage(UIImage image)
		{
			_imageView.Image = image;

			SizeF maxSize = _container.Frame.Size;
			SizeF size = GetInboundRect (maxSize, image.Size);

			_imageView.Frame = new RectangleF (new PointF (), size);
			_imageView.Center = _container.Center;
		}

		private SizeF GetInboundRect(SizeF maxSize, SizeF size)
		{
			float hRatio = maxSize.Height / size.Height;
			float wRatio = maxSize.Width / size.Width;

			float ratio = Math.Min (hRatio, wRatio);

			size.Height *= ratio;
			size.Width *= ratio;

			return size;
		}
	}
}

