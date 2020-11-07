using System;
using System.Threading.Tasks;

namespace GeetaAssessments.Services
{
    public interface IFirebaseAuthentication
    {
        Task<string> LoginWithEmailAndPassword(string email, string password);

        bool SignOut();

        bool IsSignIn();
    }
}
