using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medical_Information_System_API.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }

        public DbSet<BlacklistToken> BlacklistTokens { get; set; }

        public DbSet<DoctorDatabase> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<SpecialityModel> SpecialitiesList { get; set; }
        public DbSet<Icd10Record> Icd10 { get; set; }

        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<InspiredInspection> InspiredInspections { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DoctorDatabase>().HasKey(x => x.Id);
            builder.Entity<DoctorDatabase>().ToTable("doctor");

            builder.Entity<SpecialityModel>().HasKey(x => x.Id);
            builder.Entity<SpecialityModel>().ToTable("speciality");

            builder.Entity<Patient>().HasKey(x => x.Id);
            builder.Entity<Patient>().ToTable("patient");

            builder.Entity<BlacklistToken>().HasKey(x => x.Token);
            builder.Entity<BlacklistToken>().ToTable("tokenBlacklist");

            builder.Entity<Icd10Record>().HasKey(x => x.Id);
            builder.Entity<Icd10Record>().ToTable("icd10");

            builder.Entity<Inspection>().HasKey(x => x.Id);
            builder.Entity<Diagnose>().HasKey(x => x.Id);
            builder.Entity<Consultation>().HasKey(x => x.Id);
            builder.Entity<Comment>().HasKey(x => x.Id);

            builder.Entity<Inspection>().ToTable("inspection");
            builder.Entity<Diagnose>().ToTable("diagnose");
            builder.Entity<Consultation>().ToTable("consultation");
            builder.Entity<Comment>().ToTable("comment");

            builder.Entity<InspiredInspection>().HasKey(x => x.Id);
            builder.Entity<InspiredInspection>().ToTable("inspiredInspection");

            base.OnModelCreating(builder);
        }

        public bool CheckToken(string token)
        {

            return BlacklistTokens.Find(token) == null ? true : false;
        }

        public Icd10Record GetIcdParent(Guid id)
        {
            var record = Icd10.Find(id);
            
            if (record == null) throw new ObjectDisposedException("Record with this ID is not in the base...");

            while (record?.ParentId != null)
            {
                record = Icd10.Find(record.ParentId);
            }

            if (record == null) throw new ObjectDisposedException("Error with founding parent ID...");

            return record;
        }

    }
}
