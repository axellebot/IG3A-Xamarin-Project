﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using XamarinApp.Models;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinApp.Services.MockTodoDataStore))]
namespace XamarinApp.Services
{
    public class MockTodoDataStore : IDataStore<TodoItem>
    {
        List<TodoItem> items;

        public MockTodoDataStore()
        {
            items = new List<TodoItem>();
            var mockItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First task",Done = true },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second task", Done = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Third task", Done = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Fourth task",  Done = true },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Fifth task",  Done = true},
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Sixth task", Done= true },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(TodoItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(TodoItem todoItem)
        {
            var _todoItem = items.Where((TodoItem arg) => arg.Id == todoItem.Id).FirstOrDefault();
            items.Remove(_todoItem);
            items.Add(todoItem);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(TodoItem todoItem)
        {
            var _todoItem = items.Where((TodoItem arg) => arg.Id == todoItem.Id).FirstOrDefault();
            items.Remove(_todoItem);

            return await Task.FromResult(true);
        }

        public async Task<TodoItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<TodoItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}