using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace listviewapp
{
	public class MyCustomCell : UITableViewCell
	{
		UILabel headingLabel, subheadingLabel;

		public MyCustomCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Blue;
			ContentView.BackgroundColor = UIColor.Cyan;

			headingLabel = new UILabel () {
				Font = UIFont.FromName ("Helvetica", 17f),
				TextColor = UIColor.Red,
				BackgroundColor = UIColor.Clear
			};
			subheadingLabel = new UILabel () {
				Font = UIFont.FromName ("AmericanTypewriter", 12f),
				TextAlignment = UITextAlignment.Center,
				TextColor = UIColor.Blue,
				BackgroundColor = UIColor.Clear
			};
			ContentView.AddSubviews (new UIView[] { headingLabel, subheadingLabel });
		}

		public void UpdateCell (string _heading, string _subheading) {
			headingLabel.Text = _heading;
			subheadingLabel.Text = _subheading;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			headingLabel.Frame = new CGRect (5, 4, ContentView.Bounds.Width, 25);
			subheadingLabel.Frame = new CGRect (100, 22, 100, 20);
		}
	}
}

