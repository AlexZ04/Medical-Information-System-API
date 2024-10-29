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
        public string Anamnesis { get; set; }
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
        public PatientModel Patient { get; set; }
        public DoctorDatabase Doctor { get; set; }
        public List<Diagnose> Diagnoses { get; set; }
        public List<Consultation> Consultations { get; set; }

        public Inspection()
        {
            Diagnoses = new List<Diagnose>();
            Consultations = new List<Consultation>();
        }

        public Inspection(InspectionCreateModel inspection, PatientModel patient,
            DoctorDatabase doctor, List<Diagnose> diagnoses, List<Consultation> consultations, Guid inspectionId)
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

        }
    }
}
