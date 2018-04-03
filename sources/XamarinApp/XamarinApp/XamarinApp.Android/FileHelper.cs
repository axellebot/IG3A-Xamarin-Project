using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Xamarin.Forms;
using XamarinApp.Services;
using XamarinApp.Droid;

[assembly: Dependency(typeof(FileHelper))]
namespace XamarinApp.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}