using System.IO;
using Windows.Storage;

using Xamarin.Forms;
using XamarinApp.Services;
using XamarinApp.UWP;

[assembly: Dependency(typeof(FileHelper))]
namespace XamarinApp.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
