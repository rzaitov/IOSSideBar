using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SideBar
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow window;
		private SideBarViewController _sideBar;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			_sideBar = new SideBarViewController ();

			window.RootViewController = _sideBar;
			window.MakeKeyAndVisible ();

			return true;
		}
	}
}

