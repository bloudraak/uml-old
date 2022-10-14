namespace Uml.Tests;

public class PackageSpecTests
{
    public IPackage Package { get; set; }

    public IModel Model { get; set; }

    [SetUp]
    public void Setup()
    {
        Model = ModelFactory.Create();
        Package = Model.CreatePackage("TestPackage");
    }

    [Test]
    public void CreatePackage()
    {
        Assert.That(Package, Is.Not.Null);
        var package = Package.CreatePackage("TestPackage");
        Assert.That(package, Is.Not.Null);

        Assert.That(package.Name, Is.EqualTo("TestPackage"));
        Assert.That(Package.OwnedElements.ToList(), Does.Contain(package));
        Assert.That(Package.OwnedMembers.ToList(), Does.Contain(package));
        Assert.That(Package.OwnedPackagedElements.ToList(), Does.Contain(package));
        Assert.That(Package.NestedPackages.ToList(), Does.Contain(package));
        Assert.That(package.Owner, Is.EqualTo(Package));
    }

    [Test]
    public void CreateClass()
    {
        Assert.That(Package, Is.Not.Null);
        var @class = Package.CreateClass("TestClass");
        Assert.That(@class, Is.Not.Null);

        Assert.That(@class.Name, Is.EqualTo("TestClass"));
        Assert.That(Package.OwnedElements.ToList(), Does.Contain(@class));
        Assert.That(Package.OwnedMembers.ToList(), Does.Contain(@class));
        Assert.That(Package.OwnedTypes.ToList(), Does.Contain(@class));
        Assert.That(Package.OwnedMembers.ToList(), Does.Contain(@class));
        Assert.That(@class.Owner, Is.EqualTo(Package));
        Assert.That(@class.Package, Is.EqualTo(Package));
    }

    [Test]
    public void CreateInterface()
    {
        Assert.That(Package, Is.Not.Null);
        var @interface = Package.CreateInterface("TestInterface");
        Assert.That(@interface, Is.Not.Null);

        Assert.That(@interface.Name, Is.EqualTo("TestInterface"));
        Assert.That(Package.OwnedElements.ToList(), Does.Contain(@interface));
        Assert.That(Package.OwnedMembers.ToList(), Does.Contain(@interface));
        Assert.That(Package.OwnedTypes.ToList(), Does.Contain(@interface));
        Assert.That(Package.OwnedMembers.ToList(), Does.Contain(@interface));
        Assert.That(@interface.Owner, Is.EqualTo(Package));
        Assert.That(@interface.Package, Is.EqualTo(Package));
    }
    
    [Test]
    public void CreateEnumeration()
    {
        Assert.That(Package, Is.Not.Null);
        var enumeration = Package.CreateEnumeration("TestEnumeration");
        Assert.That(enumeration, Is.Not.Null);

        Assert.That(enumeration.Name, Is.EqualTo("TestEnumeration"));
        Assert.That(Package.OwnedElements.ToList(), Does.Contain(enumeration));
        Assert.That(Package.OwnedMembers.ToList(), Does.Contain(enumeration));
        Assert.That(Package.OwnedTypes.ToList(), Does.Contain(enumeration));
        Assert.That(Package.OwnedMembers.ToList(), Does.Contain(enumeration));
        Assert.That(enumeration.Owner, Is.EqualTo(Package));
        Assert.That(enumeration.Package, Is.EqualTo(Package));
    }
    
    [Test]
    public void CreateGeneralization()
    {
        Assert.That(Package, Is.Not.Null);
        var @class = Package.CreateClass("TestClass");
        var @interface = Package.CreateInterface("TestInterface");
        var generalization = Package.CreateGeneralization(@class, @interface);
        Assert.That(generalization, Is.Not.Null);

        Assert.That(generalization.General, Is.EqualTo(@interface));
        Assert.That(generalization.Specific, Is.EqualTo(@class));
        Assert.That(Package.OwnedElements.ToList(), Does.Contain(generalization));
        Assert.That(generalization.Owner, Is.EqualTo(Package));
        
        Assert.That(@class.Generalizations.ToList(), Does.Contain(generalization));
    }
    
    [Test]
    public void CreateInterfaceRealization()
    {
        Assert.That(Package, Is.Not.Null);
        var @class = Package.CreateClass("TestClass");
        var @interface = Package.CreateInterface("TestInterface");
        var interfaceRealization = Package.CreateInterfaceRealization(@class, @interface);
        Assert.That(interfaceRealization, Is.Not.Null);

        Assert.That(interfaceRealization.Contract, Is.EqualTo(@interface));
        Assert.That(interfaceRealization.ImplementingClassifier, Is.EqualTo(@class));
        Assert.That(Package.OwnedElements.ToList(), Does.Contain(interfaceRealization));
        Assert.That(interfaceRealization.Owner, Is.EqualTo(Package));
        
        Assert.That(@class.RealizedInterfaces.ToList(), Does.Contain(@interface));
        Assert.That(@interface.RealizingClassifiers.ToList(), Does.Contain(@class));
    }

    [Test]
    public void ApplyProfile()
    {
        Assert.That(Package, Is.Not.Null);
        var profile = Model.ProfileManager.CreateProfile("TestProfile");
        var stereotype = profile.CreateStereotype("TestStereotype");
        
        var profileInstance = Package.ApplyProfile(profile);
        Assert.That(profileInstance, Is.Not.Null);
        Assert.That(Package.AllProfileInstances.ToList(), Does.Contain(profileInstance));
        Assert.That(Package.ApplicableStereotypes.ToList(), Does.Not.Contain(stereotype));
        
    }
}