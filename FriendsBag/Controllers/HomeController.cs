using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FriendsBag.Models;

namespace FriendsBag.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ContactList()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SaveContact(ContactModel model)

        {
            try
            {
                return Json(new { Message = (new ContactModel().SaveContact(model)) },JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetContactList()
        {
            try

            {
                return Json(new { model = new ContactModel().GetContactList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult deleteContact(int Id)
        {
            try
            {
                return Json(new { model = (new ContactModel().deleteContact(Id)) },
               JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }




        public ActionResult Shop()
        {
            ViewBag.Message = "Your shop page.";

            return View();
        }
        //public ActionResult GetItemList()
        //{

        //    try
        //    {

        //        return Json(new { model = (new ItemModel().GetItemList()) }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}