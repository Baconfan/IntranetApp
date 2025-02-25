using Microsoft.EntityFrameworkCore;
using Task_Microservice.Models.Entities;

namespace Task_Microservice.Persistence
{
    public class ServiceDbContext: DbContext
    {
        public ServiceDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
