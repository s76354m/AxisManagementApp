using System;
using System.ComponentModel.DataAnnotations;

namespace AxisManagementApp.Models
{
    public class YLineTranslation
    {
        [Key]
        public int RecordID { get; set; }
        public string ProjectID { get; set; }
        public string ProjectStatus { get; set; }
        public string NDB_Yline_ProdCd { get; set; }
        public int? NDB_Yline_IPA { get; set; }
        public int? NDB_Yline_MktNum { get; set; }
        public DateTime? DataLoadDate { get; set; }
        public DateTime? LastEditDate { get; set; }
        public string LastEditMSID { get; set; }
        public int PreAward { get; set; }
    }
}
