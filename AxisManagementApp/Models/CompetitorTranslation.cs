using System;
using System.ComponentModel.DataAnnotations;

namespace AxisManagementApp.Models
{
    public class CompetitorTranslation
    {
        [Key]
        public int RecordID { get; set; }
        public string ProjectID { get; set; }
        public string ProjectStatus { get; set; }
        public string StrenuusProductCode { get; set; }
        public string Payor { get; set; }
        public string Product { get; set; }
        public bool? EI { get; set; }
        public bool? CS { get; set; }
        public bool? MR { get; set; }
        public DateTime? DataLoadDate { get; set; }
        public string LastEditMSID { get; set; }
    }
}
