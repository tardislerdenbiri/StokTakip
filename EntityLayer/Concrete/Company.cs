using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [StringLength(100)]
        [DisplayName("Müşteri Adı")]
        [Required(ErrorMessage = "Müşteri adını giriniz")]
        public string CompanyName { get; set; }

        [StringLength(100)]
        [DisplayName("Müşteri Adres")]
        [Required(ErrorMessage = "Müşteri adresini giriniz")]
        public string CompanyAdress { get; set; }

        [StringLength(100)]
        [DisplayName("Müşteri Telefon")]
        [Required(ErrorMessage = "Müşteri telefon numarası giriniz")]
        public string CompanyPhone { get; set; }

        public string CompanyNot { get; set; }

        public virtual List<History> Histories { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
