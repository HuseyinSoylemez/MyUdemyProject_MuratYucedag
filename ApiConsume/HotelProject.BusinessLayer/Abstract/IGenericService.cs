using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        T TGetById(int id);
        List<T> TGetAll();
        void TAdd(T model);
        void TUpdate(T model);
        void TDelete(int id);
    }
}
