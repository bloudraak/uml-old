namespace Uml;

internal class Operation : NamedElement, IOperation
{
    public Operation(Classifier owner, string name) : base(owner, name)
    {
    }

    public IClass? Class => Owner as IClass;
    public IInterface? Interface => Owner as IInterface;
}