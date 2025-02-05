using Microsoft.AspNetCore.Mvc;
using Scheduling.Domain.Interfaces.Handlers;

namespace SchedulingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyNotificationsController(ICompanyNotificationsHandler companyNotificationsHandler) 
        : Controller
    {        
        [HttpGet(Name = "GetCompanyNotifications")]
        public async Task<ActionResult<Scheduling.Domain.Models.CompanyNotifications>> Index(Guid index)
        {
            var companyNotifications = companyNotificationsHandler.Handle(index);

            if (companyNotifications == null)
            {
                return BadRequest(index);
            }

            return Ok(companyNotifications);
        }
    }
}
