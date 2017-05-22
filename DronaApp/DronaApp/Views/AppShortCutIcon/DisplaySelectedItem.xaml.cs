using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DronaApp
{
    public partial class DisplaySelectedItem : BaseContentPage
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

            LoadApplication(new App(_id));
        }
        */
        public DisplaySelectedItem(string ids)
        {
            LvDataSource data = new LvDataSource();
            InitializeComponent();
            List<LvDataSource> listSource = new List<LvDataSource>()
			{
				new LvDataSource{ name="One", setText="this is a testing project with number One", id="1"},
				new LvDataSource{ name="Two", setText="this is a testing project with number Two", id="2"},
				new LvDataSource{ name="Three", setText="this is a testing project with number Three", id="3"},
				new LvDataSource{ name="Four", setText="this is a testing project with number Four", id="4"},
				new LvDataSource{ name="Five", setText="this is a testing project with number Five", id="5"},
				new LvDataSource{ name="Six", setText="this is a testing project with number Six", id="6"},
				new LvDataSource{ name="Seven", setText="this is a testing project with number Seven", id="7"},
				new LvDataSource{ name="Eight", setText="this is a testing project with number Eight", id="8"},
				new LvDataSource{ name="Nine", setText="this is a testing project with number Nine", id="9"},
				new LvDataSource{ name="Ten", setText="this is a testing project with number Ten", id="10"},
				new LvDataSource{ name="Eleven", setText="this is a testing project with number Eleven", id="11"},
				new LvDataSource{ name="Twelve", setText="this is a testing project with number Twelve", id="12"},
				new LvDataSource{ name="Thirteen", setText="this is a testing project with number Thirteen", id="13"}
            };

            if(!string.IsNullOrEmpty(ids))
            {
                data = listSource.Where(X => X.id == ids).FirstOrDefault();
                names.Text = data.name;
                texts.Text = data.setText;
            }

            removeBtn.Clicked += (object sender, EventArgs e) => 
            {
                try
                {
                    DependencyService.Get<IShortCutGenerate>().RemoveShortcut(data.name, "icon.png", data.id);
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            backBtn.Clicked += (object sender, EventArgs e) => 
            {
                try
                {
                    Navigation.PopModalAsync(false);
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }
            };
        }
    }
}
