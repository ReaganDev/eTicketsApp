using ETicketsApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace ETicketsApp.Data
{
    public class CartSummaryVC : ViewComponent
    {
        private readonly ShoppingCart _cart;
        public CartSummaryVC(ShoppingCart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _cart.GetItems();
            return View(items.Count);
        }
    }
}
