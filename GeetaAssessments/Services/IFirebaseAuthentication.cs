using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeetaAssessments.Models;

namespace GeetaAssessments.Services
{
    public interface IFirebaseAuthentication
    {
        Task<string> LoginWithEmailAndPassword(string email, string password);

        bool SignOut();

        bool IsSignIn();

        Task<AuthenticatedUser> GetUserAsync();
    }
}
