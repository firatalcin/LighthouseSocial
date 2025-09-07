using LighthouseSocialProject.Application.Common;
using LighthouseSocialProject.Application.Dtos;
using LighthouseSocialProject.Domain.Interfaces;
using LighthouseSocialProject.Domain.ValueObjects;

namespace LighthouseSocialProject.Application.Features.Photo;

public class UploadPhotoHandler
{
    private readonly IPhotoStorageService _photoStorageService;
    private readonly IPhotoRepository _photoRepository;

    public UploadPhotoHandler(IPhotoRepository photoRepository, IPhotoStorageService photoStorageService)
    {
        _photoStorageService = photoStorageService;
        _photoRepository = photoRepository;
    }

    public async Task<Result<Guid> HandleAsync(PhotoDto photoDto, Stream content)
    {
        if(content == null || content.Length == 0)
            return Result<Guid>.Fail("Photo content is empty");

        var savedPath = await _photoStorageService.SaveAsync(content, photoDto.Filename);

        var metadata = new PhotoMetaData(
            "N/A",
            "Unknown",
            photoDto.CameraModel,
            photoDto.UploadedAt
            );

        var photo = new Domain.Entities.Photo(Guid.NewGuid(), photoDto.UserId, photoDto.LighthouseId, savedPath, metadata);
        
        return Result<Guid>.Ok(photo.Id);
    }
}