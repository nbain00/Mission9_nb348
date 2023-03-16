using Microsoft.AspNetCore.Mvc;
using Mission9_nb348.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_nb348.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        // This view component is for the cart icon in the corner and the info about it
        private Basket basket;
        public CartSummaryViewComponent(Basket b)
        {
            basket = b;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
