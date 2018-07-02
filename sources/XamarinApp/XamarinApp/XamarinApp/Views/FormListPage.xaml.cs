using System;

using Xamarin.Forms;

using XamarinApp.Models;
using XamarinApp.ViewModels;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace XamarinApp.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public partial class FormListPage : ContentPage
    {
        FormListViewModel viewModel;
        public FormListPage()
        {
            this.InitializeComponent();
            viewModel = new FormListViewModel();
            viewModel.navigation = Navigation;
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}
