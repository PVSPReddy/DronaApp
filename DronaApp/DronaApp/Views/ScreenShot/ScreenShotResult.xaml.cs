using System;
using System.IO;
using Xamarin.Forms;

namespace DronaApp
{
    public partial class ScreenShotResult : BaseContentPage
	{
        public ScreenShotResult(byte[] imagedata)
		{

			Image img = new Image()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Aspect = Aspect.Fill,
				BackgroundColor = Color.Black
			};

			img.Source = ImageSource.FromStream(() => new MemoryStream(imagedata));

			StackLayout imagestack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { img },
				BackgroundColor = Color.Green
			};

			Button button = new Button()
			{
				Text = "Back",
				BackgroundColor = Color.Accent,
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand

			};

			button.Clicked += (sender, e) =>
            {
                App.Current.MainPage = new ScreenPage();
            };

			StackLayout fotterstack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.EndAndExpand,
				BackgroundColor = Color.Blue,
				//HeightRequest = 60,
				HeightRequest = screenHeight / 10.51,
				Children = { button }
			};
			StackLayout stack = new StackLayout()
			{
				Children = { imagestack, fotterstack },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White,
				Spacing = 0
			};

            PageControlsStackLayout.Children.Add(stack);
			//Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

		}
	}
}

