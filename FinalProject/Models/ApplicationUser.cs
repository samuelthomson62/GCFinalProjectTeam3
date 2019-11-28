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

        public string uLevel { get; set; }

        public string UsLevel(int TimesDoneBefore, string BodyBuild, string PreExistingCondition)
        {
            


            if (BodyBuild == "overweight" || BodyBuild == "average")
            {
                if (TimesDoneBefore <= 3)
                {

                    uLevel = "green";

                }
                if (TimesDoneBefore >= 5 && TimesDoneBefore >= 3)
                {
                    if (PreExistingCondition == "y")

                    {
                        uLevel = "green";
                    }

                    else
                    {
                        uLevel = "greenBlue";
                    }

                }
            }
            if (BodyBuild == "average" || BodyBuild == "athletic")
            {
                if (TimesDoneBefore >= 8)
                {
                    if (PreExistingCondition == "Y" && BodyBuild == "average")
                    {
                        uLevel = "greenBlue";
                    }
                    else
                    {
                        uLevel = "blue";
                    }
                }

                if (TimesDoneBefore >= 10)
                {
                    if (PreExistingCondition == "y" && BodyBuild == "average")
                    {
                        uLevel = "blue";
                    }
                    else
                    {
                        uLevel = "blueBlack";
                    }
                }
                if (TimesDoneBefore >= 15)
                {
                    if (PreExistingCondition == "y" && BodyBuild == "average")
                    {
                        uLevel = "blueBlack";
                    }
                    else
                    {
                        uLevel = "Black";
                    }
                }
            }
            return uLevel;
        }






    }
}
