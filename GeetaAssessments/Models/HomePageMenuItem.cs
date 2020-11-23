using System;
using GeetaAssessments.Views;

namespace GeetaAssessments.Models
{
    public class HomePageMenuItem
    {
        public HomePageMenuItem()
        {
            // sTargetType = typeof(HomePageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
