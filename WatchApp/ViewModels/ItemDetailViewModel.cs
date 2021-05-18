using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WatchApp.Models;
using Xamarin.Forms;

namespace WatchApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string name;
        private string style;
        private string caseColor;
        private string caseMaterial;
        private string avatarUrl;
        private string description;

        public string Id { get; set; }

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

        public string AvatarUrl
        {
            get => avatarUrl;
            set => SetProperty(ref avatarUrl, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Style = item.Style;
                CaseColor = item.CaseColor;
                CaseMaterial = item.CaseMaterial;
                AvatarUrl = item.AvatarUrl;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
