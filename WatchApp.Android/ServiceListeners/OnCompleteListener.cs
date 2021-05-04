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
    class OnCompleteListener<T>: Java.Lang.Object, IOnCompleteListener where T: IIdentifiable
    {
        private TaskCompletionSource<T> _tcs;
        public OnCompleteListener(TaskCompletionSource<T> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var docObj = task.Result;
                if (docObj is DocumentSnapshot doc)
                {
                    _tcs.TrySetResult(doc.Convert<T>());
                    return;

                    /*
                    var item = new Item
                    {
                        Id = doc.Id,
                        Name = doc.GetString(DatabaseKey.FirebaseFirestore.WatchField.Name),
                        Style = doc.GetString(DatabaseKey.FirebaseFirestore.WatchField.Style),
                        CaseColor = doc.GetString(DatabaseKey.FirebaseFirestore.WatchField.CaseColor),
                        CaseMaterial = doc.GetString(DatabaseKey.FirebaseFirestore.WatchField.CaseMaterial),
                        Description = doc.GetString(DatabaseKey.FirebaseFirestore.WatchField.Description),
                        AvatarUrl = doc.GetString(DatabaseKey.FirebaseFirestore.WatchField.AvatarUrl),
                        Latitude = (double)doc.GetDouble(DatabaseKey.FirebaseFirestore.WatchField.Latitude),
                        Longitude = (double)doc.GetDouble(DatabaseKey.FirebaseFirestore.WatchField.Longitude),
                        Text = "Some random text"
                    };
                    _tcs.TrySetResult(item);
                    return;
                    */
                }
            } 
            else
            {
                _tcs.TrySetResult(default(T));
            }
        }
    }
}