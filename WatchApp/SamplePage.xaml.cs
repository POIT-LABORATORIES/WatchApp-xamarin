using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchApp.Models;
using WatchApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatchApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SamplePage : ContentPage
    {
        public IDataStore<Item> dataStore => DependencyService.Get<IDataStore<Item>>();

        public SamplePage()
        {
            InitializeComponent();
            var item = dataStore.GetItemAsync("456CE18E-8553-4B16-B726-7E0BCB706722");
            if (item != null)
            {
                Console.WriteLine(item);
            }
            else
            {
                Console.WriteLine("Cannot get item async");
            }
        }
    }
}