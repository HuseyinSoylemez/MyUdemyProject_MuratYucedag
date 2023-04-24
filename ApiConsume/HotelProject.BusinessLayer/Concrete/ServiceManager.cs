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
    public class ServiceManager:IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void TAdd(Service model)
        {
            _serviceDal.Add(model);
        }

        public void TDelete(int id)
        {
            var deleted = _serviceDal.Get(model => model.Id == id);
            _serviceDal.Delete(deleted);
        }

        public List<Service> TGetAll()
        {
            return _serviceDal.GetAll().ToList();
        }

        public Service TGetById(int id)
        {
            return _serviceDal.Get(model => model.Id == id);
        }

        public void TUpdate(Service model)
        {
            _serviceDal.Update(model);
        }
    }
}
