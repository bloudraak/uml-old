namespace Uml;

internal class Operation : NamedElement, IOperation
{
    public Operation(Classifier owner, string name) : base(owner, name)
    {
    }

    public IClass? Class => Owner as IClass;
    
    public IInterface? Interface => Owner as IInterface;
    
    protected override bool VisitBegin(IVisitor visitor)
    {
        return visitor.VisitBegin(this);
    }
    
    protected override void VisitEnd(IVisitor visitor)
    {
        visitor.VisitEnd(this);
    }
}