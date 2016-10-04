using System;
using DronaApp.iOS;
using Foundation;
using MessageUI;
using UIKit;
using Xamarin.Forms;

/*using System.Net.Mail;
using System.Collections.Generic;
using System.Net;
using System.Collections;*/
[assembly: Dependency(typeof(IEmailService))]
namespace DronaApp.iOS
{
	public class IEmailService : IEmail
	{
		public IEmailService()
		{
		}

		public void ShareFile(string name, string mimeType)
		{
			try
			{
				MFMailComposeViewController messageController = new MFMailComposeViewController();
				if (MFMessageComposeViewController.CanSendAttachments)
				{
					string filename = name;
					NSData data = NSData.FromUrl(NSUrl.FromString(filename));

					messageController.SetSubject("Document: " + filename);
					messageController.SetMessageBody("Document: " + filename, false);
					messageController.AddAttachmentData(data, mimeType, filename);

					messageController.Finished += (object s, MFComposeResultEventArgs args) =>
					{
						if (args.Result == MFMailComposeResult.Sent)
						{
							UIAlertView alert = new UIAlertView("Success", "The file has been sent successfully", null, "Close", null);
							alert.Show();
						}

						args.Controller.DismissViewController(true, null);
					};

					UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(messageController, true, null);
				}
				else {
					UIAlertView alert = new UIAlertView("Error", "The file could not be sent", null, "Close", null);
					alert.Show();
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}
}

