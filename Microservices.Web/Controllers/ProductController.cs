using Microservices.Web.Models;
using Microservices.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            var response = await _productService.GetAllProductsAsync<ResponseDto>();
            if (response?.IsSuccess == true)
            {
                var list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
                return View(list);
            }

            return View();
        }
    }
}
