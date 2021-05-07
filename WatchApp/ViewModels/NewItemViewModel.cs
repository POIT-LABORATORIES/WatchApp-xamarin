using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Input;
using WatchApp.Models;
using Xamarin.Forms;

namespace WatchApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string name;
        private string style;
        private string caseColor;
        private string caseMaterial;
        private double latitude;
        private double longitude;
        private string description;
        //private ImageSource imageStreamSource;
        private Stream imageStream;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(style)
                && !String.IsNullOrWhiteSpace(caseColor)
                && !String.IsNullOrWhiteSpace(caseMaterial)
                && !String.IsNullOrWhiteSpace(description)
                && (imageStream != null);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Style
        {
            get => style;
            set => SetProperty(ref style, value);
        }

        public string CaseColor
        {
            get => caseColor;
            set => SetProperty(ref caseColor, value);
        }

        public string CaseMaterial
        {
            get => caseMaterial;
            set => SetProperty(ref caseMaterial, value);
        }

        public double Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }

        public double Longitude
        {
            get => longitude;
            set
            {
                SetProperty(ref longitude, value);
            }
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Stream ImageStream
        {
            get => imageStream;
            set => SetProperty(ref imageStream, value);
        }

        /*
        public ImageSource ImageStreamSource
        {
            get => imageStreamSource;
            set => SetProperty(ref imageStreamSource, value);
        }
        */

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Style = Style,
                CaseColor = CaseColor,
                CaseMaterial = CaseMaterial,
                Latitude = Latitude,
                Longitude = Longitude,
                Description = Description,
                ImageStream = ImageStream
            };

            if (newItem.ImageStream != null)
                Debug.WriteLine("Image Stream is not null");

            //await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
        }
    }
}
