using Microsoft.AspNetCore.Mvc;
using MotelApi.Models;
using MotelApi.Request;
using MotelApi.Response;
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
        public async Task<ActionResult<ApiResponse<MotelResponse>>> CreateMotel([FromBody] MotelModel request)
        {
            var motel = new Motel();
            motel.Id = Guid.NewGuid();
            motel.Name = request.Name;
            motel.Descriptions = request.Descriptions;
            motel.Price = request.Price;
            motel.Status = request.Status;
            motel.Title = request.Title;
            var result = await _service.Create(motel);
            //save iamge
            var image = new Image();
            image.Id = Guid.NewGuid();
            image.Name = request.Images.Name;
            image.Description = request.Images.Base64;
            await _service.CreateImage(image);
            //save image motel
            var imageMotel = new ImageMotel();
            imageMotel.ImageId = image.Id;
            imageMotel.MotelId = motel.Id;
            await _service.ImageMotel(imageMotel);

            var actual = new MotelResponse();
            actual.Id = result.Id;
            actual.Name = request.Name;
            actual.Descriptions = request.Descriptions;
            actual.Price = request.Price;
            actual.Status = request.Status;
            actual.Title = request.Title;
            return Ok(new ApiResponse<MotelResponse>
            {
                Data = actual,
                StatusCode = 200,
                Messages = result == null ? "Create motel fail" : null
            });
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<MotelResponse>>>> GetMotels()
        {
            var result = new List<MotelResponse>();
            var motels =await _service.GetAll();
            foreach (var item in motels)
            {
                var motel = new MotelResponse();
                motel.Id = item.Id;
                motel.Name = item.Name;
                motel.Status = item.Status;
                result.Add(motel);
            };
            return Ok(new ApiResponse<List<MotelResponse>>
            {
                Data = result,
                StatusCode = 200,
            });
        }
    }
}
