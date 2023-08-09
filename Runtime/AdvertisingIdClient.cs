using System;
using System.Threading.Tasks;
using UnityEngine;

namespace PrimePeaks.AdvertisingId {

    public class AdvertisingIdClient {
        
        public Task<AdvertisingIdInfo> GetAdvertisingIdInfoAsync() {
            var tsc = new TaskCompletionSource<AdvertisingIdInfo>();

            Task.Run(() => {
                try {
                    AndroidJNI.AttachCurrentThread();
                    var ctx = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                    var clientClass = new AndroidJavaClass("com.google.android.gms.ads.identifier.AdvertisingIdClient");
                    var client = clientClass.CallStatic<AndroidJavaObject>("getAdvertisingIdInfo", ctx);
                    tsc.SetResult(new AdvertisingIdInfo {
                        Id = client.Call<string>("getId"),
                        LimitAdTrackingEnabled = client.Call<bool>("isLimitAdTrackingEnabled")
                    });
                } catch (Exception e) {
                    tsc.SetException(e);
                } finally {
                    AndroidJNI.DetachCurrentThread();
                }
            });

            return tsc.Task;
        }
        
    }
    
}
