using ApplicationCore;
using ApplicationCore.Interface;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Tests
{
    public class ContactManagerTest
    {
        [Fact]
        public void Check_Seed_Count()
        {
            var dbOption = new DbContextOptionsBuilder<EFCoreDbContext>()
                .UseSqlServer("server=(localdb)\\MSSqlLocalDb; database=Model; Integrated Security=true; Encrypt=false")
                .Options;

            var context = new EFCoreDbContext(dbOption);


            IContactRepository contactRepository = new ContactRepository(context);


            Assert.NotEmpty(contactRepository.GetAllContacts());
        }
    }
}