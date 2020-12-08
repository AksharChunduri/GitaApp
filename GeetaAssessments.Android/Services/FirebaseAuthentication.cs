
using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using GeetaAssessments.Droid.ServiceListeners;
using GeetaAssessments.Models;
using GeetaAssessments.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(GeetaAssessments.Droid.Services.FirebaseAuthentication))]
namespace GeetaAssessments.Droid.Services
{
    
    public class FirebaseAuthentication : IFirebaseAuthentication
    {
        public bool IsSignIn()
        {
            FirebaseUser user = FirebaseAuth.Instance.CurrentUser;
            return user != null;
        }

        public async Task<string> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdToken(false);

                return token.ToString();
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
        }

        public bool SignOut()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<AuthenticatedUser> GetUserAsync()
        {
            var tcs = new TaskCompletionSource<AuthenticatedUser>();
            FirestoreService.Instance.Collection("Users").Document(FirebaseAuth.Instance.CurrentUser.Uid).Get().
                AddOnCompleteListener(new OnCompleteListener(tcs));
            return tcs.Task;
        }

    }
}
