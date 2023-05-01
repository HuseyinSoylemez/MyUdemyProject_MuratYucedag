using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult GetAllServices()

        {
            try
            {
                var result = _serviceService.TGetAll();
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
        public IActionResult GetOneService([FromRoute(Name = "id")] int id)
        {
            try
            {
                var result = _serviceService.TGetById(id);

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
        public IActionResult AddService([FromBody] Service service)
        {
            try
            {
                if (service is null) { return BadRequest(); }
                if (ModelState.IsValid)
                {
                    //_manager.BookService.CreateOneBook(room);
                    service.Cdate = System.DateTime.Now;
                    _serviceService.TAdd(service);


                    return StatusCode(201, service);

                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //[HttpPut("{id:int}")]
        //public IActionResult UpdateService([FromRoute(Name = "id")] int id, [FromBody] Service service)
        [HttpPut]
        public IActionResult UpdateService([FromBody] Service service)
        {
            try
            {
                if (service is null) { return BadRequest(); }

                if (ModelState.IsValid)
                {
                    _serviceService.TUpdate(service);
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
        public IActionResult DeleteService([FromRoute(Name = "id")] int id)
        {
            try
            {
                _serviceService.TDelete(id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
