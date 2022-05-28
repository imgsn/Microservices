using Microservices.Web.Models;

namespace Microservices.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {

                ApiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/products",
                AccessToken = ""

            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {

                ApiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/products/" + id,
                AccessToken = ""

            });
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = productDto,
                ApiType = SD.ApiType.POST,
                Url = SD.ProductApiBase + "/api/products",
                AccessToken = ""

            });

        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Data = productDto,
                ApiType = SD.ApiType.PUT,
                Url = SD.ProductApiBase + "/api/products",
                AccessToken = ""

            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {

                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductApiBase + "/api/products/" + id,
                AccessToken = ""

            });
        }
    }
}
