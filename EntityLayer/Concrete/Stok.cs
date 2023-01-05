using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Stok
    {
        [Key]
        public int StokID { get; set; }

        [StringLength(100)]
        [DisplayName("Seri Numarası")]
        [Required(ErrorMessage = "Seri numarası giriniz")]
        public string StokSn { get; set; }

        public DateTime StokTarih { get; set; } = DateTime.Now;

        public int? OrderID { get; set; }
        public virtual Order Order { get; set; }

        public int StoresID { get; set; }
        public virtual Stores Stores { get; set; }

        public int ProductsID { get; set; }
        public virtual Products Products { get; set; }
    }
}
