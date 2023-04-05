using FriendsBag.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FriendsBag.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int InvoicId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string colour { get; set; }
        public decimal Price { get; set; }
        public string PaymentMode { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderNotes { get; set; }
        public string Item { get; set; }

        public string SaveOrder(OrderModel model)
        {
            string msg = "";
            FriendsBagEntities1 db = new FriendsBagEntities1();
            var SaveOrder = new tblOrder()
            {
                InvoicId = model.InvoicId,
                Name = model.Name,
                MobileNo = model.MobileNo,
                Address = model.Address,
                City = model.City,
                colour = model.colour,
                Price = model.Price,
                PaymentMode = model.PaymentMode,
                DeliveryDate = model.DeliveryDate,
                TotalAmount = model.TotalAmount,
                OrderNotes = model.OrderNotes,
                Item = model.Item,

            };
            db.tblOrders.Add(SaveOrder);
            db.SaveChanges();
            return msg;
        }

       

    }
}