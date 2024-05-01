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

        public Task<Motel> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Motel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Motel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Motel> Update(Motel model)
        {
            throw new NotImplementedException();
        }
    }
}
