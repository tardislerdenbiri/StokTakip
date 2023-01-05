using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WebConfigManager : IWebConfigService
    {
        IWebConfigDal _webConfigDal;

        public WebConfigManager(IWebConfigDal webConfigDal)
        {
            _webConfigDal = webConfigDal;
        }

        public void TAdd(WebConfig t)
        {
            _webConfigDal.Insert(t);
        }

        public void TDelete(WebConfig t)
        {
            throw new NotImplementedException();
        }

        public WebConfig TGetByID(int id)
        {
            return _webConfigDal.GetByID(id);
        }

        public WebConfig TGetID(int id)
        {
            return _webConfigDal.GetID(x=>x.OptionID==id);
        }

        public List<WebConfig> TGetList()
        {
            return _webConfigDal.GetList();
        }

        public void TUpdate(WebConfig t)
        {
            _webConfigDal.Update(t);
        }
    }
}
