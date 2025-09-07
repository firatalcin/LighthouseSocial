using LighthouseSocialProject.Application.Common;
using LighthouseSocialProject.Domain.Entities;

namespace LighthouseSocialProject.Application.Contracts.Repositories;

public interface ICountryDataReader
{
    Country GetById(int id);
    Task<Result<IReadOnlyList<Country>>> GetAllAsync();
}