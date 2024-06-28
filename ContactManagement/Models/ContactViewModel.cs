using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }      
        public string Name { get; set; }     
        public string Gender { get; set; }       
        public string Address { get; set; } = "";    
       
        public string PhoneNumber { get; set; }      
        public string FaxNumber { get; set; } = "";       
        public string EmailId { get; set; }   
        public string SocialSecurityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public string UserName { get; set; }     
        public string UserPassword { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Modified_Date { get; set; }
        public Boolean IsActive { get; set; }
    }

    public class contactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }     
        public string Gender { get; set; }     
        public string Address1 { get; set; } = "";
        public string Address2 { get; set; } = "";    
        public string City { get; set; } = "";     
        public string State { get; set; } = "";
        public string PinCode { get; set; } = "";  
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; } = "";     
        public string EmailId { get; set; }
        public string SocialSecurityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }  
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Modified_Date { get; set; }
        public Boolean IsActive { get; set; } = true;
   
    }




}
