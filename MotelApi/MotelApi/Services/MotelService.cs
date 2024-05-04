using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MotelApi.DBContext;
using MotelApi.Models;
using MotelApi.Response;
using MotelApi.Services.IServices;

namespace MotelApi.Services
{
    public class MotelService : IMotelService
    {
        private readonly MotelContext _context;
        private readonly IMapper _mapper;

        public MotelService(MotelContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Motel> Create(Motel model)
        {
            await _context.Motels.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<MotelDetail> CreateMotelDetails(MotelDetail model)
        {
            await _context.MotelDetails.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Image> CreateImage(Image model)
        {
            await _context.Images.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<ImageMotel> ImageMotel(ImageMotel model)
        {
            await _context.ImageMotels.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task<Motel> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Motel>> GetAll()
        {
            return await _context.Motels.Where(x => x.Status == Common.Status.Pending).ToListAsync();
        }

        public Task<Motel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Motel> Update(Motel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Image>> GetImages(Guid motelId)
        {
            var result = new List<Image>();
            var imageMotels = await _context.ImageMotels.Where(x => x.MotelId == motelId).ToListAsync();
            foreach (var item in imageMotels)
            {
                var image = _context.Images.FirstOrDefault(x => x.Id == item.ImageId);
                result.Add(image);
            }
            return result;
        }

        public async Task<List<MotelResponse>> GetMotels()
        {
            var motels = await _context.Motels.Where(x => x.Status == Common.Status.Pending).ToListAsync();
            var result = _mapper.Map<List<MotelResponse>>(motels);

            foreach (var item in result)
            {
                var imageMotel = _context.ImageMotels.FirstOrDefault(x => x.MotelId == item.Id);
                if(imageMotel != null)
                {
                    item.Images = _context.Images.FirstOrDefault(x => x.Id == imageMotel.ImageId).ImageUrl.Replace("\\","/");
                }
            }
            return result;
        }
    }
}
