using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DronaApp
{
	public partial class DownloadedFilesList : ContentPage
	{
		ListView foldersList;
		public static ObservableCollection<FileDataFolder> folders { get; set; }
		//List<FileDataFolder> folders;
		public static int counts { get; set; }
		public DownloadedFilesList(ObservableCollection<FileDataFolder> _folders)
		{
			folders = _folders;
			InitializeComponent();
			foldersList = new ListView()
			{
				ItemsSource = folders,
				IsPullToRefreshEnabled = true,
				ItemTemplate = new DataTemplate(typeof(DisplayFiles)),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand

			};
			//PanGestureRecognizer pangest = new PanGestureRecognizer();
			//pangest.PanUpdated += (object sender, PanUpdatedEventArgs e) =>
			//{

			//};
			//foldersList.PropertyChanged += async (object sender, System.ComponentModel.PropertyChangedEventArgs e) =>
			//{
			//	await Navigation.PushModalAsync(new FoldersList(folders));

			//};


			foldersList.ItemTapped += async (object sender, ItemTappedEventArgs e) =>
			{
				var a = sender as ListView;
				var selectitem = (FileDataFolder)a.SelectedItem;
				string Display_Data = "Display Data";
				string Send_Email = "Send Through Email";
				string fName = selectitem.file_Name;
				string fPath = selectitem.path_appdata;
				string fDocPath = fPath + "/" + fName;
				var choice = await DisplayActionSheet("Alert", "Cancel", null, Send_Email, Display_Data, "Delete Item");
				if (choice == Display_Data)
				{

					await Navigation.PushModalAsync(new DisplayDownloadedFile(fDocPath));
				}
				else if (choice == Send_Email)
				{
					var uri = new Uri(String.Format("file://{0}", fDocPath));
					var fullPath = uri.ToString();
					DependencyService.Get<IEmail>().ShareFile(fullPath, "mimeType");
				}
				else if (choice == "Delete Item")
				{

					try
					{
						int count = 0;
						foreach (var items in folders)
						{
							count++;
							if (selectitem == items)
							{
								counts = folders.IndexOf(selectitem);
								//counts = count;
								//folders.Remove(selectitem);
								DependencyService.Get<IDownload>().DeleteFile(fName, fPath);
								folders.RemoveAt(counts);
								//folders.RemoveAt(count);
								//folders.RemoveAt(count + 1);
								//foldersList.ItemsSource = folders;
								//foldersList.EndRefresh();
								//folders.RemoveAt(count);
								//RemoveItem(selectitem, count );
							}
							count++;
						}
					}
					catch (Exception ex)
					{
						var msg = ex.Message;
					}
				}
			};
			Button back = new Button()
			{
				Text = "GoBack",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Command = new Command(() =>
				{
					Navigation.PopModalAsync(true);
				})
			};
			StackLayout holderss = new StackLayout()
			{
				Children = {foldersList, back }
			};
			Content = holderss;
		}
		//void OnDelete(object sender, EventArgs e)
		//{
		//	var item = (MenuItem)sender;
		//	items.Remove(item.CommandParameter.ToString());
		//}


		void RemoveItem(FileDataFolder selectitem, int count)
		{
			////folders.Remove(selectitem);
			//for (int i = count; i < folders.Count-1; i++)
			//{
			//	var insertData = folders[count + 1];
			//	folders[count] = insertData;
			//}

		}
	}

	public class DisplayFiles : ViewCell
	{
		protected override void OnBindingContextChanged()
		{
			try
			{
				base.OnBindingContextChanged();
				dynamic c = BindingContext;
				Label _name = new Label()
				{
					TextColor = Color.Green,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				_name.Text = c.file_Name;


				var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
				deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
				deleteAction.Clicked += OnDelete;
				this.ContextActions.Add(deleteAction);


				StackLayout holder = new StackLayout()
				{
					Children = { _name },
					BackgroundColor = Color.Accent,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				View = holder;
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		void OnDelete(object sender, EventArgs e)
		{
			try
			{
				var items = DownloadedFilesList.folders;
				var place = DownloadedFilesList.counts;
				var item = (MenuItem)sender;
				var data = (FileDataFolder)(item.CommandParameter);
				foreach (var _item in items)
				{
					if (data.file_Name == _item.file_Name)
					{
						place = items.IndexOf(_item);
						DependencyService.Get<IDownload>().DeleteFile(_item.file_Name, _item.path_appdata);
						items.RemoveAt(place);
					}
				}
				//foreach (var _items in items)
				//{
				//	if(_items == item)
				//}
				//FoldersList.folders.Remove(item);
				//FoldersList.counts = FoldersList.folders.IndexOf(item);
				//FoldersList.folders.RemoveAt(FoldersList.counts);
				//DependencyService.Get<IDownload>().DeleteFile(fName, fPath);
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}
}
