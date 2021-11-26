using System.Threading.Tasks;
using ETicketsApp.Data;
using ETicketsApp.Data.Interfaces;
using ETicketsApp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ETicketsApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _cart;
        private readonly IMoviesService _service;

        public OrdersController(ShoppingCart cart, IMoviesService service)
        {
            _cart = cart;
            _service = service;
        }
        public IActionResult ShoppingCart()
        {
            var items = _cart.GetItems();
            _cart.ShoppingCartItems = items;
            var res = new ShoppingCartVM()
            {
                ShoppingCart = _cart,
                Total = _cart.GetShoppingCartTotal()
            };
            return View(res);
        }

        public async Task<RedirectToActionResult> AddToCart(int id)
        {
            var item = await _service.GetMovieByIdAync(id);
            if (item != null)
            {
                _cart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));

        }
    }
}
