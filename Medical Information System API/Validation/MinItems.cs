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
            var list = value as Array;
            if (list == null || list.Length < _length)
            {
                return false;
            }
            return true;
        }
    }
}
