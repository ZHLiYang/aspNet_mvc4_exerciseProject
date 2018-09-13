using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;


namespace MVCSportsStore.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo paginginfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}