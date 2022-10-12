namespace Uml;

internal class Property : NamedElement, IProperty
{
    public Property(Classifier owner, string name, IType type) : base(owner, name)
    {
        Type = type;
    }

    public IType Type { get; set; }
    
    public IClass? Class => base.Owner as IClass;
    
    public IInterface? Interface => base.Owner as IInterface;
}