using System.ComponentModel;
using WatchApp.ViewModels;
using Xamarin.Forms;

namespace WatchApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}