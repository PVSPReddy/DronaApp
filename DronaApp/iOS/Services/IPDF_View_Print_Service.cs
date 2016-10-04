using System;
using DronaApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IPDF_View_Print_Service))]
namespace DronaApp.iOS
{
	public class IPDF_View_Print_Service : IPDF_View_Print
	{
		public IPDF_View_Print_Service(){}

		public void PrintPdf(string filePath)
		{
			try
			{
				var printInfo = UIPrintInfo.PrintInfo;

				printInfo.Duplex = UIPrintInfoDuplex.LongEdge;

				printInfo.OutputType = UIPrintInfoOutputType.General;

				printInfo.JobName = "Test";

				var printer = UIPrintInteractionController.SharedPrintController;

				printer.PrintInfo = printInfo;

				printer.PrintingItem = NSData.FromUrl(NSUrl.FromString(filePath));

				printer.ShowsPageRange = true;

				printer.Present(true, (handler, completed, err) =>
				{
					if (!completed && err != null)
					{
						Console.WriteLine("Printer Error");
					}
				});
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public void ShowPdf(string filePath)
		{
			throw new NotImplementedException();
		}
	}
}

