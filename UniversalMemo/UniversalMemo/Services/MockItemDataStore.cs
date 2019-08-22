using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalMemo.Models;

namespace UniversalMemo.Services
{
    public class MockItemsDataStore : IDataStore<Item>
    {
        List<Item> items;
        private IDataStore<Folder> dataStore;

        public MockItemsDataStore(List<Folder> Folders)
        {
            items = new List<Item>();
            Folder[] FolderArray  = Folders.ToArray();
            var mockItems = new List<Item>
            {
                new Item { Key = Guid.NewGuid(), BelongsTo = FolderArray[0].BelongsTo, Name = "First item", Description = "This is an item description.", Body = "This is the body of the item", Date = DateTime.Now },
                new Item { Key = Guid.NewGuid(), BelongsTo = FolderArray[0].BelongsTo, Name = "Second item", Description = "This is an item description.", Body = "This is the body of the item", Date = DateTime.Now },
                new Item { Key = Guid.NewGuid(), BelongsTo = FolderArray[1].BelongsTo, Name = "Third item", Description = "This is an item description.", Body = "This is the body of the item", Date = DateTime.Now },
                new Item { Key = Guid.NewGuid(), BelongsTo = FolderArray[1].BelongsTo, Name = "Forth item", Description = "This is an item description.", Body = "This is the body of the item", Date = DateTime.Now },
                new Item { Key = Guid.NewGuid(), BelongsTo = FolderArray[2].BelongsTo, Name = "Fifth item", Description = "This is an item description.", Body = "This is the body of the item", Date = DateTime.Now },
                new Item { Key = Guid.NewGuid(), BelongsTo = FolderArray[2].BelongsTo, Name = "Sixth item", Description = "This is an item description.", Body = "This is the body of the item", Date = DateTime.Now }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public MockItemsDataStore(IDataStore<Folder> dataStore)
        {
            this.dataStore = dataStore;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Key == item.Key).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid Key)
        {
            var oldItem = items.Where((Item arg) => arg.Key == Key).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(Guid Key)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Key == Key));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public Task AddItemAsync(Folder newFolder)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}