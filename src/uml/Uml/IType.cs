namespace Uml;

public interface IType : INamedElement
{
    IPackage? Package { get; }
}