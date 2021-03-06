﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class MasterPage_LV_Menu : ContentPage
	{
		public MasterPage_LV_Menu()
		{
			InitializeComponent();
			Title = "Menu"; //mandatory
			List<PageDetails> lvMenu = new List<PageDetails>()
			{
				(new PageDetails{pageName="Home Detail", imageSource=null, pageNavigation=typeof(MasterPage_LV_Detail)}),
				(new PageDetails{pageName="Navigation from a List", imageSource=null, pageNavigation=typeof(TemporaryListPage)}),
				(new PageDetails{pageName="Download File Example", imageSource=null, pageNavigation=typeof(DownloadInputDetails)}),
				(new PageDetails{pageName="DataBase Example", imageSource=null, pageNavigation=typeof(EmployeeRegistrationForm)}),
				(new PageDetails{pageName="CameraGallery Example", imageSource=null, pageNavigation=typeof(GalleryIntroduction)})
			};
			pageMenus.ItemsSource = lvMenu;
			pageMenus.ItemSelected += SelectPage;
		}

		void SelectPage(object sender, SelectedItemChangedEventArgs e)
		{
			try
			{
				if (e.SelectedItem != null)
				{
					var makingThisAsMenu = (MasterDetailPage)this.Parent;
					//var pageToOpen = e.SelectedItem as PageDetails;
					var pageToOpen = (PageDetails)e.SelectedItem;
					if (pageToOpen != null)
					{
						makingThisAsMenu.Detail = (Page)Activator.CreateInstance(pageToOpen.pageNavigation);
					}
					makingThisAsMenu.IsPresented = false;
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
				System.Diagnostics.Debug.WriteLine("Error => " + ex.Message);
				System.Diagnostics.Debug.WriteLine("StackTrace => " + ex.StackTrace);
				//throw new Exception(ex.Message);
			}
			((ListView)sender).SelectedItem = null;
		}
	}
	public class PageDetails
	{
		public string pageName { get; set; }
		public string imageSource { get; set; }
		public Type pageNavigation { get; set; }
	}
}

