using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllProductsAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Product bulunamadı.");
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Product bulunamadı.");
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Product product)
        {
            await _productService.AddProductAsync(product);
            return Ok("Product eklendi.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.UpdateProductAsync(product);
            return Ok("Product güncellendi.");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Product silindi.");
        }
    }
}
