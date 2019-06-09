using Gatherman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gatherman.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            /*
             *  Ce code va permettre de gérer automatiquement le focus lorque l'on clique 
             *  sur la touche entrer 
             */
            Entry_Utilisateur.Completed += (s, e) => Entry_MotDePasse.Focus();
            Entry_MotDePasse.Completed += (s, e) => FunctionSeConnecter(s, e);


        }
        void FunctionSeConnecter(object sender, System.EventArgs e)
        {
            Utilisateurs utilisateur = new Utilisateurs(Entry_Utilisateur.Text, Entry_MotDePasse.Text);
            if (utilisateur.CheckInformation())
            {
                DisplayAlert("Connection", "Connection réussi", "Test Ok");
                App.UserDatabase.SaveUtilisateur(utilisateur);
            }
            else
            {
                DisplayAlert("Connection", "Connection échoué", "Test nul");
            }
        }
    }
}