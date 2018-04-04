using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemEditPage : ContentPage
    {
        TodoItemEditViewModel viewModel;
        bool newItem = false;

        public TodoItemEditPage(TodoItemEditViewModel viewModel)
        {
            InitializeComponent();

            newItem = false;
            viewModel.Title = "Edit Task";
            BindingContext = this.viewModel = viewModel;
        }

        public TodoItemEditPage()
        {
              
            InitializeComponent();

            newItem = true;

            var todoItem = new TodoItem
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Task 1",
                Done = false
            };

            viewModel = new TodoItemEditViewModel(todoItem);

            viewModel.Title = "New Task";
            BindingContext = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (newItem)
            {
                MessagingCenter.Send(this, "CreateTodoItem", viewModel.TodoItem);
            }
            else
            {
                MessagingCenter.Send(this, "UpdateTodoItem", viewModel.TodoItem);
            }
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}