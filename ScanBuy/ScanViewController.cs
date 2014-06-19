using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

using ScanditSDK;

namespace ScanBuy
{
	partial class ScanViewController : UIViewController
	{
		UIBarButtonItem btnScanProduct;
		UIBarButtonItem btnSearchProduct;
		UIBarButtonItem btnMore;

		public ScanViewController () : base ()
		{
		}

		public ScanViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (!UIImagePickerController.IsSourceTypeAvailable (UIImagePickerControllerSourceType.Camera)) {
				new UIAlertView ("Hey!!", "It seems that you don't have any camera available...\nThat's so sad... :(", null, "Let me cry alone...", null).Show ();
				return;
			}

			btnScanProduct = new UIBarButtonItem (UIImage.FromFile ("scan.png"), UIBarButtonItemStyle.Plain, OpenScandit);
			btnScanProduct.Tag = (int)KindOfScan.Save;

			btnSearchProduct = new UIBarButtonItem (UIImage.FromFile ("search.png"), UIBarButtonItemStyle.Plain, OpenScandit);
			btnSearchProduct.Tag = (int)KindOfScan.Search;

			btnMore = new UIBarButtonItem (UIImage.FromFile ("more.png"), UIBarButtonItemStyle.Plain, OpenMoreMenu);

			NavigationItem.RightBarButtonItems = new [] { btnMore, btnSearchProduct, btnScanProduct };
		}

		void OpenScandit (object sender, EventArgs e)
		{
			var button = sender as UIBarButtonItem;
			KindOfScan kind = (KindOfScan)button.Tag;

			var scanditPicker = new SIBarcodePicker (KeysAndTokens.ScanditApi.ScanditKey);
			scanditPicker.OverlayController.Delegate = new ScanditDelegate (this, kind);
			NavigationController.PushViewController (scanditPicker, true);
			scanditPicker.StartScanning ();
		}

		void OpenMoreMenu (object sender, EventArgs e)
		{

		}
	}

	class ScanditDelegate : SIOverlayControllerDelegate
	{
		ScanViewController ownerVC;
		KindOfScan kindOfScan;

		public ScanditDelegate (ScanViewController owner, KindOfScan kind)
		{
			ownerVC = owner;
			kindOfScan = kind;
		}

		public override void DidScanBarcode (SIOverlayController overlayController, NSDictionary barcode)
		{
			Console.WriteLine (barcode.ToString ());
		}

		public override void DidCancel (SIOverlayController overlayController, NSDictionary status)
		{
			Console.WriteLine (status.ToString ());
		}

		public override void DidManualSearch (SIOverlayController overlayController, string text)
		{
			Console.WriteLine (text);
		}
	}

	class TableViewSource : UITableViewSource
	{
		UIViewController ownerVC;

		public TableViewSource (UIViewController owner)
		{
			ownerVC = owner;
		}

		#region UITableViewDatasource



		#endregion

		#region UITableViewDelegate

		#endregion
	}
}
