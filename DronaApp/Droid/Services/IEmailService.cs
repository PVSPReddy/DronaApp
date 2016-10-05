using System;
using Android.Content;
using DronaApp.Droid;
using Xamarin.Forms;

[assembly : Dependency(typeof(IEmailService))]
namespace DronaApp.Droid
{
	public class IEmailService : IEmail
	{
		public IEmailService()
		{
		}

		public void ShareFile(string name, string mimeType)
		{
			var file = new Java.IO.File(name);
			var email = new Intent(Android.Content.Intent.ActionSend);
			email.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(file));
			file.SetReadable(true, false);
			email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { "person1@xamarin.com", "person2@xamrin.com" });
			email.PutExtra(Android.Content.Intent.ExtraCc, new string[] { "person3@xamarin.com" });
			email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello Email");
			email.PutExtra(Android.Content.Intent.ExtraText, "Hello from Xamarin.Android");
			email.SetType("message/rfc822");
			Forms.Context.StartActivity(Intent.CreateChooser(email, "send email..."));
		}
	}
}


