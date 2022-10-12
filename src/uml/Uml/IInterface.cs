namespace Uml;

public interface IInterface : IClassifier
{
    IProperty CreateAttribute(string name, IType type);
    IEnumerable<IProperty> OwnedAttributes { get; }
    IEnumerable<IOperation> OwnedOperations { get; }
    IEnumerable<IClassifier> RealizingClassifiers { get; }
    IOperation CreateOperation(string name);
    
}