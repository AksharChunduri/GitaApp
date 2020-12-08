using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeetaAssessments.Models;
using Xamarin.Forms;

namespace GeetaAssessments.Services
{
    public interface IFirestore
    {
        Task<List<Locations>> GetLocations();
    }

    public class DatabaseHelper 
    {
        private static IFirestore firestore = DependencyService.Get<IFirestore>();
        public static Task<List<Locations>> GetLocations()
        {
            return firestore.GetLocations();
        }
    }
}
