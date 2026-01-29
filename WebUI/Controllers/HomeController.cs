using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IOrderService orderService)
        {
            _logger = logger;
            _productService = productService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder(int productId)
        {
            var currentUserName = User.Identity?.Name;

            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null) return NotFound();

            var newOrder = new Order
            {
                OrderDate = DateTime.Now,
                UserName = currentUserName,
                TotalPrice = product.Price,
                OrderDetails = $"{product.ProductName} ürünü {currentUserName} tarafýndan satýn alýndý."
            };

            await _orderService.AddOrderAsync(newOrder);

            product.UnitsInStock -= 1;
            await _productService.UpdateProductAsync(product);

            return RedirectToAction("Index", "Order");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
