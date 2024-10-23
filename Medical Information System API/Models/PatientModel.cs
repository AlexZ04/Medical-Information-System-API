﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class PatientModel
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        [MinLength(1, ErrorMessage = "Name field must contain at least one character.")]
        public string Name { get; set; }
        [AllowNull]
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }

        public PatientModel()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
        }
        public PatientModel(PatientCreateModel model)
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
            Name = model.Name;
            Birthday = model.Birthday;
            Gender = model.Gender;
        }
    }
}
