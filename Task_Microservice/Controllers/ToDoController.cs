using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Task_Microservice.Models;
using Task_Microservice.Models.Entities;
using Task_Microservice.Persistence;

namespace Task_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ServiceDbContext _dbContext;

        public ToDoController(ServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET all the tasks of the employer since last week.
        [HttpGet]
        [Route("recent/{userId:int}")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAllRecentToDos(int userId)
        {
            if (userId < 0)
            {
                return BadRequest();
            }

            var allRecentToDos = await _dbContext.ToDoItems
                .Where(t => t.AssigneeId.Equals(userId))
                .ToListAsync();

            if (allRecentToDos.IsNullOrEmpty())
            {
                return new ToDoItem[]{};
            }

            return allRecentToDos;
        }

        // Create a new ToDoItem


        // Update a task


        // Delete a task

        
    }
}
