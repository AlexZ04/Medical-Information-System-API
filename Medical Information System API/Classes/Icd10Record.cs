using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Classes
{
    public class Icd10Record
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        [AllowNull]
        public Guid? ParentId { get; set; }

        public Icd10Record(Icd10RecordModel model, Guid parentId)
        {
            Code = model.Code;
            Name = model.Name;
            Id = model.Id;
            CreateTime = model.CreateTime;

            ParentId = parentId;
        }

        public Icd10Record(Icd10RecordModel model)
        {
            Code = model.Code;
            Name = model.Name;
            Id = model.Id;
            CreateTime = model.CreateTime;
        }

        public Icd10Record()
        {
            CreateTime = DateTime.Now.ToUniversalTime();
            Id = Guid.NewGuid();
        }
    }
}
