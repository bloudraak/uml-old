namespace Uml;

public static class ModelFactory
{
    public static IModel Create()
    {
        return new Model();
    }
}