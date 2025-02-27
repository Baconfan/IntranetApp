namespace HumanResource_Microservice.Models.Incoming;

/// <summary>
/// Data transfer object for searching for employees.
/// </summary>
public class SearchEmployeeDto
{
    /// <summary>
    /// Search term to search in fullname of the employee.
    /// </summary>
    public string? FullNameSearch { get; set; }

    /// <summary>
    /// Search term to search in first and middle name of the employee.
    /// </summary>
    public string? FirstMiddleNameSearch { get; set; }

    /// <summary>
    /// Search term to search in last name of the employee.
    /// </summary>
    public string? LastNameSearch { get; set; }

    /// <summary>
    /// NULL if all departments should be searched.
    /// </summary>
    public int? DepartmentId { get; set; }

    
}