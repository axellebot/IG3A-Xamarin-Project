using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp.ViewModels
{
    public class TodoBaseViewModel : ObservableViewModel
    {
        public IDataStore<TodoItemModel> DataStore = (new TodoDataStoreFactory()).Create();

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetAndNotify(ref isBusy, value); }
        }

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetAndNotify(ref title, value); }
        }
    }
}
