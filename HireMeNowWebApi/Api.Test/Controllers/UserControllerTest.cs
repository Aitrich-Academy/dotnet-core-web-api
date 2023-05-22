using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Api.Test.Fixtures;
using Newtonsoft.Json;
using HireMeNowWebApi.Dtos;
using System.Net.Http.Headers;
using HireMeNowWebApi.Enums;

namespace Api.Test.Controllers
{
    public class UserControllerTest
    {
        protected readonly HttpClient _httpClient;
        public UserControllerTest()
        {
            ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();
            _httpClient = _factory.CreateClient();
            //string accessToken = getAccessToken();
            //_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

        }

        [Fact]
        public async Task POST_Register_user_without_email_Results_BadRequest()
        {
            //Arrange  
            UserDto userDto = new UserDto("yadhu", "krishna", "", "male", "thrissur", 9633508643, "123", Roles.JobProvider);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            //Act
            var response = await _httpClient.PostAsync("account/register", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [Fact]
        public async Task POST_Register_User_Without_Password_Results_BadRequest()
        {
            //Arrange  
            UserDto userDto = new UserDto("yadhu", "krishna", "", "male", "thrissur", 9633508643, null, Roles.JobProvider);
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            //Act
            var response = await _httpClient.PostAsync("account/register", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task POST_Register_user_Results_Success()
        {
            //Arrange  
            UserDto userDto = new UserDto("yadhu","krishna","yadhu@gmail.com","male","thrissur",9633508643,"123",Roles.JobProvider) ;
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

           
            //Act
            var response = await _httpClient.PostAsync("account/register", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
