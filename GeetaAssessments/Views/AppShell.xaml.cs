
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeetaAssessments.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("Home", typeof(HomePage));
            Routing.RegisterRoute("Profile", typeof(ProfilePage));

        }
    }
}
