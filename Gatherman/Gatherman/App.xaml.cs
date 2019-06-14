using Gatherman.Data;
using Gatherman.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gatherman
{
    public partial class App : Application
    {

        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;

        public static string FolderPath { get; private set; }

        public App()
        {
            InitializeComponent();

            //varriable folderpath utilisée pour les données dans pagecommercants
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));



            MainPage = new NavigationPage(new LoginPage());
            
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


        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }
        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }



    }
}
