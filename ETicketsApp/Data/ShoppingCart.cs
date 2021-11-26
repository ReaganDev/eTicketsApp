using System.Collections.Generic;
using System.Linq;
using ETicketsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicketsApp.Data
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public List<ShoppingCartItem> GetItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Include(x => x.Movie).ToList());
        }

        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Select(x => x.Movie.Price * x.Amount).Sum();
            return total;
        }

        public void AddItemToCart(Movie movie)
        {
            var item = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);
            if (item == null)
            {
                item = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(item);
            }
            else
            {
                item.Amount++;
            }
            _context.SaveChanges();
        }

    }
}
