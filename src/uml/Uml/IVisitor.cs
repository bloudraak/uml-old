namespace Uml;

public interface IVisitor
{
    bool VisitBegin(IEnumeration item);
    void VisitEnd(IEnumeration item);
    bool VisitBegin(IPackage item);
    void VisitEnd(IPackage item);
    
    bool VisitBegin(IModel item);
    void VisitEnd(IModel item);
    
    bool VisitBegin(IClass item);
    void VisitEnd(IClass item);
    
    bool VisitBegin(IInterface item);
    void VisitEnd(IInterface item);
    bool VisitBegin(IOperation item);
    void VisitEnd(IOperation item);
    void Visit(IProperty item);
}