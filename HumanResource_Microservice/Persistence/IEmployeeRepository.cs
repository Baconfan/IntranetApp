using HumanResource_Microservice.Models.Incoming;
using HumanResource_Microservice.Models.Outgoing;

namespace HumanResource_Microservice.Persistence;


public interface IEmployeeRepository
{
    Task<FoundEmployeeDto?> GetEmployeeById(int id);

    Task<IEnumerable<FoundEmployeeDto>> GetEmployeesBySearchParams(SearchEmployeeDto searchParams);
}