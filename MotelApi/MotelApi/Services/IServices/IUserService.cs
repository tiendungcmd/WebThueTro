using MotelApi.Models;

namespace MotelApi.Services.IServices
{
    public interface IUserService:IServiceCommon<User>
    {
        public bool Login(string username, string password);
    }
}
