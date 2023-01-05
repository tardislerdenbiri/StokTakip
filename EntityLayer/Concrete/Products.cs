using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Products
    {
        [Key]
        public int ProductsID { get; set; }

        
        [StringLength(100)]
        [DisplayName("Ürün Marka")]
        [Required(ErrorMessage = "Marka giriniz")]
        public string ProductsMarka { get; set; }

       
        [StringLength(100)]
        [DisplayName("Ürün Model")]
        [Required(ErrorMessage = "Model giriniz")]
        public string ProductsModel { get; set; }

        public virtual List<Stok> Stoks { get; set; }
    }
}
