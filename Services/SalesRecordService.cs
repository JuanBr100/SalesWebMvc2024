using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context; 
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? start, DateTime? final)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (start.HasValue)
            {
                result = result.Where(x => x.Date >= start.Value);
            }
            if (final.HasValue)
            {
                result = result.Where(x => x.Date <= final.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public DateTime GetMinDate()
        {
            var result = from obj in _context.SalesRecords select obj;
            return result.Min(x => x.Date);
        }
    }
}
