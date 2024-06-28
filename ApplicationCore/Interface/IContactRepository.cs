using Domains.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interface
{
    public interface IContactRepository
    {
        void SaveContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContact(long id);
        void DeleteContact(long id);
        void UpdateContact(Contact contact);
    }
}
