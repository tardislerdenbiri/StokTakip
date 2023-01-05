using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHistoryService:IGenericService<History>
    {
        List<History> GetListSiparisHistoryID(int id);
        List<History> GetExcelList(int id);
    }
}
