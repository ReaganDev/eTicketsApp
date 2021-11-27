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
        private readonly IOrdersService _orders;
        private readonly IMoviesService _service;

        public OrdersController(ShoppingCart cart, IOrdersService orders, IMoviesService service)
        {
            _cart = cart;
            _orders = orders;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var userId = "";
            var orders = await _orders.GetOrdersByIdAsync(userId);
            return View(orders);
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

        public async Task<RedirectToActionResult> RemoveFromCart(int id)
        {
            var item = await _service.GetMovieByIdAync(id);
            if (item != null)
            {
                _cart.RemoveItem(item);
            }

            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _cart.GetItems();
            var user = "";
            var email = "";

            await _orders.StoreOrderAsync(items, user, email);
            await _cart.ClearCartAsync();
            return View("OrderCompleted");
        }
    }
}
