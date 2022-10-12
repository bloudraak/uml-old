namespace Uml;

internal abstract class Type : NamedElement, IType
{
    protected Type(Package? owner, string name) : base(owner, name)
    {
        Package = owner;
    }

    public IPackage? Package { get; }
}