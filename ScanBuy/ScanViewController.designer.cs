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
	[Register ("ScanViewController")]
	partial class ScanViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tblProducts { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (tblProducts != null) {
				tblProducts.Dispose ();
				tblProducts = null;
			}
		}
	}
}
