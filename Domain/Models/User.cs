﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<AddressBookModel>addressBook {  get; set; }
        public ICollection<JobTitle> jobTitles { get; set; }
        public ICollection<Department> department { get; set; }

    }
}
