using System;
namespace DronaApp
{
	public interface IPDF_View_Print
	{
		void ShowPdf(string filePath);

		void PrintPdf(string filePath);
	}
}

