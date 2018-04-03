 using System;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class TodoItemDetailViewModel : TodoBaseViewModel
    {
        public TodoItem TodoItem { get; set; }
        public TodoItemDetailViewModel(TodoItem todoItem = null)
        {
            Title = todoItem?.Text;
            TodoItem = todoItem;

            MessagingCenter.Subscribe<TodoItemEditPage, TodoItem>(this, "UpdateTodoItem", async (obj, item) =>
            {
                var _item = item as TodoItem;
                await DataStore.UpdateItemAsync(_item);
            });
        }
    }
}
