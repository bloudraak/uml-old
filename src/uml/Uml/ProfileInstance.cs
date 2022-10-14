namespace Uml;

internal class ProfileInstance : Element, IProfileInstance
{
    private readonly IPackage _package;
    private readonly IProfile _profile;

    public ProfileInstance(Package package, IProfile profile) : base(package)
    {
        _package = package;
        _profile = profile;
    }

    public IProfile Profile => _profile;
    public IPackage Package => _package;
}