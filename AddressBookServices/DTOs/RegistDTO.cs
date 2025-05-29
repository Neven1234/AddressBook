using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookServices.DTOs
{
    public class RegistDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
