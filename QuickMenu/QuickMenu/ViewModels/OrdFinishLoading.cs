using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickMenu.Models;

namespace QuickMenu.ViewModels
{
    public class OrdFinishLoading
    {
        public List<orderdetail> orderdetails = new List<orderdetail>();
        public List<product> pnames = new List<product>();
        public order order = new order();
        public OrdFinishLoading(List<orderdetail> od)
        {
            orderdetails = od;


            foreach (var r in orderdetails)
            {

                using (restaurantsdbEntities dbp = new restaurantsdbEntities())
                {
                    var Getpname = dbp.products.Where(x => x.IDProduct == r.Product_IDProduct).First();
                    pnames.Add(Getpname);
                }
                using (restaurantsdbEntities dbp = new restaurantsdbEntities())
                {
                    try
                    {
                        var Getlastid = dbp.orders.Last();
                        order.IDOrder = (Getlastid.IDOrder) + 1;
                    }
                    catch
                    {
                        order.IDOrder = 1;
                    }
                }

            }
        }
    }
}