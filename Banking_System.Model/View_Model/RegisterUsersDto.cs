using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Model.View_Model
{
   public class RegisterUsersDto
    {
        
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 4)]
        [Required(ErrorMessage = "please enter middle name")]
        public string MiddleName { get; set; }
        [StringLength(20, MinimumLength = 4)]
        [Required(ErrorMessage = "please enter last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "please enter Date Of Birth")]
        public DateTime DOB { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


    }
}
