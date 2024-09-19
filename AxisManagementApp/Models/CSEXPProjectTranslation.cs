using System;
using System.ComponentModel.DataAnnotations;

namespace AxisManagementApp.Models
{
    public class CSEXPProjectTranslation
    {
        [Key]
        public int RecordID { get; set; }

        [StringLength(12)]
        public string? ProjectID { get; set; }

        [StringLength(100)]
        public string? BenchmarkFileID { get; set; }

        [StringLength(1)]
        public string? ProjectType { get; set; }

        [StringLength(100)]
        public string? ProjectDesc { get; set; }

        [StringLength(30)]
        public string? Analyst { get; set; }

        [StringLength(30)]
        public string? PM { get; set; }

        [StringLength(10)]
        public string? GoLiveDate { get; set; }

        public int? MaxMileage { get; set; }

        [StringLength(10)]
        public string? Status { get; set; }

        [StringLength(1)]
        public string? NewMarket { get; set; }

        [StringLength(1)]
        public string? ProvRef { get; set; }

        public DateTime? DataLoadDate { get; set; }

        public DateTime? LastEditDate { get; set; }

        [StringLength(15)]
        public string? LastEditMSID { get; set; }

        [StringLength(50)]
        public string? NDB_LOB { get; set; }

        public int RefreshInd { get; set; }
    }
}