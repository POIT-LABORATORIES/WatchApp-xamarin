using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatchApp.Services;

namespace WatchApp.Droid.Extensions
{
    public static class DocumentReferenceExtensions
    {
        public static T Convert<T>(this DocumentSnapshot doc) where T: IIdentifiable
        {
            try
            {
                //var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(doc.Data.ToDictionary());

                var map = doc.Data;
                GoogleGson.Gson gson = new GoogleGson.GsonBuilder().Create();
                string stringOfT = gson.ToJson(new Java.Util.HashMap((System.Collections.IDictionary)map));
                //System.Diagnostics.Debug.WriteLine("Serialized data: " + stringOfT);
                var item = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(stringOfT);
                item.Id = doc.Id;

                //System.Diagnostics.Debug.WriteLine("");
                //System.Diagnostics.Debug.WriteLine("DESERIALIZED item: " + item);
                //System.Diagnostics.Debug.WriteLine("");

                return item;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR (DocumentReferenceExtensions.Convert<T>): " + e.Message);
            }
            return default;

            /*
            try
            {
                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(doc.Data.ToDictionary());
                System.Diagnostics.Debug.WriteLine("Serialized data: " + jsonStr);
                var item = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
                item.Id = doc.Id;
                return item;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR (DocumentReferenceExtensions.Convert<T>): " + e.Message);
            }
            return default;
            */
        }

        public static List<T> Convert<T>(this QuerySnapshot docs) where T : IIdentifiable
        {
            var list = new List<T>();
            foreach (var doc in docs.Documents)
            {
                System.Diagnostics.Debug.WriteLine("Query data: " + doc); // ДАННЫЕ ПОЛУЧЕНЫ УСПЕШНО
                list.Add(doc.Convert<T>());
            }
            return list;
        }
    }
}