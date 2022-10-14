namespace Uml;

class Model : Package, IModel
{
    public Model(string name) : base(null, name)
    {
        String = new PrimitiveType("String");
        ProfileManager = new ProfileManager(this);
    }

    public Model() : this("")
    {
    }

    public IPrimitiveType String { get; }
    
    public IProfileManager ProfileManager { get; }

    protected override bool VisitBegin(IVisitor visitor)
    {
        return visitor.VisitBegin(this);
    }
    
    protected override void VisitEnd(IVisitor visitor)
    {
        visitor.VisitEnd(this);
    }
}