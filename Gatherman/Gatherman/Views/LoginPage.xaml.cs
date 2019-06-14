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
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            LoginIcon2.HeightRequest = Constants.LoginIconHeight;
            /*
             *  Ce code va permettre de gérer automatiquement le focus lorque l'on clique 
             *  sur la touche entrer 
             */
            Entry_Utilisateur.Completed += (s, e) => Entry_MotDePasse.Focus();
            Entry_MotDePasse.Completed += (s, e) => FunctionSeConnecter(s, e);

        }
        async void FunctionSeConnecter(object sender, System.EventArgs e)
        {
            Utilisateurs utilisateur = new Utilisateurs(Entry_Utilisateur.Text, Entry_MotDePasse.Text);
            if (utilisateur.CheckInformation())
            {
                try
                {
                  //  DisplayAlert("Connection", "Connection réussi", "Test Ok");
                    App.UserDatabase.SaveUtilisateur(utilisateur);
                    await Navigation.PushAsync(new HamburgerMenu(),  false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            else
            {
                DisplayAlert("Connection", "Connection échoué", "Test nul");
            }
        }
    }
}