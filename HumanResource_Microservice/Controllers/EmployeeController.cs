using HumanResource_Microservice.Models.Incoming;
using HumanResource_Microservice.Models.Outgoing;
using HumanResource_Microservice.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource_Microservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IEmployeeRepository employeeRepository): ControllerBase
{
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
    /// <returns></returns>
    [HttpPost("BySearchParams", Name= "GetEmployeeBySearchConditions")]
    [Consumes("application/json")]
    [Produces("application/json", Type = typeof(IEnumerable<FoundEmployeeDto>))]
    public async Task<IActionResult> GetCoworkersBySearchConditions([FromBody] SearchEmployeeDto searchParams)
    {
        // Looking for matching coworkers.

        // Return a list of matching coworkers.
        return Ok(new List<FoundEmployeeDto>());
    }


}
