using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Validation
{
    public class HasMainDiagnose : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var diagnoses = value as List<DiagnosisCreateModel>;
            if (diagnoses == null) return false;

            int counter = 0;

            foreach (var diagnose in diagnoses)
            {
                if (diagnose.Type == DiagnosisType.Main)
                {
                    counter++;
                }
            }

            return counter == 1;
        }
    }
}
