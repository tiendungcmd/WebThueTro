using MotelApi.Models;

namespace MotelApi.Services.IServices
{
    public interface IMotelService : IServiceCommon<Motel>
    {
        Task<Image> CreateImage(Image model);

        Task<ImageMotel> ImageMotel(ImageMotel model);
        Task<List<Image>> GetImages(Guid id);
    }
}
