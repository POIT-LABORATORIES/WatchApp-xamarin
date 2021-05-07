using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Firestore;
using Firebase.Storage;
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
            // Закачать картинку, ожидать загрузки с пом. await. Проверить результат.
            // В качестве пути загрузки: (@"images/${item.Name}-avatar")
            //StorageReference imageRef = FirebaseStorage.Instance.GetReference("").Child($"images/{item.Name}-avatar");
            //var uploadTask = imageRef.PutStream(item.ImageStream);

            var uploadTask = FirebaseStorage.Instance.GetReference($"images/{item.Name}-avatar").PutStream(item.ImageStream);

            //Task<Uri> urlTask = uploadTask.ContinueWithTask().AddOnCompleteListener();


            // Сохранить полученный URI в AvatarUrl, залить в Firestore.
            throw new NotImplementedException();
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