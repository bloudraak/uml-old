namespace Uml;

public abstract class Visitor : IVisitor
{

    public event EventHandler<IClass> VisitClassBegin;
    public event EventHandler<IClass> VisitClassEnd;
    public event EventHandler<IInterface> VisitInterfaceBegin;
    public event EventHandler<IInterface> VisitInterfaceEnd;
    
    public virtual bool VisitBegin(IEnumeration item)
    {
        return true;
    }

    public virtual void VisitEnd(IEnumeration item)
    {

    }

    public virtual bool VisitBegin(IPackage item)
    {
        return true;
    }

    public virtual void VisitEnd(IPackage item)
    {
       
    }

    public virtual bool VisitBegin(IModel item)
    {
        return true;
    }

    public virtual void VisitEnd(IModel item)
    {

    }

    public virtual bool VisitBegin(IClass item)
    {
        VisitClassBegin?.Invoke(this, item);
        return true;
    }

    public virtual void VisitEnd(IClass item)
    {
        VisitClassEnd?.Invoke(this, item);
    }

    public virtual bool VisitBegin(IInterface item)
    {
        VisitInterfaceBegin?.Invoke(this, item);
        return true;
    }

    public virtual void VisitEnd(IInterface item)
    {
        VisitInterfaceEnd?.Invoke(this, item);
    }

    public virtual bool VisitBegin(IOperation item)
    {
        return true;
    }

    public virtual void VisitEnd(IOperation item)
    {
        
    }

    public virtual void Visit(IProperty item)
    {
    }
}