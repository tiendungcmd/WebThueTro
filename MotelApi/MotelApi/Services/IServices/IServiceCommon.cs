namespace MotelApi.Services.IServices
{
    public interface IServiceCommon<T>
    {
        public Task Create(T model);
        public Task<T> Delete(Guid id);
        public Task<T> GetById(Guid id);
        public Task<T> GetAll();
        public Task<T> Update(T model);
    }
}
