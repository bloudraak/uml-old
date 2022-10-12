namespace Uml;

internal class Generalization : Element, IGeneralization
{
    public IClassifier Specific { get; }
    public IClassifier General { get; }

    public Generalization(Package owner, IClassifier specific, IClassifier general) : base(owner)
    {
        Specific = specific;
        General = general;
    }
}