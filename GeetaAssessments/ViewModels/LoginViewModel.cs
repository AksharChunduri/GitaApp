using System.Windows.Input;
using GeetaAssessments.Services;
using GeetaAssessments.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GeetaAssessments.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        IFirebaseAuthentication authentication;

        private string _email;
        public string Email
        {
            get { return _email;  }
            set { SetValue(ref _email, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }

        public bool _areCredentialsInvalid = false;
        public bool AreCredentialsInvalid
        {
            get { return _areCredentialsInvalid;  }
            set { SetValue(ref _areCredentialsInvalid, value);  }
        }

        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            authentication = DependencyService.Get<IFirebaseAuthentication>();
           
            SubmitCommand = new Command(OnSubmit);  
        }

        private async void OnSubmit()
        {
            string token = await authentication.LoginWithEmailAndPassword(_email, _password);
            if (token != string.Empty)
            {
                AreCredentialsInvalid = false;
                await SecureStorage.SetAsync("firebase_token", token);
                Application.Current.MainPage = new AppShell();
                //await Shell.Current.GoToAsync("Home");
                //await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
            else
            {
                AreCredentialsInvalid = true;
            }
        }
    }
}
