using FriendsBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace FriendsBag.Controllers.Admin
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListInvoice()
        {
            return View();
        }
        public ActionResult SaveInvoice(InvoiceModel model)
        {
            try
            {
                return Json(new { Message = (new InvoiceModel().SaveInvoice(model)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetInvoiceList()
        {
            try

            {
                return Json(new { model = new InvoiceModel().GetInvoiceList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}