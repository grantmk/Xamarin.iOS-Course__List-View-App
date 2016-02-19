using System;

using UIKit;
using System.Collections.Generic;

namespace listviewapp
{
	public partial class ViewController : UIViewController
	{
		List<string> tableItems;

		public ViewController (IntPtr handle) : base (handle)
		{
			tableItems = new List<string> ();
			tableItems.Add ("Apple");
			tableItems.Add ("Aardvark");
			tableItems.Add ("Bee");
			tableItems.Add ("Butterfly");
			tableItems.Add ("Zebra");
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			tableView.Source = new MyTableViewSource(tableItems);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

