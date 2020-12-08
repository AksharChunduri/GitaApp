using System;
using System.IO;
using System.Reflection;
using GeetaAssessments.Models;
using GeetaAssessments.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GeetaAssessments.ViewModels
{
    public class SessionViewModel:BaseViewModel
    {
        public SessionViewModel()
        {
            GetAllSlokas();
            
        }

        private void GetAllSlokas()
        {
            var assembly = typeof(CreateSessionPage).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream()
            Stream stream = assembly.GetManifestResourceStream("GeetaAssessments.Data.English.Dhyana.json");
            using(var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<GitaChapter>(json);

            }


        }
    }
}
