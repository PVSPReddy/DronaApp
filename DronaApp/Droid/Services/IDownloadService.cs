using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using DronaApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(IDownloadService))]
namespace DronaApp.Droid
{
	public class IDownloadService : IDownload
	{
		WebClient webclient;
		string appDataPath, fName;
		DownloadInputDetails downloadpage { set; get; }
		IEnumerable<FileInfo> files;
		//List<FileDataFolder> _fileDataFolder = new List<FileDataFolder>();
		//List<FileDataFolder> _fileDataFolder1 = new List<FileDataFolder>();
		ObservableCollection<FileDataFolder> _fileDataFolder = new ObservableCollection<FileDataFolder>();
		ObservableCollection<FileDataFolder> _fileDataFolder1 = new ObservableCollection<FileDataFolder>();
		public IDownloadService()
		{
		}

		public void DownladThis(string fileUrl, string fileName, string fileexten, bool isString, DownloadInputDetails _downloadpage)
		{
			try
			{
				downloadpage = _downloadpage;
				webclient = new WebClient();
				var url = new Uri(fileUrl);
				string documentPath = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
				//string documentPath = Android.OS.Environment.ExternalStorageDirectory.ToString();
				string folderName = "Sportzb";
				var folderPath = Path.Combine(documentPath, folderName);
				Directory.CreateDirectory(folderPath);
				fName = fileName + fileexten;
				appDataPath = Path.Combine(folderPath, fName);
				#region extra for folder automatic name increment
				DirectoryInfo di = new DirectoryInfo(folderPath);
				FileInfo fi = new FileInfo(appDataPath);
				if (fi.Exists)
				{
					int count = 0;
					//fi.Delete();
					files = di.EnumerateFiles("*." + fileexten);
					foreach (var file1 in files)
					{
						foreach (var file2 in files)
						{
							if (fName == file2.Name)
							{
								count++;
								//var fName1 = Rename(files, fName, fileName);
								var place = fName.LastIndexOf('.');
								var _fileexten = fName.Substring(place + 1);
								//var _fName = fName.Remove(place);
								fName = fileName + (count.ToString()) + "." + _fileexten;
							}
						}
					}
					appDataPath = Path.Combine(folderPath, fName);
					//var appDataPathh = Path.Combine(folderPath, fName);
				}
				else
				{
					appDataPath = Path.Combine(folderPath, fName);
					//var appDataPathh = Path.Combine(folderPath, fName);
				}
				#endregion

				if (isString)
				{
					webclient.DownloadStringAsync(url);
					webclient.Encoding = Encoding.UTF8;
					webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
					{
						try
						{
							#region
							var text = e.Result;
							/*var dtaa1 = text.IndexOf("/");
							var dtaa2 = text.Substring(dtaa1 + 1);
							var dtaa3 = dtaa2.IndexOf("/");
							var dtaa4 = dtaa2.Substring(dtaa3);
							File.WriteAllText(appDataPath, text);*/
							var dtaa5 = Convert.FromBase64String(text);
							File.WriteAllBytes(appDataPath, dtaa5);
							SendDetails(appDataPath);
							SendTotalFiles(files);
							#endregion
						}
						catch (Exception _ex)
						{
							var msg = _ex.Message;
						}
					};
				}
				else
				{
					webclient.DownloadDataAsync(url);
					webclient.Encoding = Encoding.UTF8;
					webclient.DownloadDataCompleted += (object sender, DownloadDataCompletedEventArgs e) =>
					{
						try
						{
							#region
							var text = e.Result;
							File.WriteAllBytes(appDataPath, text);
							SendDetails(appDataPath);
							SendTotalFiles(files);
							#endregion
						}
						catch (Exception _ex)
						{
							var msg = _ex.Message;
						}
					};
				}

				webclient.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
				{
					var data = Convert.ToInt32(e.BytesReceived);
					//downloadpage.ProgressChanging(data);
				};
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
			#region
			#endregion
		}

		public void SendTotalFiles(IEnumerable<FileInfo> _files)
		{
			try
			{
				_fileDataFolder.Clear();
				//fio = new FileInfo(appDataPath);
				foreach (var _value in _files)
				{
					_fileDataFolder.Add(new FileDataFolder { file_Name = _value.Name, path_appdata = _value.DirectoryName/*, time = _value.CreationTime*/ });
					_fileDataFolder1 = new ObservableCollection<FileDataFolder>(_fileDataFolder.OrderBy(fdf => fdf.file_Name));
					//_fileDataFolder1 = new ObservableCollection<FileDataFolder>(_fileDataFolder.OrderBy(fio => fio.file_Name));
				}
				downloadpage.ShowAllFiles(_fileDataFolder1);
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}


		void SendDetails(string _localpath)
		{
			downloadpage.DownloadDetails(_localpath);
		}

		public void openFolders()
		{
			//int i = 0;
			//List<string> folders = new List<string>();
			//string documentPath = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
			//var directories = Directory.EnumerateDirectories("./");
			//foreach (var directory in directories)
			//{
			//	folders[i] = directory;
			//	i++;
			//}
			//return folders;
		}

		public void DeleteFile(string fileName, string filePath)
		{
			var fullPath = Path.Combine(filePath, fileName);
			FileInfo fi = new FileInfo(fullPath);
			if (fi.Exists)
			{
				fi.Delete();
			}
		}
	}
}