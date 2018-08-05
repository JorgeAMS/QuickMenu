using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickMenu.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Models.employee employeemodel)
        {

            using (Models.restaurantsdbEntities db = new Models.restaurantsdbEntities())
            {

                var UserConfirmation = db.employees.Where(x => x.Email == employeemodel.Email && x.Password == employeemodel.Password).FirstOrDefault();
                if (UserConfirmation == null)
                {
                    employeemodel.LoginError = "Wrong Email or Password";
                    employeemodel.Password = null;
                    return View("_TemLog", employeemodel);
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
                    else 
                    {
                        return RedirectToAction("Index", "Order");
                    }
                }
            }
        }
    }
}