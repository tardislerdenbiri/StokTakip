using EntityLayer.Concrete;
using System.Collections.Generic;

namespace StokTakipCoreV3.Models
{
    public class OrderListAndOrderAdd
    {
        public IEnumerable<Order> Orders { get; set; }
        public Order Order { get; set; }
    }
}
