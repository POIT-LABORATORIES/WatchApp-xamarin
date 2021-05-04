using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchApp.Droid.Extensions;
using WatchApp.Models;
using WatchApp.Services;

namespace WatchApp.Droid.ServiceListeners
{
    class OnCollectionCompleteListener<T>: Java.Lang.Object, IOnCompleteListener where T : IIdentifiable
    {
        private System.Threading.Tasks.TaskCompletionSource<IEnumerable<T>> _tcs;

        public OnCollectionCompleteListener(System.Threading.Tasks.TaskCompletionSource<IEnumerable<T>> tcs)
        {
            _tcs = tcs;
        }


        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var docsObj = task.Result;
                if (docsObj is QuerySnapshot docs)
                {
                    _tcs.TrySetResult(docs.Convert<T>());
                }
            }
        }
    }
}