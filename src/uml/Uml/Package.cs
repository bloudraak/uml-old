using System.Collections.Immutable;

namespace Uml;

class Package : Namespace, IPackage
{
    public IEnumerable<IPackage> OwnedPackagedElements => OwnedElements.OfType<IPackage>().ToImmutableArray();
    public IEnumerable<IPackage> NestedPackages => OwnedElements.OfType<IPackage>().ToImmutableArray();
    public IEnumerable<IType> OwnedTypes => OwnedElements.OfType<IType>().ToImmutableArray();
    
    public IEnumerable<IProfileInstance> AllProfileInstances => OwnedElements.OfType<IProfileInstance>().ToImmutableArray();
    public IEnumerable<IStereotype> ApplicableStereotypes { get; set; }

    public IPackage CreatePackage(string name)
    {
        return new Package(this, name);
        
    }

    public IClass CreateClass(string name)
    {
        return new Class(this, name);
    }

    public IInterface CreateInterface(string name)
    {
        return new Interface(this, name);
    }

    public IEnumeration CreateEnumeration(string name)
    {
        return new Enumeration(this, name);
    }

    public IGeneralization CreateGeneralization(IClassifier specific, IClassifier general)
    {
        return new Generalization(this, specific, general);
    }

    public IInterfaceRealization CreateInterfaceRealization(IClassifier implementingClassifier, IInterface contract)
    {
        return new InterfaceRealization(this, implementingClassifier, contract);
    }

    public IProfileInstance ApplyProfile(IProfile profile)
    {
        return new ProfileInstance(this, profile);
    }

    protected Package(Element? owner, string name) : base(owner, name)
    {
        ApplicableStereotypes = ImmutableArray<Stereotype>.Empty;
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