namespace Uml;

internal class InterfaceRealization : NamedElement, IInterfaceRealization
{
    public IClassifier ImplementingClassifier { get; }
    
    public IInterface Contract { get; }

    public InterfaceRealization(Element owner, IClassifier implementingClassifier, IInterface contract) : base(owner, $"{implementingClassifier.Name} implements {contract.Name}")
    {
        ImplementingClassifier = implementingClassifier;
        Contract = contract;
    }
    
}