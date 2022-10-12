namespace Uml;

abstract class Classifier : Type, IClassifier
{
    protected Classifier(Package owner, string name) : base(owner, name)
    {
    }

    public IEnumerable<INamedElement> OwnedMembers => base.OwnedElements.OfType<INamedElement>();


    public IEnumerable<IGeneralization> Generalizations
    {
        get
        {
            if (Package is null)
            {
                return new List<IGeneralization>();
            }
                
            return Package.OwnedElements.OfType<IGeneralization>().Where(g => g.Specific == this);
        }
    }
    
    public IEnumerable<IClassifier> Generals => this.Generalizations.Select(g => g.General);
    
    public IEnumerable<INamedElement> InheritedMembers => this.Generals.SelectMany(g => g.OwnedMembers);
}