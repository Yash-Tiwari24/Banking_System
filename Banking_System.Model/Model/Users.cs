using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.Model
{
    [Table("Users")]
    public class Users : IdentityUser
    {
        
        
        [StringLength(20, MinimumLength = 4)]
        [Required(ErrorMessage = "please enter first name")]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 4)]
        [Required(ErrorMessage = "please enter middle name")]
        public string MiddleName { get; set; }
        [StringLength(20, MinimumLength = 4)]
        [Required(ErrorMessage = "please enter last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "please enter Date Of Birth")]
        public DateTime DOB { get; set; }
        [StringLength(20, MinimumLength = 10)]
        [Required(ErrorMessage = "please enter Email Id")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string EmailId { get; set; }
        
        [Required(ErrorMessage = "please enter status")]
        public string Status { get; set; }


    }
}
