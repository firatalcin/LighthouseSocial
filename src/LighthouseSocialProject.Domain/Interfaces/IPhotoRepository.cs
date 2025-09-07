using LighthouseSocialProject.Domain.Entities;

namespace LighthouseSocialProject.Domain.Interfaces;

public interface IPhotoRepository
{
    Task AddAsync(Photo photo);
    Task DeleteAsync(Guid id);
    Task<Photo?> GetByIdAsync(Guid id);
    Task<IEnumerable<Photo>> GetByLighthouseIdAsync(Guid lighthouseId);
    Task<IEnumerable<Photo>> GetByUserIdAsync(Guid userId);
}