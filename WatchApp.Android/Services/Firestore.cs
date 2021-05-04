using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Firestore;
using Java.Lang;

namespace WatchApp.Droid.Services
{
    class Firestore
    {
        /*
        private static T Cast<T>(DocumentSnapshot doc)
        {
            var instance = Activator.CreateInstance<T>();

            var baseData = doc.Data;
            foreach (var key in baseData.Keys)
            {
                // ToDo: Error handling
                var prop = typeof(T).GetProperty(key);
                var propType = prop.PropertyType;
                prop.SetValue(instance, TypeMapper[propType](baseData[key]));
            }

            return instance;
        }

        public static Task<IEnumerable<T>> GetCollectionAsync<T>(this CollectionReference reference) where T : class
        {
            var tcs = new TaskCompletionSource<IEnumerable<T>>();

            reference
                .Get()
                .AddOnCompleteListener(new OnCompleteEventHandleListener((Android.Gms.Tasks.Task obj) =>
            {
                if (obj.IsSuccessful)
                {
                    var res = obj.GetResult(Class.FromType(typeof(QuerySnapshot))).JavaCast<QuerySnapshot>();
                    tcs.SetResult(res.Documents.Select((doc) => Cast<T>(doc)).ToList());
                }
                else
                {
                    tcs.SetException(obj.Exception);
                }
            }));

            return tcs.Task;
        }
        */
    }
}