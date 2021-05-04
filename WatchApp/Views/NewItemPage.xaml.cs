using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WatchApp.Models;
using WatchApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatchApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
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
    }
}