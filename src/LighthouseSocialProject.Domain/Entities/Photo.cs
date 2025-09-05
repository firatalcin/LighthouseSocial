using LighthouseSocialProject.Domain.Common;
using LighthouseSocialProject.Domain.ValueObjects;

namespace LighthouseSocialProject.Domain.Entities;

public class Photo : EntityBase
{
    public Guid UserId { get; private set; }
    public Guid LighthouseId { get; private set; }
    public string Filename { get; private set; }
    public DateTime UploadDate { get; private set; }
    public PhotoMetaData PhotoMetaData { get; private set; }
    public List<Comment> Comments { get; } = [];
    
    protected Photo(){}

    public Photo(Guid userId, Guid lighthouseId, string filename, PhotoMetaData photoMetaData)
    {
        UserId = userId;
        LighthouseId = lighthouseId;
        Filename = filename;
        PhotoMetaData = photoMetaData;
        UploadDate = DateTime.UtcNow;
    }
}