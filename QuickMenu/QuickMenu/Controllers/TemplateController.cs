using QuickMenu.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickMenu.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
               
        private ViewModels.TemplateLoading Loadpagestyle()
        {
            ViewModels.TemplateLoading tl = new ViewModels.TemplateLoading();
            return tl;
        }
        private ViewModels.ProductDescriptionLoading Loadpd(product p)
        {
            ViewModels.ProductDescriptionLoading pd = new ViewModels.ProductDescriptionLoading(p);
            return pd;
        }
        private ViewModels.ShoppingCartLoading LoadSC(List<orderdetail> od)
        {
            ViewModels.ShoppingCartLoading sc = new ViewModels.ShoppingCartLoading(od);
            return sc;
        }
        public ActionResult Index()
        {            
            return View(Loadpagestyle());            
        }
        [HttpPost]
        public ActionResult Confirm(employee employeemodel)
        {
                       
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {

                var UserConfirmation = db.employees.Where(x => x.Email == employeemodel.Email && x.Password == employeemodel.Password).FirstOrDefault();
                if (UserConfirmation == null)
                {                    
                    employeemodel.LoginError = "Wrong Email or Password";
                    employeemodel.Password = null;
                    return View("_TemLog",employeemodel);
                }
                else
                {
                    Session["email"] = UserConfirmation.Email;
                    Session["name"] = UserConfirmation.Name;
                    Session["position"] = UserConfirmation.Position;                    
                    if (UserConfirmation.Position == "Gerente")
                    {
                        return RedirectToAction("Index", "Management");
                    }
                    else if(UserConfirmation.Position == "Camarero" || UserConfirmation.Position == "Personal Cocina")
                    {
                        return RedirectToAction("Index", "Order");
                    }
                    else
                    {
                        return Redirect("/Template/Index/");
                    }
                }
            }
        }
        public ActionResult DesPro(product productmodel)
        {
            return PartialView("_ProDes", Loadpd(productmodel));
        }
        public ActionResult AddShC(orderdetail orderdetailmodel, string id)
        {
            Debug.WriteLine("hola" + orderdetailmodel.Product_IDProduct + " " + orderdetailmodel.Quantity);
            List<orderdetail> od = new List<orderdetail>();
            od.Add(orderdetailmodel);
            return PartialView("_ShCart",LoadSC(od));            
        }
    }
}