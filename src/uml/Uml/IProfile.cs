namespace Uml;

public interface IProfile
{
    string Name { get; }
    
    string DisplayName { get; }
    
    
    IEnumerable<IStereotype> Stereotypes { get; }
    
    
    IStereotype? GetStereotypeByName(string name);
    
    IStereotype CreateStereotype(string name);
}