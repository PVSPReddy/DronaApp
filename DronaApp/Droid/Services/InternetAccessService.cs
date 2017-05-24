using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using DronaApp.Droid;
using Java.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(InternetAccessService))]
namespace DronaApp.Droid
{
    //here you have to add permission as <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
    //https://developer.xamarin.com/recipes/android/networking/detect-network-connection/
    public class InternetAccessService : IInternetCheck
    {
        public InternetAccessService(){}

        private ConnectivityManager connectivityManager;
        ConnectivityManager ConnectivityManager
        {
            get
            {
                if (connectivityManager == null || connectivityManager.Handle == IntPtr.Zero)
                {
                    connectivityManager = (ConnectivityManager)(Android.App.Application.Context.GetSystemService(Context.ConnectivityService));
                }

                return connectivityManager;
            }
        }

        public async Task<bool> IsRemoteReachable(string host, int port = 80, int msTimeout = 5000)
        {

            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentNullException("host");
            }


            var IsConnected = GetIsConnected(ConnectivityManager);
            if (!IsConnected)
            {
                return false;
            }

            host = host.Replace("http://www.", string.Empty).
                       Replace("http://", string.Empty).
                       Replace("https://www.", string.Empty).
                       Replace("https://", string.Empty).
                       TrimEnd('/');

            return await Task.Run(async () =>
            {
                try
                {
                    var tcs = new TaskCompletionSource<InetSocketAddress>();
                    new System.Threading.Thread(() =>
                    {
                        /* this line can take minutes when on wifi with poor or none internet connectivity
                        and Task.Delay solves it only if this is running on new thread (Task.Run does not help) */
                        InetSocketAddress result = new InetSocketAddress(host, port);

                        if (!tcs.Task.IsCompleted)
                            tcs.TrySetResult(result);

                    }).Start();

                    await Task.Run(async () =>
                    {
                        await Task.Delay(msTimeout);

                        if (!tcs.Task.IsCompleted)
                        {
                            tcs.TrySetResult(null);
                        }
                    });

                    var sockaddr = await tcs.Task;

                    if (sockaddr == null)
                    {
                        return false;
                    }

                    using (var sock = new Socket())
                    {
                        await sock.ConnectAsync(sockaddr, msTimeout);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    //Debug.WriteLine("Unable to reach: " + host + " Error: " + ex);
                    return false;
                }
            });
        }

        public bool GetIsConnected(ConnectivityManager manager)
        {
            try
            {

                //When on API 21+ need to use getAllNetworks, else fall base to GetAllNetworkInfo
                //https://developer.android.com/reference/android/net/ConnectivityManager.html#getAllNetworks()
                if ((int)Android.OS.Build.VERSION.SdkInt >= 21)
                {
                    foreach (var network in manager.GetAllNetworks())
                    {
                        var info = manager.GetNetworkInfo(network);

                        if (info?.IsConnected ?? false)
                            return true;
                    }
                }
                else
                {
                    foreach (var info in manager.GetAllNetworkInfo())
                    {
                        if (info?.IsConnected ?? false)
                           return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                //Debug.WriteLine("Unable to get connected state - do you have ACCESS_NETWORK_STATE permission? - error: {0}", e);
                return false;
            }
        }


        public async Task<bool> IsNetworkAvailable()
        {
            var manager = (ConnectivityManager)(Android.App.Application.Context.GetSystemService(Context.ConnectivityService));
            try
            {
                if ((int)Android.OS.Build.VERSION.SdkInt >= 21)
                {
                    foreach (var network in manager.GetAllNetworks())
                    {
                        var info = manager.GetNetworkInfo(network);

                        if (info?.IsConnected ?? false)
                            return true;
                    }
                }
                else
                {
                    foreach (var info in manager.GetAllNetworkInfo())
                    {
                        if (info?.IsConnected ?? false)
                           return true;
                    }
                }

                return false;
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }


        public async Task<bool> CheckInternetAccessState()
        {
            try
            {
                //add permissions in properties->AndroidManifest.xml "<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE"></uses-permission>"
                var activity = (Activity)Forms.Context;//use this line or use extend Activity at class level;
                var cms = (activity.GetSystemService(Context.ConnectivityService)) as ConnectivityManager;
                //ConnectivityManager cm = (GetSystemService(Context.ConnectivityService)) as ConnectivityManager;
                NetworkInfo networkInfo = cms.ActiveNetworkInfo;
                bool isOnline = networkInfo.IsConnected;
                return isOnline;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }

        public async Task<bool> CheckWifiAccessState()
        {
            try
            {
                var activity = (Activity)Forms.Context;//use this line or use extend Activity at class level;
                var cms = (activity.GetSystemService(Context.ConnectivityService)) as ConnectivityManager;
                //ConnectivityManager cm = (GetSystemService(Context.ConnectivityService)) as ConnectivityManager;
                NetworkInfo networkInfo = cms.ActiveNetworkInfo;
                bool isWifi = networkInfo.Type == ConnectivityType.Wifi;
                if (isWifi)
                {
                    return true;
                    //Log.Debug(TAG, "Wifi connected.");
                    //_wifiImage.SetImageResource(Resource.Drawable.green_square);
                }
                else
                {
                    return false;
                    //Log.Debug(TAG, "Wifi disconnected.");
                    //_wifiImage.SetImageResource(Resource.Drawable.red_square);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }

        public async Task<bool> CheckRomaing()
        {
            try
            {
                var activity = (Activity)Forms.Context;//use this line or use extend Activity at class level;
                var cms = (activity.GetSystemService(Context.ConnectivityService)) as ConnectivityManager;
                //ConnectivityManager cm = (GetSystemService(Context.ConnectivityService)) as ConnectivityManager;
                NetworkInfo networkInfo = cms.ActiveNetworkInfo;
                if (networkInfo.IsRoaming)
                {
                    //Log.Debug(TAG, "Roaming.");
                    //_roamingImage.SetImageResource(Resource.Drawable.green_square);
                }
                else
                {
                    //Log.Debug(TAG, "Not roaming.");
                    //_roamingImage.SetImageResource(Resource.Drawable.red_square);
                }
                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }
    }
}

