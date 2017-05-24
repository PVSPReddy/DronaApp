using System;
using System.Threading.Tasks;

namespace DronaApp
{
    public interface IInternetCheck
    {

        Task<bool> CheckInternetAccessState();

        Task<bool> CheckWifiAccessState();

        Task<bool> CheckRomaing();

        Task<bool> IsNetworkAvailable();

    }
}
