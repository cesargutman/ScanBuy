// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace ScanBuy
{
	[Register ("ProductCell")]
	partial class ProductCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel lblDate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel lblPrice { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel lblProduct { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblDate != null) {
				lblDate.Dispose ();
				lblDate = null;
			}
			if (lblPrice != null) {
				lblPrice.Dispose ();
				lblPrice = null;
			}
			if (lblProduct != null) {
				lblProduct.Dispose ();
				lblProduct = null;
			}
		}
	}
}
