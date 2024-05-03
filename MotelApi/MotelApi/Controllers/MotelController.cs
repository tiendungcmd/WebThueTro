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
        private static IWebHostEnvironment _webHostEnvironment;
        public MotelController(IMotelService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<MotelResponse>>> CreateMotel([FromBody] MotelModelRequest request)
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
            image.Name = request.File.Name;

            try
            {
                if (!Directory.Exists(_webHostEnvironment.WebRootPath + ".\\Images\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + ".\\Images\\");
                }
                var fileName = request.File.FileName;
                var existImage = System.IO.File.Exists(_webHostEnvironment.WebRootPath + ".\\Images\\" + fileName);
                if (existImage)
                {
                    fileName += "(copy)";
                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + ".\\Images\\" + fileName))
                {
                    request.File.CopyTo(fileStream);
                    fileStream.Flush();
                    image.ImageUrl = "\\Images\\" + fileName;
                }


            }
            catch (Exception ex)
            {

            }

            //image.Description = request.Images.Base64;
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
            actual.Price = (int)request.Price;
            actual.Status = (Common.Status)(int)request.Status;
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
            var motels = await _service.GetAll();
            foreach (var item in motels)
            {
                var motel = new MotelResponse();
                motel.Id = item.Id;
                motel.Name = item.Name;
                motel.Status = (Common.Status)item.Status;
                result.Add(motel);
            };
            return Ok(new ApiResponse<List<MotelResponse>>
            {
                Data = result,
                StatusCode = 200,
            });
        }

        [HttpPost("upload")]
        public ActionResult Upload([FromForm] UploadFile file)
        {
            try
            {
                if (!Directory.Exists(_webHostEnvironment.WebRootPath + ".\\Images\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + ".\\Images\\");
                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + ".\\Images\\" + file.File.FileName))
                {
                    file.File.CopyTo(fileStream);
                    fileStream.Flush();
                    return Ok("\\Images\\" + file.File.FileName);
                }
            }
            catch (Exception ex)
            {

            }

            return Ok("");
        }
    }
}
