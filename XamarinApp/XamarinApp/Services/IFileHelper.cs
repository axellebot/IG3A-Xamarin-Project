using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
