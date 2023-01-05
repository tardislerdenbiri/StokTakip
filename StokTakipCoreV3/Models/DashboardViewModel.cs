using EntityLayer.Concrete;
using System.Collections.Generic;

namespace StokTakipCoreV3.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public Order Order { get; set; }
        public IEnumerable<Stok> Stoks { get; set; }
        public Stok Stok { get; set; }
        public IEnumerable<WebConfig> webConfigs { get; set; }
        public WebConfig webConfig { get; set; }
    }
}
