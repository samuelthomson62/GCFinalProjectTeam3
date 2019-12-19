using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;



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
        public ApplicationUser()
        {

        }
        public ApplicationUser(int TimesDoneBefore, string BodyBuild, string PreExistingCondition, string City, string State, string ZipCode)
        {
            this.TimesDoneBefore = int.Parse(TimesDoneBefore.ToString());
            this.BodyBuild = BodyBuild;
            this.PreExistingCondition = PreExistingCondition.ToString();
            this.City = City.ToString();
            this.State = State.ToString();
            this.ZipCode = ZipCode.ToString();
        }
    }
}
