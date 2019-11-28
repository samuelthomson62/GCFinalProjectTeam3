using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ApplicationUser : IdentityUser
    {

        public int TimesDoneBefore { get; set; }
        public string BodyBuild { get; set; }
      
        public string PreExistingCondition { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }





    }
}
