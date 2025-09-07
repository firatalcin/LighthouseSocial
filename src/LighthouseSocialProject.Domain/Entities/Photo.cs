using LighthouseSocialProject.Domain.Common;
using LighthouseSocialProject.Domain.ValueObjects;

namespace LighthouseSocialProject.Domain.Entities;

public class Photo : EntityBase
{
    public Guid UserId { get; private set; }
    public Guid LighthouseId { get; private set; }
    public string Filename { get; private set; } = null!;
    public DateTime UploadDate { get; private set; }
    public PhotoMetaData PhotoMetaData { get; private set; } = null!;
    public List<Comment> Comments { get; } = [];
    protected Photo(){}
    public Photo(Guid id, Guid userId, Guid lighthouseId, string filename, PhotoMetaData photoMetaData)
    {
        Id = id != Guid.Empty ? id : Guid.NewGuid();
        UserId = userId;
        LighthouseId = lighthouseId;
        Filename = filename ?? throw new ArgumentNullException(nameof(filename));
        PhotoMetaData = photoMetaData ?? throw new ArgumentNullException(nameof(photoMetaData));
        UploadDate = DateTime.UtcNow;
    }
}