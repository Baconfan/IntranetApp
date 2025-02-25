namespace Task_Microservice.Models.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public required string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // UserId 
        public int AssigneeId { get; set; }

        public int StatusId { get; set; }

    }
}
