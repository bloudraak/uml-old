namespace Uml;

public interface IElement
{
    IElement? Owner { get; }

    IEnumerable<IElement> OwnedElements { get; }
    
    void Accept(IVisitor visitor);
}