using Azure.Core;
using Core.Entities;
using Core.Utilities;
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

            Title[] titles = [ new(){ Id = 1, TitleName = "Pratisyen Doktor" },
                                new() { Id = 2, TitleName = "Uzman Doktor" },
                                new() { Id = 3, TitleName = "Operatör Doktor" },
                                new() { Id = 4, TitleName = "Yardımcı Doçent" },
                                new() { Id = 5, TitleName = "Doçent" },
                                new() { Id = 6, TitleName = "Profesör" },
                                new() { Id = 7, TitleName = "Ordinaryüs " },
                                ];

            Block[] blocks = [new(){ Id = 1, No = "A" },
                                new() { Id = 2, No = "B" },
                                new() { Id = 3, No = "C" }];

            Floor[] floors = [new(){ Id = 1, No = "Zemin" },
                                new(){ Id = 2, No = "1.Kat" },
                                new(){ Id = 3, No = "2.Kat" },
                                new(){ Id = 4, No = "3.Kat" },
                                new(){ Id = 5, No = "4.Kat" },
                                new(){ Id = 6, No = "-1.Kat" },
            ];

            Room[] rooms = [new(){ Id = 1, No = "O-1" },
                                new(){ Id = 2, No = "O-2" },
                                new(){ Id = 3, No = "K-1" },
                                new(){ Id = 4, No = "K-2" },
                                new(){ Id = 5, No = "K-3" },
                                new(){ Id = 6, No = "D-1" },
                                new(){ Id = 7, No = "D-2" },
                                new(){ Id = 8, No = "N-1" },
                                new(){ Id = 9, No = "N-2" },
                                new(){ Id = 10, No = "U-1" },
                                new(){ Id = 11, No = "U-2" },
            ];


            OfficeLocation[] officeLocations = [
                new(){ Id = 1, BlockId = 1, FloorId = 1, RoomId = 1 },
                new(){ Id = 2, BlockId = 1, FloorId = 1, RoomId = 2 },
                new(){ Id = 3, BlockId = 1, FloorId = 2, RoomId = 3 },
                new(){ Id = 4, BlockId = 1, FloorId = 2, RoomId = 4 },
                new(){ Id = 5, BlockId = 1, FloorId = 2, RoomId = 5 },
                new(){ Id = 6, BlockId = 2, FloorId = 1, RoomId = 6 },
                new(){ Id = 7, BlockId = 2, FloorId = 1, RoomId = 7 },
                new(){ Id = 8, BlockId = 3, FloorId = 1, RoomId = 10},
                new(){ Id = 9, BlockId = 3, FloorId = 1, RoomId = 11 },
            ];

            Clinic[] clinics =
            [
                new Clinic() { Id = 1, Name = "Yoğun Bakım", AppointmentDuration = 30 },
                new Clinic() { Id = 2, Name = "Palyatif Bakım", AppointmentDuration = 20 },
                new Clinic() { Id = 3, Name = "Beyin ve Sinir Cerrahisi", AppointmentDuration = 20 },
                new Clinic() { Id = 4, Name = "Çocuk Sağlığı ve Hastalıkları", AppointmentDuration = 15 },
                new Clinic() { Id = 5, Name = "Enfeksiyon Hastalıkları", AppointmentDuration = 15 },
                new Clinic() { Id = 6, Name = "Fiziksel Tıp ve Rehabilitasyon" , AppointmentDuration = 15},
                new Clinic() { Id = 7, Name = "Genel Cerrahi" , AppointmentDuration = 30},
                new Clinic() { Id = 8, Name = "Genel Dahiliye" , AppointmentDuration = 20},
                new Clinic() { Id = 9, Name = "Göğüs Cerrahi" , AppointmentDuration = 30},
                new Clinic() { Id = 10, Name = "Göğüs Hastalıkları" , AppointmentDuration = 30},
                new Clinic() { Id = 11, Name = "Göz Hastalıkları", AppointmentDuration = 20 },
                new Clinic() { Id = 12, Name = "Kadın Hastalıkları ve Doğum", AppointmentDuration = 30 },
                new Clinic() { Id = 13, Name = "Kalp Damar Cerrahisi" , AppointmentDuration = 20},
                new Clinic() { Id = 14, Name = "Kardiyoloji" , AppointmentDuration = 20},
                new Clinic() { Id = 15, Name = "Kulak Burun Boğaz", AppointmentDuration = 15 },
                new Clinic() { Id = 16, Name = "Nöroloji" , AppointmentDuration = 20},
                new Clinic() { Id = 17, Name = "Ortopedi ve Travmatoloji" , AppointmentDuration = 15},
                new Clinic() { Id = 18, Name = "Üroloji", AppointmentDuration = 15 }
            ];


            WorkingTime workingTime = new WorkingTime()
            {
                Id = 1, 
                StartTime= new TimeSpan(08,30,0), EndTime= new TimeSpan(17,0,0),
                StartBreakTime= new TimeSpan(12,0,0), EndBreakTime= new TimeSpan(13,0,0)
            };


            byte[] passwordSalt, passwordHash;

            HashingHelper.CreatePasswordHash("123456", out passwordSalt, out passwordHash);

            Patient admin = new Patient() { 
                Id = 1,
                FirstName = "Test",
                LastName = "Admin",
                Email = "admin@hrs.com",
                Phone = "+905000000000",
                BirthDate = DateTime.Now,
                Gender = 'U',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,

                
            };
            Admin AdminData = new Admin()
            {
                CreatedDate = DateTime.Now,
                Id = 1,
            };


            Patient doctor = new Patient()
            {
                Id = 2,
                FirstName = "Test",
                LastName = "Doctor",
                Email = "doctor@hrs.com",
                Phone = "+905000000001",
                BirthDate = DateTime.Now,
                Gender = 'U',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
                

            };
          
            Doctor doctorData = new Doctor()
            {
                Id = 2,
                ClinicId = 17,   
                TitleId = 1,
                OfficeLocationId = 1,
                CreatedDate = DateTime.Now,
            };

            Patient patient = new Patient()
            {
                Id = 3,
                FirstName = "Test",
                LastName = "Patient",
                Email = "patient@hrs.com",
                Phone = "+905000000002",
                BirthDate = DateTime.Now,
                Gender = 'U',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,


            };

            OperationClaim[] operationClaims = [new(){ Id = 1, Name = "Patient" },
                                                new(){ Id = 2, Name = "Doctor" },
                                                new(){ Id = 3, Name = "Support" },
                                                new(){ Id = 4, Name = "Admin" }];


            UserOperationClaim[] userOperationClaims = [
               new UserOperationClaim(){Id=1, UserId = 1, OperationClaimId = 1},
               new UserOperationClaim(){Id=2, UserId = 1, OperationClaimId = 4},
               new UserOperationClaim(){Id=3, UserId = 2, OperationClaimId = 1},
               new UserOperationClaim(){Id=4, UserId = 2, OperationClaimId = 2},
               new UserOperationClaim(){Id=5, UserId = 3, OperationClaimId = 1},
            ];


            modelBuilder.Entity<WorkingTime>().HasData(workingTime);
            modelBuilder.Entity<Title>().HasData(titles);
            modelBuilder.Entity<Block>().HasData(blocks);
            modelBuilder.Entity<Floor>().HasData(floors);
            modelBuilder.Entity<Room>().HasData(rooms);
            modelBuilder.Entity<OfficeLocation>().HasData(officeLocations);
            modelBuilder.Entity<Clinic>().HasData(clinics);
            modelBuilder.Entity<OperationClaim>().HasData(operationClaims);
            modelBuilder.Entity<Patient>().HasData(admin);
            modelBuilder.Entity<Admin>().HasData(AdminData);
            modelBuilder.Entity<Patient>().HasData(doctor);
            modelBuilder.Entity<Doctor>().HasData(doctorData);
            modelBuilder.Entity<Patient>().HasData(patient);
            modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaims);

        }
    }
}
