using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamarinApp.ViewModels
{
    class StopWatchViewModel : ObservableViewModel
    {
        private Stopwatch stopWatch;

        public Stopwatch StopWatch
        {
            get{ return stopWatch;}
            set{ SetAndNotify(ref stopWatch, value);}
        }

        public StopWatchViewModel()
        {
            this.StopWatch = new Stopwatch();
        }

    }
}