using Api.Test.Fixtures;
using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test.Controllers
{
	public class InterviewControllerTest
	{
		protected readonly HttpClient _httpClient;

		public InterviewControllerTest()
		{
			ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();
			_httpClient = _factory.CreateClient();
		}
		[Fact]
		public async Task POST_interview_Shedule_Success()
		{
			//Arrange  
			InterviewDto interviewdto = new InterviewDto(new Guid("62ec44fb-9f30-4f45-8e3d-f3751998af89"),new Guid("2c8303fb-c1e1-4fa6-a2e1-272472b4beb5"),"TCS", "Senior dotnet developer", "10/12/2023", "TCR","10.00");
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(interviewdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("interview/interviewShedule", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);


		}
		[Fact]
		public async Task POST_interview_Shedule_without_CompanyName_BadRequest()
		{
			InterviewDto interviewdto = new InterviewDto(Guid.NewGuid(), Guid.NewGuid(),null, "Senior dotnet developer", "10/12/2023", "TCR", "10.00");
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(interviewdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("interview/interviewShedule", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		[Fact]
		public async Task POST_interview_Shedule_without_Post_BadRequest()
		{
			InterviewDto interviewdto = new InterviewDto(Guid.NewGuid(),Guid.NewGuid(),"TCS",null, "10/12/2023", "TCR", "10.00");
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(interviewdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("interview/interviewShedule", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		[Fact]
		public async Task POST_interview_Shedule_without_Date_BadRequest()
		{
			InterviewDto interviewdto = new InterviewDto(Guid.NewGuid(), Guid.NewGuid(), "TCS", "Senior dotnet developer",null, "TCR", "10.00");
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(interviewdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("interview/interviewShedule", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		[Fact]
		public async Task POST_interview_Shedule_without_Time_BadRequest()
		{
			InterviewDto interviewdto = new InterviewDto(Guid.NewGuid(), Guid.NewGuid(), "TCS", "Senior dotnet developer", "10/12/2023 ", "TCR",null);
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(interviewdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("interview/interviewShedule", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		[Fact]
		public async Task POST_interview_Shedule_without_Location_BadRequest()
		{
			InterviewDto interviewdto = new InterviewDto(Guid.NewGuid(), Guid.NewGuid(), "TCS", "Senior dotnet developer", "10/12/2023 ",null, "10.00 ");
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(interviewdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("interview/interviewShedule", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		[Fact]
		public async Task POST_interview_Shedule_without_JobId_BadRequest()
		{
			InterviewDto interviewdto = new InterviewDto(Guid.Empty, Guid.NewGuid(),"Tcs", "Senior dotnet developer", "10/12/2023", "TCR", "10.00");
			
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(interviewdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("interview/interviewShedule", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		public async Task POST_interview_Shedule_without_CompanyId_BadRequest()
		{
			InterviewDto interviewdto = new InterviewDto(Guid.NewGuid(),Guid.Empty,"Tcs", "Senior dotnet developer", "10/12/2023", "TCR", "10.00");

			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(interviewdto), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("interview/interviewShedule", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		[Fact]
		public async Task RemoveInterview_EmptyId_ReturnBadRequest()
		{
			// Arrange
			var jobId = Guid.Empty;

			// Act
			var response = await _httpClient.DeleteAsync($"api/Interview/{jobId}");

			// Assert
			Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
		}
		[Fact]
		public async Task Remove_ValidId_ReturnsNoContent()
		{
			// Arrange
			var jobId = new Guid("62ec44fb-9f30-4f45-8e3d-f3751998af89");

			// Act
			var response = await _httpClient.DeleteAsync($"api/Interview/{jobId}");

			// Assert
			Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
		}
		[Fact]
		public async Task Get_Listing_SheduledinterviewList_with_CmpnyId_Results_Success()
		{

			var cmpnyId = "2c8303fb-c1e1-4fa6-a2e1-272472b4beb5";
			//Act
			var response = await _httpClient.GetAsync("interview/interviewSheduledlist?id=" + cmpnyId);
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
		[Fact]
		public async Task Get_Listing_SheduledinterviewList_without_CompanyId_Results_Success()
		{

			
			//Act
			var response = await _httpClient.GetAsync("interview/interviewSheduledlist?id=");
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		[Fact]
		public async Task Get_Listing_SheduledinterviewList_with_Wrong_CmpnyId_ReturnBadRequest()
		{
			//Arrange
			var cmpnyId = "2c8303fb-c1e1-4fa6-a2e1-272472";


			//Act
			var response = await _httpClient.GetAsync("interview/interviewSheduledlist?id="+cmpnyId);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

		}

	}








}
