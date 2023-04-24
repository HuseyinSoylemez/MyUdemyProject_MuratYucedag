using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult GetAllStaffs()

        {
            try
            {
                //var rooms = _manager.BookService.GetAllBooks(false);
                // return Ok(rooms);

                var result = _staffService.TGetAll();
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
        public IActionResult GetOneStaff([FromRoute(Name = "id")] int id)
        {
            try
            {
                var result = _staffService.TGetById(id);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(); //404



                //var book = _manager
                //                .BookService
                //                .GetOneBookById(id, false);

                //if (book is null)
                //    return NotFound(); //404

                //return Ok(book);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult AddStaff([FromBody] Staff staff)
        {
            try
            {
                if (staff is null) { return BadRequest(); }
                if (ModelState.IsValid)
                {
                    //_manager.BookService.CreateOneBook(room);
                    staff.Cdate = System.DateTime.Now;
                    _staffService.TAdd(staff);


                    return StatusCode(201, staff);

                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //[HttpPut("{id:int}")]
        [HttpPut]
        //public IActionResult UpdateStaff([FromRoute(Name = "id")] int id, [FromBody] Staff staff)
        public IActionResult UpdateStaff([FromBody] Staff staff)
        {
            try
            {
                if (staff is null) { return BadRequest(); }


                if (ModelState.IsValid)
                {
                    _staffService.TUpdate(staff);
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
                _staffService.TDelete(id);
                

                return NoContent();
              
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
