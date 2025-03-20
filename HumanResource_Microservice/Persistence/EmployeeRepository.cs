using HumanResource_Microservice.Models.Entities;
using HumanResource_Microservice.Models.Incoming;
using HumanResource_Microservice.Models.Outgoing;
using Microsoft.EntityFrameworkCore;

namespace HumanResource_Microservice.Persistence
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context) // ✅ Injected via constructor
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<FoundEmployeeDto?> GetEmployeeById(int id)
        {
            var result = await _context.Employees.FindAsync(id);

            return result is null
                ? null
                : ToDto(result);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<FoundEmployeeDto>> GetEmployeesBySearchParams(SearchEmployeeDto searchParams)
        {
            return [];
        }

        /// <inheritdoc />
        public async Task<IEnumerable<FoundEmployeeDto>> GetAllEmployees()
        {
            var allEmployeesAsEntities = await _context.Employees.ToListAsync();
            
            return allEmployeesAsEntities.Select(ToDto);
        }


        /// <inheritdoc />
        public async Task<int> CreateNewEmployee(AddNewEmployeeDto newEmployee)
        {
            var x = await _context.Employees.AddAsync(ToEntity(newEmployee));
            await _context.SaveChangesAsync();
            
            return x.Entity.Id;
        }


        /// <inheritdoc />
        public async Task DeleteEmployee(int id)
        {
            /*
            var toBeDeletedEntity = await _context.Employees.FindAsync(id);
            if (toBeDeletedEntity is null)
            {
                return;
            }

            _context.Employees.Remove(toBeDeletedEntity);
            await _context.SaveChangesAsync();
            */
            
            await _context.Employees.Where(e => e.Id == id).ExecuteDeleteAsync();
        }

        /// <inheritdoc />
        public async Task UpdateEmploee(UpdateExistingEmployeeDto toBeUpdatedEmployee)
        {
            var entity = await _context.Employees.FindAsync(toBeUpdatedEmployee.Id);
            if (entity is null)
            {
                return;
            }
            
            entity.FirstMiddleName = toBeUpdatedEmployee.FirstMiddleName;
            entity.LastName = toBeUpdatedEmployee.LastName;
            entity.Address = toBeUpdatedEmployee.Address;
            entity.Department = toBeUpdatedEmployee.Department;
            entity.Email = toBeUpdatedEmployee.Email;
            entity.City = toBeUpdatedEmployee.City;
            entity.State = toBeUpdatedEmployee.State;
            entity.Phone = toBeUpdatedEmployee.PhoneNumber;
            
            await _context.SaveChangesAsync();
        }

        private static FoundEmployeeDto ToDto(Employee entity)
            => new(
                Id: entity.Id, 
                FirstMiddleName: entity.FirstMiddleName, 
                LastName: entity.LastName,
                Email: entity.Email,
                PhoneNumber: entity.Phone,
                DateOfBirth: DateTime.Today); //TODO Add Database column

        private static Employee ToEntity(AddNewEmployeeDto dto) 
            => new()
            {
                FirstMiddleName = dto.FirstMiddleName,
                LastName = dto.LastName,
                Department = dto.Department,
                Position = dto.Position,
                Email = dto.Email,
                Phone = dto.PhoneNumber,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                Zip = dto.ZipCode
            };
    }
}
