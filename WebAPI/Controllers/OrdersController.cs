using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAllOrdersAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Order bulunamadı.");
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Order bulunamadı.");
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Order order)
        {
            await _orderService.AddOrderAsync(order);
            return Ok("Order eklendi.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Order order)
        {
            await _orderService.UpdateOrderAsync(order);
            return Ok("Order güncellendi.");
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return Ok("Order silindi.");
        }
    }
}
