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
            MenuItem menuItem = new MenuItem() { Text = "Logout" };
            
            menuItem.Command = new Command(async () => { Current.FlyoutIsPresented = false; await Current.GoToAsync("login"); });
            Items.Add(menuItem);
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("Home", typeof(HomePage));
            Routing.RegisterRoute("Profile", typeof(ProfilePage));
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("CreateSession", typeof(CreateSessionPage));
            Routing.RegisterRoute("MySessions", typeof(MySessionsPage));
        }
    }
}
