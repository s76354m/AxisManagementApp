using System;
using System.ComponentModel.DataAnnotations;

namespace AxisManagementApp.Models
{
    public class ServiceAreaStage
    {
        [Key]
        public int RecordID { get; set; }
        public string ProjectID { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ReportInclude { get; set; }
        public int? MaxMileage { get; set; }
        public DateTime? DataLoadDate { get; set; }
        public string ProjectStatus { get; set; }
    }
}
