using Core.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class HRSDbContext : DbContext
    {
        public DbSet<BaseUser> BaseUsers { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3CUTFEI; Database=HastaneRandevuSistemi; Trusted_Connection=True; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseUser>().ToTable("BaseUsers");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Admin>().ToTable("Admins");

            modelBuilder.Entity<Admin>().UseTphMappingStrategy();
            modelBuilder.Entity<Doctor>().UseTpcMappingStrategy();


            Admin admin = new Admin();
            admin.Id = 1;
            admin.FirstName = "test";
            admin.LastName = "Admin";
            admin.BirthDate = DateTime.Now;
            admin.Gender = 'B';
            admin.Email = "test@hrs.com";
            admin.Phone = "0500000000";

            modelBuilder.Entity<Admin>().HasData(admin);

            base.OnModelCreating(modelBuilder);
        }

    }
}
