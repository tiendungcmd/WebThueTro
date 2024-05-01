using Microsoft.EntityFrameworkCore;
using MotelApi.DBContext;
using MotelApi.Models;
using MotelApi.Services.IServices;

namespace MotelApi.Services
{
    public class MotelService : IMotelService
    {
        private readonly MotelContext _context;

        public MotelService(MotelContext context)
        {
            _context = context;
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
    }
}
