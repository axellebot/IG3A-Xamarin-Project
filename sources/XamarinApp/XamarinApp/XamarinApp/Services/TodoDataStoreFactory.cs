using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApp.Models;

namespace XamarinApp.Services
{
    public class TodoDataStoreFactory
    {
        string dbPath = "TodoSQLite.db3";
          
        public IDataStore<TodoItem> Create()
        {
            return CreateDiskDataStore();
        }

        public IDataStore<TodoItem> CreateDiskDataStore()
        {
            return new TodoDiskDataStore(DependencyService.Get<IFileHelper>().GetLocalFilePath(dbPath));
        }

        public IDataStore<TodoItem> CreateCacheDataStore()
        {
            return new TodoCacheDataStore();
        }
    }
}
