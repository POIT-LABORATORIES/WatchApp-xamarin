using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchApp.Droid.ServiceListeners
{
    class OnUploadImageCompleteListener: Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<string> _tcs;
        private StorageReference _storageReference;
        
        public OnUploadImageCompleteListener(TaskCompletionSource<string> tcs, StorageReference storageReference)
        {
            _tcs = tcs;
            _storageReference = storageReference;
        }
        

        public async void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var imageUrl = await _storageReference.GetDownloadUrlAsync();
                string imageUrlString = imageUrl.ToString();
                _tcs.TrySetResult(imageUrl.ToString());
            }
        }
    }
}