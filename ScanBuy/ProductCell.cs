using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace ScanBuy
{
	partial class ProductCell : UITableViewCell
	{
		public UILabel LblDate {
			get { return lblDate; }
			set { lblDate = value; }
		}

		public UILabel LblPrice {
			get { return lblPrice; }
			set { lblPrice = value; }
		}

		public UILabel LblProduct {
			get { return lblProduct; }
			set { lblProduct = value; }
		}

		public ProductCell (IntPtr handle) : base (handle)
		{

		}
	}
}
