using FriendsBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FriendsBag.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BillList()
        {
            return View();
        }

        public ActionResult SaveBill(BillModel model)
        {

            try
            {

                return Json(new { model = (new BillModel().SaveBill(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetBillList()
        {
            try

            {
                return Json(new { model = new BillModel().GetBillList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EditBill(int Bill_Id)
        {
            try
            {
                return Json(new { model = (new BillModel().EditBill(Bill_Id)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}