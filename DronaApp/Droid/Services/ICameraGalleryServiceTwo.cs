using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Provider;
using Android.Widget;
using DronaApp.Droid;
using Java.IO;
using Xamarin.Forms;

using Android.OS;
using Java.Util.Regex;
using Android.Database;
using Android.Graphics;


#region startup reading page
/*in this method we have to write code in deppendency and as well in Mainactivity also so to write code in single page watch my next
project coined as ICameraGalleryService2 in th same project for ios i wrote only one dependency service but for android there are many
dont forget to get permissions for camera, write external storage, read external storage then it makes all the magic
 try to implement each and every line of this code which gives a better result*/
#endregion

[assembly: Dependency(typeof(ICameraGalleryServiceTwo))]
namespace DronaApp.Droid
{
	public class ICameraGalleryServiceTwo : ICameraGalleryDroidSpl
	{
		public ICameraGalleryServiceTwo(){}

		public void CaptureImageDroidSplOne(MyImageDisplay _myimagedisplay)
		{
			//var activity = Forms.Context as MainActivity;
			var activity = Forms.Context as Activity;
			//activity = (Activity)Forms.Context;
			try
			{
				var isCameraAvailable = activity.PackageManager.HasSystemFeature(PackageManager.FeatureCamera);//use the Android.Content.PM
				if (isCameraAvailable)
				{
					if (Build.VERSION.SdkInt >= BuildVersionCodes.Gingerbread)
					{
						isCameraAvailable |= activity.PackageManager.HasSystemFeature(PackageManager.FeatureCameraFront);
					}
					try
					{
						var intent = new Intent(activity, typeof(ICameraGalleryServiceActivity));
						intent.PutExtra("id", 1);
						activity.StartActivity(intent);
						//intent = new Intent(MediaStore.ActionImageCapture);
						//intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
						//intent.PutExtra("_intent", intent);
						//intent = new Intent(MediaStore.ActionImageCapture);
						//intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
						//activity.StartActivityForResult(intent, 1);
						//activity.StartActivityForResult(intent, 1);
						//bndle.PutSerializable("this_intent", intent);

						//var path = file.AbsolutePath;

						//mtco.ShowImageAndroid(path);
					}
					catch (Exception ex)
					{
						var msg = ex.Message;
					}

				}

			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public void ShowSelectedImageDroidSplOne(MyImageDisplay _myimagedisplay)
		{
			var activity = Forms.Context as Activity;
			try
			{
				var intent = new Intent(activity, typeof(ICameraGalleryServiceActivity));
				intent.PutExtra("id", 2);
				activity.StartActivity(intent);
				////Intent = new Intent();
				//intent.SetType("image/*");
				////Intent.PutExtra(Intent.ActionSendMultiple, true);
				////Intent.PutExtra(Intent.ExtraAllowMultiple, true);
				//intent.SetAction(Intent.ActionGetContent);
				//activity.StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), 2);

			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}



	[Activity(Label = "ICameraGalleryServiceActivity")]
	public class ICameraGalleryServiceActivity : Activity
	{
		static readonly File file = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "tmp.jpg");

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			int _id = Intent.GetIntExtra("id", 0);
			Intent intent = new Intent();
			if (_id == 1)
			{
				intent.SetAction(MediaStore.ActionImageCapture);
				intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
				StartActivityForResult(intent, _id);
			}
			else if (_id == 2)
			{

				if (Build.VERSION.SdkInt < BuildVersionCodes.Kitkat)
				{
					intent = new Intent();
					intent.SetType("image/*");
					intent.SetAction(Intent.ActionGetContent);
					StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), 2);
				}
				else
				{
					intent = new Intent();
					intent.SetType("image/*");
					intent.SetAction(Intent.ActionOpenDocument);
					intent.AddCategory(Intent.CategoryOpenable);
					StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), 2);
				}

				#region general
				/*intent.SetType("image/*");
				//Intent.PutExtra(Intent.ActionSendMultiple, true);
				//Intent.PutExtra(Intent.ExtraAllowMultiple, true);
				intent.SetAction(Intent.ActionGetContent);
				StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), 2);*/
				#endregion
			}
			else
			{
				Finish();
			}


		}

		protected async override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			try
			{
				string uuuri = file.ToString();
				base.OnActivityResult(requestCode, resultCode, data);
				if (requestCode == 2)
				{
					if (resultCode == Result.Ok)
					{
						try
						{
							var uri1 = data.Data;
							uuuri = await getRealPathFromURI(this, uri1);
							//getFileNameByUri(this, uri1);
							//var uuuri = getImagePath(this, uri1);
							//MyImageDisplay.mid.ShowImageDroid(uuuri);
							//Finish();
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
						uuuri = file.ToString();
						//var uri1 = data.Data;
						//var uuuri = getRealPathFromURI(this, uri1);
						//getFileNameByUri(this, uri1);
						//var uuuri = getImagePath(this, uri1);
						//MyImageDisplay.mid.ShowImageDroid(file.ToString());
						//Finish();
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

				try
				{
					#region 
					var _file = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "Display.jpg");
					var _uuuri = _file.ToString();
					Bitmap originalImage;
					BitmapFactory.Options options = new BitmapFactory.Options();
					//options.InPreferredConfig = Android.Graphics.Bitmap.Config.Rgb565;// this decreases the image temp size and avoides exception out of memory
					options.InJustDecodeBounds = true;
					//options.InTempStorage = new byte[16 * 1024]; //use if any error occurs more frequently
					originalImage = BitmapFactory.DecodeFile(uuuri, options);
					//options.InSampleSize = 2;

					#region For Screen Height & Width
					var pixels = Resources.DisplayMetrics.WidthPixels;
					var scale = Resources.DisplayMetrics.Density;

					var dps = (double)((pixels - 0.5f) / scale);

					int reqWidth = ((int)dps) - 20;

					pixels = Resources.DisplayMetrics.HeightPixels;
					dps = (double)((pixels - 0.5f) / scale);

					int reqHeight = ((int)dps) - 20;
					#endregion

					int actualWidth = options.OutWidth;
					int actualHeight = options.OutHeight;
					options.InSampleSize = await CalculateInSampleSize(options, reqHeight, reqWidth);
					options.InJustDecodeBounds = false;

					//var imagestream = Forms.Context.ContentResolver.OpenInputStream(data.Data);
					//Bitmap originalImage = BitmapFactory.DecodeStream(imagestream);
					//Bitmap originalImage = BitmapFactory.DecodeFile(uuuri, options);
					originalImage = BitmapFactory.DecodeFile(uuuri, options);
					Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, reqWidth, reqHeight, false);
					using (System.IO.Stream stream = System.IO.File.Create(_uuuri))
					{
						//var filedone = resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
						var filedone = resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 30, stream);
						MyImageDisplay.mid.ShowImageDroid(_uuuri);
						if (originalImage != null)
						{
							originalImage.Recycle();
							originalImage = null;
							//originalImage.Dispose();
							options = null;
							System.GC.Collect();
						}
					}
					//originalImage.Dispose();
					Finish();
					#endregion
				}
				catch (Exception ex)
				{
					var msg = ex.Message;
				}

			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}



		public async Task<int> CalculateInSampleSize(BitmapFactory.Options options, int reqHeight, int reqWidth)
		{
			int height = options.OutHeight;
			int width = options.OutWidth;
			int inSampleSize = 1;
			if (height > reqHeight || width > reqWidth)
			{

				int halfHeight = height / 2;
				int halfWidth = width / 2;

				// Calculate the largest inSampleSize value that is a power of 2 and keeps both
				// height and width larger than the requested height and width.
				while ((halfHeight / inSampleSize) >= reqHeight
						&& (halfWidth / inSampleSize) >= reqWidth)
				{
					inSampleSize *= 2;
				}
			}

			return inSampleSize;
		}


		public async Task<string> getRealPathFromURI(Context context, Android.Net.Uri contentURI)
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

		public override void OnBackPressed()
		{
			base.OnBackPressed();
			Finish();
		}
	}
}
