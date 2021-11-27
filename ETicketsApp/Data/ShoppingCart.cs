using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicketsApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            var cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public List<ShoppingCartItem> GetItems()
        {
            return ShoppingCartItems ??= _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Include(x => x.Movie).ToList();
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

        public void RemoveItem(Movie movie)
        {
            var item = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);
            if (item != null)
            {
                if (item.Amount > 1)
                {
                    item.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(item);
                }
            }
            _context.SaveChanges();
        }

        public async Task ClearCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

    }
}
