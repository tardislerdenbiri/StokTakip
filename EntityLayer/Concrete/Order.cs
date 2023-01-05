using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [DisplayName("Sipariş Tarihi")]
        [Required(ErrorMessage = "Sipariş tarihi giriniz")]
        public DateTime OrderTarih { get; set; }

        [StringLength(100)]
        [DisplayName("Sipariş Adresi")]
        [Required(ErrorMessage = "Sipariş adresi giriniz")]
        public string OrderAdres { get; set; }

        public bool OrderDurum { get; set; }

        [DisplayName("Sipariş Nedeni")]
        [Required(ErrorMessage = "Sipariş nedeni seçiniz")]
        public string OrderNedeni { get; set; }

        [DisplayName("Sipariş Notu")]
        public string OrderNot { get; set; }

        [DisplayName("Müşteri Adı")]
        [Required(ErrorMessage = "Müşteri seçiniz")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        public virtual List<Stok> Stoks { get; set; }
        public virtual List<History> Histories { get; set; }
    }
}
