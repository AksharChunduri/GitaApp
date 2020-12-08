using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GeetaAssessments.Models;
using GeetaAssessments.Services;
using Xamarin.Forms;

namespace GeetaAssessments.ViewModels
{
    public class ProfileViewModel
    {
        public ObservableCollection<Locations> Locations { get; set; }


        public ProfileViewModel()
        {
            Locations = new ObservableCollection<Locations>();
            ReadLocations();
        }

        public async void ReadLocations()
        {
            var locations = await DatabaseHelper.GetLocations();
            Locations.Clear();
            foreach(var loc in locations)
            {
                Locations.Add(loc);
            }
        }
    }
}
