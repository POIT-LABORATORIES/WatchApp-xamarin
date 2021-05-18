using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WatchApp.Services
{
    public interface IImageUploaderService
    {
        Task<string> UploadImage(Stream imageStream, string storagePath);
    }
}
