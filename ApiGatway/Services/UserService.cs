using ApiGatway.Constants;
using ApiGatway.Interfaces;
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
        private HttpClient httpClient;

        public UserService(IHttpClientFactory polly)
        {
            _polly = polly;
            httpClient = _polly.CreateClient("GenericPolly");
        }

        public async Task<string> Login(Login loginData)
        {
            string body = JsonConvert.SerializeObject(loginData);
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"{UrlApis.UserApiUrl}Login", content);

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            return null;
        }

        public async Task<bool> CreateAccount(UserDto userData)
        {
            string body = JsonConvert.SerializeObject(userData);
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"{UrlApis.UserApiUrl}CreatAccount", content);

            if (response.IsSuccessStatusCode)
            {
                return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
            }

            return false;
        }

    }
}
