using DelegacionMAUI.Acceso;

namespace DelegacionMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Login());
        }
    }
}
