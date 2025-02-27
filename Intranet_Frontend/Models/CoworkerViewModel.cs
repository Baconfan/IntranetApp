namespace Intranet_Frontend.Models
{
    public class CoworkerViewModel
    {
        public IEnumerable<CoworkerItem> CoworkerCollection = [];
    }

    public class CoworkerItem
    {
        public string FirstAndMiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstAndMiddleName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public string JobLocation { get; set; } = string.Empty;
        public string LinkPicture { get; set; } = string.Empty;
    }
}
