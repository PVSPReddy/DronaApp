using System;
using SQLite.Net;

namespace DronaApp
{
	public interface IDataBase
	{
		SQLiteConnection GetConnection(String dBName);
	}
}

