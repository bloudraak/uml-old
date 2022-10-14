namespace Uml;

internal class Stereotype : IStereotype
{
    public Stereotype(Profile profile, string name, string displayName)
    {
        Name = name;
        DisplayName = displayName;
        Profile = profile;
    }

    public string Name { get; }
    public string DisplayName { get; }
    public IProfile Profile { get; }
}