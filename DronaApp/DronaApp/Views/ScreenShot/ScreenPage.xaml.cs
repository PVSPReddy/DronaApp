using System;

using Xamarin.Forms;

namespace DronaApp
{
    public partial class ScreenPage : BaseContentPage
	{
		public ScreenPage()
		{
			StackLayout headerstack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Blue,
				//HeightRequest = 70
				HeightRequest = screenHeight / 10.51
			};

			Entry firstname = new Entry()
			{
				Placeholder = "First Name",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				//VerticalOptions = LayoutOptions.StartAndExpand,
				BackgroundColor = Color.White
			};

			Entry secondname = new Entry()
			{
				Placeholder = "Second Name",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				//VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.White
			};

			Entry Data = new Entry()
			{
				Placeholder = "Data",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				//VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.White
			};

			Entry Data1 = new Entry()
			{
				Placeholder = "Data1",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				//VerticalOptions = LayoutOptions.EndAndExpand,
				BackgroundColor = Color.White
			};

			Entry Data2 = new Entry()
			{
				Placeholder = "Data2",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				//VerticalOptions = LayoutOptions.End,
				BackgroundColor = Color.White
			};

			StackLayout bodystack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { firstname, secondname, Data, Data1, Data2 },
				Spacing = 50,
				BackgroundColor = Color.Aqua
			};


			Button button = new Button()
			{
				Text = "ScreenShot",
				BackgroundColor = Color.Accent,
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand

			};

			StackLayout fotterstack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.EndAndExpand,
				BackgroundColor = Color.Blue,
				//HeightRequest = 70,
				HeightRequest = screenHeight / 10.51,
				Children = { button }
			};

			button.Clicked += (sender, e) =>
						{

							DependencyService.Get<IScreenshot>().Capture(headerstack.Height, fotterstack.Height);
						};





			StackLayout stack = new StackLayout()
			{
				Children = { headerstack, bodystack, fotterstack },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Aqua
			};

			PageControlsStackLayout.Children.Add(stack);
			//Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

		}
	}
}

