using EventBL;
using EventBL.Interfaces;
using EventBL.Managers;
using EventREST.Mappers;
using EventREST.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private IVisitorManager vm;

        public VisitorController(IVisitorManager vm)
        {
            this.vm = vm;
        }

        [HttpGet]
        public IActionResult GetVisitors()
        {
            return Ok(vm.GetAllVisitors());
        }
        [HttpGet("{id}")]
        public IActionResult GetVisitorById(int id)
        {
            return Ok(vm.GetVisitor(id));
        }
        [HttpPost]
        public IActionResult AddVisitor([FromBody] VisitorInputDTO visitorDTO)
        {
            Visitor visitor = VisitorMapper.MapToDomain(visitorDTO);
            vm.RegisterVisitor(visitor);
            vm.SubscribeVisitor(visitor);
            return CreatedAtAction(nameof(GetVisitorById), new { id = visitor.Id }, visitor);
            //return Ok();
        }
    }
}
