using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalMemo.Models;

namespace UniversalMemo.Services
{
    public class MockFoldersDataStore : IDataStore<Folder>
    {
        List<Folder> Folders;

        public MockFoldersDataStore()
        {
            Folders = new List<Folder>
            {
                new Folder { BelongsTo = Guid.NewGuid(), Text = "First item", Detail = DateTime.Now },
                new Folder { BelongsTo = Guid.NewGuid(), Text = "Second item", Detail = DateTime.Now},
                new Folder { BelongsTo = Guid.NewGuid(), Text = "Third item", Detail = DateTime.Now },
                new Folder { BelongsTo = Guid.NewGuid(), Text = "Forth item", Detail = DateTime.Now },
                new Folder { BelongsTo = Guid.NewGuid(), Text = "Fifth item", Detail = DateTime.Now },
                new Folder { BelongsTo = Guid.NewGuid(), Text = "Sixth item", Detail = DateTime.Now }
            };
        }

        public async Task<bool> AddItemAsync(Folder NewFolders)
        {
                Folders.Add(NewFolders);

                return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Folder NewFolders)
        {
            var oldItem = Folders.Where((Folder arg) => arg.BelongsTo == NewFolders.BelongsTo).FirstOrDefault();
            Folders.Remove(oldItem);
            Folders.Add(NewFolders);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid Key)
        {
            var oldItem = Folders.Where((Folder arg) => arg.BelongsTo == Key).FirstOrDefault();
            Folders.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Folder> GetItemAsync(Guid Key)
        {
            return await Task.FromResult(Folders.FirstOrDefault(s => s.BelongsTo == Key));
            
        }

        public async Task<IEnumerable<Folder>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Folders);
        }

        Task<bool> IDataStore<Folder>.AddItemAsync(Folder item)
        {
            throw new NotImplementedException();
        }

        Task<Folder> IDataStore<Folder>.GetItemAsync(string Key)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Folder>> IDataStore<Folder>.GetItemsAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore<Folder>.UpdateItemAsync(Folder item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore<Folder>.DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task IDataStore<Folder>.AddItemAsync(Folder newFolder)
        {
            throw new NotImplementedException();
        }
    }
}