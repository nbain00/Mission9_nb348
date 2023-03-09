using Microsoft.AspNetCore.Mvc;
using Mission9_nb348.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_nb348.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository _repo { get; set; }

        public TypesViewComponent(IBookstoreRepository temp)
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookType"];

            var types = _repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
