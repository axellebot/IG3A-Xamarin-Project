using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using XamarinApp.Models;
using XamarinApp.Services;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{

    public class FormListViewModel : BaseViewModel
    {
        private ObservableCollection<FormItemCellViewModel> items;
        public ObservableCollection<FormItemCellViewModel> Items
        {
            get { return items; }
            set { SetAndNotify(ref items, value); }
        }

        private FormItemCellViewModel selectedItem;
        public FormItemCellViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetAndNotify(ref selectedItem, value);
                if (selectedItem == null)
                    return;
                SelectItemCommand.Execute(selectedItem);
                SelectedItem = null;
            }
        }

        public ICommand LoadItemsCommand { get; private set; }
        public ICommand CreateItemCommand { get; private set; }
        public ICommand SelectItemCommand { get; private set; }

        public IDataStore<FormItemModel> DataStore = (new FormDataStoreFactory()).Create();

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetAndNotify(ref title, value); }
        }

        public INavigation navigation;

        public FormListViewModel()
        {
            Title = "Drugs List";
            Items = new ObservableCollection<FormItemCellViewModel>();

            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
            CreateItemCommand = new Command(async () => await CreateItemAsync());
            SelectItemCommand = new Command<FormItemCellViewModel>(async (viewModel) => await SelecteItemAsync(viewModel));

            MessagingCenter.Subscribe<FormItemCellViewModel, FormItemModel>(this, "CheckFormItem", async (obj, item) =>
            {
                var _item = item as FormItemModel;
                await DataStore.UpdateItemAsync(_item);
            });

            MessagingCenter.Subscribe<FormDetailViewModel, FormItemModel>(this, "UpdateFormItem", async (obj, item) =>
            {
                var _item = item as FormItemModel;
                await DataStore.UpdateItemAsync(_item);
                await LoadItemsAsync();
            });

            MessagingCenter.Subscribe<FormDetailViewModel, FormItemModel>(this, "CreateFormItem", async (obj, item) =>
            {
                var _item = item as FormItemModel;
                await DataStore.AddItemAsync(_item);
                await LoadItemsAsync();
            });

            MessagingCenter.Subscribe<FormDetailViewModel, FormItemModel>(this, "DeleteFormItem", async (obj, item) =>
            {
                var _item = item as FormItemModel;
                await DataStore.DeleteItemAsync(_item);
                await LoadItemsAsync();
            });

            MessagingCenter.Subscribe<FormItemCellViewModel, FormItemModel>(this, "DeleteFormItem", async (obj, item) =>
            {
                var _item = item as FormItemModel;
                await DataStore.DeleteItemAsync(_item);
                await LoadItemsAsync();
            });
        }

        async Task MoreItemAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await SelectedItem?.MoreItemAsync();

            IsBusy = false;
        }

        private async Task LoadItemsAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await DataStore.GetItemsAsync(true);
                Items.Clear();
                foreach (var item in items)
                {
                    FormItemCellViewModel viewModel = new FormItemCellViewModel(item);
                    viewModel.navigation = navigation;
                    Items.Add(viewModel);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task CreateItemAsync()
        {
            await navigation.PushModalAsync(new NavigationPage(new FormDetailPage(new FormDetailViewModel())));
        }
        private async Task SelecteItemAsync(FormItemCellViewModel formItemCellViewModel)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await formItemCellViewModel.MoreItemAsync();

            IsBusy = false;
        }
    }
}
