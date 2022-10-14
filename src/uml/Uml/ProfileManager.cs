using System.Collections.Immutable;

namespace Uml;

internal class ProfileManager : IProfileManager
{
    private readonly List<Profile> _profiles;
    private readonly Model _model;

    public ProfileManager(Model model)
    {
        _model = model;
        _profiles = new List<Profile>();
    }

    public IEnumerable<IProfile> Profiles => _profiles.ToImmutableArray();

    public IProfile? GetProfile(string name)
    {
        return _profiles.FirstOrDefault(p => p.Name == name);
    }

    public IProfile CreateProfile(string name, string? displayName)
    {
        var profile = new Profile(name, displayName ?? name);
        _profiles.Add(profile);
        return profile;
    }
}