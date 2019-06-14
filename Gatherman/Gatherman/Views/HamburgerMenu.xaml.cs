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
    public partial class HamburgerMenu : MasterDetailPage
    {
        public HamburgerMenu()
        {
            InitializeComponent();
            MyMenu();
        }

        public void MyMenu()
        {
            try
            {
                Detail = new NavigationPage(new PageProfil());
                NavigationPage.SetHasNavigationBar(this, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            List<Menu> menu = new List<Menu>
            {
                new Menu{Page = new PageProfil(), MenuTitle ="Profil", MenuDetail="Consulter le profil", icon="user.png"},
                new Menu{Page = new PageCommercants(), MenuTitle ="Liste des commerçants", MenuDetail="Consulter la liste", icon="list.png"},
                new Menu{Page = new PageParametres(), MenuTitle ="Paramétres", MenuDetail="Paramétres de l'application", icon="params.png"},
                new Menu{Page = new LoginPage(), MenuTitle ="Se déconnecter", MenuDetail="Quitter la session", icon="logout.png"}
            };

            ListMenu.ItemsSource = menu;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }

        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }
            public string MenuDetail
            {
                get;
                set;
            }

            public ImageSource icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }
    }
}