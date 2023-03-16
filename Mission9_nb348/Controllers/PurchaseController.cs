using Microsoft.AspNetCore.Mvc;
using Mission9_nb348.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_nb348.Controllers
{
    // Make new controller per requirements
    public class PurchaseController : Controller
    {
        // Bring in repo
        private IPurchaseRepository _repo { get; set; }
        // Bring in basket
        private Basket basket { get; set; }

        // Contstructor for new controller
        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            _repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (basket.Items.Count() == 0)
            {
                // If no items in the cart, let the user know
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                // If everything is good, send things to the repo
                purchase.Lines = basket.Items.ToArray();
                _repo.SavePurchase(purchase);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                // If there's an error in the inputs, send them back
                return View();
            }
        }
    }
}
