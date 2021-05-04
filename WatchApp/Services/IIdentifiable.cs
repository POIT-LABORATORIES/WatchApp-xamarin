using System;
using System.Collections.Generic;
using System.Text;

namespace WatchApp.Services
{
    public interface IIdentifiable
    {
        string Id { get; set; }
    }
}
