using System.Collections.Immutable;

namespace Uml;

class Class : Classifier, IClass
{
    public Class(Package owner, string name) : base(owner, name)
    {
    }
    
    public IProperty CreateAttribute(string name, IType type)
    {
        return new Property(this, name, type);
    }

    public IEnumerable<IProperty> OwnedAttributes => OwnedElements.OfType<IProperty>();
    
    public IEnumerable<IOperation> OwnedOperations => OwnedElements.OfType<IOperation>();

    public IEnumerable<IInterface> RealizedInterfaces
    {
        get
        {
            if (Package is null) yield break;
            foreach (var item in Package.OwnedElements.OfType<IInterfaceRealization>())
            {
                if (item.ImplementingClassifier != this) continue;
                yield return item.Contract;
            }
        }
    }

    public IOperation CreateOperation(string name)
    {
        return new Operation(this, name);
    }
    
    protected override bool VisitBegin(IVisitor visitor)
    {
        return visitor.VisitBegin(this);
    }
    
    protected override void VisitEnd(IVisitor visitor)
    {
        visitor.VisitEnd(this);
    }
}