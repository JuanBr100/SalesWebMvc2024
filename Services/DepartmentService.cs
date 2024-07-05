using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public ICollection<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }


    }
}
