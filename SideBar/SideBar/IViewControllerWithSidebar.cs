using System;

using MonoTouch.UIKit;

namespace SideBar
{
	public interface IViewControllerWithSidebar
	{
		UIView ViewToMove { get; }
		float SideBarWidth { get; }
	}
}

