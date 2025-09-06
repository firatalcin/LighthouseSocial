namespace LighthouseSocialProject.Application.Dtos;

public record PhotoDto(Guid id, string Filename, DateTime UploadedAt, string CameraModel, Guid UserId, Guid LighthouseId);