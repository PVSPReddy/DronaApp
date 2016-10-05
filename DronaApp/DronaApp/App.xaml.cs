using Xamarin.Forms;

namespace DronaApp
{
	public partial class App : Application
	{
		public static int ScreenWidth;
		public static int ScreenHeight;
		#region
		/*// it is better to use MainPage = new NavigationPage(new DownloadInputDetails());
		// as so we can use pushasync in child pages as popasync is not always accepted by ios
		//so use pushasync(new navigationpage(new page****())) or pushmodalasync(new Navigatiopage(new page****()))
		//in your child classes if you want to use popasync in your ios app to return to back same page
		//to hide navigation bar in ios use protected override void OnAppearing()
		//{
		//	base.OnAppearing();
		//	NavigationPage.SetHasNavigationBar(this, false);
		//}
		//or
		//NavigationPage.SetHasNavigationBar(this, false);
		//to stop or hide navigationbar in ios stopping navigation bar when using masterdetail page in ios is mandatory
		//as we can use our custom navigation bar if wanted*/
		#endregion
		public App()
		{
			InitializeComponent();

			//MainPage = new MasterPage_LV_Detail();
			//MainPage = new NavigationPage(new DownloadInputDetails());
			MainPage = new DBIntroduction();
			//MainPage = new DisplayDownloadedFile("/Users/rabbit/Library/Developer/CoreSimulator/Devices/181B3DA1-30B6-4A59-9D79-331C3C344171/data/Containers/Data/Application/C11988AA-AE98-4E09-9672-E23BD8856B50/Documents/.config/AppNamesSivaPrasad/Download4.pdf");



			#region when using database use this to we can get to particular page based on the presence of database
			/*var info = new DataBaseMethods().userRetrivedInfo();
			if (info == null)
			{
				MainPage = new EmployeeRegistrationForm();
			}
			else
			{
				MainPage = new EmployeeLoginForm();
			}*/
			#endregion
		}

		protected override void OnStart()
		{
			#region this should be used along with database if any error occurs showing null database mostly in android and sometimes in ios also
			/*SQLiteConnection mySQLiteConnection = DependencyService.Get<IDataBase>().GetConnection("MY_SELF");
			if (mySQLiteConnection.Table<MySelf>() == null)
			{
				MySelf mytbl = new MySelf();
				mytbl._userId = 0;
			}

			SQLiteConnection myPeopleSQLiteConnection = DependencyService.Get<IDataBase>().GetConnection("MY_PEOPLE");
			if (myPeopleSQLiteConnection.Table<MyPeopleTable>() == null)
			{
				MyPeopleTable myplptbl = new MyPeopleTable();
				myplptbl._userId_ = 0;
			}*/
			#endregion


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

