using LighthouseSocialProject.Domain.Common;

namespace LighthouseSocialProject.Domain.Enumerations;

public sealed class CameraType : EnumerationBase
{
    private CameraType(int id,  string name) : base(id, name) { }
    
    public static readonly CameraType SLR = new (1, "SLR");
    public static readonly CameraType DSLR = new (2, "SLR");
    public static readonly CameraType Mirrorless = new (3, "SLR");
    public static readonly CameraType Phone = new (4, "SLR");
    
    public static IEnumerable<CameraType> List() => new[] { SLR, DSLR, Mirrorless,  Phone };

    public static CameraType FromId(int id)
    {
        return List().FirstOrDefault(x => x.Id == id) 
               ?? throw new ArgumentOutOfRangeException();
    }

    public static CameraType FromName(string name)
    {
        return List().FirstOrDefault(x => x.Name.Equals(name,StringComparison.OrdinalIgnoreCase)) 
               ?? throw new ArgumentException($"Invalid camera type {name}");
    }
}