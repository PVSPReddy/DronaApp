using System;
using DronaApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(IDownloadService))]
namespace DronaApp.Droid
{
	public class IDownloadService : IDownload
	{
		public IDownloadService()
		{
		}

		public void DownladThis(string fileUrl, string fileName, string fileexten, bool isString, DownloadInputDetails _downloadpage)
		{
			
		}

		public void DeleteFile(string fileName, string filePath)
		{
			
		}
	}
}

