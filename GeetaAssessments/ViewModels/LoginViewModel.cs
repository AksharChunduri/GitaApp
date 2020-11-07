using System;
using System.ComponentModel;
using System.Windows.Input;
using GeetaAssessments.Services;
using GeetaAssessments.Views;
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
                Application.Current.MainPage = new HomePage();
            }
        }
    }
}
