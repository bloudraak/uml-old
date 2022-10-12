namespace Uml;

internal class Enumeration : Type, IEnumeration
{
    public Enumeration(Package? owner, string name) : base(owner, name)
    {
    }
}