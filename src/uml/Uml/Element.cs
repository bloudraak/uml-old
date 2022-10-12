namespace Uml;

internal abstract class Element : IElement
{
    private readonly List<IElement> _ownedElements = new();

    protected Element(Element? owner)
    {
        Owner = owner;
        owner?._ownedElements.Add(this);
    }

    public IElement? Owner { get; }

    public IEnumerable<IElement> OwnedElements => _ownedElements;
}