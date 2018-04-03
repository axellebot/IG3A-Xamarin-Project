using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinApp.Models;
using XamarinApp.Views;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
	public partial class TodoItemsPage : ContentPage
    {
        TodoItemsViewModel viewModel;

        public TodoItemsPage()
		{
			InitializeComponent();

            BindingContext = viewModel = new TodoItemsViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as TodoItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new TodoItemDetailPage(new TodoItemDetailViewModel(item)));

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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
