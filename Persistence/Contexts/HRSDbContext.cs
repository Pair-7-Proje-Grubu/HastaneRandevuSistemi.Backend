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
        public DbSet<BaseUser> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3CUTFEI; Database=HastaneRandevuSistemi; Trusted_Connection=True; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BaseUser>().ToTable("Users");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Admin>().ToTable("Admins");


            Admin admin = new Admin();
            admin.Id = 1;
            admin.FirstName = "test";
            admin.LastName = "Admin";
            admin.BirthDate = DateTime.Now;
            admin.Gender = 'B';
            admin.Email = "testAdmin@hrs.com";
            admin.Phone = "0500000000";


            Title title = new Title();
            title.Id = 1;
            title.TitleName = "Uzman";

            Doctor doctor = new Doctor();
            doctor.Id = 2;
            doctor.FirstName = "test";
            doctor.LastName = "Doctor";
            doctor.BirthDate = DateTime.Now;
            doctor.Gender = 'B';
            doctor.Email = "testDoctor@hrs.com";
            doctor.Phone = "0500000000";
            doctor.TitleId = 1;
            doctor.OfficeId = 2;
            doctor.ClinicId = 3;


            modelBuilder.Entity<Admin>().HasData(admin);
            modelBuilder.Entity<Title>().HasData(title);
            modelBuilder.Entity<Doctor>().HasData(doctor);

            base.OnModelCreating(modelBuilder);
        }

    }
}
