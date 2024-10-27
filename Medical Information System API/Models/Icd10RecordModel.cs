using Medical_Information_System_API.Classes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class Icd10RecordModel
    {
        [AllowNull]
        public string Code { get; set; }
        [AllowNull]
        public string Name { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }

        public Icd10RecordModel()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
        }

        public Icd10RecordModel(string code, string name)
        {
            Code = code;
            Name = name;
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
        }

        public Icd10RecordModel(Icd10Record recordFromData)
        {
            Code = recordFromData.Code;
            Name = recordFromData.Name;
            Id = recordFromData.Id;
            CreateTime = recordFromData.CreateTime;
        }
    }
}
