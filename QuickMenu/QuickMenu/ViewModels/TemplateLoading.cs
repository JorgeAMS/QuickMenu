using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickMenu.Models;

namespace QuickMenu.ViewModels
{
    public class TemplateLoading
    {
        
        public List<product> products=new List<product>();               
        public TemplateLoading()
        {
                   
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {
                
                var GetProducts = db.products.Where(x=>x.IDProduct >0);
                foreach (var r in GetProducts)
                {
                    products.Add(r);
                }
            }            
        }
    }
}