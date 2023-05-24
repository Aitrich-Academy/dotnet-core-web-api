using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Api.Test.Fixtures;
using System.Net.Http.Headers;

namespace Api.Test.Controllers
{
	public class JobControllerTest
	{
		protected readonly HttpClient _httpClient;
		public JobControllerTest()
		{
			ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();
			_httpClient = _factory.CreateClient();
			//string accessToken = getAccessToken();
			//_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

		}
		[Fact]
		public async Task POST_Job_Results_Success()
		{
			//Arrange  
			JobDto jobDto = new JobDto("Java Developer", "Senior dotnet developer", "kochi","100000-300000", Guid.NewGuid(), "Aitrich");
			jobDto.Experience = "2-3 years";
			jobDto.TypeOfWork = "Online";
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(jobDto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("job/PostJob", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

		}
	}
}
