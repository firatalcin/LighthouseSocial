using LighthouseSocialProject.Application.Dtos;

namespace LighthouseSocialProject.Application.Contracts;

public interface IPhotoService
{
    Task<Guid> UploadAsync(PhotoDto dto, Stream fileContent);
    Task DeleteAsync(Guid id);
}