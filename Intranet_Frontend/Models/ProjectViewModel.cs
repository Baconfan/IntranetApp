using IntranetLibrary.Enums;

namespace Intranet_Frontend.Models
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
        
        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.Unknown;
    }

}
