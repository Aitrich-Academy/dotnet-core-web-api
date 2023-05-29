using Api.Test.Fixtures;
using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test.Controllers
{
	public class JobSeekerControllerTest
	{
		protected readonly HttpClient _httpClient;

		public JobSeekerControllerTest()
		{
			ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();
			_httpClient = _factory.CreateClient();
		}
		[Fact]
		public async Task POST_Apply_Job_Success()
		{
			//Arrange  
			ApplicationDto applicationdto = new ApplicationDto();
			applicationdto.JobId = new Guid("62ec44fb-9f30-4f45-8e3d-f3751998af89");
			applicationdto.UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(applicationdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("JobSeeker/ApplyJob", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);


		}

		[Fact]
		public async Task POST_Apply_Job_WrongData_BadRequest()
		{
			//Arrange  
			ApplicationDto applicationdto = new ApplicationDto();
			applicationdto.JobId = new Guid();
			applicationdto.UserId = new Guid();
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(applicationdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("JobSeeker/ApplyJob", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


		}
		[Fact]
		public async Task Get_Listing_AppliedjobLIst_Results_Success()
		{

		
			//Act
			var response = await _httpClient.GetAsync("JobSeeker/AllApplyJobs");
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
		[Fact]
		public async Task Get_Listing_AppliedJobs_With_CompanyIdandUserID_Results_Success()
		{
			//Arrange  
			
			var response = await _httpClient.GetAsync("company/memberListing?CmpId=2c8303fb-c1e1-4fa6-a2e1-272472b4beb5?UserId=3fa85f64-5717-4562-b3fc-2c963f66afa6");
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
		[Fact]
		public async Task Get_Listing_AppliedJobs_Withnull_CompanyIdandUserID_Results_ReturnBadRequest()
		{
			var CmpId=Guid.Empty;
			var userId = Guid.Empty;
		
			//Act
			var response = await _httpClient.GetAsync("company/memberListing?CmpId=?UserId="+ userId+ "?CmpId="+CmpId );
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
	
		
	}
}
