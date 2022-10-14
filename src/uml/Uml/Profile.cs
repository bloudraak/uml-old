using System.Collections.Immutable;

namespace Uml;

internal class Profile : IProfile
{
    private List<Stereotype> _stereotypes = new List<Stereotype>();

    public Profile(string name, string displayName)
    {
        Name = name;
        DisplayName = displayName;
    }

    public string Name { get; }
    
    public string DisplayName { get; }
    
    public IEnumerable<IStereotype> Stereotypes => _stereotypes.ToImmutableArray();
    
    public IStereotype? GetStereotypeByName(string name)
    {
        return _stereotypes.FirstOrDefault(s => s.Name == name);
    }

    public IStereotype CreateStereotype(string name)
    {
        var stereotype = new Stereotype(this, name, name);
        _stereotypes.Add(stereotype);
        return stereotype;
    }
}