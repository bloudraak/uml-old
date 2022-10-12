namespace Uml;

public interface IProperty : INamedElement
{
    IType Type { get; set; }
    
    IClass? Class { get; }
    
    IInterface? Interface { get; }
}