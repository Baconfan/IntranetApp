using HumanResource_Microservice.Models.Incoming;
using HumanResource_Microservice.Models.Outgoing;

namespace HumanResource_Microservice.Persistence;


public interface IEmployeeRepository
{
    /// <summary>
    /// Searches for Employee with an ID.
    /// </summary>
    /// <param name="id">unique ID for search</param>
    /// <returns>Matched Employee, NULL if no Employee was found</returns>
    Task<FoundEmployeeDto?> GetEmployeeById(int id);

    /// <summary>
    /// Searches for Employees with parameters.
    /// </summary>
    /// <param name="searchParams">parameters for search</param>
    /// <returns>Matched Employees</returns>
    Task<IEnumerable<FoundEmployeeDto>> GetEmployeesBySearchParams(SearchEmployeeDto searchParams);

    /// <summary>
    /// Returns all Employees.
    /// </summary>
    /// <returns>All Employees</returns>
    Task<IEnumerable<FoundEmployeeDto>> GetAllEmployees();

    /// <summary>
    /// Creates a new Employee and returns the ID.
    /// </summary>
    /// <param name="newEmployee">data of the new employee</param>
    /// <returns>newly created ID</returns>
    Task<int> CreateNewEmployee(AddNewEmployeeDto newEmployee);
    
    /// <summary>
    /// Deletes an Employee with the given ID.
    /// </summary>
    /// <param name="id">ID of the employee who will be deleted</param>
    Task DeleteEmployee(int id);

    /// <summary>
    /// Update an existing Employee.
    /// </summary>
    /// <param name="toBeUpdatedEmployee">new data</param>
    Task UpdateEmploee(UpdateExistingEmployeeDto toBeUpdatedEmployee);
}