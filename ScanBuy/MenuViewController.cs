using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace ScanBuy 
{

	partial class MenuViewController : UITableViewController 
	{
		public MenuViewController () : base ()
		{
		}

		public MenuViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Assign the UITableView's DataSource and Delegate
			TableView.Source = new TableViewSource (this);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			// Set the background image
			View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile ("menu-background.png"));
		}
	}

	class TableViewSource : UITableViewSource 
	{

		#region Static Variablew

		static readonly string cellID = "CellID";

		#endregion

		#region Instance Variables

		string [] rowNames = new [] { "Escanear producto", "Ver historial" };
		ScanViewController scanVC;
		RecordViewController recordVC;
		UITableViewController ownerVC;

		#endregion

		#region Constructors

		public TableViewSource (UITableViewController owner)
		{
			// Save the view that contains the UITableView
			ownerVC = owner;
		}

		#endregion

		#region UITableViewDataSource

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return rowNames.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellID);

			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellID);

			// Configure the design of the cell
			cell.TextLabel.Text = rowNames[indexPath.Row];
			cell.BackgroundColor = UIColor.Clear;
			cell.TextLabel.TextColor = UIColor.White;

			return cell;
		}

		public override float GetHeightForHeader (UITableView tableView, int section)
		{
			// Add a header to prevent that the first cell being of the top of the screen
			return 22;
		}

		public override UIView GetViewForHeader (UITableView tableView, int section)
		{
			// Make the header transparent
			var view = new UIView ();
			view.BackgroundColor = UIColor.Clear;

			return view;
		}

		#endregion

		#region UITableViewDelegate

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.CellAt (indexPath);
			AppDelegate del = UIApplication.SharedApplication.Delegate as AppDelegate;;

			// Sends the tag of the view that will be switched for
			switch (cell.TextLabel.Text) {

			case "Escanear producto":
				del.ChangeViewController (ViewTag.ScanView);
				break;

			case "Ver historial":
				del.ChangeViewController (ViewTag.RecordView);
				break;

			default:
				break;
			}
		}

		#endregion

	}
}
