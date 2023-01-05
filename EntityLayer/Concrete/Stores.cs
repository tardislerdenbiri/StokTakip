using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Stores
    {
        [Key]
        [Required(ErrorMessage = "Depo Seçiniz")]
        public int StoresID { get; set; }

        [StringLength(100)]
        [DisplayName("Depo Adı")]
        [Required(ErrorMessage = "Depoyu seçiniz")]
        public string StoresName { get; set; }

        public virtual List<Stok> Stoks { get; set; }
    }
}
