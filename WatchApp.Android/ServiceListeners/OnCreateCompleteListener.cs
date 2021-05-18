using Android.Gms.Tasks;
using Firebase.Firestore;
using System.Threading.Tasks;

namespace WatchApp.Droid.ServiceListeners
{
    public class OnCreateCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<bool> _tcs;

        public OnCreateCompleteListener(TaskCompletionSource<bool> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                if (task.Result is DocumentReference doc)
                {
                    _tcs.TrySetResult(true);
                    return;
                }
            }
            _tcs.TrySetResult(false);
        }
    }
}