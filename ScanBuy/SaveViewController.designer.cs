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
	[Register ("SaveViewController")]
	partial class SaveViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnCancel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSave { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtPrice { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtProductName { get; set; }

		[Action ("CancelSave:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CancelSave (UIButton sender);

		[Action ("SaveProduct:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SaveProduct (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnCancel != null) {
				btnCancel.Dispose ();
				btnCancel = null;
			}
			if (btnSave != null) {
				btnSave.Dispose ();
				btnSave = null;
			}
			if (txtPrice != null) {
				txtPrice.Dispose ();
				txtPrice = null;
			}
			if (txtProductName != null) {
				txtProductName.Dispose ();
				txtProductName = null;
			}
		}
	}
}
