namespace Uml;

class Namespace : NamedElement, INamespace
{
    public Namespace(Element? owner, string name) : base(owner, name)
    {
    }

    public IEnumerable<INamedElement> OwnedMembers => base.OwnedElements.OfType<INamedElement>();


}