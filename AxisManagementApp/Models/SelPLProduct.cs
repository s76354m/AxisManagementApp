using System;
using System.ComponentModel.DataAnnotations;

namespace AxisManagementApp.Models
{
    public class SelPLProduct
    {
        [Key]
        public int RecordID { get; set; }
        public string ProjectID { get; set; }
        public string ProjectStatus { get; set; }
        public string NWNW_ID { get; set; }
        public string NWPR_PFX { get; set; }
        public string GRGR_ID { get; set; }
        public string GRGR_NAME { get; set; }
        public string LastEditMSID { get; set; }
        public DateTime DataLoadDate { get; set; }
    }
}
