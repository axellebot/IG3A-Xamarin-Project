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
        TodoItemViewModel viewModel;

        public TodoItemEditPage(TodoItemViewModel viewModel)
        {
            InitializeComponent();

            viewModel.Title = "Edit Task";
            BindingContext = this.viewModel = viewModel;
        }

        public TodoItemEditPage()
        {
            InitializeComponent();

            viewModel = new TodoItemViewModel();

            viewModel.Title = "New Task";
            BindingContext = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            viewModel.SaveItemCommand.Execute(null);

            if (viewModel.IsDeletable)
            {
                MessagingCenter.Send(this, "UpdateTodoItem", viewModel.TodoItemModel);
                await Navigation.PopAsync();
            }
            else
            {
                MessagingCenter.Send(this, "CreateTodoItem", viewModel.TodoItemModel);
                await Navigation.PopModalAsync();
            }
        }
        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteTodoItem", viewModel.TodoItemModel);
            if (viewModel.IsDeletable)
            {
                await Navigation.PopAsync();
            }
            else
            {
                await Navigation.PopModalAsync();
            }
            viewModel.DeleteItemCommand.Execute(null);
        }
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            if (viewModel.IsDeletable)
            {
                await Navigation.PopAsync();
            }
            else
            {
                await Navigation.PopModalAsync();
            }
        }
    }
}