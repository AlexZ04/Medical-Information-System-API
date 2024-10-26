namespace Medical_Information_System_API.Data
{
    public class Icd10JsonModel
    {
        public int Id { get; set; }
        public string Rec_Code { get; set; }
        public string Mkb_Code { get; set; }
        public string Mkb_Name { get; set; }
        public string Id_Parent { get; set; }
        public string Actual { get; set; }
        public string Date { get; set; }
    }
}
