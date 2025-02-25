namespace Task_Microservice.Models;

public class AddToDoItemDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description = string.Empty;

    public int AssigneeId { get; set; }

    public int StatusId { get; set; }
}