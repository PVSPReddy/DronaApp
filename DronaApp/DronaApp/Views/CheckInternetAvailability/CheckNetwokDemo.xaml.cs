using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
    public partial class CheckNetwokDemo : ContentPage
    {
        public CheckNetwokDemo()
        {
            InitializeComponent();
        }

        public async void SubmitBtnClicked(object sender, EventArgs e)
        {
            try
            {
                popupStack.IsVisible = true;
                CheckNetworkAvailability cna = new CheckNetworkAvailability();
                var data = await cna.IsNetworkConnected();
                if(data == true)
                {
                    await DisplayAlert("Alert", "Network is Connected",  "Ok");
                }
                else
                {
                    await DisplayAlert("Alert", "Network is Not Connected",  "Cancel");
                }
                popupStack.IsVisible = false;
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                popupStack.IsVisible = false;
            }
        }
   }
}
