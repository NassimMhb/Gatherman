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
    public partial class PageAjouterCommercants : ContentPage
    {
        public PageAjouterCommercants()
        {
            InitializeComponent();
        }
        async void EnregistrerCommercant(object sender, EventArgs e)
        {
            var note = (Commercants)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.newNotes.txt");
                File.WriteAllText(filename, note.NomCommercant);
                File.WriteAllText(filename, note.PrenomCommercant);
                File.WriteAllText(filename, "12343");
            }
            else
            {
                File.WriteAllText(note.Filename, note.NomCommercant);
                File.WriteAllText(note.Filename, note.PrenomCommercant);
                File.WriteAllText(note.Filename, "12343");
            }

            await Navigation.PopAsync();
        }

        async void SupprimerCommercant(object sender, EventArgs e)
        {
            var note = (Commercants)BindingContext;

            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }

            await Navigation.PopAsync();
        }
    }
}