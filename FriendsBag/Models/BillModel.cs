using FriendsBag.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FriendsBag.Models
{
    public class BillModel
    {
        public int Bill_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Item_Name { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Total_Amount { get; set; }
        public int Invoice_No { get; set; }
        public string Date { get; set; }
        public string Payment_Mode { get; set; }

        public string SaveBill(BillModel model)
        {
            string msg = "";
            FriendsBagEntities1 db = new FriendsBagEntities1();
            if (model.Bill_Id == 0)
            {
                var SaveBill = new tblBill()
                {
                    Customer_Name = model.Customer_Name,
                    Item_Name = model.Item_Name,
                    Quantity = model.Quantity,
                    Amount = model.Amount,
                    Total_Amount = model.Total_Amount,
                    Invoice_No = model.Invoice_No,
                    Date = Convert.ToDateTime(model.Date),
                    Payment_Mode = model.Payment_Mode,
                };
                db.tblBills.Add(SaveBill);
                db.SaveChanges();
                msg = "Data Saved";
            }

            else
            {
                var BillData = db.tblBills.Where(p => p.Bill_Id == model.Bill_Id).FirstOrDefault();
                if (BillData != null)
                {
                    BillData.Customer_Name = model.Customer_Name;
                    BillData.Item_Name = model.Item_Name;
                    BillData.Quantity = model.Quantity;
                    BillData.Amount = model.Amount;
                    BillData.Total_Amount = model.Total_Amount;
                    BillData.Invoice_No = model.Invoice_No;
                    BillData.Date = Convert.ToDateTime(model.Date);
                    BillData.Payment_Mode = model.Payment_Mode;

                };

                db.SaveChanges();
                msg = "Updated Successfully";

               

            }

            return msg;

        }
    
        public List<BillModel> GetBillList()
        {
            FriendsBagEntities1 db = new FriendsBagEntities1();
            List<BillModel> lstBill = new List<BillModel>();
            var BillList = db.tblBills.ToList();
            if (BillList != null)
            {
                foreach (var bill in BillList)
                {
                  lstBill.Add(new BillModel()
                    {
                        Bill_Id = bill.Bill_Id,
                        Customer_Name = bill.Customer_Name,
                        Item_Name = bill.Item_Name,
                        Quantity = bill.Quantity,
                        Amount = bill.Amount,
                        Total_Amount = bill.Total_Amount,
                        Invoice_No = bill.Invoice_No,
                      Date = bill.Date.ToShortDateString(),
                      Payment_Mode = bill.Payment_Mode,

                    });
                }
            }
            return lstBill;
        }
        public BillModel EditBill(int Bill_Id)
        {
            string Message = "";
            BillModel model = new BillModel();
            FriendsBagEntities1 db = new FriendsBagEntities1();
            var BillData = db.tblBills.Where(p => p.Bill_Id == Bill_Id).FirstOrDefault();
            if (BillData != null)
            {
                model.Bill_Id = BillData.Bill_Id;
                model.Customer_Name = BillData.Customer_Name;
                model.Item_Name = BillData.Item_Name;
                model.Quantity = BillData.Quantity;
                model.Amount = BillData.Amount;
                model.Total_Amount = BillData.Total_Amount;
                model.Invoice_No = BillData.Invoice_No;
                model.Date = BillData.Date.ToShortDateString();
                model.Payment_Mode = BillData.Payment_Mode;

            };
            return model;
        }
    }

}