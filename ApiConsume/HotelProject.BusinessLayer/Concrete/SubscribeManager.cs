using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public void TAdd(Subscribe model)
        {
            _subscribeDal.Add(model);
        }

        public void TDelete(int id)
        {
            var deleted = _subscribeDal.Get(model => model.Id == id);
            _subscribeDal.Delete(deleted);
        }

        public List<Subscribe> TGetAll()
        {
            return _subscribeDal.GetAll().ToList();
        }

        public Subscribe TGetById(int id)
        {
            return _subscribeDal.Get(model => model.Id == id);
        }

        public void TUpdate(Subscribe model)
        {
            _subscribeDal.Update(model);
        }
    }
}
