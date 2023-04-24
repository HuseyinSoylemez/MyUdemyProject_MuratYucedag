using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult GetAllSubscribes()

        {
            try
            {
                var result = _subscribeService.TGetAll();
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
        public IActionResult GetOneSubscribe([FromRoute(Name = "id")] int id)
        {
            try
            {
                var result = _subscribeService.TGetById(id);

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
        public IActionResult AddSubscribe([FromBody] Subscribe subscribe)
        {
            try
            {
                if (subscribe is null) { return BadRequest(); }
                if (ModelState.IsValid)
                {
                    //_manager.BookService.CreateOneBook(room);
                    subscribe.Cdate = System.DateTime.Now;
                    _subscribeService.TAdd(subscribe);


                    return StatusCode(201, subscribe);

                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateSubscribe([FromRoute(Name = "id")] int id, [FromBody] Subscribe subscribe)

        {
            try
            {
                if (subscribe is null) { return BadRequest(); }

                if (ModelState.IsValid)
                {
                    _subscribeService.TUpdate(subscribe);
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
        public IActionResult DeleteSubscribe([FromRoute(Name = "id")] int id)
        {
            try
            {
                _subscribeService.TDelete(id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
