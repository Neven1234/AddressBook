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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasOne(d => d.user)
                .WithMany(u => u.department)
                .HasForeignKey(d => d.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobTitle>()
                .HasOne(j => j.user)
                .WithMany(u => u.jobTitles)
                .HasForeignKey(j => j.userId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<AddressBookModel>()
                .HasOne(a => a.user)
                .WithMany(u => u.addressBook)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
        public DbSet<User> User {  get; set; }
        public DbSet<AddressBookModel> AddressBook {  get; set; }
        public DbSet<JobTitle> jobTitle { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
