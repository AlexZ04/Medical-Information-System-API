using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Newtonsoft.Json;

namespace Medical_Information_System_API.Classes
{
    public class Icd10Manager
    {
        private readonly string _filePath = "./Data/МКБ-10.json";

        private List<Icd10Record> records = new List<Icd10Record>();
        Dictionary <int, Guid> idPairs = new Dictionary<int, Guid>();

        public List<Icd10Record> GetListIcd10()
        {
            using StreamReader reader = new(_filePath);
            var json = reader.ReadToEnd();

            List<Icd10JsonModel> jsonRecords = GetJsonList();
            jsonRecords.Add(new Icd10JsonModel { Id_Parent = null, Mkb_Code = "XXXXX" });

            List<Icd10Record> roots = new List<Icd10Record>();

            string firstCode = "", lastCode = "";
            bool getFirstCode = false;

            foreach (var record in jsonRecords) {
                if (record.Id_Parent == null)
                {
                    if (roots.Count != 0)
                    {
                        lastCode = records[^1].Code.Split(".")[0];
                        roots[^1].Code = firstCode + "-" + lastCode;

                        if (record.Mkb_Code == "XXXXX") break;
                    }

                    roots.Add(new Icd10Record(new Icd10RecordModel(record.Mkb_Code, record.Mkb_Name)));
                    records.Add(roots[^1]);

                    getFirstCode = true;
                }
                else
                {
                    if (getFirstCode)
                    {
                        getFirstCode = false;
                        firstCode = record.Mkb_Code.Split("-")[0];
                    }

                    var parentId = idPairs[Int32.Parse(record.Id_Parent)];

                    records.Add(new Icd10Record(new Icd10RecordModel(record.Mkb_Code, record.Mkb_Name), parentId));
                }

                idPairs.Add(record.Id, records[^1].Id);
                
            }

            //return roots;
            return records;
        }

        public List<Icd10JsonModel> GetJsonList()
        {
            using StreamReader reader = new(_filePath);
            var json = reader.ReadToEnd();

            List<Icd10JsonModel> jsonRecords = JsonConvert.DeserializeObject<List<Icd10JsonModel>>(json).OrderBy(x => x.Rec_Code).ToList();

            return jsonRecords;
        }
    }
}
