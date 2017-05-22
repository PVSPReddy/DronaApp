using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
    /* in pcl
	in pcl
	------
	public App(string id)
	{
		InitializeComponent();

		if (string.IsNullOrEmpty(id))
		{
			MainPage = new ShortCutOperator();
		}
		else
		{
			MainPage = new DisplaySelectedItem(id);
		}
	}
	in main Activity
	protected override void OnCreate(Bundle bundle)
	{
		TabLayoutResource = Resource.Layout.Tabbar;
		ToolbarResource = Resource.Layout.Toolbar;
		string _id = Intent.GetStringExtra("id");
		base.OnCreate(bundle);


		global::Xamarin.Forms.Forms.Init(this, bundle);

		LoadApplication(new App(_id))   
	}
     */
    public partial class ShortCutOperator : BaseContentPage
    {
        public ShortCutOperator()
        {
            InitializeComponent();
            /*
            List<LvDataSource> listSource = new List<LvDataSource>()
            {
                new LvDataSource{ name="One", setText="this is a testing project with number One", id="1", profilePic="icon1.png"},
                new LvDataSource{ name="Two", setText="this is a testing project with number Two", id="2", profilePic="icon2.png"},
                new LvDataSource{ name="Three", setText="this is a testing project with number Three", id="3", profilePic="icon3.png"},
                new LvDataSource{ name="Four", setText="this is a testing project with number Four", id="4", profilePic="icon4.png"},
                new LvDataSource{ name="Five", setText="this is a testing project with number Five", id="5", profilePic="icon5.png"},
                new LvDataSource{ name="Six", setText="this is a testing project with number Six", id="6", profilePic="icon6.png"},
                new LvDataSource{ name="Seven", setText="this is a testing project with number Seven", id="7", profilePic="icon7.png"},
                new LvDataSource{ name="Eight", setText="this is a testing project with number Eight", id="8", profilePic="icon8.png"},
                new LvDataSource{ name="Nine", setText="this is a testing project with number Nine", id="9", profilePic="icon9.png"},
                new LvDataSource{ name="Ten", setText="this is a testing project with number Ten", id="10", profilePic="icon10.png"},
                new LvDataSource{ name="Eleven", setText="this is a testing project with number Eleven", id="11", profilePic="icon11.png"},
                new LvDataSource{ name="Twelve", setText="this is a testing project with number Twelve", id="12", profilePic="icon12.png"},
                new LvDataSource{ name="Thirteen", setText="this is a testing project with number Thirteen", id="13", profilePic="icon.png"}
            };
            */
            List<LvDataSource> listSource = new List<LvDataSource>()
			{
                new LvDataSource{ name="One", setText="this is a testing project with number One", id="1", profilePic="icon1", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAo_AAAAJGQ1NGE5NThkLWQ4NmEtNDY2Yy1hNjU4LTRiY2MwMDdlYmVjMQ.jpg"},
				new LvDataSource{ name="Two", setText="this is a testing project with number Two", id="2", profilePic="icon2", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAhHAAAAJGFlZDVkNDkzLTQwMjctNDVhMC05YWNiLWIwMWQzNjIyYzQ2NA.jpg"},
				new LvDataSource{ name="Three", setText="this is a testing project with number Three", id="3", profilePic="icon3", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAYaAAAAJDQzNDE3MGJiLTFiNTEtNDMwMC1iNDE4LTU2MjAzZmFkMjhiOQ.jpg"},
				new LvDataSource{ name="Four", setText="this is a testing project with number Four", id="4", profilePic="icon4", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAtGAAAAJDkxZWI1NTMwLTdlOTMtNDE2Ny04MTdiLTIwMGY1N2RmMDU0MQ.jpg"},
				new LvDataSource{ name="Five", setText="this is a testing project with number Five", id="5", profilePic="icon5", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAg1AAAAJDhmOTBjYjEwLTliZmMtNGEwZS1iOWQ2LTUxMzRhMmExMzgwOA.jpg"},
				new LvDataSource{ name="Six", setText="this is a testing project with number Six", id="6", profilePic="icon6", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAVMAAAAJDczOWZjY2RlLTczMTMtNGNlNy04ODQ2LWFkNDdhMTE3ZjU1OA.jpg"},
				new LvDataSource{ name="Seven", setText="this is a testing project with number Seven", id="7", profilePic="icon7", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAUGAAAAJGEyMjBhOTFhLTYyN2UtNDBiOC04NWM4LWM1OGNlN2FhODZkOA.jpg"},
				new LvDataSource{ name="Eight", setText="this is a testing project with number Eight", id="8", profilePic="icon8", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAsAAAAAJGVlOTVjZTJiLTZlNzQtNDU2ZS05ZTE5LTZjNmQ2NzY0MDBjMg.jpg"},
				new LvDataSource{ name="Nine", setText="this is a testing project with number Nine", id="9", profilePic="icon9", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAd5AAAAJDE0ZDc5MjY5LThlOGEtNDUwNS1iMzk0LTE5MTAzNmU5NWQyMQ.jpg"},
				new LvDataSource{ name="Ten", setText="this is a testing project with number Ten", id="10", profilePic="icon10", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAc_AAAAJGRlYjAyY2IyLWMwNzktNDczMS1iMWEyLWE0Y2IxMzY1OWMwNQ.jpg"},
				new LvDataSource{ name="Eleven", setText="this is a testing project with number Eleven", id="11", profilePic="icon11", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAffAAAAJDFiN2I3ODhiLTIwNTMtNDEyZi1hMjY3LWJmYjk5MzQ0M2I1ZQ.jpg"},
				new LvDataSource{ name="Twelve", setText="this is a testing project with number Twelve", id="12", profilePic="icon12", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAhJAAAAJDA3ZGQ5NmMzLWVmZWYtNDY2NC1hMDQ4LWY1NTBmZjQyOGQ3ZA.jpg"},
				new LvDataSource{ name="Thirteen", setText="this is a testing project with number Thirteen", id="13", profilePic="icon", profilePicUrl="https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAEAAQAAAAAAAAk5AAAAJDllMjI2MGQ0LTA5NTAtNDQxNy04MDE4LWU5ZDNiOTU1OTYwNA.jpg"}
            };
            listv.ItemsSource = listSource;
            listv.ItemSelected += async (object sender, SelectedItemChangedEventArgs e) => 
            {
                try
                {
                    var selectedItem = e.SelectedItem as LvDataSource;
                    if(selectedItem == null)
                    {
                        return;
                    }
                    var choice = await DisplayAlert("Alert", "Shall we creaetea shortcut for this block data", "Ok", "Cancel" );
                    string[] styleOption = new string[]{"Image from android Resource","Image form URL"};
                    if(choice == true)
                    {
                        ImageSource imgsrc;
                        var style = await DisplayActionSheet("select a Option", "Cancel", null, styleOption);
                        switch (style)
                        {
                            case "Image from android Resource":
                                imgsrc = ImageSource.FromFile(selectedItem.profilePic);
                                DependencyService.Get<IShortCutGenerate>().GenerateShortCutOne(selectedItem.name, selectedItem.profilePic, imgsrc, selectedItem.id);
                                break;
                            case "Image form URL":
                                imgsrc = ImageSource.FromUri(new Uri(selectedItem.profilePicUrl));
                                DependencyService.Get<IShortCutGenerate>().GenerateShortCutTwo(selectedItem.name, selectedItem.profilePic, imgsrc, selectedItem.id);
                                break;
                            default:
                                break;
                                
                        }
                    }
                    //Navigation.PushModalAsync(new DisplaySelectedItem(selectedItem.id));
                    ((ListView)sender).SelectedItem = null;
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }
            };

            /*
            createBtn.Clicked += (object sender, EventArgs e) => 
            {
                try
                {
                    DependencyService.Get<IShortCutGenerate>().GenerateShortCut("myApp", "icon.png", "1");
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            destroyBtn.Clicked += (object sender, EventArgs e) => 
            {
                try
                {
                    DependencyService.Get<IShortCutGenerate>().RemoveShortcut("myApp", "icon.png", "1");
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            */
        }
    }

    public class LvDataSource
    {
        public string id { get; set; }

        public string name { get; set; }

        public string setText { get; set; }

        public string profilePic { get; set;}

        public string profilePicUrl { get; set;}
    }
}
