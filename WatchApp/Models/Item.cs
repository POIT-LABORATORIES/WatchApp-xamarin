using System;
using WatchApp.Services;

namespace WatchApp.Models
{
    public class Item: IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string CaseColor { get; set; }
        public string CaseMaterial { get; set; }
        public string AvatarUrl { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
    }
}