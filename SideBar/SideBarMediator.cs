using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

using Touch.Common;

namespace SideBar
{
	public class SideBarMediator
	{
		private const double SidebarAnimateDuration = 0.4;

		private readonly UIViewController _extendedViewController;
		private readonly UIViewController _sideBar;
		private readonly UIView _viewToMove;
		private readonly float _sideBarWidth;

		public bool IsSideBarOpened { get; set; }

		public SideBarMediator(UIViewController extendedViewController, UIView viewToMove, UIViewController sideBar, float sideBarWidth)
		{
			_extendedViewController = extendedViewController;
			_viewToMove = viewToMove;
			_sideBar = sideBar;
			_sideBarWidth = sideBarWidth;
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
			IsSideBarOpened = true;

			// Для правильного жизненого цикла. Будут вызваны метды VillAppear итд
			_extendedViewController.AddChildViewController(_sideBar);

			_viewToMove.RemoveFromSuperview ();
			_sideBar.View.AddSubview (_viewToMove);

			NSAction animation = () =>
			{
				_viewToMove.SetFrameX(_sideBarWidth);
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
				_viewToMove.SetFrameX(0);
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

