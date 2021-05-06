using System.IO;
using System.Threading.Tasks;

namespace WatchApp.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
