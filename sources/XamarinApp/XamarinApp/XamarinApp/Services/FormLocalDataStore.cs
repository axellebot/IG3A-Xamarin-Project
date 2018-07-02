using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using SQLite;

using XamarinApp.Models;

namespace XamarinApp.Services
{
    public class FormDiskDataStore : IDataStore<FormItemModel>
    {
        SQLiteAsyncConnection database;

        public FormDiskDataStore(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<FormItemModel>().Wait();
        }

        public Task<int> AddItemAsync(FormItemModel item)
        {
            return database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(FormItemModel item)
        {
            return database.DeleteAsync(item);
        }

        public Task<FormItemModel> GetItemAsync(string id)
        {
            return database.Table<FormItemModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<FormItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return database.Table<FormItemModel>().ToListAsync();
        }

        public Task<int> UpdateItemAsync(FormItemModel item)
        {
            return database.UpdateAsync(item);
        }
    }
}
