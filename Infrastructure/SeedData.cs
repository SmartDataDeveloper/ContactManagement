using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domains.Entity;
using System.Reflection;

namespace Infrastructure
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EFCoreDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EFCoreDbContext>>()))
            {
                // Look for any Contacts.
                if (context.Contacts.Any())
                {
                    return;   // DB has been seeded
                }
                context.Contacts.AddRange(
                    new Contact
                    {
                        FirstName="TestFname",
                        LastName = "TestLname",
                        Gender="Male",
                        Address1 ="New Gandhi Square",
                        City="Nagpur",
                        State="Maharashtra",
                        PinCode = "440034",
                        PhoneNumber="(0712)2222222",
                        EmailId="girish@smartdatainc.net",
                        SocialSecurityNumber="7777777",
                        DateOfBirth = DateTime.Parse("04/11/1990"),
                        UserName="girish",
                        UserPassword = "girish",
                        CreatedDate=DateTime.Now,
                        IsActive=true

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
