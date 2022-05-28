using AutoMapper;
using Microservices.Services.Product.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ProductDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var products = _db.Products.FirstOrDefault(x => x.ProductId == id);
            return _mapper.Map<ProductDto>(products);
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Entities.Product>(productDto);
            if (product.ProductId > 0)
                _db.Products.Update(product);
            else
                _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var products = _db.Products.FirstOrDefault(x => x.ProductId == productId);
            if (products == null)
                return false;

            _db.Products.Remove(products);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
