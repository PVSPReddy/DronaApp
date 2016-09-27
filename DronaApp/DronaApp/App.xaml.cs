using Xamarin.Forms;

namespace DronaApp
{
	public partial class App : Application
	{
		public static int ScreenWidth;
		public static int ScreenHeight;
		public App()
		{
			InitializeComponent();

			MainPage = new DronaAppPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

