namespace Uml;

public interface IPackage : INamespace
{
    IEnumerable<IPackage> OwnedPackagedElements { get; }
    IEnumerable<IPackage> NestedPackages { get; }
    IEnumerable<IType> OwnedTypes { get; }
    
    IEnumerable<IProfileInstance> AllProfileInstances { get; }
    IEnumerable<IStereotype> ApplicableStereotypes { get;  }

    IPackage CreatePackage(string name);
    IClass CreateClass(string name);
    IInterface CreateInterface(string name);
    IEnumeration CreateEnumeration(string name);
    IGeneralization CreateGeneralization(IClassifier specific, IClassifier general);
    IInterfaceRealization CreateInterfaceRealization(IClassifier implementingClassifier, IInterface contract);
    
    IProfileInstance ApplyProfile(IProfile profile);
}