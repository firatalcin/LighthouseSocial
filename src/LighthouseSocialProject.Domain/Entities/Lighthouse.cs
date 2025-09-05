using LighthouseSocialProject.Domain.Common;
using LighthouseSocialProject.Domain.ValueObjects;

namespace LighthouseSocialProject.Domain.Entities;

public class Lighthouse : EntityBase
{
    public string Name { get; private set; }
    public string Country { get; private set; }
    public Coordinates Location { get; private set; }
    public List<Photo> Photos { get; } = [];
    
    protected Lighthouse(){}
    
    public Lighthouse(string name, string country, Coordinates location)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Country = country  ?? throw new ArgumentNullException(nameof(country));
        Location = location;
    }
}