using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Android.Provider;
using Android.Database;
using Java.Util.Regex;

namespace DronaApp.Droid
{
	[Activity(Label = "DronaApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		public string patths;
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			#region For Screen Height & Width
			var pixels = Resources.DisplayMetrics.WidthPixels;
			var scale = Resources.DisplayMetrics.Density;

			var dps = (double)((pixels - 0.5f) / scale);

			App.ScreenWidth = (int)dps;

			pixels = Resources.DisplayMetrics.HeightPixels;
			dps = (double)((pixels - 0.5f) / scale);

			App.ScreenHeight = (int)dps;
			#endregion

			LoadApplication(new App());
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (requestCode == 2)
			{
				if (resultCode == Result.Ok)
				{
					try
					{
						var uri1 = data.Data;
						var uuuri = getRealPathFromURI(this, uri1);
						//getFileNameByUri(this, uri1);
						//var uuuri = getImagePath(this, uri1);
						MyImageDisplay.mid.ShowImageDroid(uuuri);
						/*if (uuuri == "not possible")
						{

							if (resultCode == Result.Ok)
							{
								ImageSource imageSource = ImageSource.FromStream(() => Forms.Context.ContentResolver.OpenInputStream(data.Data));
								//Console.WriteLine("uri : {0}", imageSource.ToString());
								//MainPage.attachImage(imageSource);
								//mid.ShowImage(imageSource);
							}
							else
							{
								//mid.ShowImage(imageSource);
							}

						}
						else
						{
							//mid.ShowImage(uuuri);
						}*/
					}
					catch (Exception ex)
					{
						var msg = ex.Message;
					}

				}
			}
			else if (requestCode == 1)
			{
				if (resultCode == Result.Ok)
				{
					//var uri1 = data.Data;
					//var uuuri = getRealPathFromURI(this, uri1);
					//getFileNameByUri(this, uri1);
					//var uuuri = getImagePath(this, uri1);
					MyImageDisplay.mid.ShowImageDroid(ICameraGalleryService.file.ToString());
					//ImageSource imageSource = ImageSource.FromStream(() => Forms.Context.ContentResolver.OpenInputStream(data.Data));
					//Console.WriteLine("uri : {0}", imageSource.ToString());
					//MainPage.attachImage(imageSource);
					//.ShowImageAndroid(imageSource);
				}
				else
				{
					//mid.ShowImage(imageSource);
				}
			}
		}

		public string getRealPathFromURI(Context context, Android.Net.Uri contentURI)
		{
			try
			{
				var fixedUri = FixUri(contentURI.Path);

				if (fixedUri != null)
				{
					contentURI = fixedUri;
				}

				if (contentURI.Scheme == "file")
				{
					var _filepath = new System.Uri(contentURI.ToString()).LocalPath;
					//mid.ShowImageAndroid(_filepath);
					return _filepath;
				}
				else if (contentURI.Scheme == "content")
				{
					ICursor cursor = ContentResolver.Query(contentURI, null, null, null, null);
					try
					{
						string contentPath = null;
						cursor.MoveToFirst();
						string[] projection = new[] { MediaStore.Images.Media.InterfaceConsts.Data };
						String document_id = cursor.GetString(0);
						document_id = document_id.Substring(document_id.LastIndexOf(":") + 1);
						cursor.Close();

						cursor = ContentResolver.Query(MediaStore.Images.Media.ExternalContentUri, null, MediaStore.Images.Media.InterfaceConsts.Id + " = ? ", new String[] { document_id }, null);
						cursor.MoveToFirst();
						contentPath = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.Media.InterfaceConsts.Data));
						cursor.Close();

						//return contentPath;
						//}
						// If they don't follow the "rules", try to copy the file locally
						//							if (contentPath == null || !contentPath.StartsWith("file"))
						//							{
						//								copied = true;
						//								Uri outputPath = GetOutputMediaFile(context, "temp", null, isPhoto);
						//
						//								try
						//								{
						//									using (Stream input = context.ContentResolver.OpenInputStream(uri))
						//									using (Stream output = File.Create(outputPath.Path))
						//										input.CopyTo(output);
						//
						//									contentPath = outputPath.Path;
						//								}
						//								catch (FileNotFoundException)
						//								{
						//									// If there's no data associated with the uri, we don't know
						//									// how to open this. contentPath will be null which will trigger
						//									// MediaFileNotFoundException.
						//								}
						//							}
						return contentPath;
					}
					catch (Exception ex)
					{
						var msg = ex.Message;
						return null;
					}
					finally
					{
						if (cursor != null)
						{
							cursor.Close();
							cursor.Dispose();
						}
					}
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
				return null;
			}
		}


		public Android.Net.Uri FixUri(string uriPath)
		{
			//remove /ACTUAL
			if (uriPath.Contains("/ACTUAL"))
			{
				uriPath = uriPath.Substring(0, uriPath.IndexOf("/ACTUAL", StringComparison.Ordinal));
			}

			Java.Util.Regex.Pattern pattern = Java.Util.Regex.Pattern.Compile("(content://media/.*\\d)");

			if (uriPath.Contains("content"))
			{
				Matcher matcher = pattern.Matcher(uriPath);

				if (matcher.Find())
				{
					matcher.Group(1);
					var flvse = Android.Net.Uri.Parse(matcher.Group(1));
					return flvse;
				}
				else
				{
					throw new ArgumentException("Cannot handle this URI");
				}
			}
			else
			{
				return null;
			}
		}

	}
}

