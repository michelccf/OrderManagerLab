using ApiGatway.Auth;
using ApiGatway.Constants;
using ApiGatway.Interfaces;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Newtonsoft.Json;
using Resouces.DTOs;
using Resources.DTOs;
using System.Net.Http;
using System.Text;

namespace ApiGatway.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _polly;
        private readonly JwtAuth _jwt;
        private HttpClient httpClient;

        public UserService(IHttpClientFactory polly, JwtAuth jwt)
        {
            _polly = polly;
            httpClient = _polly.CreateClient("GenericPolly");
            _jwt = jwt;
        }

        public async Task<Login> Login(Login loginData)
        {
            string body = JsonConvert.SerializeObject(loginData);
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"{UrlApis.UserApiUrl}Login", content);
            string passwordHash = Encrypto(loginData.Password);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                UserDto user = JsonConvert.DeserializeObject<UserDto>(result);

                if(BCrypt.Net.BCrypt.Verify(loginData.Password, user.Password))
                {
                    loginData.Token = _jwt.GenerateJwt(user.Id, user.Email);
                    loginData.UserId = user.Id;
                    return loginData;
                }
                     
            }

            return null;
        }

        private bool VerifyPassword(string passwordHash, string password)
        {
            return passwordHash == password;
        }

        public async Task<bool> CreateAccount(UserDto userData)
        {
            userData.Password = Encrypto(userData.Password);
            string body = JsonConvert.SerializeObject(userData);
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"{UrlApis.UserApiUrl}CreateAccount", content);

            if (response.IsSuccessStatusCode)
            {
                return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
            }

            return false;
        }

        private string Encrypto(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
