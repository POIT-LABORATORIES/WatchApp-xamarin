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
        public Task<bool> AddItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var tcs = new TaskCompletionSource<Item>();

            FirebaseFirestore.Instance
                .Collection(DatabaseKey.FirebaseFirestore.Collection.Watches)
                .Document(id)
                .Get()
                .AddOnCompleteListener(new OnCompleteListener<Item>(tcs));

            return await tcs.Task;
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