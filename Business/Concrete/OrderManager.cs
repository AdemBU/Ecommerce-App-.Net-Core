using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task AddOrderAsync(Order order) => await _orderDal.AddAsync(order);

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _orderDal.GetByIdAsync(id);
            if (order != null)
            {
                await _orderDal.DeleteAsync(order);
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() => await _orderDal.GetAllAsync();

        public async Task<Order> GetOrderByIdAsync(int id) => await _orderDal.GetByIdAsync(id);

        public async Task UpdateOrderAsync(Order order) => await _orderDal.UpdateAsync(order);
    }
}
