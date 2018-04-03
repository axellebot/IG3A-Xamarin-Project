using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemDetailPage : ContentPage
    {
        TodoItemDetailViewModel viewModel;

        public TodoItemDetailPage(TodoItemDetailViewModel viewModel)
        {
            InitializeComponent();
            
            BindingContext = this.viewModel = viewModel;
        }

        async void EditItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new TodoItemEditPage(new TodoItemEditViewModel(viewModel.TodoItem))));
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteTodoItem", viewModel.TodoItem);
            await Navigation.PopAsync();
        }
    }
}