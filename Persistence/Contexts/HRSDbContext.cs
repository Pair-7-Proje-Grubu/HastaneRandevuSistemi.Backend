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
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<OfficeLocation> OfficeLocations { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<OldAppointmentDuration> AppointmentDurationHistory { get; set; }
        public DbSet<NoWorkHour> NoWorkHours { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<FAQ> FAQs { get; set; }


        public HRSDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            

            modelBuilder.Entity<Appointment>()
                .HasOne(x => x.Patient)
                .WithMany(x=>x.Appointments)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(x => x.Doctor)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedData.Initialize(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is BaseEntity);

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            {
                                // UpdatedDate'i güncelle
                                entityReference.UpdatedDate = DateTime.Now;
                                // CreatedDate'in güncellenmesini engelle
                                item.Property(nameof(BaseEntity.CreatedDate)).IsModified = false;
                                break;
                            }
                        case EntityState.Added:
                            {
                                // CreatedDate ve UpdatedDate'i ayarla
                                entityReference.CreatedDate = DateTime.Now;
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
