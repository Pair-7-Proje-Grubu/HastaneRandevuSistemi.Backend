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
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {

            Title title = new Title() { Id = 1, TitleName = "Uzman" };
            Block block = new Block() { Id = 1, No = "A" };
            Floor floor = new Floor() { Id = 1, No = "Zemin" };
            Room room = new Room() { Id = 1, No = "15" };
            Room room2 = new Room() { Id = 2, No = "20" };
            OfficeLocation officeLocation = new OfficeLocation() { Id = 1, BlockId = 1, FloorId = 1, RoomId = 1 };
            OfficeLocation officeLocation2 = new OfficeLocation() { Id = 2, BlockId = 1, FloorId = 1, RoomId = 2 };
            Clinic clinic = new Clinic() { Id = 1, Name = "Ortopedi", PhoneNumber = "0500000000" };


            Admin admin = new Admin()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Admin",
                BirthDate = DateTime.Now,
                Gender = 'M',
                Email = "testAdmin@hrs.com",
                Phone = "0500000000",
            };



            modelBuilder.Entity<Title>().HasData(title);
            modelBuilder.Entity<Block>().HasData(block);
            modelBuilder.Entity<Floor>().HasData(floor);
            modelBuilder.Entity<Room>().HasData(room);
            modelBuilder.Entity<Room>().HasData(room2);
            modelBuilder.Entity<OfficeLocation>().HasData(officeLocation);
            modelBuilder.Entity<OfficeLocation>().HasData(officeLocation2);
            modelBuilder.Entity<Clinic>().HasData(clinic);

            modelBuilder.Entity<Admin>().HasData(admin);
        }
    }
}
