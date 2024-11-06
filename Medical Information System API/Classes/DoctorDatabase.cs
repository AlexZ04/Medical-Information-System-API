using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.Web.Helpers;

namespace Medical_Information_System_API.Classes
{
    // сущность, хранящаяся в базе данных
    public class DoctorDatabase
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid Speciality { get; set; }

        public DoctorDatabase()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
        }

        public DoctorDatabase(DoctorRegisterModel registerModel)
        {
            Password = Crypto.HashPassword(registerModel.Password);
            Name = registerModel.Name;
            Birthday = registerModel.Birthday;
            Gender = registerModel.Gender;
            Email = registerModel.Email;
            Phone = registerModel.Phone;
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
            Speciality = registerModel.Speciality;
        }
    }
}
