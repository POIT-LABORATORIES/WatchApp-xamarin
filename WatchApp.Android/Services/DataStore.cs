using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Firestore;
using Firebase.Storage;
using Java.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchApp.Droid.ServiceListeners;
using WatchApp.Models;
using WatchApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(WatchApp.Droid.Services.DataStore))]
namespace WatchApp.Droid.Services
{
    class DataStore : IDataStore<Item>
    {
        public async Task<bool> AddItemAsync(Item item)
        {
            item.AvatarUrl = await FirebaseCloudStorage.UploadImage(item.ImageStream, $"images/{item.Name}-avatar");

            System.Diagnostics.Debug.WriteLine("\n\nDataStore.AddItemAsync: image URL is " + item.AvatarUrl + "\n\n");

            /*
            Item newItem = new Item()
            {
                Id = item.Id,
                Name = item.Name,
                Style = item.Style,
                CaseColor = item.CaseColor,
                CaseMaterial = item.CaseMaterial,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                AvatarUrl = item.AvatarUrl,
                Description = item.Description
            };
            */

            item.ImageStream = null;

            var tcs = new TaskCompletionSource<bool>();

            FirebaseFirestore.Instance
                .Collection(DatabaseKey.FirebaseFirestore.Collection.Watches)
                .Add(item.Convert())
                .AddOnCompleteListener(new OnCreateCompleteListener(tcs));

             return await tcs.Task;
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(string id)
        {
            var tcs = new TaskCompletionSource<Item>();

            FirebaseFirestore.Instance
                .Collection(DatabaseKey.FirebaseFirestore.Collection.Watches)
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnCompleteListener<Item>(tcs));

            return tcs.Task;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            var tcs = new TaskCompletionSource<IEnumerable<Item>>();
            var list = new List<Item>();

            FirebaseFirestore.Instance
                .Collection(DatabaseKey.FirebaseFirestore.Collection.Watches)
                .Get()
                .AddOnCompleteListener(new OnCollectionCompleteListener<Item>(tcs));

            return await tcs.Task;
        }

        public Task<bool> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}