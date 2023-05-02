using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About model)
        {
            _aboutDal.Add(model);
        }

        public void TDelete(int id)
        {
            var deleted = _aboutDal.Get(model => model.AboutID == id);
            _aboutDal.Delete(deleted);
        }

        public List<About> TGetAll()
        {
            return _aboutDal.GetAll().ToList();
        }

        public About TGetById(int id)
        {
            return _aboutDal.Get(model => model.AboutID == id);
        }

        public void TUpdate(About model)
        {
            _aboutDal.Update(model);
        }
    }
}
