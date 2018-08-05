using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickMenu.Models;

namespace QuickMenu.ViewModels
{
    public class ProductDescriptionLoading
    {
        
        public orderdetail orddet= new orderdetail();
        public product product;       
        public ProductDescriptionLoading(product p)
        {
            product = p;
        }
    }
}