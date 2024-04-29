using MotelApi.DBContext;
using MotelApi.Models;
using MotelApi.Services.IServices;

namespace MotelApi.Services
{
    public class UserService : IUserService
    {
        public readonly MotelContext _context;
        public UserService(MotelContext context)
        {
            _context = context;
        }
        public async Task Create(User model)
        {
             await _context.Users.AddAsync(model);
             _context.SaveChanges();
        }

        public Task<User> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x=>x.UserName == username);
            if (user != null && user.PasswordHash == password)
            {
                return true;
            }
            return false;
        }

        public Task<User> Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
