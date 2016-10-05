using System;
using System.IO;
using DronaApp.iOS;
using SQLite.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(IDataBaseService))]
namespace DronaApp.iOS
{
	#region
	/*//in Android dependency for a database try to not include "string libraryPath = Path.Combine(folderPath, "..", "Library");"
	//this above line will create a exception and alse terminates the program so not include this in android fo ios it can be used*/
	#endregion
	public class IDataBaseService : IDataBase
	{
		public IDataBaseService(){}

		public SQLiteConnection GetConnection(string dBName)
		{
			var myTable = dBName + ".db";
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine(folderPath, "..", "Library");
			var path = Path.Combine(libraryPath, myTable);
			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var conn = new SQLiteConnection(plat, path);
			return conn;
		}
	}
}

