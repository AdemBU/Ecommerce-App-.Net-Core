using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task AddProductAsync(Product product) => await _productDal.AddAsync(product);

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productDal.GetByIdAsync(id);
            if (product != null)
            {
                await _productDal.DeleteAsync(product);
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _productDal.GetAllAsync();

        public async Task<Product> GetProductByIdAsync(int id) => await _productDal.GetByIdAsync(id);

        public async Task UpdateProductAsync(Product product) => await _productDal.UpdateAsync(product);
    }
}
