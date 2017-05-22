using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using DronaApp.Droid;
using Java.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly : Dependency(typeof(ShortcutGenerateService))]
namespace DronaApp.Droid
{
    public class ShortcutGenerateService : IShortCutGenerate// Activity, IShortCutGenerate
    {
        public ShortcutGenerateService(){}

        public async void GenerateShortCut(string title, string icon, ImageSource imgSource, string id)
        {
            try
            {
                #region
                #endregion



                /*
                //add permissions add shortcut
                //var shortcutIntent = new Intent(this, typeof(SomeActivity));
                var shortcutIntent = new Intent();
                shortcutIntent.SetAction(Intent.ActionMain);
                Intent intent = new Intent();

                intent.PutExtra(Intent.ExtraShortcutIntent, shortcutIntent);
                // Sets the custom shortcut's title
                intent.PutExtra(Intent.ExtraShortcutName, title);

                intent.PutExtra(Intent.ExtraShortcutIcon, icon);
                intent.PutExtra("duplicate", false);

                // add the shortcut
                intent.SetAction("com.android.launcher.action.INSTALL_SHORTCUT");
                var activity = (Activity)Forms.Context;
                activity.SendBroadcast(intent);
               */

                //Uri otherPath = new Uri("android.resource://com.segf4ult.test/drawable/icon");
                //var iconPath = "android.resource://com.companyname.dronaapp/drawable/" + icon;
                //File file = new File("resources/" + icon);
                //String absolutePath = file.AbsolutePath;

                //Drawable drawable = getResources().getDrawable(getResources().getIdentifier("d002_p00" + j, "drawable", getPackageName()));
                //var drawables = Resources.GetDrawable(icon);


                var activity = (Activity)Forms.Context; 
                var psck = activity.PackageName;
                var idss = activity.Resources.GetIdentifier(icon, "drawable", psck);
                //var idssss = Resources.GetIdentifier("com.companyname.dronaapp:drawable/"+icon, "drawable", psck);
                //var idsss = Resources.GetIdentifier("com.companyname.dronaapp:drawable/" +icon, null, null);






                //var activity = (Activity)Forms.Context; 
                var shortcutIntent = new Intent(activity, typeof(MainActivity));
                shortcutIntent.PutExtra("id",id);
                shortcutIntent.SetAction(Intent.ActionMain);
                Intent intent = new Intent();
                //Bitmap bitmap = Bitmap.CreateBitmap(100, 100, Bitmap.Config.Argb8888);
                //((ImageView)FindViewById(Resource.Drawable.icon2)).SetImageBitmap(bitmap);
                //Bitmap bitmap = BitmapFactory.DecodeFile(iconPath);
                //((ImageView)FindViewById(Resource.Drawable.icon2)).SetImageBitmap(bitmap);





                //var handler = new ImageLoaderSourceHandler();
                //var bitmap = await handler.LoadImageAsync(imgSource, this);

                //Bitmap scaledBitmap = Bitmap.CreateScaledBitmap(bitmap, 78, 78, true);




                //Bitmap originalImage;
                //BitmapFactory.Options options = new BitmapFactory.Options();
                //options.InJustDecodeBounds = true;
                //originalImage = BitmapFactory.DecodeFile(uuuri, options);


                intent.PutExtra(Intent.ExtraShortcutIntent, shortcutIntent);
                // Sets the custom shortcut's title
                intent.PutExtra(Intent.ExtraShortcutName, title);
                //intent.PutExtra(Intent.ExtraShortcutIcon, icon);
                intent.PutExtra(Intent.ExtraShortcutIconResource, Intent.ShortcutIconResource.FromContext(activity, idss));
                //intent.PutExtra(Intent.ExtraShortcutIconResource, Intent.ShortcutIconResource.FromContext(activity, Resource.Drawable.icon4));



                //intent.PutExtra(Intent.ExtraShortcutIcon, bitmap);


                //ShortcutIconResource iconResource = Intent.ShortcutIconResource.fromContext(context, appInfo.icon);
                //shortcut.putExtra(Intent.EXTRA_SHORTCUT_ICON_RESOURCE, iconResource);
                intent.PutExtra("duplicate", false);

                // add the shortcut
                intent.SetAction("com.android.launcher.action.INSTALL_SHORTCUT");
                activity.SendBroadcast(intent);

            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public async void GenerateShortCutOne(string title, string icon, ImageSource imgSource, string id)
        {
            try
            {
                #region this is a working code One
                //
                //this lines creates a activity, by this we can take the advantage of an android native activity in current cross platform forms project
                var activity = (Activity)Forms.Context;

                //this line gives the package name of this project
                var psck = activity.PackageName;

                //this line give the id of a resource or element by using it name in string format preferable for images inside the project under resources folders
                var idss = activity.Resources.GetIdentifier(icon, "drawable", psck);

                //this line helps the icon to navigate to main activity on touch as it is the primary page or app start page
                var shortcutIntent = new Intent(activity, typeof(MainActivity));
                //this is to set an id for every icon create to discriminate seperate action for seperate id
                shortcutIntent.PutExtra("id",id);
                shortcutIntent.SetAction(Intent.ActionMain);

                //this line creates app icon intent
                Intent intent = new Intent();
                intent.PutExtra(Intent.ExtraShortcutIntent, shortcutIntent);
                // Sets the custom shortcut's title that displays
                intent.PutExtra(Intent.ExtraShortcutName, title);

                //by this we are giving the shortcut icon a image from drawable in local images of project
                intent.PutExtra(Intent.ExtraShortcutIconResource, Intent.ShortcutIconResource.FromContext(activity, idss));

                //if you want a common image for all icons then instead of idss(above line) you can use below one
                //intent.PutExtra(Intent.ExtraShortcutIconResource, Intent.ShortcutIconResource.FromContext(activity, Resource.Drawable.icon4));

                //this line helps to stop creating duplicate of icon with same parameters currently it is differentiated based on the title we provide
                intent.PutExtra("duplicate", false);

                // add the shortcut
                intent.SetAction("com.android.launcher.action.INSTALL_SHORTCUT");
                activity.SendBroadcast(intent); 
                #endregion
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public async void GenerateShortCutTwo(string title, string icon, ImageSource imgSource, string id)
        {
            try
            {
                #region this is a working code Two
                //
                //this lines creates a activity, by this we can take the advantage of an android native activity in current cross platform forms project
                var activity = (Activity)Forms.Context;

                //this line gives the package name of this project
                var psck = activity.PackageName;

                //this line give the id of a resource or element by using it name in string format preferable for images inside the project under resources folders
                var idss = activity.Resources.GetIdentifier(icon, "drawable", psck);

                //this line helps the icon to navigate to main activity on touch as it is the primary page or app start page
                var shortcutIntent = new Intent(activity, typeof(MainActivity));
                //this is to set an id for every icon create to discriminate seperate action for seperate id
                shortcutIntent.PutExtra("id",id);
                shortcutIntent.SetAction(Intent.ActionMain);

                //this line creates app icon intent
                Intent intent = new Intent();
                intent.PutExtra(Intent.ExtraShortcutIntent, shortcutIntent);
                // Sets the custom shortcut's title that displays
                intent.PutExtra(Intent.ExtraShortcutName, title);

                //by this we are giving the shortcut icon a image from online url in pcl adding it to image source and here we are converting it to bitmap and the we are using this as icon image source
                var handler = new ImageLoaderSourceHandler();
                var bitmap = await handler.LoadImageAsync(imgSource, activity);
                intent.PutExtra(Intent.ExtraShortcutIcon, bitmap);
                //dont feel tensed if no image or shortcut icon appears or it is because of the large or very small size of the image, here it gives no exception

                //this line helps to stop creating duplicate of icon with same parameters currently it is differentiated based on the title we provide
                intent.PutExtra("duplicate", false);

                // add the shortcut
                intent.SetAction("com.android.launcher.action.INSTALL_SHORTCUT");
                activity.SendBroadcast(intent); 
                #endregion
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void RemoveShortcut(string title, string icon, string id)
        {
            try
            {
               /*
                //add permissions add uninstall shortcut
                //var shortcutIntent = new Intent(this, typeof(MyAwesomeActivity));
                var shortcutIntent = new Intent();
                shortcutIntent.SetAction(Intent.ActionMain);

                var intent = new Intent();
                intent.PutExtra(Intent.ExtraShortcutIntent, shortcutIntent);
                intent.PutExtra(Intent.ExtraShortcutName, title);
                intent.SetAction("com.android.launcher.action.UNINSTALL_SHORTCUT");
                var activity = (Activity)Forms.Context;
                activity.SendBroadcast(intent);
                //SendBroadcast(intent);
                */


                //add permissions add uninstall shortcut
                //var shortcutIntent = new Intent(this, typeof(MyAwesomeActivity));
                var activity = (Activity)Forms.Context;
                var shortcutIntent = new Intent(activity, typeof(MainActivity));
                shortcutIntent.SetAction(Intent.ActionMain);

                var intent = new Intent();
                intent.PutExtra(Intent.ExtraShortcutIntent, shortcutIntent);
                intent.PutExtra(Intent.ExtraShortcutName, title);
                intent.SetAction("com.android.launcher.action.UNINSTALL_SHORTCUT");
                activity.SendBroadcast(intent);
                //SendBroadcast(intent);

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public static Bitmap bytesToUIImage(byte[] bytes)
        {
            if (bytes == null)
                return null;

            Bitmap bitmap;


            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            //Create a folder for the images if not exists
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(documentsFolder, "images"));

            string imatge = System.IO.Path.Combine(documentsFolder, "images", "image.jpg");


            System.IO.File.WriteAllBytes(imatge, bytes.Concat(new Byte[] { (byte)0xD9 }).ToArray());

            bitmap = BitmapFactory.DecodeFile(imatge);

            return bitmap;
        }
    }
}

