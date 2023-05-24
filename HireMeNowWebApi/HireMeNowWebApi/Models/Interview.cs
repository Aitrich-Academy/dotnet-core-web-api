using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNowWebApi.Models
{
    public class Interview
    {
        public Guid Id { get; set; }
        public int JobId { get; set; }
        public string Company { get; set; }
        public string Post { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }

        public Interview(string company, string post, string date, string location, string time)
        {
            //  JobId = jobId;
            Id = Guid.NewGuid();
            Company = company;
            Post = post;
            Date = date;
            Location = location;
            Time = time;
        }
        public Interview()
        {
            
        }
    }
}
