using EntityLayer.Concrete;
using System.Collections.Generic;

namespace StokTakipCoreV3.Models
{
    public class SiparisHistory
    {
        public IEnumerable<Order> Orders { get; set; }
        public Order Order { get; set; }
        public IEnumerable<History> Histories { get; set; }
        public History History { get; set; }
    }
}
