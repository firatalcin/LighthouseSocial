using LighthouseSocialProject.Application.Common;
using LighthouseSocialProject.Application.Dtos;
using LighthouseSocialProject.Domain.Interfaces;

namespace LighthouseSocialProject.Application.Features.Lighthouse;

public class GetAllLighthousesHandler
{
    private readonly ILighthouseRepository _repository;

    public GetAllLighthousesHandler(ILighthouseRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Result<IEnumerable<LighthouseDto>>> HandleAsync()
    {
        var lighthouses = await _repository.GetAllAsync();

        if (!lighthouses.Any())
        {
            return Result<IEnumerable<LighthouseDto>>.Fail("No Lighthouse found");
        }

        var dtos = lighthouses.Select(x => new LighthouseDto(
            x.Id,
            x.Name,
            x.CountyId,
            x.Location.Latitude,
            x.Location.Longitude
            ));
        
        return Result<IEnumerable<LighthouseDto>>.Ok(dtos);
    }
}