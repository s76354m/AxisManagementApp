using System;
using System.ComponentModel.DataAnnotations;

namespace AxisManagementApp.Models
{
    public class ProjectNote
    {
        [Key]
        public int RecordID { get; set; }
        public string ProjectID { get; set; }
        public string Notes { get; set; }
        public string ActionItem { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime? DataLoadDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string OrigNoteMSID { get; set; }
        public string LastEditMSID { get; set; }
        public string ProjectCategory { get; set; }
    }
}
