using Core.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public DbSet<OfficeLocation> OfficeLocations { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Clinic> Clinics { get; set; }

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



            Title title = new Title();
            title.Id = 1;
            title.TitleName = "Uzman";


            Block block = new Block();
            block.Id = 1;
            block.No = "A";

            Floor floor = new Floor();
            floor.Id = 1;
            floor.No = "Zemin";

            Room room = new Room();
            room.Id = 1;
            room.No = "15";

            Room room2 = new Room();
            room2.Id = 2;
            room2.No = "20";

            OfficeLocation officeLocation = new OfficeLocation();
            officeLocation.Id = 1;
            officeLocation.BlockId = 1;
            officeLocation.FloorId = 1;
            officeLocation.RoomId = 1;


            OfficeLocation officeLocation2 = new OfficeLocation();
            officeLocation2.Id = 2;
            officeLocation2.BlockId = 1;
            officeLocation2.FloorId = 1;
            officeLocation2.RoomId = 2;


            Clinic clinic = new Clinic();
            clinic.Id = 1;
            clinic.Name = "Ortopedi";
            clinic.PhoneNumber = "0500000000";


            Admin admin = new Admin();
            admin.Id = 1;
            admin.FirstName = "test";
            admin.LastName = "Admin";
            admin.BirthDate = DateTime.Now;
            admin.Gender = 'B';
            admin.Email = "testAdmin@hrs.com";
            admin.Phone = "0500000000";



            Doctor doctor = new Doctor();
            doctor.Id = 2;
            doctor.FirstName = "test";
            doctor.LastName = "Doctor";
            doctor.BirthDate = DateTime.Now;
            doctor.Gender = 'B';
            doctor.Email = "testDoctor@hrs.com";
            doctor.Phone = "0500000000";
            doctor.TitleId = 1;
            doctor.OfficeLocationId = 2;
            doctor.ClinicId = 1;


            modelBuilder.Entity<Admin>().HasData(admin);
            modelBuilder.Entity<Title>().HasData(title);
            modelBuilder.Entity<Doctor>().HasData(doctor);
            modelBuilder.Entity<Block>().HasData(block);
            modelBuilder.Entity<Floor>().HasData(floor);
            modelBuilder.Entity<Room>().HasData(room);
            modelBuilder.Entity<Room>().HasData(room2);
            modelBuilder.Entity<OfficeLocation>().HasData(officeLocation);
            modelBuilder.Entity<OfficeLocation>().HasData(officeLocation2);
            modelBuilder.Entity<Clinic>().HasData(clinic);

            base.OnModelCreating(modelBuilder);
        }

    }
}
