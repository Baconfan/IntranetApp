using HumanResource_Microservice.Models.Incoming;
using HumanResource_Microservice.Models.Outgoing;
using HumanResource_Microservice.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource_Microservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IEmployeeRepository employeeRepository): ControllerBase
{
    /// <summary>
    /// Searches for 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Ok result with found employee or NotFound result</returns>
    [HttpGet("ById/{id:int}",Name = "GetEmployeeById")]
    [Produces("application/json", Type = typeof(FoundEmployeeDto))]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var matchingEmployee = await employeeRepository.GetEmployeeById(id);

        return matchingEmployee is null
            ? NotFound()
            : Ok(matchingEmployee);
    }

    /// <summary>
    /// Searches for employees by search parameters.
    /// </summary>
    /// <param name="searchParams">search parameter (e.g. fullname)</param>
    /// <returns>matched employees</returns>
    [HttpPost("BySearchParams", Name= "GetEmployeeBySearchConditions")]
    [Consumes("application/json")]
    [Produces("application/json", Type = typeof(IEnumerable<FoundEmployeeDto>))]
    public async Task<IActionResult> GetEmployeesBySearchConditions([FromBody] SearchEmployeeDto searchParams)
    {
        // Looking for matching coworkers.
        

        // Return a list of matching coworkers.
        return Ok(new List<FoundEmployeeDto>());
    }

    /// <summary>
    /// Searches for all employees.
    /// </summary>
    /// <returns>OK result with all employees</returns>
    [HttpGet("all", Name = "GetAllEmployees")]
    [Produces("application/json", Type = typeof(IEnumerable<FoundEmployeeDto>))]
    public async Task<IActionResult> GetAllEmployees()
    {
        return Ok(await employeeRepository.GetAllEmployees());
    }

    /// <summary>
    /// Adds a new employee with the given data.
    /// </summary>
    /// <param name="addNewEmployeeDto">data of new employee</param>
    /// <returns>OK result with ID of newly created employee</returns>
    [HttpPost("new", Name = "AddEmployee")]
    [Consumes("application/json")]
    public async Task<IActionResult> AddNewEmployee(AddNewEmployeeDto addNewEmployeeDto)
    {
        var newId = await employeeRepository.CreateNewEmployee(addNewEmployeeDto);
        
        return Ok(newId);
    }

    /// <summary>
    /// Deletes an employee with the given ID.
    /// </summary>
    /// <param name="id">ID of to be deleted employee</param>
    /// <returns>NoContent Result</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await employeeRepository.DeleteEmployee(id);
        
        return NoContent();
    }

}
