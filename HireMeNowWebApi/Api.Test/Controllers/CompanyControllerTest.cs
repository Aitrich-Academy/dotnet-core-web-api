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
    public class CompanyControllerTest
    {
        protected readonly HttpClient _httpClient;

        public CompanyControllerTest()
        {
            ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();
            _httpClient = _factory.CreateClient();

        }

        [Fact]
        public async Task POST_Register_member_without_email_Results_BadRequest()
        {
            //Arrange  
            UserDto userDto = new UserDto("anshid", "ansar", "", "male", "thrissur", 9633508643, "123", Roles.CompanyMember);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            //Act
            var response = await _httpClient.PostAsync("company/memberRegister", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [Fact]
        public async Task POST_Register_member_Without_Password_Results_BadRequest()
        {
            //Arrange  
            UserDto userDto = new UserDto("yadhu", "krishna", "", "male", "thrissur", 9633508643, null, Roles.JobProvider);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            //Act
            var response = await _httpClient.PostAsync("company/memberRegister", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task POST_Register_company_member_Results_Success()
        {
            //Arrange  
            UserDto userDto = new UserDto("yadhu", "krishna", "yadhu@gmail.com", "male", "thrissur", 9633508643, "123", Roles.JobProvider);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            //Act
            var response = await _httpClient.PostAsync("company/memberRegister", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task Get_Listing_Company_Members_Without_CompanyId_Results_BadRequest()
        {
            //Arrange  
            UserDto userDto = new UserDto("yadhu", "krishna", "yadhu@gmail.com", "male", "thrissur", 9633508643, "123", Roles.JobProvider);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Act
            var response = await _httpClient.GetAsync("company/memberListing?companyId=");
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task Get_Listing_Company_Members_With_CompanyId_Results_Success()
        {
            //Arrange  
            UserDto userDto = new UserDto("yadhu", "krishna", "yadhu@gmail.com", "male", "thrissur", 9633508643, "123", Roles.JobProvider);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Act
            var response = await _httpClient.GetAsync("company/memberListing?companyId=1d8303fb-c1e1-4fa6-a2e1-272472b2beb4");
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
     

    }
}
