using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DronaApp
{
	public partial class DisplayDownloadedFile : ContentPage
	{
		#region
		/*if this printer code or webview is not working well or if it gives any exception or null then
		then change page navigation type to pushasync from push modalasync and viceversa */
		#endregion
		CustomProperties cp = new CustomProperties();
		StackLayout stackL, holder1, holding;
		string fullPath;
		public DisplayDownloadedFile(string viewData)
		{
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;
			WebView browser;
			InitializeComponent();
			var uri = new Uri(String.Format("file://{0}", viewData));
			fullPath = uri.ToString();
			browser = new WebView();
			browser.Source = fullPath;
			browser.HeightRequest = ((screenHeight * 9) / 10) - ((screenHeight * 1) / 500);
			//browser.WidthRequest = ((screenWidth * 9) / 10) - ((screenHeight * 1) / 500);
			holder1 = new StackLayout()
			{
				HeightRequest = (screenHeight * 9) / 10,
				//WidthRequest = (screenWidth * 9) / 10,
				BackgroundColor = Color.Green,
				//Padding = 30,
				Children = { browser },
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill
			};

			Label Download = new Label()
			//Image Download = new Image()
			{
				Text = "Email",
				TextColor = Color.Maroon,
				//Source = "Download.png",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.EndAndExpand
			};
			TapGestureRecognizer download_Data = new TapGestureRecognizer();
			download_Data.NumberOfTapsRequired = 1;
			download_Data.Tapped += (object sender, EventArgs e) =>
			{
				DependencyService.Get<IEmail>().ShareFile(fullPath, "mimeType");
			};
			Download.GestureRecognizers.Add(download_Data);

			Label Print = new Label()
			//Image Print = new Image()
			{
				Text = "Print",
				TextColor = Color.Maroon,
				//Source = "Print.png",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.EndAndExpand
			};

			TapGestureRecognizer print_Data = new TapGestureRecognizer();
			print_Data.NumberOfTapsRequired = 1;
			print_Data.Tapped += (object sender, EventArgs e) =>
			{
				DependencyService.Get<IPDF_View_Print>().PrintPdf(fullPath);
			};
			Print.GestureRecognizers.Add(print_Data);
			Button back = new Button()
			{
				Text = "GoBack",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Command = new Command(() =>
				{
					Navigation.PopModalAsync(true);
				})
			};
			stackL = new StackLayout()
			{
				BackgroundColor = Color.Blue,
				Orientation = StackOrientation.Horizontal,
				Children = { back ,Download, Print },
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.EndAndExpand
			};
			holding = new StackLayout()
			{
				HeightRequest = screenHeight,
				WidthRequest = screenWidth,
				Children = { holder1, stackL},
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			Content = holding;
		}

		//#region presently no use of this as the above code works well
		//public DisplayDownloadedFile(Task<string> viewData)
		//{
		//	CustomProperties cp = new CustomProperties();
		//	var screenHeight = cp.AppScreenHeight;
		//	var screenWidth = cp.AppScreenWidth;
		//	WebView browser;
		//	InitializeComponent();
		//	var uri = new Uri(String.Format("file://{0}", viewData));
		//	var fullPath = uri.ToString();
		//	browser = new WebView();
		//	browser.Source = fullPath;
		//}
		//#endregion
	}
}

