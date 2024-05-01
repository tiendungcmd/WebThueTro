using Microsoft.AspNetCore.Mvc;
using MotelApi.Models;
using MotelApi.Request;
using MotelApi.Services.IServices;

namespace MotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotelController : ControllerBase
    {
        private readonly IMotelService _service;

        public MotelController(IMotelService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult> CreateMotel([FromBody] MotelModel request)
        {
            var motel = new Motel();
            motel.Id = Guid.NewGuid();
            motel.Name = request.Name;
            motel.Descriptions = request.Descriptions;
            motel.Price = request.Price;
            motel.Status = request.Status;
            var result = await _service.Create(motel);
            return Ok(result);
        }
    }
}
