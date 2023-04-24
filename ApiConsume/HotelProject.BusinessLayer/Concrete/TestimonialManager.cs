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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TAdd(Testimonial model)
        {
            _testimonialDal.Add(model);
        }

        public void TDelete(int id)
        {
            var deleted = _testimonialDal.Get(model => model.Id == id);
            _testimonialDal.Delete(deleted);
        }

        public List<Testimonial> TGetAll()
        {
            return _testimonialDal.GetAll().ToList(); 
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialDal.Get(model => model.Id == id);
        }

        public void TUpdate(Testimonial model)
        {
            _testimonialDal.Update(model);
        }
    }
}
