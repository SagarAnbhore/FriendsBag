using FriendsBag.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;

namespace FriendsBag.Models
{
    public class InvoiceModel
    {
        public int Invoice_Id { get; set; }
        public int Customer_Id { get; set; }
        public string Item_Name { get; set; }
        public decimal Amout { get; set; }
        public decimal Discount { get; set; }
        public int Quntity { get; set; }
        public decimal Total_Amount { get; set; }
        public string Invoice_Date { get; set; }
        public string Payment_Mode { get; set; }
        public decimal IGST { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }

        public string SaveInvoice(InvoiceModel model)
        {
            string msg = "";
            FriendsBagEntities1 db = new FriendsBagEntities1();
            var SaveInvoice = new tbiInvoice()
            {
                Customer_Id = model.Customer_Id,
                Item_Name = model.Item_Name,
                Amout = model.Amout,
                Discount = model.Discount,
                Quntity = model.Quntity,
                Total_Amount = model.Total_Amount,
                Invoice_Date = Convert.ToDateTime(model.Invoice_Date),
                Payment_Mode = model.Payment_Mode,
                IGST = model.IGST,
                CGST = model.CGST,
                SGST = model.SGST,
            };
            db.tbiInvoices.Add(SaveInvoice);
            db.SaveChanges();
            return msg;
        }

        public List<InvoiceModel>GetInvoiceList()
        {
            FriendsBagEntities1 db = new FriendsBagEntities1();
            List<InvoiceModel>lstInvoice = new List<InvoiceModel>();
            var InvoiceList = db.tbiInvoices.ToList();
            if(InvoiceList!=null)
            {
                foreach(var Invoice in InvoiceList)
                {
                    lstInvoice.Add(new InvoiceModel()
                    {
                        Invoice_Id = Invoice.Invoice_Id,
                        Customer_Id = Invoice.Customer_Id,
                        Item_Name = Invoice.Item_Name,
                        Amout = Invoice.Amout,
                        Discount = Invoice.Discount,
                        Quntity = Invoice.Quntity,
                        Total_Amount = Invoice.Total_Amount,
                        Invoice_Date = Invoice.Invoice_Date.ToShortDateString(),
                        Payment_Mode = Invoice.Payment_Mode,
                        IGST = Invoice.IGST,
                        CGST = Invoice.CGST,
                        SGST = Invoice.SGST,
                    });

                }
            }
            return lstInvoice;
            
        }
    }
}