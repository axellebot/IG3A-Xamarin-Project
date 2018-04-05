using System;

using Xamarin.Forms;

using XamarinApp.Models;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
	public partial class TodoListPage : ContentPage
    {
        TodoListViewModel viewModel;

        public TodoListPage()
		{
			InitializeComponent();

            BindingContext = viewModel = new TodoListViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as TodoItemModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new TodoItemEditPage(new TodoItemViewModel(item)));

            // Manually deselect item.
            TodoItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new TodoItemEditPage()));
        }

        void RefreshItems_Clicked(object sender, EventArgs e)
        {
            viewModel.LoadItemsCommand.Execute(null);
            TodoItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
