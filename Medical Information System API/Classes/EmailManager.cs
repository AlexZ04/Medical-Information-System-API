namespace Medical_Information_System_API.Classes
{
    public class EmailManager
    {
        public static string MakeEmailText(InspiredInspection insp)
        {
            string res = $"Здравствуйте, {insp.Inspection.Doctor.Name}!\n\n" +
                $"Новый пропущенный осмотр!\n" +
                $"Пациент: {insp.Inspection.Patient.Name}";

            if (insp.Inspection.Patient.Birthday != null)
            {
                res += $", дата рождения: {ConvertTime(insp.Inspection.Patient.Birthday ?? DateTime.MinValue)}\n";
            }

            res += $"Время осмотра: {ConvertTime(insp.Inspection.Date)}\n\n" +
                $"С уважением, администрация МЕГА поликлиники";

            return $"Здравствуйте, {insp.Inspection.Doctor.Name}!\n\n" +
                $"Новый пропущенный осмотр!\n" +
                $"Пациент: {insp.Inspection.Patient.Name}, дата рождения: {insp.Inspection.Patient.Birthday}\n" +
                $"Время осмотра: {insp.Inspection.Date}\n\n" +
                $"С уважением, администрация МЕГА поликлиники";
        }

        public static DateTime ConvertTime(DateTime oldTime)
        {
            return TimeZoneInfo.ConvertTime(oldTime, TimeZoneInfo.Local);
        }
    }
}
