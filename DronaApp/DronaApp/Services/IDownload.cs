using System;
namespace DronaApp
{
	public interface IDownload
	{
		void DownladThis(string fileUrl, string fileName, string fileexten, bool isString, DownloadInputDetails _downloadpage);

		void DeleteFile(string fileName, string filePath);
	}
}

