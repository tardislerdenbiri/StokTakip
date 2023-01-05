using EntityLayer.Concrete;
using System.Collections.Generic;

namespace StokTakipCoreV3.Models
{
    public class FirmaAndHistoryView
    {
        public IEnumerable<Company> Companies { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
