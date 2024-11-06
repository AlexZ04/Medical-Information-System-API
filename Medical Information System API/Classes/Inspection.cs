using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Classes
{
    public class Inspection
    {   
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime Date { get; set; }
        public string? Anamnesis { get; set; }
        public string Complaints { get; set; }
        public string Treatment { get; set; }
        public Conclusion Conclusion { get; set; }
        [AllowNull]
        public DateTime? NextVisitDate { get; set; }
        [AllowNull]
        public DateTime? DeathDate { get; set; }
        [AllowNull]
        public Guid? BaseInspectionId { get; set; }
        [AllowNull]
        public Guid? PreviousInspectionId { get; set; }
        public Patient Patient { get; set; }
        public DoctorDatabase Doctor { get; set; }
        public List<Diagnose> Diagnoses { get; set; }
        public List<Consultation> Consultations { get; set; }
        public int Group { get; set; }

        public Inspection()
        {
            Diagnoses = new List<Diagnose>();
            Consultations = new List<Consultation>();
            Group = 0;
        }

        public Inspection(InspectionCreateModel inspection, Patient patient,
            DoctorDatabase doctor, List<Diagnose> diagnoses, List<Consultation> consultations, Guid inspectionId, int groupNumber)
        {
            Id = inspectionId;
            CreateTime = DateTime.Now.ToUniversalTime();

            Patient = patient;
            Doctor = doctor;
            Diagnoses = diagnoses;
            Consultations = consultations;

            Date = inspection.Date;
            Anamnesis = inspection.Anamnesis;
            Complaints = inspection.Complaints;
            Treatment = inspection.Treatment;
            Conclusion = inspection.Conclusion;
            NextVisitDate = inspection.NextVisitDate;
            DeathDate = inspection.DeathDate;
            BaseInspectionId = inspection.PreviousInspectionId;
            PreviousInspectionId = inspection.PreviousInspectionId;

            Group = groupNumber;
        }
    }
}
