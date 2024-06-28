using ApplicationCore.Interface;
using ContactManagement.Models;
using Domains.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactManagement.Controllers
{
    public class ContactsController : Controller
    {
        IContactRepository contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
         }
        public IActionResult Index()
        {      
            List<ContactViewModel> model = this.contactRepository.GetAllContacts().Select(s => new ContactViewModel
            {
                Id = s.Id,
                Name = $"{s.FirstName} {s.LastName}",
                SocialSecurityNumber = s.SocialSecurityNumber,
                EmailId = s.EmailId,
                DateOfBirth= Convert.ToDateTime(s.DateOfBirth, CultureInfo.InvariantCulture),
                Gender=s.Gender,
                Address= (s.Address1.Trim().Length>0 ? s.Address1 +"," : "") + (s.Address2.Trim().Length > 0 ? s.Address2 + "," : "") + (s.City.Trim().Length > 0 ? s.City + "," : "") + (s.State.Trim().Length > 0 ? s.State + "," : "") + (s.PinCode.Trim().Length > 0 ? s.PinCode + "," : "")//$"{s.Address1} {s.Address2}, {s.City}, {s.State}, {s.PinCode}"
            }).ToList();
            return View("Index", model);
        }
      [HttpGet]
        public JsonResult List()
        {
            List<ContactViewModel> model = this.contactRepository.GetAllContacts().Select(s => new ContactViewModel
            {
                Id = s.Id,
                Name = $"{s.FirstName} {s.LastName}",
                SocialSecurityNumber = s.SocialSecurityNumber,
                EmailId = s.EmailId,
                DateOfBirth = s.DateOfBirth,
                Gender = s.Gender,
                Address = (s.Address1.Trim().Length > 0 ? s.Address1 + "," : "") + (s.Address2.Trim().Length > 0 ? s.Address2 + "," : "") + (s.City.Trim().Length > 0 ? s.City + "," : "") + (s.State.Trim().Length > 0 ? s.State + "," : "") + (s.PinCode.Trim().Length > 0 ? s.PinCode  : "")//$"{s.Address1} {s.Address2}, {s.City}, {s.State}, {s.PinCode}"
            }).ToList();
            return Json(model, new System.Text.Json.JsonSerializerOptions());
        }
        [HttpGet]
        public JsonResult Search(string searchtext)
        {
            if (searchtext == null)
            {
                return List();
            }

            List<ContactViewModel> model = this.contactRepository.GetAllContacts().Where(x=>x.FirstName.Contains(searchtext) || x.LastName.Contains(searchtext) || x.EmailId.Contains(searchtext) || x.PinCode.Contains(searchtext)).Select(s => new ContactViewModel
            {
                Id = s.Id,
                Name = $"{s.FirstName} {s.LastName}",
                SocialSecurityNumber = s.SocialSecurityNumber,
                EmailId = s.EmailId,
                DateOfBirth = s.DateOfBirth,
                Gender = s.Gender,
                Address = (s.Address1.Trim().Length > 0 ? s.Address1 + "," : "") + (s.Address2.Trim().Length > 0 ? s.Address2 + "," : "") + (s.City.Trim().Length > 0 ? s.City + "," : "") + (s.State.Trim().Length > 0 ? s.State + "," : "") + (s.PinCode.Trim().Length > 0 ? s.PinCode : "")//$"{s.Address1} {s.Address2}, {s.City}, {s.State}, {s.PinCode}"
            }).ToList();
            return Json(model, new System.Text.Json.JsonSerializerOptions());
        }
        [HttpGet]
        public JsonResult GetbyID(int ID)
        {
            var contact = this.contactRepository.GetContact(ID); ;
            return Json(contact, new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost]
        public IActionResult Update(contactDto obj)
        {
            var contact = this.contactRepository.GetContact(obj.Id); 

            contact.Id = obj.Id;
            contact.FirstName = obj.FirstName;
            contact.LastName = obj.LastName;
            contact.Gender = obj.Gender;
            contact.Address1 = obj.Address1==null ?"" : obj.Address1;
            contact.Address2 = obj.Address2 == null ? "" : obj.Address2;
            contact.City = obj.City == null ? "" : obj.City;
            contact.State = obj.State == null ? "" : obj.State;
            contact.PinCode = obj.PinCode == null ? "" : obj.PinCode;
            contact.PhoneNumber = obj.PhoneNumber;
            contact.FaxNumber = obj.FaxNumber == null ? "" : obj.FaxNumber;
            contact.EmailId = obj.EmailId;
            contact.SocialSecurityNumber = obj.SocialSecurityNumber;
            contact.DateOfBirth = obj.DateOfBirth;
            contact.UserName = obj.UserName;
            contact.UserPassword = obj.UserPassword;
            contact.CreatedDate = contact.CreatedDate;
            contact.Modified_Date = DateTime.Now;
            contact.IsActive = contact.IsActive;

            this.contactRepository.UpdateContact(contact); ;
            return Json(obj, new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost]
        public JsonResult Delete(int ID)
        {
            Contact obj = new Contact();
            this.contactRepository.DeleteContact(ID); 
            return Json(obj, new System.Text.Json.JsonSerializerOptions());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Add(contactDto obj)
        {
            var contact = new Contact() ;

            //contact.Id = obj.Id;
            contact.FirstName = obj.FirstName;
            contact.LastName = obj.LastName;
            contact.Gender = obj.Gender;
            contact.Address1 = obj.Address1 == null ? "" : obj.Address1;
            contact.Address2 = obj.Address2 == null ? "" : obj.Address2;
            contact.City = obj.City == null ? "" : obj.City;
            contact.State = obj.State == null ? "" : obj.State;
            contact.PinCode = obj.PinCode == null ? "" : obj.PinCode;
            contact.PhoneNumber = obj.PhoneNumber;
            contact.FaxNumber = obj.FaxNumber == null ? "" : obj.FaxNumber;
            contact.EmailId = obj.EmailId;
            contact.SocialSecurityNumber = obj.SocialSecurityNumber;
            contact.DateOfBirth = obj.DateOfBirth;
            contact.UserName = obj.UserName;
            contact.UserPassword = obj.UserPassword;
            contact.CreatedDate = DateTime.Now;
           // contact.Modified_Date = DateTime.Now;
            contact.IsActive = contact.IsActive;
            this.contactRepository.SaveContact(contact);
            return Json(contact, new System.Text.Json.JsonSerializerOptions());
        }
    }
}
