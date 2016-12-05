using System;
using System.Collections.Generic;
using System.Linq;
using DronaApp;
using DronaApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

//[assembly : ExportRenderer(typeof(MyViewCellOne), typeof(NativeIOSCell))]
namespace DronaApp.iOS
{
	public class MyListViewSourceOne : UITableViewSource
	{

		IList<Names> tableItems;
		MyListViewOne myView;
		readonly NSString cellIdentifier = new NSString("TableCell");

		public IEnumerable<Names> Items
		{
			//get{ }
			set
			{
				tableItems = value.ToList();
			}
		}

		public MyListViewSourceOne(MyListViewOne _myView)
		{
			myView = _myView;



			List<Names> listName = new List<Names>()
			{
				new Names{myName="Sivaprasad"},
				new Names{myName="Venky Bala"},
				new Names{myName="Gopi Gopi"},
				new Names{myName="Manohar"},
				new Names{myName="Venkateswarulu"},
				new Names{myName="Sandeep"},
				new Names{myName="Alok Das"},
				new Names{myName="Sirisha"},
				new Names{myName="Raju Raju"},
				new Names{myName="Sivaprasad"},
				new Names{myName="Venky Bala"},
				new Names{myName="Gopi Gopi"},
				new Names{myName="Manohar"},
				new Names{myName="Venkateswarulu"},
				new Names{myName="Sandeep"},
				new Names{myName="Alok Das"},
				new Names{myName="Sirisha"},
				new Names{myName="Raju Raju"},
				new Names{myName="Sivaprasad"},
				new Names{myName="Venky Bala"},
				new Names{myName="Gopi Gopi"},
				new Names{myName="Manohar"},
				new Names{myName="Venkateswarulu"},
				new Names{myName="Sandeep"},
				new Names{myName="Alok Das"},
				new Names{myName="Sirisha"},
				new Names{myName="Raju Raju"},
				new Names{myName="Sivaprasad"},
				new Names{myName="Venky Bala"},
				new Names{myName="Gopi Gopi"},
				new Names{myName="Manohar"},
				new Names{myName="Venkateswarulu"},
				new Names{myName="Sandeep"},
				new Names{myName="Alok Das"},
				new Names{myName="Sirisha"},
				new Names{myName="Raju Raju"},
				new Names{myName="All Happies"}
			};

			tableItems = listName;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			

			NativeIOSCell cell = tableView.DequeueReusableCell(cellIdentifier) as NativeIOSCell;
			if (cell == null)
			{
				cell = new NativeIOSCell(cellIdentifier);
			}
			if (String.IsNullOrWhiteSpace(tableItems[indexPath.Row].myName))
			{
				cell.UpdateCell(tableItems[indexPath.Row].myName, tableItems[indexPath.Row].myName, null);
			}
			else 
			{
				cell.UpdateCell(tableItems[indexPath.Row].myName, tableItems[indexPath.Row].myName, null);// UIImage.FromFile("Images/" + tableItems[indexPath.Row].ImageFilename + ".jpg"));
			}

			return cell;
		}


		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			base.RowSelected(tableView, indexPath);
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return 0;
		}

	}

	public class NativeIOSCell : UITableViewCell
	{
		UILabel headingLabel, subheadingLabel;
		UIImageView imageView;

		public NativeIOSCell(NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			//var sectionStyle = UITableViewCellSectionStyle.Gray;
			 
			ContentView.BackgroundColor = UIColor.Cyan;

			headingLabel = new UILabel()
			{
				Font = UIFont.FromName("Cochin-BoldItalic", 22f),
				TextColor = UIColor.FromRGB(127, 51, 0),
				BackgroundColor = UIColor.Clear
			};

			subheadingLabel = new UILabel()
			{
				Font = UIFont.FromName("AmericanTypewriter", 12f),
				TextColor = UIColor.FromRGB(38, 127, 0),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};

			ContentView.Add(headingLabel);
			ContentView.Add(subheadingLabel);
		}

		public void UpdateCell(string caption, string subtitle, UIImage image)
		{
			headingLabel.Text = caption;
			subheadingLabel.Text = subtitle;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			headingLabel.Frame = new CoreGraphics.CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
			subheadingLabel.Frame = new CoreGraphics.CGRect(100, 18, 100, 20);
			//imageView.Frame = new CoreGraphics.CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);
		}
	}
}

