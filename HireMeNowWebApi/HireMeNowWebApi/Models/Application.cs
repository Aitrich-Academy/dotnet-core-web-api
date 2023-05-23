using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNowWebApi.Models
{
    public class Application
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Job Job { get; set; }
        public string Status { get; set; }
        public Guid CompanyId { get; set; }
        public Application()
        {
            
        }
        public Application(Job job, User user, string status, Guid? companyId=null)
        {
            Id=Guid.NewGuid();
			Job = job;
            User = user;
            Status = status;
            CompanyId = companyId??CompanyId;
           
        }
    }
}
