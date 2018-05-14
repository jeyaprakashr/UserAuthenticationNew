using DataAccess.DataModel;
using DataAccess.Repository;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserAuthentication.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        private ICustomerService _ICustomerService;

        public CustomerController(ICustomerService ICustomerService)
        {
            _ICustomerService = ICustomerService;
        }

        public ActionResult GetCustomer()
        {
            return Json(_ICustomerService.GetCustomers(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomerEntities()
        {
            return Json(_ICustomerService.GetCustomerEntities(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddCustomer()
        {
            return Json(_ICustomerService.AddCustomer(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        public ActionResult JQAjaxAddCustomerDB(CustomerMaster cm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerRepository cmRepo = new CustomerRepository();
                    if (cmRepo.AddCustomer(cm))
                    {
                        return Json(new
                        {
                            msg = "Successfully added " + cm.CompanyName
                        });
                        //ViewBag.Message = "Customer details added successfully";
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}