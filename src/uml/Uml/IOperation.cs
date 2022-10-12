namespace Uml;

public interface IOperation : INamedElement
{
    IClass? Class { get; }
    
    IInterface? Interface { get; }
}