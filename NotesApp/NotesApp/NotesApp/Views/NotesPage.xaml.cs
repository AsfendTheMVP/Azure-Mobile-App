using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesApp.Models;
using NotesApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        //NotesService notesService = new NotesService();
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshNotes();
        }

        public async void RefreshNotes()
        {
            LvNotes.ItemsSource = await App.GetNotesService().GetNotes();

        }

        private void TapAddNote_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddNotePage());
        }

        private void LvNotes_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedNote = e.SelectedItem as Notes;
            Navigation.PushAsync(new UpdateNotePage(selectedNote));
        }

        private async void DeleteNote_OnClicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var notes = menuItem.CommandParameter as Notes;
            await App.GetNotesService().DeleteNote(notes);
            RefreshNotes();

        }
    }
}