using EventBL;
using EventBL.Interfaces;
using EventREST.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventManager em;
        private IVisitorManager vm;

        public EventController(IEventManager em, IVisitorManager vm)
        {
            this.em = em;
            this.vm = vm;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(em.GetAllEvents().Select(e=>EventMapper.MapFromDomain(e)));
        }
        [HttpPost]
        [Route("{eventName}/visitors")]
        public IActionResult AddVisitorToEvent(string eventName,[FromBody] int vistorId)
        {
            try
            {
                Visitor visitor = vm.GetVisitor(vistorId);
                Event e = em.GetEvent(eventName);
                e.AddVisitor(visitor);
                return Ok(e);
            }
            catch (EventException) { return BadRequest("Event problem"); }
            catch (Exception) {return BadRequest("technical issue"); }
        }
    }
}
