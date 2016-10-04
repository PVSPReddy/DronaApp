using System;
namespace DronaApp
{
	#region
	/*if this printer code or webview is not working well or if it gives any exception or null then
	then change page navigation type to pushasync from push modalasync and viceversa */
	#endregion
	public interface IPDF_View_Print
	{
		void ShowPdf(string filePath);

		void PrintPdf(string filePath);
	}
}

