using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DronaApp
{
    public class CheckNetworkAvailability
	{
		public async Task<bool> IsNetworkConnected()
		{
			bool retVal = false;

			try
			{
                retVal = await DependencyService.Get<IInternetCheck>().IsNetworkAvailable();
				return retVal;
			}
			catch (Exception ex)
			{
                var msg = ex.Message;
                return false;
				//System.Diagnostics.Debug.WriteLine(ex.Message);
				//throw ex;
			}
		}

        /*
		public static async Task<bool> IsHostReached()
		{
			bool retVal = false;
			try
			{
				retVal = await CrossConnectivity.Current.IsReachable("http://www.google.com/");
				return retVal;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				throw ex;
			}
		}
		*/
	}
}