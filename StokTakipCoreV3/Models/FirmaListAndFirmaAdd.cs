using EntityLayer.Concrete;
using System.Collections.Generic;

namespace StokTakipCoreV3.Models
{
    public class FirmaListAndFirmaAdd
    {
        public IEnumerable<Company> Companies { get; set; }
        public Company Company { get; set; }
    }
}
