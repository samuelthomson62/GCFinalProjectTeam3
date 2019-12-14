using Newtonsoft.Json.Linq;

namespace FinalProject.Models
{
    public class Trails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Difficulty { get; set; }
        public string Location { get; set; }
        //public string ImgSqSmall { get; set; }
        //public string ImgSmall { get; set; }
        public string ImgSmallMed { get; set; }
        //public string ImgMedium { get; set; }
        public decimal Length { get; set; }
        public  string Date {get; set;}
        public string CompleteMark { get; set; }
        //public string ConditionStatus { get; set; }
        //public string ConditionDetails { get; set; }
        //public Datetime ConditionDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Trails()
        {

        }
        public Trails(JToken t)
        {
            this.Id = int.Parse(t["id"].ToString());
            this.Name = t["name"].ToString();
            this.Summary = t["summary"].ToString();
            this.Difficulty = t["difficulty"].ToString();
            this.Location = t["location"].ToString();
            //this.ImgSqSmall = t["imgSqSmall"].ToString();
            this.ImgSmallMed = t["imgSmallMed"].ToString();
            //this.ImgSmall = t["imgSmall"].ToString();
            // this.ImgMedium = t["imgMedium"].ToString();
            this.Length = decimal.Parse(t["length"].ToString());
            //this.ConditionStatus = t["conditionStatus"].ToString();
            //this.ConditionDetails = t["conditionDetails"].ToString();
        }
    }
}
