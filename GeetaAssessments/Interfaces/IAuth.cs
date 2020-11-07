using System;
using System.Threading.Tasks;

namespace GeetaAssessments.Interfaces
{
    public interface IAuth
    {
        Task<bool> LoginWithEmailPassword(string email, string password);
    }
}
