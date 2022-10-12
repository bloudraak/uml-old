namespace Uml;

public interface IGeneralization : IElement
{
    IClassifier General { get; }
    IClassifier Specific { get; }
}