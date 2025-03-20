namespace HumanResource_Microservice.Models.Outgoing;

public record FoundEmployeeDto(
    int Id, 
    string FirstMiddleName, 
    string LastName, 
    string Email, 
    string PhoneNumber, 
    DateTime DateOfBirth);