using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {

            try
            {
                var result = _aboutService.TGetAll();
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





     
        [HttpPost]
        public IActionResult AddAbout([FromBody] About about)
        {

            try
            {
                if (about is null) { return BadRequest(); }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _aboutService.TAdd(about);


                return StatusCode(201, about);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }






        [HttpDelete("{id:int}")]
        public IActionResult DeleteAbout([FromRoute(Name = "id")] int id)
        {
            try
            {
                //var result = _staffService.TGetById(id);
                _aboutService.TDelete(id);


                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateAbout([FromBody] About about)
        {
            try
            {
                if (about is null) { return BadRequest(); }


                if (ModelState.IsValid)
                {
                    _aboutService.TUpdate(about);
                    return NoContent();

                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetAbout([FromRoute(Name = "id")] int id)
        {
            try
            {
                var result = _aboutService.TGetById(id);

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
    }
}
