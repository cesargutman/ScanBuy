using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ScanBuy
{
	public class MenuTableViewController : UITableViewController
	{
		public MenuTableViewController ()
		{
			TableView.Source = new MenuTableViewSource ();
		}
	}

	class MenuTableViewSource : UITableViewSource
	{

		#region UITableViewDataSource

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return 1;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			return null;
		}

		#endregion

		#region UITableViewDelegate

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			// TODO: Implements the action to run when the user taps the cell
		}

		#endregion

	}
}

