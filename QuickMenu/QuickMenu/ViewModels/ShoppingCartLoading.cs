using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using QuickMenu.Models;

namespace QuickMenu.ViewModels
{
    public class ShoppingCartLoading
    {
        
        public List<orderdetail> orderdetails = new List<orderdetail>();
        public List<product> pnames = new List<product>();        
        public ShoppingCartLoading(List<orderdetail> od)
        {               
           
            orderdetails = od;
                 
            
                foreach (var r in orderdetails)
                {
                    
                    using (restaurantsdbEntities dbp = new restaurantsdbEntities())
                    {                   
                       var Getpname = dbp.products.Where(x => x.IDProduct == r.Product_IDProduct).First();
                    }
                                       
                }                
            
        }        
    }
}