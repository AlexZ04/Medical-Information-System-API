using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Validation
{
    public class MinItems : ValidationAttribute
    {
        int _length;

        public MinItems(int length)
        {
            _length = length;
        }

        public override bool IsValid(object? value)
        {
            var list = value as List<DiagnosisCreateModel>;
            if (list == null || list.Count < _length)
            {
                return false;
            }
            return true;
        }
    }
}
