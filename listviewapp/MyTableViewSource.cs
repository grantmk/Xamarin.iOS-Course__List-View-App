using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace listviewapp
{
	public class MyTableViewSource: UITableViewSource
	{
		List<string> tableItems;
		Dictionary<string, List<string>> indexedTableItems;
		string[] keys;

		public MyTableViewSource (List<string> _tableItems)
		{
			tableItems = _tableItems;
			indexedTableItems = new Dictionary<string, List<string>> ();
			foreach (var t in tableItems) {
				if (indexedTableItems.ContainsKey (t [0].ToString ())) {
					indexedTableItems [t [0].ToString ()].Add (t);
				} else {
					indexedTableItems.Add (t [0].ToString (), new List<string> () { t });
				}
			}
			keys = indexedTableItems.Keys.ToArray ();
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return keys.Length;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return indexedTableItems [keys [section]].Count;
		}

		public override string[] SectionIndexTitles (UITableView tableView)
		{
			return keys;
		}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return keys [section];
		}

		public override string TitleForFooter (UITableView tableView, nint section)
		{
			return "Section end";
		}

		public override UIView GetViewForHeader (UITableView tableView, nint section)
		{
			var view = new UIView (new CoreGraphics.CGRect (0, 0, tableView.Bounds.Width, 44f));
			var label = new UILabel () {
				Font = UIFont.FromName ("Helvetica", 22f),
				Frame = new CoreGraphics.CGRect (10, 5, tableView.Bounds.Width, 25),
				TextColor = UIColor.Red,
				Text = keys [section]
			};
			view.Add (label);
			return view;
		}

		public override nfloat GetHeightForHeader (UITableView tableView, nint section)
		{
			return 44f;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("tableViewCell") as MyCustomCell;
			if (cell == null)
				cell = new MyCustomCell (new Foundation.NSString ("tableViewCell"));

			cell.UpdateCell (indexedTableItems[keys[indexPath.Section]][indexPath.Row], "placeholder");
			return cell;
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
		}

		public override nfloat GetHeightForRow (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return 250f;
		}
	}
}

