using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FriendsBag.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
       
        public ActionResult AddShopIndex()
        {
            return View();
        }
        public ActionResult DetailsShopIndex()
        {
            return View();
        }
    }
}