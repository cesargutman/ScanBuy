using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using SQLite;

namespace ScanBuy
{
	partial class SaveViewController : UIViewController
	{
		public string Code { get; set; }
		public bool IsShown { get; set; }

		public SaveViewController () : base ()
		{
		}

		public SaveViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			IsShown = true;
		}

		partial void CancelSave (UIButton sender)
		{
			IsShown = false;
			DismissViewController (true, null);
		}

		partial void SaveProduct (UIButton sender)
		{
			string productName = txtProductName.Text;
			string productPrice = txtPrice.Text;

			if (string.IsNullOrWhiteSpace (productName) || string.IsNullOrWhiteSpace (productPrice)) {
				new UIAlertView ("Hey!!", "Fill all the fields please...", null, "Ok...", null).Show ();
				return;
			}

			double price;

			if (!double.TryParse (productPrice, out price)) {
				new UIAlertView ("Hey!!", "Insert a valid price please...", null, "Ok...", null).Show ();
				return;
			}

			var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

			using (var db = new SQLiteConnection (appDelegate.DatabasePath)) {
				var product = new Product {
					Name = productName,
					Price = price,
					Barcode = Code,
					Date = DateTime.Now
				};

				db.Insert (product);
				IsShown = false;
				DismissViewController (true, null);
			}
		}
	}
}
