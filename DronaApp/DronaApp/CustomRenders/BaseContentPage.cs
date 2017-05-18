using System;

using Xamarin.Forms;

namespace DronaApp
{
	public abstract class BaseContentPage : ContentPage
	{
		public AbsoluteLayout contentLayout;
		public ActivityIndicator aiLoader;
		public StackLayout PageLoading, PageControlsStackLayout;
		public readonly string appTitle = "CorpAlert";
		public static int screenHeight, screenWidth;

		public BaseContentPage()
		{
			this.BackgroundColor = Color.Transparent;

			aiLoader = new ActivityIndicator
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Color = Color.White,
				//BackgroundColor = Color.FromRgba (0, 0, 0, 0.3),
				IsEnabled = true,
				IsVisible = true,
				IsRunning = true,
			};

			contentLayout = new AbsoluteLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			PageLoading = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromRgba(0, 0, 0, 0.4),
				//BackgroundColor = Color.Transparent,
				IsVisible = false,
				Children = { aiLoader }
			};

			PageControlsStackLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				//VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0),
				Spacing = 0
			};
			AbsoluteLayout.SetLayoutFlags(PageControlsStackLayout, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(PageControlsStackLayout, new Rectangle(0, 0, 1, 1));
			contentLayout.Children.Add(PageControlsStackLayout);

			AbsoluteLayout.SetLayoutFlags(PageLoading, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(PageLoading, new Rectangle(0.5, 0.5, 1, 1));
			contentLayout.Children.Add(PageLoading);
			Content = contentLayout;

		}
	}
}

