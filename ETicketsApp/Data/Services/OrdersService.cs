using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicketsApp.Data.Interfaces;
using ETicketsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicketsApp.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByIdAsync(string userId)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Movie).Where(x => x.UserId == userId).ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string email)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = email,
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
