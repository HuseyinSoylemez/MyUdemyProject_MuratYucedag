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
    public class StaffManager:IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public void TAdd(Staff model)
        {
            _staffDal.Add(model);
        }

        public void TDelete(int id)
        {
            var deleted = _staffDal.Get(model => model.Id == id);
            _staffDal.Delete(deleted);
        }

        public List<Staff> TGetAll()
        {
            return _staffDal.GetAll().ToList();
        }

        public Staff TGetById(int id)
        {
            return _staffDal.Get(model => model.Id == id);
        }

        public void TUpdate(Staff model)
        {
            _staffDal.Update(model);
        }
    }
}
