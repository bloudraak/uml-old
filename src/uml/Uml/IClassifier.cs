namespace Uml;

public interface IClassifier : IType, INamespace
{
    IEnumerable<IGeneralization> Generalizations { get; }
    
    IEnumerable<IClassifier> Generals { get; }
    
    IEnumerable<INamedElement> InheritedMembers { get; }
}