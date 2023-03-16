using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_nb348.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext _context;
        public EFPurchaseRepository(BookstoreContext temp)
        {
            _context = temp;
        }
        public IQueryable<Purchase> Purchases => _context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);
        public void SavePurchase(Purchase purchase)
        {
            _context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.PurchaseId == 0)
            {
                _context.Purchases.Add(purchase);
            }

            _context.SaveChanges();
        }
    }
}
