using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickMenu.Models;

namespace QuickMenu.ViewModels
{
    public class ManagementLoading
    {
        
        public List<product> products = new List<product>();
        public List<employee> employees = new List<employee>();
        public ManagementLoading()
        {
            
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {
                var GetProducts = db.products.Where(x => x.IDProduct > 0);
                var GetEmployees = db.employees.Where(x => x.Email != null);
                foreach (var r in GetProducts)
                {
                    products.Add(r);
                }
                foreach (var r in GetEmployees)
                {
                    employees.Add(r);
                }
            }
        }
    }
}