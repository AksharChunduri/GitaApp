
using Xamarin.Forms;

namespace GeetaAssessments.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            Shell.Current.FlyoutIsPresented = true;
            InitializeComponent();
        }
    }
}
