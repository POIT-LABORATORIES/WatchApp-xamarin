using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using WatchApp.Models;
using System.Diagnostics;
using WatchApp.Services;

namespace WatchApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        public MapPage()
        {
            InitializeComponent();
            InitMap();
        }

        async void InitMap()
        {
            Content = await LoadPins();
        }

        async Task<Map> LoadPins()
        {
            IsBusy = true;

            Map map = new Map { };

            try
            {
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Pin pin = new Pin
                    {
                        Label = item.Name,
                        Address = $"Latitude: {item.Latitude}, Longitude: {item.Longitude}",
                        Type = PinType.Place,
                        Position = new Position(item.Latitude, item.Longitude)
                    };
                    map.Pins.Add(pin);
                }
                return map;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return map;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}