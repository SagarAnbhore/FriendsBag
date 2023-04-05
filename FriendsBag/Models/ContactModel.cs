using FriendsBag.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FriendsBag.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Message { get; set; }

        public String SaveContact(ContactModel model)
        {
            string msg = "";
            FriendsBagEntities1 db = new FriendsBagEntities1();
            var SaveContact = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                MobileNo = model.MobileNo,
                Message = model.Message,
            };
            db.Contacts.Add(SaveContact);
            db.SaveChanges();
            return msg;
        }
        public List<ContactModel> GetContactList()
        {
            FriendsBagEntities1 db = new FriendsBagEntities1();
            List<ContactModel> lstContact = new List<ContactModel>();
            var AddContactList = db.Contacts.ToList();
            if (AddContactList != null)
            {
                foreach (var Contact in AddContactList)
                {
                    lstContact.Add(new ContactModel()
                    {
                        Id = Contact.Id,
                        FirstName = Contact.FirstName,
                        LastName = Contact.LastName,
                        Email = Contact.Email,
                        MobileNo = Contact.MobileNo,
                        Message = Contact.Message,

                    });
                }
            }
            return lstContact;
        }

        public string deleteContact(int Id)
        {
            string msg = "";
            FriendsBagEntities1 db = new FriendsBagEntities1();
            var deleteContact = db.Contacts.Where(p => p.Id == Id).FirstOrDefault();
            if (deleteContact != null)
            {
                db.Contacts.Remove(deleteContact);
            };
            db.SaveChanges();
            msg = "Record delete";
            return msg;
        }

    }
}