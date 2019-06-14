using Gatherman.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gatherman.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCommercants : ContentPage
    {
        public PageCommercants()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var listeCommercants = new List<Commercants>();

            //récupération des commercants qui sont stockées dans les fichiers locaux du device
            var files = Directory.EnumerateFiles(App.FolderPath, "*.newNotes.txt");

         //   foreach (var filename in files){
                listeCommercants.Add(new Commercants
                {
                    /*  Filename = filename,
                      NomCommercant = "Nom" + File.ReadAllText(filename),
                      PrenomCommercant = "Prenom" + File.ReadAllText(filename),
                      ChiffreAffaire = 13443,
                      Date = File.GetCreationTime(filename)
                      */
                    Filename = "",
                    NomCommercant = "René",
                    PrenomCommercant = "Laport",
                    ChiffreAffaire = 12332,
                    Date = new DateTime(2018, 6, 21),
                    PhotoDeProfil = "photoprofil.png"

                });
        //    }
            listeCommercants.Add(new Commercants
            {
                Filename = "",
                NomCommercant = "Simpson",
                PrenomCommercant = "Homer",
                ChiffreAffaire = 134873,
                Date = new DateTime(2018, 6, 21),
                PhotoDeProfil = "photoprofil.png"

            }); listeCommercants.Add(new Commercants
            {
                Filename = "",
                NomCommercant = "Bart",
                PrenomCommercant = "Ujed",
                ChiffreAffaire = 13423,
                Date = new DateTime(2018, 6, 21),
                PhotoDeProfil = "photoprofil.png"

            }); listeCommercants.Add(new Commercants
            {
                Filename = "",
                NomCommercant = "Ked",
                PrenomCommercant = "Oled",
                ChiffreAffaire = 13423,
                Date = new DateTime(2018, 6, 21),
                PhotoDeProfil = "photoprofil.png"

            });
            listView.ItemsSource= listeCommercants.OrderBy(d => d.Date).ToList();
        }

        async void AddCommercant(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAjouterCommercants
            {
                BindingContext = new Commercants()
            });
        }

        async void OnListViewItemSelected(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAjouterCommercants
            {
              
            });
        }
    }
}