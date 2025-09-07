using LighthouseSocialProject.Domain.Common;
using LighthouseSocialProject.Domain.ValueObjects;

namespace LighthouseSocialProject.Domain.Entities;

public class Lighthouse : EntityBase
{
    public string Name { get; private set; } = string.Empty;
    public int CountyId { get; private set; }
    public Country Country { get; private set; } = null!;
    public Coordinates Location { get; private set; }
    public List<Photo> Photos { get; } = [];
    protected Lighthouse(){}
    public Lighthouse(Guid id, string name, Country country, Coordinates location)
    {
        Id = id != Guid.Empty ? id : Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Country = country  ?? throw new ArgumentNullException(nameof(country));
        CountyId = country.Id;
        Location = location;
    }
}