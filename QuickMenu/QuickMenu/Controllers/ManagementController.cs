using QuickMenu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickMenu.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        private ViewModels.ManagementLoading managementLoading()
        {
            ViewModels.ManagementLoading ml = new ViewModels.ManagementLoading();
            return ml;
        }
        public ActionResult Index()
        {
            
                return View(managementLoading());
           
            
        }
        public ActionResult IndexAlt()
        {
           
                return View(managementLoading());
           

        }
        public ActionResult GetProducts()
        {
                   
            return View("Index", managementLoading());
        }
        public ActionResult GetEmployees()
        {
                              
            return View("IndexAlt", managementLoading());
        }
        public ActionResult EditEmp(employee employeemodel)
        {
            return PartialView("_EmpEdit",employeemodel);
        }
        public ActionResult EditPro(product productmodel)
        {
            return PartialView("_ProEdit", productmodel);
        }        
        [HttpPost]
        public ActionResult AddEmp(employee employeemodel)
        {
            
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {
                try
                {
                    var EmployeeCreation = db.Set<employee>();
                    EmployeeCreation.Add(new employee { Email = employeemodel.Email, Password = employeemodel.Password, Name = employeemodel.Name, Position = employeemodel.Position });                    
                    db.SaveChanges();
                    return RedirectToAction("Index", "Management");
                }
                catch (Exception ex)
                {
                    employeemodel.AddEError = "Couldn't create new Employee" + ex;
                    return PartialView("_EmpAdd", employeemodel);
                }
            }
        }
        [HttpPost]
        public ActionResult AddPro(product productmodel)
        {
            
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {
                try
                {
                    int idp;
                    product LastProduct;
                    try
                    {
                        LastProduct = db.products.Where(x => x.IDProduct > 0).OrderByDescending(x => x.IDProduct).First();
                        idp = LastProduct.IDProduct + 1;
                    }
                    catch
                    {
                        idp = 1;
                    }                   
                    var ProductCreation = db.Set<product>();
                    ProductCreation.Add(new product { IDProduct = idp, Name = productmodel.Name, Price = productmodel.Price,Details=productmodel.Details });
                    db.SaveChanges();
                    return RedirectToAction("Index", "Management");
                }
                catch (Exception ex)
                {
                    productmodel.AddPError = "Couldn't create new Product" + ex;
                    return PartialView("_ProAdd", productmodel);
                }
            }
        }
        [HttpPost]
        public ActionResult UpdateEmp(employee employeemodel)
        {
       
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(employeemodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("GetEmployees");
                }
                else
                {
                    employeemodel.AddEError = "Couldn't edit Employee";
                    return PartialView("_EmpEdit", employeemodel);
                }
            }
        }
        [HttpPost]
        public ActionResult UpdatePro(product productmodel)
        {
           
            using (restaurantsdbEntities db = new restaurantsdbEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(productmodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("GetProducts");
                }
                else
                {
                    productmodel.AddPError = "Couldn't edit Product";
                    return PartialView("_ProEdit", productmodel);
                }
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return Redirect("/Template/Index/");
        }
    }
}