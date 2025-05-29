using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookServices.DTOs
{
    public class AddOrEditAddreassBookDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public IFormFile PhotoFile { get; set; }
        public string Photo { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }
        public string Passwrod { get; set; }
        public int JobTitleId { get; set; }
        public int DepartmentId { get; set; }
        public long userId {  get; set; }

    }
}
