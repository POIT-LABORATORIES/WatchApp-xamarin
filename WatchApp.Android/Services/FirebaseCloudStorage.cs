using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchApp.Droid.ServiceListeners;
using WatchApp.Services;

namespace WatchApp.Droid.Services
{
    public static class FirebaseCloudStorage
    {
        public static Task<string> UploadImage(Stream imageStream, string storagePath)
        {
            var tcs = new TaskCompletionSource<string>();

            StorageReference storageRef = FirebaseStorage.Instance.GetReference(storagePath);
            var uploadTask = storageRef.PutStream(imageStream);
            uploadTask.AddOnCompleteListener(new OnUploadImageCompleteListener(tcs, storageRef));

            return tcs.Task;
        }
    }
}