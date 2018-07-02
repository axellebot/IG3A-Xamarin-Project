using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace XamarinApp.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormItemCell : ViewCell
    {
        // Needed by CellRenderer
        public FormItemCell()
        {
            InitializeComponent();
        }

        public FormItemCell(FormItemCellViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
