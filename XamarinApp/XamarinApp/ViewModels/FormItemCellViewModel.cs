using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{

    public class FormItemCellViewModel : BaseViewModel
    {
        public ICommand DeleteItemCommand { get; private set; }

        private FormItemModel formItem;
        public FormItemModel FormItem { get { return formItem; } }

        public string Name_Drug { get { return formItem.Name_Drug; } }
        public string Name_Doctor{ get { return formItem.Name_Doctor; } }
        public string Name_Body { get { return formItem.Name_Body; } }
        public string Dosage { get { return formItem.Dosage; } }
        public DateTime Date_Deb { get { return formItem.Date_Deb; } }
        public DateTime Date_Fin { get { return formItem.Date_Fin; } }
        public string Dose { get { return formItem.Dose; } }
        public TimeSpan Time_1 { get { return formItem.Time_1; } }
        public TimeSpan Time_2 { get { return formItem.Time_2; } }
        public TimeSpan Time_3 { get { return formItem.Time_3; } }

        public bool Notif
        {
            get { return formItem.Notif; }
            set
            {
                formItem.Notif = value;
                ItemCheckedAsync();
                OnPropertyChanged("Notif");
                FormDetailViewModel v = new FormDetailViewModel(FormItem);
                v.Notification();
            }
        }

        public bool TimeCheck_1
        {
            get { return formItem.TimeCheck_1; }
            set
            {
                formItem.TimeCheck_1 = value;
                ItemCheckedAsync();
                OnPropertyChanged("TimeCheck_1");
                FormDetailViewModel v = new FormDetailViewModel(FormItem);
                v.Notification();
            }
        }

        public bool TimeCheck_2
        {
            get { return formItem.TimeCheck_2; }
            set
            {
                formItem.TimeCheck_2 = value;
                ItemCheckedAsync();
                OnPropertyChanged("TimeCheck_2");
                FormDetailViewModel v = new FormDetailViewModel(FormItem);
                v.Notification();
            }
        }

        public bool TimeCheck_3
        {
            get { return formItem.TimeCheck_3; }
            set
            {
                formItem.TimeCheck_3 = value;
                ItemCheckedAsync();
                OnPropertyChanged("TimeCheck_3");
                FormDetailViewModel v = new FormDetailViewModel(FormItem);
                v.Notification();
            }
        }

        public INavigation navigation;
        public FormItemCellViewModel(FormItemModel formItem)
        {
            this.formItem = formItem;

            DeleteItemCommand = new Command(async () => await DeleteItemAsync());
        }

        public async Task DeleteItemAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            MessagingCenter.Send(this, "DeleteFormItem", this.formItem);

            IsBusy = false;
        }

        public void ItemCheckedAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            MessagingCenter.Send(this, "CheckFormItem", this.formItem);

            IsBusy = false;
        }
        public async Task MoreItemAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            FormDetailViewModel viewModel = new FormDetailViewModel(FormItem);
            await navigation.PushAsync(new FormDetailPage(viewModel));

            IsBusy = false;
        }
    }
}
