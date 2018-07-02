using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using XamarinApp.Models;

namespace XamarinApp.Services
{
    public class FormCacheDataStore : IDataStore<FormItemModel>
    {
        List<FormItemModel> items;

        public FormCacheDataStore()
        {
            items = new List<FormItemModel>();
            var mockItems = new List<FormItemModel>
            {
                new FormItemModel { Id = Guid.NewGuid().ToString(), Name_Drug = "Doliprane", Notif = true },
                new FormItemModel { Id = Guid.NewGuid().ToString(), Name_Drug = "Efferalgan", Notif = false },
                new FormItemModel { Id = Guid.NewGuid().ToString(), Name_Drug = "Lomusol", Notif = false },
                new FormItemModel { Id = Guid.NewGuid().ToString(), Name_Drug = "Imodium",  Notif = true },
                new FormItemModel { Id = Guid.NewGuid().ToString(), Name_Drug = "Voltarene",  Notif = true},
                new FormItemModel { Id = Guid.NewGuid().ToString(), Name_Drug = "Smecta", Notif= true },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<int> AddItemAsync(FormItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(1);
        }

        public async Task<int> UpdateItemAsync(FormItemModel formItem)
        {
            var _formItem = items.Where((FormItemModel arg) => arg.Id == formItem.Id).FirstOrDefault();
            items.Remove(_formItem);
            items.Add(formItem);

            return await Task.FromResult(1);
        }

        public async Task<int> DeleteItemAsync(FormItemModel formItem)
        {
            var _formItem = items.Where((FormItemModel arg) => arg.Id == formItem.Id).FirstOrDefault();
            items.Remove(_formItem);

            return await Task.FromResult(1);
        }

        public async Task<FormItemModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<List<FormItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
