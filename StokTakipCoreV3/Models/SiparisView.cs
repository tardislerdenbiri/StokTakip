using EntityLayer.Concrete;
using System.Collections.Generic;

namespace StokTakipCoreV3.Models
{
    public class SiparisView
    {
        public IEnumerable<Order> Orders { get; set; }
        public Order Order { get; set; }
        public Order OrderEdit { get; set; }
        public IEnumerable<Stok> Stoks { get; set; }
        public Stok Stok { get; set; }
    }
}
