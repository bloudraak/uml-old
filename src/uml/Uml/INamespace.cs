namespace Uml;

public interface INamespace : INamedElement
{
    IEnumerable<INamedElement> OwnedMembers { get; }
}