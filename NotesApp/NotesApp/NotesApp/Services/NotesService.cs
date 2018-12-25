using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using NotesApp.Models;
using Plugin.Connectivity;

namespace NotesApp.Services
{
    public class NotesService
    {
        private MobileServiceClient _mobileServiceClient;
        private IMobileServiceSyncTable<Notes> _notesTable;

        public NotesService(string url)
        {
            _mobileServiceClient = new MobileServiceClient(url);
            var store = new MobileServiceSQLiteStore("notesdb.db");
            store.DefineTable<Notes>();
            _mobileServiceClient.SyncContext.InitializeAsync(store);

            _notesTable = _mobileServiceClient.GetSyncTable<Notes>();
        }

        public async Task<IEnumerable<Notes>> GetNotes()
        {
            // var table = _mobileServiceClient.GetTable<Notes>();
            await SyncNotes();
            return await _notesTable.ReadAsync();
        }

        public async Task AddNote(Notes notes)
        {
           // var table = _mobileServiceClient.GetTable<Notes>();
            await SyncNotes();
            await _notesTable.InsertAsync(notes);
        }

        public async Task UpdateNote(Notes notes)
        {
            // var table = _mobileServiceClient.GetTable<Notes>();
            await SyncNotes();
            await _notesTable.UpdateAsync(notes);
        }

        public async Task DeleteNote(Notes notes)
        {
            //var table = _mobileServiceClient.GetTable<Notes>();
            await SyncNotes();
            await _notesTable.DeleteAsync(notes);
        }

        public async Task SyncNotes()
        {
            if(!CrossConnectivity.Current.IsConnected)
                return;
            await _mobileServiceClient.SyncContext.PushAsync();
            await _notesTable.PullAsync("allNotes", _notesTable.CreateQuery());
        }
    }
}
