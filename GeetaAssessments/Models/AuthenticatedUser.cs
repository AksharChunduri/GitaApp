using System;
using System.Collections.Generic;

namespace GeetaAssessments.Models
{
    public class AuthenticatedUser
    {
        public string ID { get; set; }
        public List<string> Roles { get; set; }
        public string Location { get; set; }
    }
}
