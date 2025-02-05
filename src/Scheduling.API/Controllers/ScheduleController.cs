using Microsoft.AspNetCore.Mvc;
using Scheduling.Domain.Interfaces.Handlers;
using System.Net;
using ScheduleItem = Scheduling.Domain.Models.ScheduleItem;

namespace SchedulingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController(ICreateScheduleHandler createScheduleHandler) 
        : ControllerBase
    {      
        [HttpPost]
        public HttpResponseMessage CreateSchedule(ScheduleItem scheduleItem)
        {
            HttpResponseMessage? response;

            if (createScheduleHandler.Handle(scheduleItem))
            { 
                response = new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode)(int)HttpStatusCode.OK
                };
            }
            else
            {
                response = new HttpResponseMessage
                {
                    StatusCode = (HttpStatusCode)(int)HttpStatusCode.BadRequest
                };
            }

            return response;
        }
    }
}
