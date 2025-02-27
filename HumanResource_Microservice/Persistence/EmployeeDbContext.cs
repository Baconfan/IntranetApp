using HumanResource_Microservice.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResource_Microservice.Persistence;

public class EmployeeDbContext: DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }
    public virtual DbSet<Employee> Employees { get; set; } = null!;
}