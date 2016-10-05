using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class DisplayAllEmployees : ContentPage
	{
		DataBaseMethods dbms;
		public DisplayAllEmployees()
		{
			dbms = new DataBaseMethods();
			var ms_details = dbms.userRetrivedInfo();
			/*List<Employee> emp = new List<Employee>()
			{
				new Employee{FName="Siva", LName="Prasad", Mobile="7867532453453", Email="sdgdsfvdfsv", Address="ergrgre" },
				new Employee{FName="Venkata", LName="Swamy", Mobile="453432453453", Email="sdfsdcvdsvdf", Address="ewefwfsdfsd" },
				new Employee{FName="Alok", LName="Das", Mobile="453453453452452", Email="wefvdsvcdvsdfv", Address="dsvdfsgds" },
				new Employee{FName="Satya", LName="Narayana", Mobile="4534534534", Email="dsgvdfbvfdsbva", Address="sdgdgfg" },
				new Employee{FName="Veeresh", LName="Kanchumarthy", Mobile="435543453", Email="sdfsdgvfdbdfb", Address="sddggg" },
				new Employee{FName="Hima", LName="Shankar", Mobile="453535435464", Email="sdfdsfbdfbxza", Address="sddsgdfg" },
				new Employee{FName="Siva", LName="Muralidhar", Mobile="354345634565", Email="asdfdsgsgdsga", Address="sdggdfgdfg" },
				new Employee{FName="Venkatateswarlu", LName="N", Mobile="45343453635", Email="asdfdsgdsgscvs", Address="sddgdfgfgfgf" },
				new Employee{FName="Gopi", LName="Vaka", Mobile="53453453453", Email="sdfwgdsvsasvdvfg", Address="dgfgfgfgfgfg" },
				new Employee{FName="Krishna", LName="Mohan", Mobile="4534534535353", Email="dwefewgdfhdfdda", Address="sddfdfdsfdf" },
				new Employee{FName="Vishwanath", LName="Vundi", Mobile="45335534535", Email="sefweghrtsserewe", Address="sdgdgfgf" },
				new Employee{FName="Krishna", LName="Mohan", Mobile="4534535353453", Email="segergdggfgfg", Address="sdgfgfggdf" },
				new Employee{FName="Chandra", LName="S", Mobile="4355345354345", Email="strtredfdggd", Address="sddfgfgfgfg" }
			};*/
			CustomProperties cp = new CustomProperties();
			InitializeComponent();
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;



			holder.HeightRequest = screenHeight;
			holder.WidthRequest = screenHeight;
			//userFName.WidthRequest = (screenWidth * 1.5) / 3;
			//user_FName.WidthRequest = (screenWidth * 1.2) / 3;
			//userLName.WidthRequest = (screenWidth * 1.5) / 3;
			//user_LName.WidthRequest = (screenWidth * 1.2) / 3;
			//userMobile.WidthRequest = (screenWidth * 1.5) / 3;
			//user_Mobile.WidthRequest = (screenWidth * 1.2) / 3;
			//userEmail.WidthRequest = (screenWidth * 1.5) / 3;
			//user_Email.WidthRequest = (screenWidth * 1.2) / 3;
			//userAddress.WidthRequest = (screenWidth * 1.5) / 3;
			//userAddress.HeightRequest = (screenWidth * 1.2) / 3;
			//user_Address.WidthRequest = (screenWidth * 1.2) / 3;
			back.WidthRequest = (screenWidth * 3) / 5;


			EmployeeDetails.ItemsSource = ms_details;
			EmployeeDetails.RowHeight = Convert.ToInt32((screenWidth * 1.5) / 3);

		}
		public async void BackClicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new EmployeeRegistrationForm());

		}
	}

}

