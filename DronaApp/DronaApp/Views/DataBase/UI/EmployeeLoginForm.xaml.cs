using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DronaApp
{
	public partial class EmployeeLoginForm : ContentPage
	{
		DataBaseMethods dbms = new DataBaseMethods();
		public EmployeeLoginForm()
		{
			CustomProperties cp = new CustomProperties();
			InitializeComponent();
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;

			holder.HeightRequest = screenHeight;
			holder.WidthRequest = screenHeight;
			userName.WidthRequest = (screenWidth * 1.5) / 3;
			user_Name.WidthRequest = (screenWidth * 1.2) / 3;
			userPassword.WidthRequest = (screenWidth * 1.5) / 3;
			user_Password.WidthRequest = (screenWidth * 1.2) / 3;
			submit.WidthRequest = (screenWidth * 3) / 5;

		}
		async void NotHavingAccountTapped(Object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new EmployeeRegistrationForm());
		}
		async void SubmitClicked(Object sender, EventArgs e)
		{
			try
			{
				var _response = Convert.ToBoolean(await ValidateInfo());
				if (_response == true)
				{
					string u_name = userName.Text;
					//_userFName_
					//String query = "SELECT * FROM MyListOfPeople WHERE COL__userFName_ LIKE '%" + user_Name.Text + "%'";
					String query = "SELECT * FROM MySelfDetailsToAccess WHERE _userFName ='" + u_name + "'";
					//String query = "SELECT * FROM [MyListOfPeople] WHERE _userFName_ ='" + u_name + "'";
					//List<MySelf> response = new List<MySelf>();

					var response = dbms.RetrivedMyInfo(query);
					//var dats = response.GetEnumerator();
					//var password = dats.Current._userPassword;
					var dats = response[0];
					//dats = response.GetEnumerator().Current;
					string password = dats._userPassword;
					if (response != null)
					{
						if (password == userPassword.Text)
						{
							await Navigation.PushModalAsync(new MyFriendsRegistration());
							response.Clear();
						}
						else
						{
							await DisplayAlert("Alert", "Invalid User Password", "cancel");
							response.Clear();
						}
					}
				}

			}
			catch (Exception ex)
			{
				var msg = ex.Message;
				await DisplayAlert("Alert", "Invalid User Name", "cancel");
			}
		}


		async Task<bool> ValidateInfo()
		{

			bool response;
			if (userName.Text != "" && userName.Text != null)
			{
				if (userPassword.Text != "" && userPassword.Text != null)
				{
					response = true;
				}
				else
				{
					await DisplayAlert("Alert", "Password Cannot be Empty", "Cancel");
					response = false;
				}
			}
			else
			{
				await DisplayAlert("Alert", "First Name Cannot be Empty", "Cancel");
				response = false;
			}
			return response;
		}
	}
}

