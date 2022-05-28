using Microservices.Services.Product.Dtos;
using Microservices.Services.Product.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.Product.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ResponseDto _responseDto;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _responseDto = new ResponseDto();
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                _responseDto.Result = products;
            }
            catch (Exception exception)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Errors = new List<string> { exception.ToString() };
            }
            return _responseDto;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var products = await _productRepository.GetProductById(id);
                _responseDto.Result = products;
            }
            catch (Exception exception)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Errors = new List<string> { exception.ToString() };
            }
            return _responseDto;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                var products = await _productRepository.CreateUpdateProduct(productDto);
                _responseDto.Result = products;
            }
            catch (Exception exception)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Errors = new List<string> { exception.ToString() };
            }
            return _responseDto;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                var products = await _productRepository.CreateUpdateProduct(productDto);
                _responseDto.Result = products;
            }
            catch (Exception exception)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Errors = new List<string> { exception.ToString() };
            }
            return _responseDto;
        }
        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                var products = await _productRepository.DeleteProduct(id);
                _responseDto.Result = products;
            }
            catch (Exception exception)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Errors = new List<string> { exception.ToString() };
            }
            return _responseDto;
        }
    }
}
