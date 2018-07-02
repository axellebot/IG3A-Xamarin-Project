using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp.UWP
{
	public partial class MainPage 
	{
		public MainPage()
		{
			this.InitializeComponent();

            LoadApplication(new XamarinApp.App());
        }
    }
}
