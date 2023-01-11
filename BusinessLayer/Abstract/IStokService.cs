using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStokService:IGenericService<Stok>
    {
        List<Stok> GetUrunlerStok(int id);
        List<Stok> GetListUrunDetayDepoAdet(int id);
        List<Stok> GetListSiparisView(int id);
        List<Stok> OrderDeleteGetStokProductid(int id);
        List<Stok> GetStokSn(string sn);
        List<Stok> GetStokSiparisTamamla(int id);
    }
}
