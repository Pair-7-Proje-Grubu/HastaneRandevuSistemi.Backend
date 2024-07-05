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

            ///

            Patient doctorPatient1 = new Patient()
            {
                Id = 4,
                FirstName = "Ahmet",
                LastName = "Yıldız",
                Email = "ahmet.yildiz@hrs.com",
                Phone = "+905301234567",
                BirthDate = new DateTime(1975, 9, 20),
                Gender = 'M',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient doctorPatient2 = new Patient()
            {
                Id = 5,
                FirstName = "Emine",
                LastName = "Şahin",
                Email = "emine.sahin@hrs.com",
                Phone = "+905412345678",
                BirthDate = new DateTime(1980, 12, 15),
                Gender = 'F',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient doctorPatient3 = new Patient()
            {
                Id = 6,
                FirstName = "Mustafa",
                LastName = "Aydın",
                Email = "mustafa.aydin@hrs.com",
                Phone = "+905523456789",
                BirthDate = new DateTime(1972, 6, 8),
                Gender = 'M',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient doctorPatient4 = new Patient()
            {
                Id = 7,
                FirstName = "Hacer",
                LastName = "Korkmaz",
                Email = "hacer.korkmaz@hrs.com",
                Phone = "+905634567890",
                BirthDate = new DateTime(1983, 2, 28),
                Gender = 'F',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient doctorPatient5 = new Patient()
            {
                Id = 8,
                FirstName = "İbrahim",
                LastName = "Arslan",
                Email = "ibrahim.arslan@hrs.com",
                Phone = "+905745678901",
                BirthDate = new DateTime(1978, 4, 17),
                Gender = 'M',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient doctorPatient6 = new Patient()
            {
                Id = 14,
                FirstName = "Seda",
                LastName = "Kara",
                Email = "seda.kara@hrs.com",
                Phone = "+905356789012",
                BirthDate = new DateTime(1982, 3, 15),
                Gender = 'F',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient doctorPatient7 = new Patient()
            {
                Id = 15,
                FirstName = "Okan",
                LastName = "Yılmaz",
                Email = "okan.yilmaz@hrs.com",
                Phone = "+905467890123",
                BirthDate = new DateTime(1979, 7, 22),
                Gender = 'M',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient doctorPatient8 = new Patient()
            {
                Id = 16,
                FirstName = "Sevgi",
                LastName = "Öztürk",
                Email = "sevgi.ozturk@hrs.com",
                Phone = "+905578901234",
                BirthDate = new DateTime(1985, 11, 8),
                Gender = 'F',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };


            // 
            Doctor doctor1 = new Doctor()
            {
                Id = 4,
                ClinicId = 1,
                TitleId = 2,
                OfficeLocationId = 2,
                CreatedDate = DateTime.Now,
            };

            Doctor doctor2 = new Doctor()
            {
                Id = 5,
                ClinicId = 3,
                TitleId = 3,
                OfficeLocationId = 3,
                CreatedDate = DateTime.Now,
            };

            Doctor doctor3 = new Doctor()
            {
                Id = 6,
                ClinicId = 5,
                TitleId = 4,
                OfficeLocationId = 4,
                CreatedDate = DateTime.Now,
            };

            Doctor doctor4 = new Doctor()
            {
                Id = 7,
                ClinicId = 7,
                TitleId = 5,
                OfficeLocationId = 5,
                CreatedDate = DateTime.Now,
            };

            Doctor doctor5 = new Doctor()
            {
                Id = 8,
                ClinicId = 9,
                TitleId = 6,
                OfficeLocationId = 6,
                CreatedDate = DateTime.Now,
            };

            Doctor doctor6 = new Doctor()
            {
                Id = 14,
                ClinicId = 3, 
                TitleId = 2,  
                OfficeLocationId = 7,
                CreatedDate = DateTime.Now,
            };

            Doctor doctor7 = new Doctor()
            {
                Id = 15,
                ClinicId = 3, 
                TitleId = 3,  
                OfficeLocationId = 8,
                CreatedDate = DateTime.Now,
            };

            Doctor doctor8 = new Doctor()
            {
                Id = 16,
                ClinicId = 3, 
                TitleId = 4,  
                OfficeLocationId = 9,
                CreatedDate = DateTime.Now,
            };

            // 
            Patient patient4 = new Patient()
            {
                Id = 9,
                FirstName = "Ayşe",
                LastName = "Yılmaz",
                Email = "ayse.yilmaz@email.com",
                Phone = "+905856789012",
                BirthDate = new DateTime(1985, 5, 15),
                Gender = 'F',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient patient5 = new Patient()
            {
                Id = 10,
                FirstName = "Mehmet",
                LastName = "Kaya",
                Email = "mehmet.kaya@email.com",
                Phone = "+905967890123",
                BirthDate = new DateTime(1990, 8, 22),
                Gender = 'M',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient patient6 = new Patient()
            {
                Id = 11,
                FirstName = "Fatma",
                LastName = "Demir",
                Email = "fatma.demir@email.com",
                Phone = "+905078901234",
                BirthDate = new DateTime(1978, 11, 30),
                Gender = 'F',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient patient7 = new Patient()
            {
                Id = 12,
                FirstName = "Ali",
                LastName = "Öztürk",
                Email = "ali.ozturk@email.com",
                Phone = "+905189012345",
                BirthDate = new DateTime(1995, 3, 10),
                Gender = 'M',
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedDate = DateTime.Now,
            };

            Patient patient8 = new Patient()
            {
                Id = 13,
                FirstName = "Zeynep",
                LastName = "Çelik",
                Email = "zeynep.celik@email.com",
                Phone = "+905290123456",
                BirthDate = new DateTime(1988, 7, 5),
                Gender = 'F',
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
               ///
               new UserOperationClaim(){Id=6, UserId = 4, OperationClaimId = 1},
               new UserOperationClaim(){Id=7, UserId = 4, OperationClaimId = 2},
               new UserOperationClaim(){Id=8, UserId = 5, OperationClaimId = 1},
               new UserOperationClaim(){Id=9, UserId = 5, OperationClaimId = 2},
               new UserOperationClaim(){Id=10, UserId = 6, OperationClaimId = 1},
               new UserOperationClaim(){Id=11, UserId = 6, OperationClaimId = 2},
               new UserOperationClaim(){Id=12, UserId = 7, OperationClaimId = 1},
               new UserOperationClaim(){Id=13, UserId = 7, OperationClaimId = 2},
               new UserOperationClaim(){Id=14, UserId = 8, OperationClaimId = 1},
               new UserOperationClaim(){Id=15, UserId = 8, OperationClaimId = 2},
               //
               new UserOperationClaim(){Id=16, UserId = 9, OperationClaimId = 1},
               new UserOperationClaim(){Id=17, UserId = 10, OperationClaimId = 1},
               new UserOperationClaim(){Id=18, UserId = 11, OperationClaimId = 1},
               new UserOperationClaim(){Id=19, UserId = 12, OperationClaimId = 1},
               new UserOperationClaim(){Id=20, UserId = 13, OperationClaimId = 1},
               new UserOperationClaim(){Id=21, UserId = 14, OperationClaimId = 1}, 
               new UserOperationClaim(){Id=22, UserId = 14, OperationClaimId = 2}, 
               new UserOperationClaim(){Id=23, UserId = 15, OperationClaimId = 1}, 
               new UserOperationClaim(){Id=24, UserId = 15, OperationClaimId = 2},
               new UserOperationClaim(){Id=25, UserId = 16, OperationClaimId = 1}, 
               new UserOperationClaim(){Id=26, UserId = 16, OperationClaimId = 2} 


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
            modelBuilder.Entity<Patient>().HasData(doctorPatient1, doctorPatient2, doctorPatient3, doctorPatient4, doctorPatient5, doctorPatient6, doctorPatient7, doctorPatient8);
            modelBuilder.Entity<Doctor>().HasData(doctor1, doctor2, doctor3, doctor4, doctor5, doctor6, doctor7, doctor8);
            modelBuilder.Entity<Patient>().HasData(patient4, patient5, patient6, patient7, patient8);
            modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaims);


        }
    }
}
