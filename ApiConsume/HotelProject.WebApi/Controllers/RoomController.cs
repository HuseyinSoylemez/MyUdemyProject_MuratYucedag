using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult GetAllRooms()

        {
            try
            {
                //var rooms = _manager.BookService.GetAllBooks(false);
                // return Ok(rooms);

                var result = _roomService.TGetAll();
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest(result);
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        

        [HttpGet("{id:int}")]
        public IActionResult GetOneRoom([FromRoute(Name = "id")] int id)
        {
            try
            {
                var result = _roomService.TGetById(id);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(); //404
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult AddRoom([FromBody] Room room)
        {
            try
            {
                if (room is null) { return BadRequest(); }

               
                if (ModelState.IsValid)
                {
                    //_manager.BookService.CreateOneBook(room);
                    room.Cdate = System.DateTime.Now;
                    _roomService.TAdd(room);


                    return StatusCode(201, room);

                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateRoom([FromRoute(Name = "id")] int id, [FromBody] Room room)
        //     [HttpPut]
        //public IActionResult UpdateRoom([FromBody] Room room)
        {
            try
            {
                if (room is null) { return BadRequest(); }

                if (ModelState.IsValid)
                {
                    _roomService.TUpdate(room);
                    return NoContent();

                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



        [HttpDelete("{id:int}")]
        public IActionResult DeleteRoom([FromRoute(Name = "id")] int id)
        {
            try
            {

                //var result = _staffService.TGetById(id);
                _roomService.TDelete(id);


                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        //[HttpPatch("{id:int}")]
        //public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch) //Kısmi güncelleme
        //{
        //    try
        //    {
        //        var entity = _manager.BookService.GetOneBookById(id, true);
        //        if (entity is null)
        //            return NotFound(new
        //            {
        //                statusCode = 404,
        //                mesaj = $"id: {id} olan kitap bulunamadı"
        //            });//404
        //        bookPatch.ApplyTo(entity);
        //        _manager.BookService.UpdateOneBook(id, entity, true);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }

        //}
    }
}
