using System;
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

in android project in AndroidManifest.xml add permissions
<uses-permission android:name="com.android.launcher.permission.INSTALL_SHORTCUT" />
<uses-permission android:name="com.android.launcher.permission.UNINSTALL_SHORTCUT" />
     */
    public interface IShortCutGenerate
    {
        void GenerateShortCutOne(string title, string icon, Xamarin.Forms.ImageSource imgSource, string id);

        void GenerateShortCutTwo(string title, string icon, Xamarin.Forms.ImageSource imgSource, string id);

        void RemoveShortcut(string title, string icon, string id);
    }
}
