using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9_nb348.Infrastructure;
using Mission9_nb348.Models;

namespace Mission9_nb348.Pages
{
    public class ShopModel : PageModel
    {
        private IBookstoreRepository _repo { get; set; }  
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public ShopModel (IBookstoreRepository temp, Basket b)
        {
            _repo = temp;
            basket = b;
        }



        public void OnGet(string returnUrl)
        {
            ReturnUrl = ReturnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = _repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
