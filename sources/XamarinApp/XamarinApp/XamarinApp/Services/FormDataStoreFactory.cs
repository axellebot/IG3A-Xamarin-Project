using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.Services
{

    public class FormDataStoreFactory
    {
        string dbPath = "FormSQLite.db3";

        public IDataStore<FormItemModel> Create()
        {
            return CreateDiskDataStore();
        }

        public IDataStore<FormItemModel> CreateDiskDataStore()
        {
            return new FormDiskDataStore(DependencyService.Get<IFileHelper>().GetLocalFilePath(dbPath));
        }

        public IDataStore<FormItemModel> CreateCacheDataStore()
        {
            return new FormCacheDataStore();
        }
    }

}
