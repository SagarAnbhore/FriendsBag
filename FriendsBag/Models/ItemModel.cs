using FriendsBag.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace FriendsBag.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string Discount { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public string SaveItem(HttpPostedFileBase fb, ItemModel model)
        {
            String msg = "";
            FriendsBagEntities1 db = new FriendsBagEntities1();
            string filePath = "";
            string fileName = "";
            string sysFileName = "";
            if (fb != null && fb.ContentLength > 0)
            {

                //filePath = HttpContext.Current.Server.MapPath("~/Content/Pages/images/");
                filePath = HttpContext.Current.Server.MapPath("~/Content/img/");
                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!di.Exists)
                {
                    di.Create();
                }
                fileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string filename = HttpContext.Current.Server.MapPath("~/Content/img/") + "/" + sysFileName;

                }
            }
            var SaveItem = new tblItem()
            {
                ItemName = model.ItemName,
                ItemPrice = model.ItemPrice,
                Discount = model.Discount,
                Gender = model.Gender,              
                Colour = model.Colour,
                Description = model.Description,
                Date = Convert.ToDateTime(model.Date),
                Image = sysFileName,
            };
            db.tblItems.Add(SaveItem);
            db.SaveChanges();
            return msg;

        }

        public List<ItemModel> GetItemList()
        {
            FriendsBagEntities1 db = new FriendsBagEntities1();
            List<ItemModel> lstItem = new List<ItemModel>();
            var ItemList = db.tblItems.ToList();
            if (ItemList != null)
            {
                foreach (var Item in ItemList)
                {
                    lstItem.Add(new ItemModel()
                    {
                        Id = Item.Id,
                        ItemName = Item.ItemName,
                        ItemPrice = Item.ItemPrice,
                        Discount = Item.Discount,
                        Gender = Item.Gender,                      
                        Colour = Item.Colour,
                        Description = Item.Description,
                        Date = Item.Date.ToShortDateString(),
                        Image = Item.Image,

                    });
                }
            }
            return lstItem;
        }
        public List<ItemModel> GetItemddl()
        {
            FriendsBagEntities1 Db = new FriendsBagEntities1();
            List<ItemModel> lstItem = new List<ItemModel>();
            var SaveItem = Db.tblItems.ToList();
            if (SaveItem != null)
            {
                foreach (var Drop in SaveItem)
                {
                    lstItem.Add(new ItemModel()
                    {
                        Id = Drop.Id,
                        ItemName = Drop.ItemName,
                    });

                }
            }
            return lstItem;
        }
    }
    }
     