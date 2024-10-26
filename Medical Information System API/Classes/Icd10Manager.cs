using Medical_Information_System_API.Data;
using Newtonsoft.Json;

namespace Medical_Information_System_API.Classes
{
    public class Icd10Manager
    {
        private readonly string _filePath = "./Data/МКБ-10.json";

        private List<Icd10Record> records = new List<Icd10Record>();

        public List<Icd10Record> GetListIcd10()
        {
            using StreamReader reader = new(_filePath);
            var json = reader.ReadToEnd();

            List<Icd10JsonModel> jsonRecords = JsonConvert.DeserializeObject<List<Icd10JsonModel>>(json);

            return records;
        }

        public List<Icd10JsonModel> Test()
        {
            using StreamReader reader = new(_filePath);
            var json = reader.ReadToEnd();

            List<Icd10JsonModel> jsonRecords = JsonConvert.DeserializeObject<List<Icd10JsonModel>>(json);

            return jsonRecords;
        }
    }
}
