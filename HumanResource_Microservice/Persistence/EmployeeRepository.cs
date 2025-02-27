using HumanResource_Microservice.Models.Incoming;
using HumanResource_Microservice.Models.Outgoing;

namespace HumanResource_Microservice.Persistence
{
    public class EmployeeRepository: IEmployeeRepository
    {

        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context) // ✅ Injected via constructor
        {
            _context = context;
        }
        public async Task<FoundEmployeeDto?> GetEmployeeById(int id)
        {
            var result = await _context.Employees.FindAsync(id);

            return result is null
                ? null
                : new FoundEmployeeDto(FirstMiddleName: result.FirstMiddleName, LastName: result.LastName);
        }

        public async Task<IEnumerable<FoundEmployeeDto>> GetEmployeesBySearchParams(SearchEmployeeDto searchParams)
        {
            return Enumerable.Empty<FoundEmployeeDto>();
        }
    }
}
