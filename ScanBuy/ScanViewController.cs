using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using ScanditSDK;
using SQLite;

namespace ScanBuy
{
	partial class ScanViewController : UIViewController
	{
		UIBarButtonItem btnScanProduct;
		UIBarButtonItem btnSearchProduct;
//		UIBarButtonItem btnMore;
		ProductTableViewSource source;

		public ScanViewController () : base ()
		{
		}

		public ScanViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnScanProduct = new UIBarButtonItem (UIImage.FromFile ("scan.png"), UIBarButtonItemStyle.Plain, OpenScandit);
			btnScanProduct.Tag = (int)KindOfScan.Save;

			btnSearchProduct = new UIBarButtonItem (UIImage.FromFile ("search.png"), UIBarButtonItemStyle.Plain, OpenScandit);
			btnSearchProduct.Tag = (int)KindOfScan.Search;

//			btnMore = new UIBarButtonItem (UIImage.FromFile ("more.png"), UIBarButtonItemStyle.Plain, OpenMoreMenu);

			NavigationItem.RightBarButtonItems = new [] { btnSearchProduct, btnScanProduct };
			source = new ProductTableViewSource (this);
			tblProducts.Source = source;
		}

		void OpenScandit (object sender, EventArgs e)
		{
			if (!UIImagePickerController.IsSourceTypeAvailable (UIImagePickerControllerSourceType.Camera)) {
				new UIAlertView ("Hey!!", "It seems that you don't have any camera available...\nThat's so sad... :(", null, "Let me cry alone...", null).Show ();
				return;
			}

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
		SaveViewController saveVC;
		ScanViewController ownerVC;
		KindOfScan kindOfScan;

		public ScanditDelegate (ScanViewController owner, KindOfScan kind)
		{
			ownerVC = owner;
			kindOfScan = kind;
		}

		public override void DidScanBarcode (SIOverlayController overlayController, NSDictionary barcode)
		{
			string code = barcode ["barcode"].ToString ();

			if (kindOfScan == KindOfScan.Save) {
				if (saveVC == null) {
					saveVC = ownerVC.Storyboard.InstantiateViewController ("SaveViewControllerID") as SaveViewController;
					saveVC.IsShown = false;
				}

				if (saveVC.IsShown)
					return;

				saveVC.Code = code;

				ownerVC.PresentViewController (saveVC, true, null);
			} else {

				var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

				using (var db = new SQLiteConnection (appDelegate.DatabasePath)) {
					var product = db.Table<Product> ().Where (p => p.Barcode == code).FirstOrDefault ();

					if (product != null) {
						new UIAlertView (product.Name, "The price of the product registered in the database is: " + product.Price.ToString (), null, "Ok", null).Show ();
					} else {
						new UIAlertView ("Mmm...", "It seems that the product hasn't been registered before...", null, "Ok", null).Show ();
					}
				}
			}

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

	class ProductTableViewSource : UITableViewSource
	{
		static string cellID = "ProductCellID";
		UIViewController ownerVC;
		List<Product> lstProducts;

		public ProductTableViewSource (UIViewController owner)
		{
			ownerVC = owner;
			var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

			using (var db = new SQLiteConnection (appDelegate.DatabasePath)) {
				lstProducts = db.Table<Product> ().ToList ();
			}
		}

		#region UITableViewDatasource

		public override int NumberOfSections (UITableView tableView)
		{
			return 2;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return 3;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell ("CellID");

			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, "CellID");
			}

			cell.TextLabel.Text = "Hola";
//			ProductCell cell = tableView.DequeueReusableCell (cellID) as ProductCell;
//
//			cell.LblProduct.Text = lstProducts [indexPath.Row].Name;
//			cell.LblDate.Text = lstProducts [indexPath.Row].Date.ToShortDateString ();
//			cell.LblPrice.Text = "$" + lstProducts [indexPath.Row].Price.ToString ();

			return cell;
		}

		#endregion

		#region UITableViewDelegate

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{

		}

		#endregion
	}
}
