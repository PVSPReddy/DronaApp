using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;

namespace DronaApp
{
	public class DataBaseMethods
	{
		static SQLiteConnection mySQLiteConnection, myPeopleSQLiteConnection;
		public DataBaseMethods()
		{
			mySQLiteConnection = DependencyService.Get<IDataBase>().GetConnection("DataBase_MyName");
			myPeopleSQLiteConnection = DependencyService.Get<IDataBase>().GetConnection("MY_PEOPLE");
			mySQLiteConnection.CreateTable<MySelf>();
			myPeopleSQLiteConnection.CreateTable<MyFriends>();
		}

		public void InsertUserInfo(MySelf infoObject)
		{
			try
			{
				//if (infoObject.ID == 0)
				//{
				//	infoObject.ID = 1;
				//}
				//else
				//{
				//	infoObject.ID += 1;
				//}
				//sqliteconnection.Query<PeopleTable>("delete from UserInformation");
				mySQLiteConnection.Insert(new MySelf
				{
					_userId = infoObject._userId,
					_userFName = infoObject._userFName,
					_userLName = infoObject._userLName,
					_userPassword = infoObject._userPassword,
					_userMobile = infoObject._userMobile,
					_userEmail = infoObject._userEmail,
					_userAddress = infoObject._userAddress
				});
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public void UpdateUserInfo(MySelf updateObject)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<MySelf> userRetrivedInfo()
		{
			//return sqliteconnection.Table<PeopleTable>().FirstOrDefault();
			/*List<PeopleTable> dataretrive1 = new List<PeopleTable>();
			int i = 0;
			var dataretrive = sqliteconnection.Query<PeopleTable>("select * from UserInformation");
			foreach (var item in dataretrive)
			{
				dataretrive1[i] = item;
				i++;
			}
			return dataretrive1;*/
			/*
			PeopleTable dataretrive1 = new PeopleTable();
			ObservableCollection<PeopleTable> dataretrive = new ObservableCollection<PeopleTable>();
			int i = 0;
			var tabledata = sqliteconnection.Table<PeopleTable>();
			foreach (var s in tabledata)
			{
				dataretrive1.ID = s.ID;
				dataretrive1.FirstName = s.FirstName;
				dataretrive1.LastName = s.LastName;
				dataretrive1.Address = s.Address;
				dataretrive1.EMail = s.EMail;
				dataretrive1.Mobile = s.Mobile;
				dataretrive[i] = dataretrive1;
				i++;
			}*/
			List<MySelf> dataretrive;
			return dataretrive = (mySQLiteConnection.Table<MySelf>()).ToList();
		}
		public List<MySelf> RetrivedMyInfo(string querys)
		{
			List<MySelf> dataretrive = (mySQLiteConnection.Query<MySelf>(querys)).ToList();
			return dataretrive;
		}

		public void DeleteInfo(string id)
		{
			//sqliteconnection.Query<PeopleTable>().BinarySearch(id);
			mySQLiteConnection.Query<MySelf>("delete from MySelfDetailsToAccess");
		}







		public void InsertUser_Info(MyFriends infoObject)
		{
			try
			{
				//if (infoObject.ID == 0)
				//{
				//	infoObject.ID = 1;
				//}
				//else
				//{
				//	infoObject.ID += 1;
				//}
				//sqliteconnection.Query<PeopleTable>("delete from UserInformation");
				myPeopleSQLiteConnection.Insert(new MyFriends
				{
					userId_ = infoObject.userId_,
					userFName_ = infoObject.userFName_,
					userLName_ = infoObject.userLName_,
					userMobile_ = infoObject.userMobile_,
					userEmail_ = infoObject.userEmail_,
					userAddress_ = infoObject.userAddress_
				});
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public void UpdateUser_Info(MyFriends updateObject)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<MyFriends> userRetrived_Info()
		{
			//return sqliteconnection.Table<PeopleTable>().FirstOrDefault();
			/*List<PeopleTable> dataretrive1 = new List<PeopleTable>();
			int i = 0;
			var dataretrive = sqliteconnection.Query<PeopleTable>("select * from UserInformation");
			foreach (var item in dataretrive)
			{
				dataretrive1[i] = item;
				i++;
			}
			return dataretrive1;*/
			/*
			PeopleTable dataretrive1 = new PeopleTable();
			ObservableCollection<PeopleTable> dataretrive = new ObservableCollection<PeopleTable>();
			int i = 0;
			var tabledata = sqliteconnection.Table<PeopleTable>();
			foreach (var s in tabledata)
			{
				dataretrive1.ID = s.ID;
				dataretrive1.FirstName = s.FirstName;
				dataretrive1.LastName = s.LastName;
				dataretrive1.Address = s.Address;
				dataretrive1.EMail = s.EMail;
				dataretrive1.Mobile = s.Mobile;
				dataretrive[i] = dataretrive1;
				i++;
			}*/
			List<MyFriends> dataretrive;
			return dataretrive = (myPeopleSQLiteConnection.Table<MyFriends>()).ToList();
		}

		public void Delete_Info(string id)
		{
			//sqliteconnection.Query<PeopleTable>().BinarySearch(id);
			myPeopleSQLiteConnection.Query<MyFriends>("delete from MyListOfPeople");
		}

	}
}

