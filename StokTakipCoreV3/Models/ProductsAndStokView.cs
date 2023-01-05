using EntityLayer.Concrete;
using System.Collections.Generic;

namespace StokTakipCoreV3.Models
{
    public class ProductsAndStokView
    {
        public IEnumerable<Products> Productss { get; set; }
        public Products Products { get; set; }
        public IEnumerable<Stok> Stoks { get; set; }
        public Stok Stok { get; set; }
        public IEnumerable<Stores> Storess { get; set; }
        public Stores Stores { get; set; }
    }
}
