using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AddressBookModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string? Photo { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
       
        public int JobTitleId { get; set; }
        public int DepartmentId {  get; set; }
        public long UserId {  get; set; }
        public User user { get; set; }
        public JobTitle jobTitle { get; set; }
        public Department department { get; set; }
    }
}
