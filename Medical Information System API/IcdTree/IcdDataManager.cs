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

            //await ChildParentIcd();
        }

        // мне стыдно за эту функцию
        public async Task ChildParentIcd()
        {
            var data = await _context.Icd10.ToListAsync();

            List<ChildParentIcd> res = new List<ChildParentIcd>();
            foreach (var record in data) {

                var rootId = _context.GetIcdParent(record.Id).Id;
                res.Add(new ChildParentIcd { Id = record.Id, ParentId = rootId });

                record.RootId = rootId;
                await _context.SaveChangesAsync();
            }

            var allData = await _context.ChildParentIcd.ToListAsync();
            _context.ChildParentIcd.RemoveRange(allData);
            await _context.ChildParentIcd.AddRangeAsync(res);

            await _context.SaveChangesAsync();
        }
    }
}
