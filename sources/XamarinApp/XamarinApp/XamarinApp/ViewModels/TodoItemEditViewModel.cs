 using System;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class TodoItemEditViewModel : TodoBaseViewModel
    {
        public TodoItem TodoItem { get; set; }
        public TodoItemEditViewModel(TodoItem todoItem = null)
        {
            Title = todoItem?.Text;
            TodoItem = todoItem;
        }
    }
}
