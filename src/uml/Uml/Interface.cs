namespace Uml;

internal class Interface : Classifier, IInterface
{
    public Interface(Package owner, string name) : base(owner, name)
    {
    }

    public IProperty CreateAttribute(string name, IType type)
    {
        return new Property(this, name, type);
        
    }

    public IEnumerable<IProperty> OwnedAttributes => OwnedElements.OfType<IProperty>();
    
    public IEnumerable<IOperation> OwnedOperations=> OwnedElements.OfType<IOperation>();

    public IEnumerable<IClassifier> RealizingClassifiers
    {
        get
        {
            if (Package is null) yield break;
            foreach (var item in Package.OwnedElements.OfType<IInterfaceRealization>())
            {
                if (item.Contract != this) continue;
                yield return item.ImplementingClassifier;
            }
        }
    }

    public IOperation CreateOperation(string name)
    {
        return new Operation(this, name);
    }
}