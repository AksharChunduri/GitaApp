using GeetaAssessments.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GeetaAssessments
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage());
            var token = SecureStorage.GetAsync("firebase_token");
            if (token != null)
            {
                MainPage = new LoginPage();
            }
            else
            {
                MainPage = new AppShell();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
