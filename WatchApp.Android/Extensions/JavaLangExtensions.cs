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

namespace WatchApp.Droid.Extensions
{
    public static class JavaLangExtensions
    {
        public static IDictionary<string, object> ToDictionary(this IDictionary<string, Java.Lang.Object> map)
        {
            var dict = new Dictionary<string, object>();

            foreach (var key in map.Keys)
            {
                var value = map[key];

            }

            return dict;
        }
    }
}