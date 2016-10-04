using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DronaApp
{
	public partial class DownloadInputDetails : ContentPage
	{
		CustomProperties cp = new CustomProperties();
		string fileUrl, fileName, filePath, filePath1, fileexten;
		IDownload downloadService;
		IPDF_View_Print displayService;
		ObservableCollection<FileDataFolder> filesList;

		public DownloadInputDetails()
		{
			downloadService = DependencyService.Get<IDownload>();
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;
			var headerHeight = cp.AppHeaderHeight;
			var headerWidth = cp.AppHeaderWidth;
			InitializeComponent();
			holder.HeightRequest = screenHeight;
			holder.WidthRequest = screenWidth;
			header.HeightRequest = headerHeight;
			header.WidthRequest = headerWidth;
			Title = ""; //mandatory
			urlHolder.WidthRequest = (screenWidth * 2.8) / 3;
			fileName_Holder.WidthRequest = (screenWidth * 0.9) / 3;
			fileNameHolder.WidthRequest = (screenWidth * 1.8) / 3;
			extension_Holder.WidthRequest = (screenWidth * 0.9) / 3;
			extensionHolder.WidthRequest = (screenWidth * 1.8) / 3;
			download.WidthRequest = (screenWidth * 2) / 5;
			display.WidthRequest = (screenWidth * 2) / 5;
			folderView.WidthRequest = (screenWidth * 2) / 5;
		}
		public void MenuClicked(object sender, EventArgs e)
		{
			try
			{
				var makeThisAsMenu = (MasterDetailPage)this.Parent;
				makeThisAsMenu.IsPresented = (makeThisAsMenu.IsPresented == false) ? true : false;
				makeThisAsMenu.IsPresentedChanged += async (object _sender, EventArgs _e) =>
				{
					if (makeThisAsMenu.IsPresented)
					{
						menu.Text = "<";
						await DisplayAlert("Alert", "got true value baby", "cancel");
						//await boxanime.LayoutTo(new Rectangle((screenwd / 3.8), (screenht / 3), (screenwd / 2.09), (screenht / 3.5)), 0, null);
					}
					else
					{
						menu.Text = ">";
						await DisplayAlert("Alert", "got false value baby", "cancel");
						//await boxanime.LayoutTo(new Rectangle((screenwd / 3.8), (screenht / 3), (screenwd / 2.09), (screenht / 3.5)), 0, null);
					}
				};
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public void ShowImage()
		{
			//var uri = new Uri(String.Format("file://{0}", filePath1));
			//var fullPath = uri.ToString();
			//imageHolder.Source = ImageSource.FromUri(uri);
		}
		void DownloadClicked(object sender, EventArgs e)
		{
			try
			{
				#region Coining the File Data
				if (urlHolder.Text == null || urlHolder.Text == "")
				{
					fileUrl = "http://devrabbit.com/lic/pdfbase64bin.php";
					//fileUrl = "http://devrabbit.com/lic/imgbase64bin.php";
					//"https://developer.xamarin.com/guides/xamarin-forms/getting-started/hello-xamarin-forms/quickstart/offline.pdf";
					//"https://developer.xamarin.com/guides/xamarin-forms/controls/layouts/offline.pdf";
					//"https://developer.xamarin.com/guides/xamarin-forms/getting-started/offline.pdf";
				}
				else
				{
					fileUrl = urlHolder.Text;
				}
				//fileName = (fileNameHolder.Text!=null) ? fileNameHolder.Text : "Download";
				if (fileNameHolder.Text == null || fileNameHolder.Text == "")
				{
					fileName = "Download";
				}
				else
				{
					fileName = fileNameHolder.Text;
				}
				if (extensionHolder.Text == null || extensionHolder.Text == "")
				{
					fileexten = "pdf";
				}
				else
				{
					fileexten = extensionHolder.Text;
				}
				//var place = fileUrl.LastIndexOf('.');
				//fileexten = fileUrl.Substring(place + 1);
				var _fileName = fileName + "." + fileexten;
				#endregion
				//downloadService.DownladThis(fileUrl, fileName, fileexten, this);
				//downloadService.DownladThis("http://devrabbit.com/lic/imgbase64bin.php", fileName, "jpeg", this);
				downloadService.DownladThis(fileUrl, fileName, fileexten, true, this);
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public async void DownloadDetails(string filePath2)
		{
			try
			{
				filePath1 = filePath2.ToString();
				await DisplayAlert("Alert", "Your file is Downloaded to " + filePath1, "Ok", "Cancel");
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public void ProgressChanging(int data)
		{
			//progressed.Progress = (data) / 433994;
		}

		async void DisplayClicked(object sender, EventArgs e)
		{
			try
			{
				#region
				/*if this printer code or webview is not working well or if it gives any exception or null then
				then change page navigation type to pushasync from push modalasync and viceversa */
				#endregion
				if (filePath1 != null)
				{
					if (Device.OS == TargetPlatform.iOS)
					{
						await Navigation.PushModalAsync(new DisplayDownloadedFile(filePath1));
					}
					else if (Device.OS == TargetPlatform.Android)
					{
						displayService.ShowPdf(filePath1);
					}
					else if (Device.OS == TargetPlatform.WinPhone)
					{
						displayService.ShowPdf(filePath1);
					}
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public void ShowAllFiles(ObservableCollection<FileDataFolder> _files)
		{
			filesList = _files;
			ShowImage();
		}
		async void FolderViewClicked(object sender, EventArgs e)
		{
			try
			{

				//await Navigation.PushAsync(new FoldersList(filesList));
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}


		public void movefurtherClicked(object sender, EventArgs e)
		{
			try
			{
				
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}


		public void goBackClicked(object sender, EventArgs e)
		{
			try
			{
				Navigation.PopModalAsync(true);
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}
	public class FileDataFolder
	{
		public string file_Name { set; get; } // { get; set:}
		public string path_appdata { set; get; }
		public string path_extdata { set; get; }
		//public DateTime time{ set; get; }
	}
}
