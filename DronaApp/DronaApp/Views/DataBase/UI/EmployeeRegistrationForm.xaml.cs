using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DronaApp
{
	public partial class EmployeeRegistrationForm : ContentPage
	{
		DataBaseMethods dbm = new DataBaseMethods();
		public EmployeeRegistrationForm()
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
			userPassword.WidthRequest = (screenWidth * 1.5) / 3;
			user_Password.WidthRequest = (screenWidth * 1.2) / 3;
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
		async void HavingAccountTapped(Object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new EmployeeLoginForm());
		}


		async void SubmitClicked(Object sender, EventArgs e)
		{
			try
			{
				var _response = Convert.ToBoolean(await ValidateInfo());
				//if (userFName.Text != "" && userLName.Text != "" && userMobile.Text != "" && userEmail.Text != "" && userPassword.Text != "" && userAddress.Text != "" )
				if (_response == true)
				{
					MySelf msDetails = new MySelf()
					{
						_userFName = userFName.Text,
						_userLName = userLName.Text,
						_userPassword = userPassword.Text,
						_userMobile = Convert.ToDouble(userMobile.Text),
						_userEmail = userEmail.Text,
						_userAddress = userAddress.Text
						//_userFName = (string.IsNullOrEmpty(userFName.Text) ? "" : userFName.Text),
						//_userLName = (string.IsNullOrEmpty(userLName.Text) ? "" : userLName.Text),
						//_userPassword = (string.IsNullOrEmpty(userPassword.Text) ? "" : userPassword.Text),
						//_userMobile = Convert.ToDouble(userMobile.Text), //Convert.ToDouble(string.IsNullOrEmpty(userMobile.Text) ? "" : userMobile.Text),
						//_userEmail = (string.IsNullOrEmpty(userEmail.Text) ? "" : userEmail.Text),
						//_userAddress = (string.IsNullOrEmpty(userAddress.Text) ? "" : userAddress.Text)
					};
					var response = Convert.ToBoolean(await checkUser(msDetails));
					if (response)
					{
						dbm.InsertUserInfo(msDetails);
						await Navigation.PushModalAsync(new DisplayAllEmployees());
					}
					else
					{
						//await DisplayAlert("Alert", "User already Existed", "Cancel");
					}
				}
				else
				{
					//await DisplayAlert("Alert", "Data Cannot be Empty", "Cancel");
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
		async Task<bool> checkUser(MySelf msDetails)
		{
			bool response;
			try
			{
				string u_Mobile = userMobile.Text;
				string u_Email = userEmail.Text;
				String mobileQuery = "SELECT * FROM MySelfDetailsToAccess WHERE _userMobile ='" + u_Mobile + "'";
				String emailQuery = "SELECT * FROM MySelfDetailsToAccess WHERE _userEmail ='" + u_Email + "'";
				var dbMobileResponse = dbm.RetrivedMyInfo(mobileQuery);
				if (dbMobileResponse.Count == 0)
				{
					var dbEmailResponse = dbm.RetrivedMyInfo(emailQuery);
					if (dbEmailResponse.Count == 0)
					{
						response = true;
					}
					else
					{
						await DisplayAlert("Alert", "Email Already Exists, enter new email id", "cancel");
						response = false;
						dbEmailResponse.Clear();
					}
				}
				else
				{
					await DisplayAlert("Alert", "Mobile number Already Exists, enter new Mobile number", "cancel");
					response = false;
					dbMobileResponse.Clear();
				}
				return response;
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
				response = true;
				return response;
			}

		}

		/*async Task<bool> ValidateInfo()
		{
			Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
			Regex rMobile = new Regex(@"[0-9]*");
			bool response;
			if (userFName.Text != "" && userFName.Text != null)
			{
				var response1 = true;
			}
			else
			{
				await DisplayAlert("Alert", "First Name Cannot be Empty", "Cancel");
				response = false;
			}
			if (userLName.Text != "" && userLName.Text != null)
			{

			}
			else
			{
				await DisplayAlert("Alert", "Last Name Cannot be Empty", "Cancel");
				response = false;
			}
			if (userPassword.Text != "" && userPassword.Text != null)
			{

			}
			else
			{
				await DisplayAlert("Alert", "Password Cannot be Empty", "Cancel");
				response = false;
			}
			if (userMobile.Text != "" && userMobile.Text != null)
			{

			}
			else
			{
				await DisplayAlert("Alert", "MobileNumber Cannot be Empty", "Cancel");
				response = false;
			}
			if (userEmail.Text != "" && userEmail.Text != null)
			{

			}
			else
			{
				await DisplayAlert("Alert", "Email Address Cannot be Empty", "Cancel");
				response = false;
			}
			if (userAddress.Text != "" && userAddress.Text != null)
			{
				response = true;
			}
			else
			{
				await DisplayAlert("Alert", "Address Cannot be Empty", "Cancel");
				response = false;
			}
			if ()
			{
			}
			return response;
		}*/
		/*async void SubmitClicked(Object sender, EventArgs e)
		{
			try
			{
				//var response = ValidateInfo();
				if (userFName.Text != "" && userLName.Text != "" && userMobile.Text != "" && userEmail.Text != "" && userPassword.Text != "" && userAddress.Text != "" )
				{
					DataBaseMethods dbm = new DataBaseMethods();
					MySelf msDetails = new MySelf()
					{
						_userFName = userFName.Text,
						_userLName = userLName.Text,
						_userPassword = userPassword.Text,
						_userMobile = Convert.ToDouble(userMobile.Text),
						_userEmail = userEmail.Text,
						_userAddress = userAddress.Text
						//_userFName = (string.IsNullOrEmpty(userFName.Text) ? "" : userFName.Text),
						//_userLName = (string.IsNullOrEmpty(userLName.Text) ? "" : userLName.Text),
						//_userPassword = (string.IsNullOrEmpty(userPassword.Text) ? "" : userPassword.Text),
						//_userMobile = Convert.ToDouble(userMobile.Text), //Convert.ToDouble(string.IsNullOrEmpty(userMobile.Text) ? "" : userMobile.Text),
						//_userEmail = (string.IsNullOrEmpty(userEmail.Text) ? "" : userEmail.Text),
						//_userAddress = (string.IsNullOrEmpty(userAddress.Text) ? "" : userAddress.Text)
					};
					dbm.InsertUserInfo(msDetails);
				}
				await Navigation.PushModalAsync(new DisplayAllEmployees());
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}*/


		async Task<bool> ValidateInfo()
		{
			Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
			Regex rMobile = new Regex(@"^(\d*)$");
			bool response;
			if (userFName.Text != "" && userFName.Text != null)
			{
				if (userLName.Text != "" && userLName.Text != null)
				{
					if (userPassword.Text != "" && userPassword.Text != null)
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
						await DisplayAlert("Alert", "Password Cannot be Empty", "Cancel");
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
		//async Task<bool> ValidateInfo()
		//{
		//	var response = Convert.ToBoolean(await Validate_FNmae());
		//	//var response = Validate_Password();
		//	return response;
		//}

		//async Task<bool> Validate_FNmae()
		//{
		//	bool response;
		//	if (userFName.Text != "" && userFName.Text != null)
		//	{
		//		response = Convert.ToBoolean( await Validate_LNmae());
		//	}
		//	else
		//	{
		//		await DisplayAlert("Alert", "First Name Cannot be Empty", "Cancel");
		//		response = false;
		//	}
		//	return response;
		//}

		//async Task<bool> Validate_LNmae()
		//{
		//	bool response;
		//	if (userFName.Text != "" && userFName.Text != null)
		//	{
		//		response = Convert.ToBoolean(await Validate_LNmae());
		//	}
		//	else
		//	{
		//		await DisplayAlert("Alert", "Last Name Cannot be Empty", "Cancel");
		//		response = false;
		//	}
		//	return response;
		//}

		//async Task<bool> Validate_Mobile()
		//{
		//	var response = Validate_LNmae();

		//	return response;
		//}

		//async Task<bool> Validate_Email()
		//{
		//	var response = Validate_Mobile();

		//	return response;
		//}

		//async Task<bool> Validate_Password()
		//{
		//	var response = Validate_Email();
		//	return response;
		//}
	}
	public class Employee
	{
		public string FName { set; get; }
		public string LName { set; get; }
		public string Password { set; get; }
		public string Mobile { set; get; }
		public string Email { set; get; }
		public string Address { set; get; }
	}
}