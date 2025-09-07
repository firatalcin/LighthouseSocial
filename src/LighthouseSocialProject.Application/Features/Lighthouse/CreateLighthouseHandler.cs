using LighthouseSocialProject.Application.Common;
using LighthouseSocialProject.Application.Contracts.Repositories;
using LighthouseSocialProject.Application.Dtos;
using LighthouseSocialProject.Domain.Entities;
using LighthouseSocialProject.Domain.Interfaces;
using LighthouseSocialProject.Domain.ValueObjects;

namespace LighthouseSocialProject.Application.Features.Lighthouse;

public class CreateLighthouseHandler
{
    private readonly ILighthouseRepository _repository;
    private readonly ICountryDataReader _countryDataReader;

    public CreateLighthouseHandler(ILighthouseRepository repository, ICountryDataReader countryDataReader)
    {
        _repository = repository;
        _countryDataReader = countryDataReader;
    }

    public async Task<Result<Guid>> HandleAsync(LighthouseDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return Result<Guid>.Fail("Lighthouse name is required");

        Country? country;
        try
        {
            country = _countryDataReader.GetById(dto.CountryId);
        }
        catch (Exception e)
        {
            return Result<Guid>.Fail($"Invalid country id: {dto.CountryId}, {e.Message}");
        }
        
        var location = new Coordinates(dto.Latitude, dto.Longitude);
        var lighthouse = new LighthouseSocialProject.Domain.Entities.Lighthouse(dto.id, dto.Name, country, location);
        
        await _repository.AddAsync(lighthouse);
        
        return Result<Guid>.Ok(lighthouse.Id);
    }
}

