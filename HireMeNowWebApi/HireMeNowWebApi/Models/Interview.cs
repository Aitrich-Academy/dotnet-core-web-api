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
        public Guid JobId { get; set; }
        public Guid CompanyId { get; set; }
        public string Company { get; set; }
        public string Post { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }

        public Interview(Guid jobId,Guid companyId,string company, string post, string date, string location, string time, Guid? id = null)
        {
			Id = id ?? Guid.NewGuid();
			JobId = jobId;
            CompanyId = companyId;
			
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
