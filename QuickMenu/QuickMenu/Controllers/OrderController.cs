using QuickMenu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickMenu.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private ViewModels.OrdersLoading ordersLoading()
        {
            ViewModels.OrdersLoading ml = new ViewModels.OrdersLoading();
            return ml;
        }
        public ActionResult Index()
        {
            
                return View(ordersLoading());
           

        }
        public ActionResult GetOrders()
        {
            
            return PartialView("Index", ordersLoading());
        }
        
        
        public ActionResult EditOrd(order ordermodel)
        {
            return PartialView("_OrdEdit", ordermodel);
        }
        
        public ActionResult DetOrd(order ordermodel)
        {
            return PartialView("_OrdDet", LoadOrdDet(ordermodel.IDOrder));
        }
        public ActionResult UpdateOrd(order ordermodel)
        {
           
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ordermodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("GetOrders");
                }
                else
                {
                    ordermodel.AddOError = "Couldn't edit Order";
                    return PartialView("_OrdEdit", ordermodel);
                }
            }
        }
        public ActionResult OrderDetails(int id)
        {
            return PartialView("_Details", LoadOrdDet(id));
        }
        private ViewModels.DetailsLoading LoadOrdDet(int id)
        {
           
            ViewModels.DetailsLoading dl = new ViewModels.DetailsLoading(id);
            return dl;
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return Redirect("/Template/Index/");
        }
    }
}