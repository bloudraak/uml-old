namespace Uml;

class Model : Package, IModel
{
    public Model(string name) : base(null, name)
    {
        String = new PrimitiveType("String");
    }

    public Model() : this("")
    {
    }

    public IPrimitiveType String { get; }
}