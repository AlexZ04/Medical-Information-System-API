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
        public bool IsParent { get; set; }

        public Icd10Record(Icd10RecordModel model, bool isParent)
        {
            Code = model.Code;
            Name = model.Name;
            Id = model.Id;
            CreateTime = model.CreateTime;

            IsParent = isParent;
        }
    }
}
