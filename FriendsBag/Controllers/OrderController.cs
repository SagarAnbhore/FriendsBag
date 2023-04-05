using FriendsBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace FriendsBag.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveOrder(OrderModel model)
        {
            try
            {
                return Json(new { Message = (new OrderModel().SaveOrder(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json (new {ex.Message},JsonRequestBehavior.AllowGet);
            }

        }
    }
}