using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class History
    {
        [Key]
        public int HistoryID { get; set; }
        public DateTime HistoryTarih { get; set; }
        public string HistoryFirmaAdi { get; set; }
        public string HistorySiparisAdres { get; set; }
        public string HistoryUrunMarka { get; set; }
        public string HistoryUrunModel { get; set; }
        public string HistoryUrunSn { get; set; }
        public string HistoryUrunDepo { get; set; }

        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
    }
}
