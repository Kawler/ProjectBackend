using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;
using Project.Dto;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_scheduleService.GetSchedule().ConvertAll(t => t.ConvertToScheduleDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Schedule schedule)
        {
            try
            {
                _scheduleService.Create(schedule);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id?}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _scheduleService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id?}")]
        public IActionResult Update(int id, Schedule schedule)
        {
            try
            {
                _scheduleService.Update(id, schedule);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
