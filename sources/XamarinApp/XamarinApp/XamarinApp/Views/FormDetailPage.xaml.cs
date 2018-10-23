using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinApp.ViewModels;



// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace XamarinApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormDetailPage : ContentPage
    {
        FormDetailViewModel viewModel;

        public FormDetailPage(FormDetailViewModel viewModel)
        {
            InitializeComponent();

            viewModel.Title = "Edit";
            viewModel.navigation = this.Navigation;
            BindingContext = this.viewModel = viewModel;

        }

        public FormDetailPage()
        {
            InitializeComponent();

            viewModel = new FormDetailViewModel();

            viewModel.Title = "New";
            viewModel.navigation = this.Navigation;

            BindingContext = viewModel;


        }
    }
}
