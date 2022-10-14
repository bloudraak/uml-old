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

    public void Accept(IVisitor visitor)
    {
        if (!VisitBegin(visitor)) return;
        
        VisitMembers(visitor);
        VisitEnd(visitor);
    }

    private void VisitMembers(IVisitor visitor)
    {
        foreach (var ownedElement in OwnedElements)
        {
            ownedElement.Accept(visitor);
        }
    }

    protected virtual void VisitEnd(IVisitor visitor)
    {
    }

    protected virtual bool VisitBegin(IVisitor visitor)
    {
        return true;
    }
}