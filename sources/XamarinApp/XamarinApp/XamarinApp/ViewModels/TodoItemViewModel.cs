using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class TodoItemViewModel : TodoBaseViewModel
    {
        public Command SaveItemCommand { get; set; }
        public Command DeleteItemCommand { get; set; }

        private bool isDeletable = false;
        public bool IsDeletable
        {
            get { return isDeletable; }
            set { SetAndNotify(ref isDeletable, value); }
        }

        private TodoItemModel todoItemModel = null;
        public TodoItemModel TodoItemModel {
            get { return todoItemModel; }
            set { SetAndNotify(ref todoItemModel, value); }
        }

        public TodoItemViewModel(TodoItemModel todoItemModel = null)
        {
            if (todoItemModel == null) {
                TodoItemModel = new TodoItemModel();
                IsDeletable = false;
            }
            else
            {
                TodoItemModel = todoItemModel;
                IsDeletable = true;
            }

            Title = TodoItemModel?.Name;

            SaveItemCommand = new Command(async () => await SaveItemCommandAsync());
            DeleteItemCommand = new Command(async () => await ExecuteDeleteItemCommandAsync());
        }

        private async Task SaveItemCommandAsync()
        {
            if (IsDeletable) {
                await DataStore.UpdateItemAsync(TodoItemModel);
            }
            else
            {
                await DataStore.AddItemAsync(TodoItemModel);
            }
        }
        private async Task ExecuteDeleteItemCommandAsync()
        {
            if (IsDeletable) {
                await DataStore.DeleteItemAsync(TodoItemModel);
            };
        }
    }
}
