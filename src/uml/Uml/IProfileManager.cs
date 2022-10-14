namespace Uml;

public interface IProfileManager
{
    IEnumerable<IProfile> Profiles { get; }
    
    IProfile? GetProfile(string name);
    
    IProfile CreateProfile(string name, string? displayName = null);
}