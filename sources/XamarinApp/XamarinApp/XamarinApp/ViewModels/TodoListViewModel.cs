using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class TodoListViewModel : TodoBaseViewModel
    {
        public ObservableCollection<TodoItemModel> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public TodoListViewModel()
        {
            Title = "Todo List";
            Items = new ObservableCollection<TodoItemModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<TodoItemEditPage, TodoItemModel>(this, "UpdateTodoItem",  (obj, item) =>
            {
                LoadItemsCommand.Execute(null);
            });

            MessagingCenter.Subscribe<TodoItemEditPage, TodoItemModel>(this, "CreateTodoItem",  (obj, item) =>
            {
                var _item = item as TodoItemModel;
                Items.Add(_item);
            });

            MessagingCenter.Subscribe<TodoItemEditPage, TodoItemModel>(this, "DeleteTodoItem",  (obj, item) =>
            {
                var _item = item as TodoItemModel;
                Items.Remove(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
