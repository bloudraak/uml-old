namespace Uml;

public interface IModel : IPackage
{
    IPrimitiveType String { get; }
    IProfileManager ProfileManager { get; }
}