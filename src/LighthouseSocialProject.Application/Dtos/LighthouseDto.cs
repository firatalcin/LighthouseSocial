namespace LighthouseSocialProject.Application.Dtos;

public record LighthouseDto(Guid id, string Name, int CountryId, double Latitude, double Longitude);