using Medical_Information_System_API.Models;

namespace Medical_Information_System_API.Classes
{
    public class EmailManager
    {
        public static string MakeEmailText(InspiredInspection insp)
        {
            return $"Здравствуйте, {insp.Inspection.Doctor.Name}!\n\n" +
                $"Новый пропущенный осмотр!\n" +
                $"Пациент: {insp.Inspection.Patient.Name}, дата рождения: {ConvertTime(insp.Inspection.Patient.Birthday ?? DateTime.MinValue)}\n" +
                $"Время осмотра: {ConvertTime(insp.Inspection.NextVisitDate ?? DateTime.MinValue)}\n\n" +
                $"С уважением, администрация МЕГА поликлиники";
        }

        public static DateTime ConvertTime(DateTime oldTime)
        {
            return TimeZoneInfo.ConvertTime(oldTime, TimeZoneInfo.Local);
        }
    }
}
