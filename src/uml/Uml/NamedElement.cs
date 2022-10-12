namespace Uml;

internal abstract class NamedElement : Element, INamedElement
{
    protected NamedElement(Element? owner, string name) : base(owner)
    {
        Name = name;
    }

    public string Name { get; set; }
}