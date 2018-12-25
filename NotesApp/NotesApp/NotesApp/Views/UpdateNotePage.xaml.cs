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
	public partial class UpdateNotePage : ContentPage
	{
	    //private NotesService _notesService;
	    private string _noteId;
		public UpdateNotePage (Notes note)
		{
			InitializeComponent ();
           // _notesService = new NotesService();
		    EntTitle.Text = note.title;
		    EdtDescription.Text = note.description;
		    _noteId = note.id;
		}

	    private async void TbUpdateNote_OnClicked(object sender, EventArgs e)
	    {
	        var note = new Notes()
	        {
                title = EntTitle.Text,
                description = EdtDescription.Text,
                id = _noteId
	        };
	        await App.GetNotesService().UpdateNote(note);
	    }
	}
}