namespace Uml.Generators.Go;

public class GoGenerator : Visitor
{
    public GoGenerator(IModel model)
    {
        Model = model;
        base.VisitClassBegin += OnVisitClassBegin;  
        base.VisitInterfaceBegin += OnVisitInterface;
    }

    private void OnVisitInterface(object? sender, IInterface e)
    {
        var template = new InterfaceTextTemplate(e);
        var text = template.TransformText();
        var path = Path.Combine(OutputDirectory, $"{e.Name}.go");
        File.WriteAllText(path, text);
    }

    private void OnVisitClassBegin(object? sender, IClass e)
    {
        var template = new ClassTextTemplate(e);
        var text = template.TransformText();
        var path = Path.Combine(OutputDirectory, $"{e.Name}.go");
        File.WriteAllText(path, text);
    }

    public string OutputDirectory { get; set; }

    public IModel Model
    {
        get;
    }
    
    
    public void Generate()
    {
        Model.Accept(this);
    }
}