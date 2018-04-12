using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StopWatchPage : ContentPage
	{
        StopWatchViewModel viewModel;

        public StopWatchPage()
		{
            InitializeComponent();

            BindingContext = this.viewModel = new StopWatchViewModel();
        }

        void Start_Clicked(object sender, EventArgs e)
        {
        }

        void Pause_Clicked(object sender, EventArgs e)
        {
        }

        void Reset_Clicked(object sender, EventArgs e)
        {
        }

        void Loop_Clicked(object sender, EventArgs e)
        {
        }
    }
}