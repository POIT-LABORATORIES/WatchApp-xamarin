using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using WatchApp.Models;
using WatchApp.Services;
using WatchApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatchApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        NewItemViewModel _viewModel;

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewItemViewModel();
        }

        private void NumericEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            try
            {
                Entry entry = (Entry)sender;

                Regex regex = new Regex(@"\d+\,\d+");
                if (!regex.IsMatch(entry.Text))
                {
                    entry.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                Debug.WriteLine("NewItemPage: Stream is " + stream);
                var image = new Image();
                image.Source = ImageSource.FromStream(() => stream);
                //_viewModel.ImageStreamSource
                //Item.ImageStream = stream;
                //Item.ImageStreamSource = ImageSource.FromStream(() => stream);
            } 
            else
            {
                Debug.WriteLine("NewItemPage: stream is NULL");
            }

            (sender as Button).IsEnabled = true;
        }
    }
}