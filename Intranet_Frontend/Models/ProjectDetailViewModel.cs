namespace Intranet_Frontend.Models
{
    public class ProjectDetailViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
        public string ProjectManager { get; set; } = string.Empty;
        public string ProjectLocation { get; set; } = string.Empty;
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
    }
}
