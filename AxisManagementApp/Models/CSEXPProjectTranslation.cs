using System;
using System.ComponentModel.DataAnnotations;

namespace AxisManagementApp.Models
{
    public class CSEXPProjectTranslation
    {
        [Key]
        public int RecordID { get; set; }

        [Required]
        [StringLength(12)]
        public string ProjectID { get; set; }

        [Required]
        [StringLength(30)]
        public string Analyst { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(100)]
        public string ProjectDesc { get; set; }

        [Required]
        [StringLength(50)]
        public string Product { get; set; }

        [Required]
        [StringLength(30)]
        public string PM { get; set; }

        [Required]
        public int Iteration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime GoLiveDate { get; set; }

        [Required]
        public int MaxMileage { get; set; }

        public bool IsLimitedExpansionProject { get; set; }

        [StringLength(1)]
        public string ProjectType { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(1)]
        public string NewMarket { get; set; }

        [StringLength(1)]
        public string ProvRef { get; set; }

        public DateTime? DataLoadDate { get; set; }

        public DateTime? LastEditDate { get; set; }

        [StringLength(15)]
        public string LastEditMSID { get; set; }

        [StringLength(50)]
        public string NDB_LOB { get; set; }

        public int RefreshInd { get; set; }
    }
}