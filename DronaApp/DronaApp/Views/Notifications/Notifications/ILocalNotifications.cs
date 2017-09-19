using System;
using System.Threading.Tasks;
namespace DronaApp
{
    public interface ILocalNotifications
    {
        Task<bool> GetNotificationImmediately();
    }
}
