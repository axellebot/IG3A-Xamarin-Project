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
        private TimeSpan initial_time;
        public bool again;
        public int value = 0;

        public StopWatchPage()
		{
            InitializeComponent();

            SetWatch(); 
        }

        public void SetWatch()
        {
            var sec = TimeSpan.FromMilliseconds(100);
            Device.StartTimer(sec, () => {
                this.valueLabel.Text = DateTime.Now.TimeOfDay.Hours.ToString()+":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.TimeOfDay.Seconds.ToString();

                return true;
            });

        }

        void Start_Clicked(object sender, EventArgs e)
        {
            initial_time = DateTime.Now.TimeOfDay;
            again = true;

            var sec = TimeSpan.FromMilliseconds(100);
            Device.StartTimer(sec, () => {
                TimeSpan now = DateTime.Now.TimeOfDay;
                TimeSpan value = now.Subtract(initial_time);
                this.Timer.Text = value.Hours.ToString() + ":" + value.Minutes.ToString() + ":" + value.Seconds.ToString();

                return again;
            });
        }

        void Stop_Clicked(object sender, EventArgs e)
        {
            this.again = false;
        }

        void Compt_Add_Clicked(object sender, EventArgs e)
        {
            value++;
            this.Counter.Text = value.ToString() ;
        }

        void Compt_Remove_Clicked(object sender, EventArgs e)
        {
            value--;
            this.Counter.Text = value.ToString();
        }

        void Compt_Reset_Clicked(object sender, EventArgs e)
        {
            value=0;
            this.Counter.Text = value.ToString();
        }

    }
}