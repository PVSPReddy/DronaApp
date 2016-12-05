using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace DronaApp
{
	public partial class ListViewTouchCoordinates : ContentPage
	{
		public static List<Names> _listName;
		public List<Names> listName;
		public static ListViewTouchCoordinates dbn;
		public static int count, counts;
		public ListViewTouchCoordinates()
		{
			InitializeComponent();
			dbn = this;
			TapGestureRecognizer tapped = new TapGestureRecognizer();
			tapped.NumberOfTapsRequired = 1;
			tapped.Tapped += (object sender, EventArgs e) =>
			{
				var btn = sender as BoxView;
				var cord = btn.X;
				var cords = btn.Y;
				var final = btn.AnchorX;
				var finals = btn.AnchorY;
				var trans = btn.TranslationX;
				var transs = btn.TranslationY;

				//	var data = sender as TapGestureRecognizer;
				//	var view = sender as StackLayout;
				//	var loc = view.X;
				//	var seconloc = view.Y;
				//	var sizex = view.Width;
				//	var sizey = view.Height;
				//	var file = data;
			};
			//numberOne.GestureRecognizers.Add(tapped);
			//numberTwo.GestureRecognizers.Add(tapped);
			//numberThree.GestureRecognizers.Add(tapped);
			//numberFour.GestureRecognizers.Add(tapped);
			//Testing.GestureRecognizers.Add(tapped);

			listName = new List<Names>()
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
			_listName = listName;
			count = listName.Count;
			displayView.ItemsSource = _listName;
			displayView.ItemSelected += Selected_Item;
			displayView.ItemAppearing += (object sender, ItemVisibilityEventArgs e) =>
			{
				var cords = ((ListView)sender).Bounds;
			};
			displayView.ItemTapped += (object sender, ItemTappedEventArgs e) =>
			{
				//var cords = ((ListView)sender).ItemsSource as ViewCell;
				//var cords1 = cords.View.X;
				//var cords2 = cords.View.Y;
			};

		}
		public void ClickClicked(object sender, EventArgs args)
		{
			var btn = sender as Button;
			var cord = btn.X;
			var cords = btn.Y;
			var final = btn.AnchorX;
			var finals = btn.AnchorY;
			var trans = btn.TranslationX;
			var transs = btn.TranslationY;
			//holder.IsEnabled = true;
			//Names data2 = null;
			//Display_HideLayout(data2);
		}

		public async void StartFloating(float x, float y, long positions, bool _value)
		{
			if (_value == true)
			{
				floatDisplay.Opacity = 0;
				AbsoluteLayout.SetLayoutFlags(floatDisplay, AbsoluteLayoutFlags.None);
				float x1 = x;
				float y1 = y;
				var _positions = Convert.ToInt32(positions);
				await floatDisplay.LayoutTo(new Rectangle(300, y1, 50, 50));
				var file = listName[_positions];

				floatDisplay.Opacity = 1;
			}
			else
			{
				floatDisplay.Opacity = 0;
			}
		}

		public void CloseLayout(object sender, EventArgs args)
		{
			data2.letUsShow = false;
			displayView.IsEnabled = true;
			//holder.IsEnabled = true;
			//Names data2 = null;
			//Display_HideLayout(data2);
		}
		public void Selected_Item(object sender, SelectedItemChangedEventArgs e)
		{
			var height = displayView.Height;
			var data = ((ListView)sender).SelectedItem as Names;

			var datas = sender as VisualElement;

			var datas2 = datas.X;
			var datas3 = datas.Y;

			var data2 = ((ListView)sender).SelectedItem as ViewCell;
			//var data1 = ((ListView)sender).SelectedItem as Element;
			var itemnumber = listName.IndexOf(data);
			counts = itemnumber;
			if (data == null)
			{
				return;
			}
			MessagingCenter.Send<ListViewTouchCoordinates>(this, "hi");

			//var parntx = data1.View.X;
			//var parnty = data1.View.Y;
			//Display_HideLayout(data);
			//displayView.IsEnabled = true;

			//if (data.letShow == true)
			//{
			//	data.letUsShow = false;
			//	//holder.IsEnabled = true;
			//}
			//else
			//{
			//	data.letUsShow = true;
			//	//holder.IsEnabled = false;
			//}

			((ListView)sender).SelectedItem = null;

		}


		Names data2 = new Names();
		bool isGoingAction = false;


		void Display_HideLayout(Names data)
		{

			if (data2 != null)
			{
				data2.letUsShow = false;
				var name = data2.myName;
				var names = data.myName;
			}
			data.letUsShow = true;
			data2 = data;
		}
	}

	public class Names : INotifyPropertyChanged
	{
		public string myName { get; set; }

		public static Rectangle[] cordns { get; set; }

		public bool letShow = false;

		public bool letUsShow
		{
			get
			{
				return letShow;
			}
			set
			{
				if (letShow != value)
				{
					letShow = value;
					PropertyChanged(this, new PropertyChangedEventArgs("letUsShow"));
				}

			}
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };
	}
}

