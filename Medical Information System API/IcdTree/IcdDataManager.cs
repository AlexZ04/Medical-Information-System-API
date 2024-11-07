using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Medical_Information_System_API.IcdTree
{
    public class IcdDataManager
    {
        public static List<Icd10Record> Roots = new List<Icd10Record>();
        public static Tree CodeTree = new Tree();
        public static Tree NameTree = new Tree();
        private readonly DataContext _context;

        public IcdDataManager(DataContext context)
        {
            _context = context;
        }

        public async Task Init()
        {
            Roots = await _context.Icd10
                .Where(r => r.ParentId == null)
                .ToListAsync();

            var icdData = await _context.Icd10.ToListAsync();

            CodeTree.Build(icdData, true);
            NameTree.Build(icdData);       
        }
    }
}
