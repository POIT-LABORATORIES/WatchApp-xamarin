using System;
using System.Collections.Generic;
using System.Text;

namespace WatchApp.Services
{
    public static class DatabaseKey
    {
        public static class FirebaseFirestore
        {
            public static class Collection
            {
                public static readonly String Watches = "watches";
                public static readonly String Users = "users";
            }

            public static class WatchField
            {
                public static readonly String Name = "name";
                public static readonly String Style = "style";
                public static readonly String CaseColor = "caseColor";
                public static readonly String CaseMaterial = "caseMaterial";
                public static readonly String AvatarUrl = "avatarUrl";
                public static readonly String Description = "description";
                public static readonly String Longitude = "longitude";
                public static readonly String Latitude = "latitude";
            }
        }       
    }
}
