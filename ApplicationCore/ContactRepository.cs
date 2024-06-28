using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interface;
using Domains.Entity;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore
{
    public class ContactRepository : IContactRepository
    {
        private EFCoreDbContext context;
        private DbSet<Contact> contactEntity;
        public ContactRepository(EFCoreDbContext context)
        {
            this.context = context;
            contactEntity = context.Set<Contact>();
        }
        public void DeleteContact(long id)
        {

            Contact contact = GetContact(id);
            contact.IsActive = false;
            context.SaveChanges();
        }

        public List<Contact> GetAllContacts()
        {
            return contactEntity.Where (x=>x.IsActive==true).ToList();
        }

        public Contact GetContact(long id)
        {
            return contactEntity.FirstOrDefault<Contact>(s => s.Id == id);
        }

        public void SaveContact(Contact contact)
        {
            context.Entry(contact).State = EntityState.Added;
            context.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            //context.Entry(contact).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
