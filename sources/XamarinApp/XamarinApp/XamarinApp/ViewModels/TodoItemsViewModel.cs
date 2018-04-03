using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class TodoItemsViewModel : TodoBaseViewModel
    {
        public ObservableCollection<TodoItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TodoItemsViewModel()
        {
            Title = "Todo List";
            Items = new ObservableCollection<TodoItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<TodoItemEditPage, TodoItem>(this, "CreateTodoItem", async (obj, item) =>
            {
                var _item = item as TodoItem;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });

            MessagingCenter.Subscribe<TodoItemDetailPage, TodoItem>(this, "DeleteTodoItem", async (obj, item) =>
            {
                var _item = item as TodoItem;
                Items.Remove(_item);
                await DataStore.DeleteItemAsync(_item);
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
