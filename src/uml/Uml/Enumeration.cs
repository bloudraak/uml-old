namespace Uml;

internal class Enumeration : Classifier, IEnumeration
{
    public Enumeration(Package owner, string name) : base(owner, name)
    {
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