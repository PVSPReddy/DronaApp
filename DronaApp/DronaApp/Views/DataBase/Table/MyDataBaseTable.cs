using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace DronaApp
{
	public class MyDataBaseTable
	{
		public static string tableName;
		public MyDataBaseTable(){}
	}

	[Table("MySelfDetailsToAccess")]
	public class MySelf
	{
		[PrimaryKey, AutoIncrement]
		public int _userId { set; get; }

		public string _userFName { set; get; }

		public string _userLName { set; get; }

		public string _userPassword { set; get; }

		public double _userMobile { set; get; }

		public string _userEmail { set; get; }

		public string _userAddress { set; get; }
	}



	[Table("MyFriendsDetails")]
	public class MyFriends
	{
		[AutoIncrement, PrimaryKey]
		public int userId_ { set; get; }

		public string userFName_ { set; get; }

		public string userLName_ { set; get; }

		public double userMobile_ { set; get; }

		public string userEmail_ { set; get; }

		public string userAddress_ { set; get; }
	}
}


