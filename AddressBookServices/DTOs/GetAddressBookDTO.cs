using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookServices.DTOs
{
    public class GetAddressBookDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Passwrod { get; set; }
        public int JobTitleId { get; set; }
        public int DepartmentId { get; set; }
        public int Age { get; set; }

        
    }
}
