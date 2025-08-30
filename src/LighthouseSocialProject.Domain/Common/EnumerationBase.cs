namespace LighthouseSocialProject.Domain.Common;

public abstract class EnumerationBase(int id, string name)
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name; 
}