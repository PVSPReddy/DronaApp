using System;
using Android.Content;
using DronaApp.Droid;
using Java.IO;
using Xamarin.Forms;

[assembly : Dependency(typeof(IPDF_View_Print_Service))]
namespace DronaApp.Droid
{
	public class IPDF_View_Print_Service : IPDF_View_Print
	{
		public IPDF_View_Print_Service(){}

		public void ShowPdf(string filePath)
		{
			//var fileLocation = "/sdcard/Template.pdf";
			var fileLocation = filePath;
			var file = new File(fileLocation);

			if (!file.Exists())
				return;

			var intent = DisplayPdf(file);
			Forms.Context.StartActivity(intent);
		}

		public Intent DisplayPdf(File file)
		{
			var intent = new Intent(Intent.ActionView);
			var filepath = Android.Net.Uri.FromFile(file);
			intent.SetDataAndType(filepath, "application/pdf");
			intent.SetFlags(ActivityFlags.ClearTop);
			return intent;
		}


		public void PrintPdf(string filePath)
		{
			throw new NotImplementedException();
		}
	}
}

