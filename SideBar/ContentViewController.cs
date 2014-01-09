using System;
using System.Drawing;

using MonoTouch.UIKit;

using Touch.Common;

namespace SideBar
{
	public class ContentViewController : UIViewController
	{
		private UINavigationBar _navigationBar;
		private UIView _container;
		private UIImageView _imageView;
		private SideBarViewController _sideBar;

		private SideBarMediator _sideBarMediator;

		public ContentViewController(SideBarViewController sideBar)
		{
			_sideBar = sideBar;
			_sideBar.SideBarItemSelected += HandleSideBarItemSelected;
		}

		void HandleSideBarItemSelected (SideBarItemModel selectedItem)
		{
			UIImage contentImg = UIImage.FromFile(selectedItem.IconPath);
			SetImage (contentImg);

			_sideBarMediator.ToggleSideBar();
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			_sideBarMediator.TryHideSideBar ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_container = new UIView ();
			View.AddSubview (_container);
			_container.Frame = _container.Superview.Bounds;
			_container.BackgroundColor = UIColor.Gray;

			_imageView = new UIImageView ();
			_container.AddSubview (_imageView);

			_navigationBar = new UINavigationBar ();
			_navigationBar.Frame = new RectangleF (0f, 0f, 320f, 55f);
			_navigationBar.BarStyle = UIBarStyle.Default;

			UINavigationItem navItems = new UINavigationItem { LeftBarButtonItem = new UIBarButtonItem("Меню", UIBarButtonItemStyle.Plain, OnMenuButtonPressed) };
			_navigationBar.Items = new UINavigationItem[]
			{
				navItems
			};
			_container.AddSubview(_navigationBar);

			_sideBarMediator = new SideBarMediator(this, _container, _sideBar, 260f);

			SetImage(UIImage.FromFile("wishlist.png"));
		}

		private void OnMenuButtonPressed(object sender, EventArgs e)
		{
			_sideBarMediator.ToggleSideBar();
		}

		public void SetImage(UIImage image)
		{
			_imageView.Image = image;

			SizeF maxSize = _container.Frame.Size;
			SizeF size = GetInboundRect (maxSize, image.Size);

			_imageView.Frame = new RectangleF (new PointF (), size);
			_imageView.CenterInParent ();
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

