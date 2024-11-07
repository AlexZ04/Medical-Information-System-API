namespace Medical_Information_System_API.Classes
{
    public class EmailManager
    {
        public static string MakeEmailText(InspiredInspection insp)
        {
            return $"Здравствуйте, {insp.Inspection.Doctor.Name}!\n\n" +
                $"Новый пропущенный осмотр!\n" +
                $"Пациент: {insp.Inspection.Patient.Name}, дата рождения: {insp.Inspection.Patient.Birthday}\n" +
                $"Время осмотра: {insp.Inspection.Date}\n\n" +
                $"С уважением, администрация МЕГА поликлиники";
        }
    }
}
