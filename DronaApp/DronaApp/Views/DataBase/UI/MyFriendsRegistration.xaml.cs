using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DronaApp
{
	public partial class MyFriendsRegistration : ContentPage
	{
		public MyFriendsRegistration()
		{
			CustomProperties cp = new CustomProperties();
			InitializeComponent();
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;

			holder.HeightRequest = screenHeight;
			holder.WidthRequest = screenHeight;
			userFName.WidthRequest = (screenWidth * 1.5) / 3;
			user_FName.WidthRequest = (screenWidth * 1.2) / 3;
			userLName.WidthRequest = (screenWidth * 1.5) / 3;
			user_LName.WidthRequest = (screenWidth * 1.2) / 3;
			userMobile.WidthRequest = (screenWidth * 1.5) / 3;
			user_Mobile.WidthRequest = (screenWidth * 1.2) / 3;
			userEmail.WidthRequest = (screenWidth * 1.5) / 3;
			user_Email.WidthRequest = (screenWidth * 1.2) / 3;
			userAddress.WidthRequest = (screenWidth * 1.5) / 3;
			userAddress.HeightRequest = (screenWidth * 1.2) / 3;
			user_Address.WidthRequest = (screenWidth * 1.2) / 3;
			submit.WidthRequest = (screenWidth * 3) / 5;

			userMobile.TextChanged += (object sender, TextChangedEventArgs e) =>
			{
				var _text = userMobile.Text;
				if (_text.Length > 10)
				{
					var _texts = _text.Remove(_text.Length - 1);
					userMobile.Text = _texts;
				}
			};

		}

		async void SubmitClicked(Object sender, EventArgs e)
		{
			try
			{
				var response = Convert.ToBoolean(await ValidateInfo());
				//if (userFName.Text != "" && userLName.Text != "" && userMobile.Text != "" && userEmail.Text != "" && userPassword.Text != "" && userAddress.Text != "" )
				if (response == true)
				{
					DataBaseMethods dbms = new DataBaseMethods();
					MyFriends mptb = new MyFriends()
					{
						userFName_ = userFName.Text,
						userLName_ = userLName.Text,
						userMobile_ = Convert.ToDouble(userMobile.Text),
						userEmail_ = userEmail.Text,
						userAddress_ = userAddress.Text
					};
					dbms.InsertUser_Info(mptb);
					await Navigation.PushModalAsync(new DisplayAllWorkers());
				}
				else
				{
					await DisplayAlert("Alert", "Data Cannot be Empty", "Cancel");
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		async void logoutClicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new EmployeeLoginForm());
		}

		async Task<bool> ValidateInfo()
		{
			Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
			Regex rMobile = new Regex(@"^(\d*)$");
			bool response;
			if (userFName.Text != "" && userFName.Text != null)
			{
				if (userLName.Text != "" && userLName.Text != null)
				{
					if (userMobile.Text != "" && userMobile.Text != null)
					{
						if (rMobile.IsMatch(userMobile.Text.Trim()))
						{
							if (userEmail.Text != "" && userEmail.Text != null)
							{
								if (rEmail.IsMatch(userEmail.Text.Trim()))
								{
									if (userAddress.Text != "" && userAddress.Text != null)
									{
										response = true;
									}
									else
									{
										await DisplayAlert("Alert", "Address Cannot be Empty", "Cancel");
										response = false;
									}
								}
								else
								{
									await DisplayAlert("Alert", "Email Address is Invalid", "Cancel");
									response = false;
								}
							}
							else
							{
								await DisplayAlert("Alert", "Email Address Cannot be Empty", "Cancel");
								response = false;
							}
						}
						else
						{
							await DisplayAlert("Alert", "Enter a valid Mobile Number", "Cancel");
							response = false;
						}
					}
					else
					{
						await DisplayAlert("Alert", "Mobile Number Cannot be Empty", "Cancel");
						response = false;
					}

				}
				else
				{
					await DisplayAlert("Alert", "Last Name Cannot be Empty", "Cancel");
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
