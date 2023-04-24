using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService ;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult GetAllTestimonials()

        {
            try
            {
                var result = _testimonialService.TGetAll();
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
        public IActionResult GetOneTestimonial([FromRoute(Name = "id")] int id)
        {
            try
            {
                var result = _testimonialService.TGetById(id);

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
        public IActionResult AddTestimonial([FromBody] Testimonial testimonial )
        {
            try
            {
                if (testimonial is null) { return BadRequest(); }
                if (ModelState.IsValid)
                {
                    //_manager.BookService.CreateOneBook(room);
                    testimonial.Cdate = System.DateTime.Now;
                    _testimonialService.TAdd(testimonial);


                    return StatusCode(201, testimonial);

                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateTestimonial([FromRoute(Name = "id")] int id, [FromBody] Testimonial testimonial)
      
        {
            try
            {
                if (testimonial is null) { return BadRequest(); }

                if (ModelState.IsValid)
                {
                    _testimonialService.TUpdate(testimonial);
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
        public IActionResult DeleteTestimonial([FromRoute(Name = "id")] int id)
        {
            try
            {
                _testimonialService.TDelete(id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
