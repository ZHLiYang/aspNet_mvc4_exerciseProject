using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using MVCSportsStore.Models;

namespace MVCSportsStore.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private IProductRepository repository;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public int PageSize = 4;
        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                paginginfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =category==null? repository.Products.Count():
                    repository.Products.Where(p => category==p.Category).Count()
                },
                CurrentCategory=category
            };
            return View(model);
        }

    }
}
