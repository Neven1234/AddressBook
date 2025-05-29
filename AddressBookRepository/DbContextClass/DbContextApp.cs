using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookRepository.DbContextClass
{
    public class DbContextApp:DbContext
    {
        public DbContextApp(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<User> User {  get; set; }
        public DbSet<AddressBookModel> AddressBook {  get; set; }
        public DbSet<JobTitle> jobTitle { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
