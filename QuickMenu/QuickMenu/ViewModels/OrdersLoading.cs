using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickMenu.Models;

namespace QuickMenu.ViewModels
{
    public class OrdersLoading
    {
       
        public List<order> orders = new List<order>();        
        public OrdersLoading()
        {
           
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {                
                var GetOrders = db.orders.Where(x => x.IDOrder >0);
                foreach (var r in GetOrders)
                {
                    orders.Add(r);
                }
                
            }
        }        
    }
}