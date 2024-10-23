using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class Icd10RecordModel
    {
        [AllowNull]
        public string Code { get; set; }
        [AllowNull]
        public string Name { get; set; }
        public Guid Id { get; set; }
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
    }
}
