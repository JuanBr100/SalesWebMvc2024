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

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? start, DateTime? final)
        {
            var query = _context.SalesRecords.AsQueryable();

            if (start.HasValue)
            {
                query = query.Where(x => x.Date >= start.Value);
            }

            if (final.HasValue)
            {
                query = query.Where(x => x.Date <= final.Value);
            }

            // Execute a consulta no banco de dados e traga os dados para a memória
            var result = await query
                .Include(x => x.Seller)
                .ThenInclude(s => s.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

            // Agora aplique o agrupamento na memória
            var groupedResult = result.GroupBy(x => x.Seller.Department).ToList();

            return groupedResult;
        }
    }
}
