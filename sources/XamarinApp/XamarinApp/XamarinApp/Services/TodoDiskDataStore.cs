using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using SQLite;

using XamarinApp.Models;

namespace XamarinApp.Services
{
    public class TodoDiskDataStore : IDataStore<TodoItem>
    {
        SQLiteAsyncConnection database;

        public TodoDiskDataStore(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }
        
        public Task<int> AddItemAsync(TodoItem item)
        {
            return database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return database.DeleteAsync(item);
        }

        public Task<TodoItem> GetItemAsync(string id)
        {
            return database.Table<TodoItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<TodoItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<int> UpdateItemAsync(TodoItem item)
        {
            return database.UpdateAsync(item);
        }
    }
}
