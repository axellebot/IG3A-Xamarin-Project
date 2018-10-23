using Plugin.LocalNotifications;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Models;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{

    public class FormDetailViewModel : BaseViewModel
    {
        public ICommand SaveItemCommand { get; private set; }
        public ICommand DeleteItemCommand { get; private set; }
        public ICommand CancelItemCommand { get; private set; }

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetAndNotify(ref title, value); }
        }

        private FormItemModel formItemModel;

        public bool Notif
        {
            get { return formItemModel.Notif; }
            set
            {
                if (value != formItemModel.Notif)
                {
                    formItemModel.Notif = value;
                    OnPropertyChanged("Notif");
                    this.Notification();
                }
            }
        }

        public bool TimeCheck_1
        {
            get { return formItemModel.TimeCheck_1; }
            set
            {
                formItemModel.TimeCheck_1 = value;
                OnPropertyChanged("TimeCheck_1");
            }
        }

        public bool TimeCheck_2
        {
            get { return formItemModel.TimeCheck_2; }
            set
            {
                formItemModel.TimeCheck_2 = value;
                OnPropertyChanged("TimeCheck_2");
            }
        }

        public bool TimeCheck_3
        {
            get { return formItemModel.TimeCheck_3; }
            set
            {
                formItemModel.TimeCheck_3 = value;
                OnPropertyChanged("TimeCheck_3");
            }
        }

        public string Name_Drug
        {
            get { return formItemModel.Name_Drug; }
            set
            {
                if (value != formItemModel.Name_Drug)
                {
                    formItemModel.Name_Drug = value;
                    OnPropertyChanged("Drug's Name");
                }
            }
        }

        public string Name_Body
        {
            get { return formItemModel.Name_Body; }
            set
            {
                if (value != formItemModel.Name_Body)
                {
                    formItemModel.Name_Body = value;
                    OnPropertyChanged("Part of the body");
                }
            }
        }

        public string Name_Doctor
        {
            get { return formItemModel.Name_Doctor; }
            set
            {
                if (value != formItemModel.Name_Doctor)
                {
                    formItemModel.Name_Doctor = value;
                    OnPropertyChanged("Doctor's Name");
                }
            }
        }

        public string Dosage
        {
            get { return formItemModel.Dosage; }
            set
            {
                if (value != formItemModel.Dosage)
                {
                    formItemModel.Dosage = value;
                    OnPropertyChanged("Dosage");
                }
            }
        }

        public DateTime Date_Deb
        {
            get { return formItemModel.Date_Deb; }
            set
            {
                if (value != formItemModel.Date_Deb)
                {
                    formItemModel.Date_Deb = value;
                    OnPropertyChanged("Date_Deb");
                }
            }
        }

        public DateTime Date_Fin
        {
            get { return formItemModel.Date_Fin; }
            set
            {
                if (value != formItemModel.Date_Fin)
                {
                    formItemModel.Date_Fin = value;
                    OnPropertyChanged("Date_Fin");
                }
            }
        }

        public TimeSpan Time_1
        {
            get { return formItemModel.Time_1; }
            set
            {
                if (value != formItemModel.Time_1)
                {
                    formItemModel.Time_1 = value;
                    OnPropertyChanged("Time_1");
                }
            }
        }

        public TimeSpan Time_2
        {
            get { return formItemModel.Time_2; }
            set
            {
                if (value != formItemModel.Time_2)
                {
                    formItemModel.Time_2 = value;
                    OnPropertyChanged("Time_2");
                }
            }
        }

        public TimeSpan Time_3
        {
            get { return formItemModel.Time_3; }
            set
            {
                if (value != formItemModel.Time_3)
                {
                    formItemModel.Time_3 = value;
                    OnPropertyChanged("Time_3");
                }
            }
        }

        public string Dose
        {
            get { return formItemModel.Dose; }
            set
            {
                if (value != formItemModel.Dose)
                {
                    formItemModel.Dose = value;
                    OnPropertyChanged("Dose");
                }
            }
        }

        private bool isNew;
        public INavigation navigation;
        public FormDetailViewModel(FormItemModel formItemModel = null)
        {
            if (formItemModel == null)
            {
                this.formItemModel = new FormItemModel();
                isNew = true;
            }
            else
            {
                this.formItemModel = formItemModel;
                isNew = false;
            }

            Title = Name_Drug;

            SaveItemCommand = new Command(async () => await SaveItemCommandAsync());
            DeleteItemCommand = new Command(async () => await DeleteItemCommandAsync());
            CancelItemCommand = new Command(async () => await CancelCommandAsync());

        }

        public void Notification()
        {
            
            var minutes = TimeSpan.FromMinutes(1);
            Device.StartTimer(minutes, () => {

                if (this.Notif){
                    
                    string message = "You must take : " + this.Name_Drug;
                    if (this.Name_Drug == "")
                    {
                        message = "You must take a drug";
                    }

                        if (this.TimeCheck_1)
                        {
                            if ((DateTime.Now.TimeOfDay.Hours == Time_1.Hours) && (DateTime.Now.TimeOfDay.Minutes == Time_1.Minutes))
                            {
                                CrossLocalNotifications.Current.Show("Prescription", message, 101, Convert.ToDateTime(Time_1.ToString()));
                            }                            
                        }
                        if (this.TimeCheck_2)
                        {
                            if ((DateTime.Now.TimeOfDay.Hours == Time_2.Hours) && (DateTime.Now.TimeOfDay.Minutes == Time_2.Minutes))
                        {
                                CrossLocalNotifications.Current.Show("Prescription", message, 101, Convert.ToDateTime(Time_2.ToString()));
                            }
                        }

                        if (this.TimeCheck_3)
                        {
                            if ((DateTime.Now.TimeOfDay.Hours == Time_3.Hours) && (DateTime.Now.TimeOfDay.Minutes == Time_3.Minutes))
                        {
                                CrossLocalNotifications.Current.Show("Prescription", message, 101, Convert.ToDateTime(Time_3.ToString()));
                            }
                        }

                }
                // Returning true means you want to repeat this timer
                return this.Notif ;
                });
            }


            private async Task SaveItemCommandAsync(){
            if (IsBusy)
                return;

            IsBusy = true;

            if (isNew)
            {
                MessagingCenter.Send(this, "CreateFormItem", formItemModel);
            }
            else
            {
                MessagingCenter.Send(this, "UpdateFormItem", formItemModel);
            }

            await BackAsync();

            IsBusy = false;
            
            }

        

        private async Task DeleteItemCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            if (!isNew)
            {
                MessagingCenter.Send(this, "DeleteFormItem", formItemModel);
            };

            await BackAsync();

            IsBusy = false;
        }

        private async Task CancelCommandAsync()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            await BackAsync();

            IsBusy = false;
        }

        private async Task BackAsync()
        {
            if (isNew)
            {
                await navigation.PopModalAsync();
            }
            else
            {
                await navigation.PopAsync();
            }
        }
    }
}
