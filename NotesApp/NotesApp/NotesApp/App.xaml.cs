using System;
using NotesApp.Services;
using NotesApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NotesApp
{
    public partial class App : Application
    {
        private static NotesService _notesService;

        static App()
        {
            _notesService = new NotesService("https://mynotesapi.azurewebsites.net/");
        }

        public static NotesService GetNotesService()
        {
            return _notesService;
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new NotesPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
