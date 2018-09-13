using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace MVCSportsStore.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/
        IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categorys = repository.Products.Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p);
            return PartialView(categorys);
        }

    }
}
