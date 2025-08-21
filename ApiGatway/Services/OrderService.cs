using ApiGatway.Constants;
using ApiGatway.Interfaces;
using Newtonsoft.Json;
using Resouces.DTOs;
using Resouces.Entities;
using System.Net.Http;
using System.Text;

namespace ApiGatway.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory _polly;
        private HttpClient httpClient;

        public OrderService(IHttpClientFactory polly)
        {
            _polly = polly;
            httpClient = _polly.CreateClient("GenericPolly");
        }

        public async Task<bool> Order(List<ProductsDto> CartProducts, long UserId)
        {
            string body = JsonConvert.SerializeObject(CartProducts);
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync($"{UrlApis.OrderApiUrl}Order/UserId/{UserId}", content);

            if (response.IsSuccessStatusCode)
            {
                return Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
            }

            return false;
            
        }
    }
}
