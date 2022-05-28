using System.Text;
using Microservices.Web.Models;
using Newtonsoft.Json;

namespace Microservices.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseDto { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseDto = new ResponseDto();
            this.httpClient = httpClient;
        }

        public void Dispose()
        {

        }





        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MangoAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8,
                        "application/json");
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                var response = await client.SendAsync(message);
                var apiContent = await response.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch (Exception exception)
            {
                var dto = new ResponseDto
                {
                    Message = "Error",
                    IsSuccess = false,
                    Errors = new List<string>() { exception.Message }
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;

            }


        }
    }
}
