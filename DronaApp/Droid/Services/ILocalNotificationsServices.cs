using System;
using System.Threading.Tasks;
using DronaApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ILocalNotificationsServices))]
namespace DronaApp.Droid
{
    public class ILocalNotificationsServices : ILocalNotifications
    {
        public ILocalNotificationsServices() { }

        public async Task<bool> GetNotificationImmediately()
        {
            bool isNotified = false;
            try
            {
                isNotified = true;
            }
            catch (Exception ex)
            {
                isNotified = false;
                var msg = ex.Message;
            }
            return isNotified;
        }
    }
}
