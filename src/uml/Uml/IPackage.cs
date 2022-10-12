namespace Uml;

public interface IPackage : INamespace
{
    IEnumerable<IPackage> OwnedPackagedElements { get; }
    IEnumerable<IPackage> NestedPackages { get; }
    IEnumerable<IType> OwnedTypes { get; }

    IPackage CreatePackage(string name);
    IClass CreateClass(string name);
    IInterface CreateInterface(string name);
    IEnumeration CreateEnumeration(string name);
    IGeneralization CreateGeneralization(IClassifier specific, IClassifier general);
    IInterfaceRealization CreateInterfaceRealization(IClassifier implementingClassifier, IInterface contract);
}