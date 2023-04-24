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
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void TAdd(Room model)
        {
           _roomDal.Add(model);
        }

        public void TDelete(int id)
        {
            var deleted = _roomDal.Get(model => model.Id == id);
            _roomDal.Delete(deleted);
        }

        public List<Room> TGetAll()
        {
            return _roomDal.GetAll().ToList();
        }

        public Room TGetById(int id)
        {
            return _roomDal.Get(model => model.Id == id);
        }

        public void TUpdate(Room model)
        {
            _roomDal.Update(model);
        }
    }
}
