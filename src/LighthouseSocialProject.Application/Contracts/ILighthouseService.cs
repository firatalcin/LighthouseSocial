using LighthouseSocialProject.Application.Dtos;

namespace LighthouseSocialProject.Application.Contracts;

public interface ILighthouseService
{
    Task<IEnumerable<LighthouseDto>> GetAllAsync();
    Task<LighthouseDto?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(LighthouseDto dto);
    Task UpdateAsync(Guid id, LighthouseDto dto);
    Task DeleteAsync(Guid id);
}