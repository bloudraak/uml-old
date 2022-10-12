namespace Uml;

public interface IInterfaceRealization : IElement
{
    IClassifier ImplementingClassifier { get; }
    IInterface Contract { get; }
}