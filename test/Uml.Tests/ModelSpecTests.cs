namespace Uml.Tests;

public class ModelSpecTests
{
    public IModel Model { get; set; }

    [SetUp]
    public void Setup()
    {
        Model = ModelFactory.Create();
    }

    [Test]
    public void CreatePackage()
    {
        Assert.That(Model, Is.Not.Null);
        var package = Model.CreatePackage("TestPackage");
        Assert.That(package, Is.Not.Null);
        Assert.That(package.Name, Is.EqualTo("TestPackage"));
        Assert.That(Model.OwnedElements.ToList(), Does.Contain(package));
        Assert.That(Model.OwnedMembers.ToList(), Does.Contain(package));
        Assert.That(Model.OwnedPackagedElements.ToList(), Does.Contain(package));
        Assert.That(Model.NestedPackages.ToList(), Does.Contain(package));
        Assert.That(package.Owner, Is.EqualTo(Model));
    }
}