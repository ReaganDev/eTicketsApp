using System.Collections.Generic;
using System.Threading.Tasks;
using ETicketsApp.Models;

namespace ETicketsApp.Data.Interfaces
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string email);
        Task<List<Order>> GetOrdersByIdAsync(string userId);

    }
}
