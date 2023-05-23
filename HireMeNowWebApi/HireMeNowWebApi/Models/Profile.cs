using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HireMeNowWebApi.Models
{
	public class ProfileDetails
	{
		public string? About { get; set; }
		public List<string>? Skills { get; set; } = new List<string>();
		public List<Education>? Educations { get; set; } = new List<Education>();
		public List<Experience>? Experiences { get; set; } = new List<Experience>();

		public string? Designation { get; set; }
	
		public Guid? companyId { get; set; }

		public string? Image { get; set; }


	}
}
