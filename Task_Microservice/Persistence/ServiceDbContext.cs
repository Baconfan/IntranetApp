using Microsoft.EntityFrameworkCore;
using Task_Microservice.Models.Entities;

namespace Task_Microservice.Persistence
{
    public class ServiceDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
