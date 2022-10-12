namespace Uml;

public interface IClass : IClassifier
{
    IProperty CreateAttribute(string name, IType type);
    
    IEnumerable<IProperty> OwnedAttributes { get; }
    
    IEnumerable<IOperation> OwnedOperations { get; }
    
    IEnumerable<IInterface> RealizedInterfaces { get; }


    IOperation CreateOperation(string name);
}