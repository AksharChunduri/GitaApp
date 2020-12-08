using Xamarin.Forms;

namespace GeetaAssessments.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public Command CreateNewCommand { get; }
        public HomePageViewModel()
        {
            CreateNewCommand = new Command(OnNewSessionClicked);
            
            //add the code to check for role

        }

        private async void OnNewSessionClicked(object obj)
        {
            await Shell.Current.GoToAsync("CreateSession");
        }
    }
}
