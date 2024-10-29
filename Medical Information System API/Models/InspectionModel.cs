using Medical_Information_System_API.Classes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class InspectionModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        public DateTime Date { get; set; }
        [AllowNull]
        public string Anamnesis { get; set; }
        [AllowNull]
        public string Complaints { get; set; }
        [AllowNull]
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
        public DoctorModel Doctor { get; set; }
        [AllowNull]
        public List<DiagnosisModel> Diagnoses { get; set; }
        [AllowNull]
        public List<InspectionConsultationModel> Consultations { get; set; }

        public InspectionModel(Inspection insp)
        {
            Id = insp.Id;
            CreateTime = insp.CreateTime;
            Date = insp.Date;
            Anamnesis = insp.Anamnesis;
            Complaints = insp.Complaints;
            Treatment = insp.Treatment;
            Conclusion = insp.Conclusion;
            NextVisitDate = insp.NextVisitDate;
            DeathDate = insp.DeathDate;
            BaseInspectionId = insp.BaseInspectionId;
            PreviousInspectionId = insp.PreviousInspectionId;
            Patient = insp.Patient;

            Doctor = new DoctorModel(insp.Doctor);

            Diagnoses = new List<DiagnosisModel>();
            foreach (var diagnose in insp.Diagnoses)
            {
                Diagnoses.Add(new DiagnosisModel(diagnose));
            }

            Consultations = new List<InspectionConsultationModel>();
            foreach (var consultation in insp.Consultations)
            {
                Consultations.Add(new InspectionConsultationModel(consultation));
            }
        }
    }
}
