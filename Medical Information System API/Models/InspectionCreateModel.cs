﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class InspectionCreateModel
    {
        [Required]
        public DateTime Date {  get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "Invalid anamnesis field length.")]
        public string Anamnesis { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "Invalid complaints field length.")]
        public string Complaints { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "Invalid treatment field length.")]
        public string Treatment { get; set; }
        [Required]
        public Conclusion Conclusion { get; set; }
        [AllowNull]
        public DateTime NextVisitDate { get; set; }
        [AllowNull]
        public DateTime DeathDate { get; set; }
        [AllowNull]
        public Guid PreviousInspectionId {  get; set; }
        [Required]
        public List<DiagnosisCreateModel> Diagnoses { get; set; }
        [AllowNull]
        public List<ConsultationCreateModel> Consultations { get; set; }
    }
}
