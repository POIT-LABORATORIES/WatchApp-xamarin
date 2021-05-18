using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WatchApp.Models;
using WatchApp.Services;

namespace WatchApp.Droid.ServiceListeners
{
    public static class IIdentifiableExtensions
    {
        //Dictionary<string, Java.Lang.Object>
        public static Java.Util.HashMap Convert(this IIdentifiable item)
        {
            var dict = new Dictionary<string, Java.Lang.Object>();
            //var dict = new Java.Util.HashMap(dictionary);

            System.Diagnostics.Debug.WriteLine("\n\nConverting item\n\n"); //МУСОР

            var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);

            System.Diagnostics.Debug.WriteLine("\n\nNewtonsoft.SerializeObject result -> " + jsonStr + "\n\n"); //МУСОР

            var propertyDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr);

            System.Diagnostics.Debug.WriteLine("\n\nNewtonsoft.DeserializeObject result -> " + propertyDict + "\n\n"); //МУСОР



            foreach (var key in propertyDict.Keys)
            {
                System.Diagnostics.Debug.WriteLine("\n\nKey value -> " + key); //МУСОР

                if (key.Equals("Id"))
                    continue;
                var val = propertyDict[key];
                Java.Lang.Object javaVal = null;
                if (val is string str)
                    javaVal = new Java.Lang.String(str);
                else if (val is double dbl)
                    javaVal = new Java.Lang.Double(dbl);
                else if (val is int intVal)
                    javaVal = new Java.Lang.Integer(intVal);
                else if (val is DateTime dt)
                    javaVal = dt.ToString();
                else if (val is bool boolVal)
                    javaVal = new Java.Lang.Boolean(boolVal);
                else if (val is Stream stream)
                    continue;

                if (javaVal != null)
                {
                    System.Diagnostics.Debug.WriteLine("Java object value -> " + javaVal); //МУСОР
                    dict.Add(key, javaVal);
                    //dict.Put(key, javaVal);
                }
            }

            var javaDict = new Java.Util.HashMap(dict);
            return javaDict;
        }
    }
}