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
    public partial class PageProfil : ContentPage
    {
        public PageProfil()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AccesAppliWeb(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.viewstats.nassimmouhoubi.com/"));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}