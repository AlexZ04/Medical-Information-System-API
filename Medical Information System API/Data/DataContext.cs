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

        public DbSet<DoctorDatabase> Doctors { get; set; }
        public DbSet<SpecialityModel> SpecialitiesList { get; set; }
        public DbSet<PatientModel> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DoctorDatabase>().HasKey(x => x.Id);
            builder.Entity<DoctorDatabase>().ToTable("doctor");

            builder.Entity<SpecialityModel>().HasKey(x => x.Id);
            builder.Entity<SpecialityModel>().HasData(
                CreateSpecialitiesList()
            );
            builder.Entity<SpecialityModel>().ToTable("speciality");

            builder.Entity<PatientModel>().HasKey(x => x.Id);
            builder.Entity<PatientModel>().ToTable("patient");

            base.OnModelCreating(builder);
        }

        private List<SpecialityModel> CreateSpecialitiesList()
        {
            List<SpecialityModel> list = new List<SpecialityModel>() {
                new SpecialityModel("Акушер-гинеколог"),
                new SpecialityModel("Анестезиолог-реаниматолог"),
                new SpecialityModel("Дерматовенеролог"),
                new SpecialityModel("Инфекционист"),
                new SpecialityModel("Кардиолог"),
                new SpecialityModel("Невролог"),
                new SpecialityModel("Онколог"),
                new SpecialityModel("Отоларинголог"),
                new SpecialityModel("Офтальмолог"),
                new SpecialityModel("Психиатр"),
                new SpecialityModel("Психолог"),
                new SpecialityModel("Рентгенолог"),
                new SpecialityModel("Стоматолог"),
                new SpecialityModel("Терапевт"),
                new SpecialityModel("УЗИ-специалист"),
                new SpecialityModel("Уролог"),
                new SpecialityModel("Хирург"),
                new SpecialityModel("Эндокринолог"),
            };

            return list;
        }

    }
}
