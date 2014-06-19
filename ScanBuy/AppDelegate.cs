using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using ECSlidingViewControllerSDK;

namespace ScanBuy
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{

		#region Instance Variables

		UINavigationController scanNC;
		UINavigationController recordNC;
		UIBarButtonItem btnMenu;

		#endregion

		// class-level declarations
		#region Properties

		public ScanBuyViewController ScanBuyVC { get; private set; }
		public override UIWindow Window {
			get;
			set;
		}

		#endregion

		#region Instance Variables

		#endregion

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Gets the first view controller that is created, the base of the app
			if (Window.RootViewController is ScanBuyViewController) {
				ScanBuyVC = Window.RootViewController as ScanBuyViewController;
			} else {
				throw new Exception ("The RootViewController is not a ScanViewController class");
			}

			// Creates the button that shows the menu
			btnMenu = new UIBarButtonItem (UIImage.FromFile ("menu.png"), UIBarButtonItemStyle.Plain, (sender, e) => {
				ScanBuyVC.AnchorTopViewToRight (true);
			});

			// Create and configure the first view, with his navigation, that will be shown
			var scanVC = ScanBuyVC.Storyboard.InstantiateViewController ("ScanViewControllerID") as UIViewController;
			scanVC.NavigationItem.LeftBarButtonItem = btnMenu;
			scanNC = new UINavigationController (scanVC);

			// Sets the first view that will be shown
			ScanBuyVC.TopViewController = scanNC;

			// Set the menu to the left of the main view controller
			var leftVC = ScanBuyVC.Storyboard.InstantiateViewController ("MenuViewControllerID") as MenuViewController;
			ScanBuyVC.UnderLeftViewController = leftVC;
			ScanBuyVC.AnchorLeftRevealAmount = 200f;
			ScanBuyVC.View.AddGestureRecognizer (ScanBuyVC.PanGesture);

			return true;
		}
		
		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
		}

		public void ChangeViewController (ViewTag tag)
		{
			// Does the switch between the diferents views
			switch (tag) {
			case ViewTag.ScanView:
				// If it's the first time being called, created it and assign it
				if (scanNC == null) {
					var scanVC = ScanBuyVC.Storyboard.InstantiateViewController ("ScanViewControllerID") as ScanViewController;
					scanVC.NavigationItem.LeftBarButtonItem = btnMenu;
					scanNC = new UINavigationController (scanVC);
				}

				ScanBuyVC.TopViewController = scanNC;
				break;

			case ViewTag.RecordView:
				if (recordNC == null) {
					var recordVC = ScanBuyVC.Storyboard.InstantiateViewController ("RecordViewControllerID") as RecordViewController;
					recordVC.NavigationItem.LeftBarButtonItem = btnMenu;
					recordNC = new UINavigationController (recordVC);
				}

				ScanBuyVC.TopViewController = recordNC;
				break;

			default:
				break;
			}

			ScanBuyVC.ResetTopView (true);
		}
	}

	public enum ViewTag {
		ScanView = 0,
		RecordView
	}
}

