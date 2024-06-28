using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entity
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }    
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        [MaxLength(100)]
        public string Address1 { get; set; } = "";
        [MaxLength(100)]
        public string Address2 { get; set; } = "";
        [MaxLength(100)]
        public string City { get; set; } = "";
        [MaxLength(100)]
        public string State { get; set; } = "";
        [MaxLength(30)]
        public string PinCode { get; set; } = "";
        [MaxLength(50)]
        public string PhoneNumber { get; set; } 
        [MaxLength(50)]
        public string FaxNumber { get; set; } = "";

        [MaxLength(100)]
        public string EmailId { get; set; }

        [MaxLength(50)]
        public string SocialSecurityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string UserPassword { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Modified_Date { get; set; }
        public Boolean IsActive { get; set; } = true;
    }
}
