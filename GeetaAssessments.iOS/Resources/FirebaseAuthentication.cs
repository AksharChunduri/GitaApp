using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Foundation;
using GeetaAssessments.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(GeetaAssessments.iOS.Services.FirebaseAuthentication))]
namespace GeetaAssessments.iOS.Services
{
    public class FirebaseAuthentication : IFirebaseAuthentication
    {
        public bool IsSignIn()
        {
            var user = Auth.DefaultInstance.CurrentUser;
            return user != null;
        }

        public async Task<string> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return string.Empty;
            }
        }

        public bool SignOut()
        {
            try
            {
                _ = Auth.DefaultInstance.SignOut(out NSError error);
                return error == null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}