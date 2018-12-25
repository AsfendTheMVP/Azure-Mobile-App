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
	public partial class AddNotePage : ContentPage
	{
	   // private NotesService _notesService;
		public AddNotePage ()
		{
			InitializeComponent ();
           // _notesService = new NotesService();
		}

	    private async void TbAddNote_OnClicked(object sender, EventArgs e)
	    {
	        var note = new Notes()
	        {
                title = EntTitle.Text,
                description = EdtDescription.Text
	        };
	        await App.GetNotesService().AddNote(note);
	    }
	}
}