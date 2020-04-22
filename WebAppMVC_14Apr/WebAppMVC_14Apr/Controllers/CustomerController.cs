using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC_14Apr.Models;

namespace WebAppMVC_14Apr.Controllers
{
    public class CustBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objContext = controllerContext.HttpContext;
            string custCode = objContext.Request.Form["txtCustomerCode"];
            string custName = objContext.Request.Form["txtCustomerName"];
            Customer obj = new Customer()
                            {
                                CustomerCode = custCode,
                                CustomerName = custName
                            };
            return obj;
        }
    }

    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        public ActionResult Load()
        {
            Customer obj =
                         new Customer
                         {
                             CustomerCode = "1001",
                             CustomerName = "Dipti"
                         };
            return View("Customer", obj);
        }
        public ActionResult Enter()
        {
            return View("EnterCustomer", new Customer());
        }

        //public ActionResult Submit( [ModelBinder(typeof(CustBinder))]
        //                            Customer obj)
        public ActionResult Submit(Customer obj)
        {
            //Customer obj = new Customer();
            //obj.CustomerName = Request.Form["CustomerName"];
            //obj.CustomerCode = Request.Form["CustomerCode"];
            if (ModelState.IsValid)
            {
                return View("Customer", obj);
            }
            else
            {
                return View("EnterCustomer", obj);
            }
        }
    }
}