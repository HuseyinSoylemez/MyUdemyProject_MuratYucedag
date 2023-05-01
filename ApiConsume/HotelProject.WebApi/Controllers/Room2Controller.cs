using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
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
        [HttpPost]
        public IActionResult AddRoom([FromBody] RoomAddDto roomAddDto)
        {

            try
            {
                if (roomAddDto is null) { return BadRequest(); }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var values = _mapper.Map<Room>(roomAddDto);
                values.Cdate = System.DateTime.Now;
                _roomService.TAdd(values);
                return StatusCode(201, values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateRoom([FromRoute(Name = "id")] int id, [FromBody] UpdateRoomDto updateRoomDto)
        {
            if (updateRoomDto is null) { return BadRequest(); }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(updateRoomDto);
            values.Cdate = System.DateTime.Now;
            _roomService.TUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }
    }
}