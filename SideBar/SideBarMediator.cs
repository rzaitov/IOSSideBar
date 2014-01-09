using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

using Touch.Common;

namespace SideBar
{
	public class SideBarMediator<T> where T: UIViewController, IViewControllerWithSidebar
	{
		private const double SidebarAnimateDuration = 0.4;

		private readonly T _extendedViewController;
		private readonly UIViewController _sideBar;

		public bool IsSideBarOpened { get; set; }

		public SideBarMediator(T extendedViewController, UIViewController sideBar)
		{
			_extendedViewController = extendedViewController;
			_sideBar = sideBar;
		}

		public void TryHideSideBar()
		{
			if (IsSideBarOpened)
				HideSideBar(animated: false);
		}

		public void ToggleSideBar()
		{
			if (IsSideBarOpened)
				HideSideBar(animated: true);
			else
				ShowSideBar();
		}

		private void ShowSideBar ()
		{
//			Assert.False(IsSideBarOpened);
			IsSideBarOpened = true;

			_extendedViewController.AddChildViewController(_sideBar);

			NSAction animation = () =>
			{
				_extendedViewController.ViewToMove.SetFrameX(_extendedViewController.SideBarWidth);
			};

			NSAction onComplete = () =>
			{
				_sideBar.DidMoveToParentViewController(_extendedViewController);
			};

			_extendedViewController.View.InsertSubview(_sideBar.View, 0);
			UIView.Animate(SidebarAnimateDuration, animation, onComplete);
		}

		private void HideSideBar(bool animated)
		{
//			Assert.True(IsSideBarOpened);
			IsSideBarOpened = false;

			_sideBar.WillMoveToParentViewController(null);

			NSAction animation = () =>
			{
				_extendedViewController.ViewToMove.SetFrameX(0);
			};

			NSAction onComplete = () =>
			{
				_sideBar.View.RemoveFromSuperview();
				_sideBar.RemoveFromParentViewController();
			};

			double duration = animated ? SidebarAnimateDuration : 0;
			UIView.Animate(duration, animation, onComplete);
		}
	}
}

