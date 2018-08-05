using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickMenu.Models;

namespace QuickMenu.ViewModels
{
    public class DetailsLoading
    {
        public List<orderdetail> orderdetails = new List<orderdetail>();
        public List<product> pnames = new List<product>();
        public order order = new order();
        public DetailsLoading( int id)
        {   
            
            
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {
                order = db.orders.Find(id);
            }
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {
                var GetOD = db.orderdetails.Where(x => x.IDOrder == id);
                foreach (var r in GetOD)
                {
                    product Getpname;
                    using (restaurantsdbEntities dbp = new restaurantsdbEntities())
                    {
                        Getpname = dbp.products.Where(x => x.IDProduct == r.Product_IDProduct).First();
                    }
                    pnames.Add(Getpname);
                    orderdetails.Add(r);
                }
                
            }
        }        
    }
}