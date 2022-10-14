namespace Uml;

public interface IProfileInstance : IElement
{
    IProfile Profile { get; }
    IPackage Package { get; }
}