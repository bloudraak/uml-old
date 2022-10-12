namespace Uml.Tests;

public class InterfaceSpecTests
{
    public IInterface Interface { get; set; }

    public IModel Model { get; set; }

    [SetUp]
    public void Setup()
    {
        Model = ModelFactory.Create();
        Interface = Model.CreateInterface("TestInterface");
    }

    [Test]
    public void CreateAttribute()
    {
        Assert.That(Interface, Is.Not.Null);
        var attribute = Interface.CreateAttribute("TestAttribute", Model.String);
        Assert.That(attribute, Is.Not.Null);

        Assert.That(attribute.Name, Is.EqualTo("TestAttribute"));
        Assert.That(Interface.OwnedElements.ToList(), Does.Contain(attribute));
        Assert.That(Interface.OwnedMembers.ToList(), Does.Contain(attribute));
        Assert.That(Interface.OwnedAttributes.ToList(), Does.Contain(attribute));
        Assert.That(attribute.Owner, Is.EqualTo(Interface));
        Assert.That(attribute.Interface, Is.EqualTo(Interface));
    }

    [Test]
    public void CreateOperation()
    {
        Assert.That(Interface, Is.Not.Null);
        var operation = Interface.CreateOperation("TestOperation");
        Assert.That(operation, Is.Not.Null);

        Assert.That(operation.Name, Is.EqualTo("TestOperation"));
        Assert.That(Interface.OwnedElements.ToList(), Does.Contain(operation));
        Assert.That(Interface.OwnedMembers.ToList(), Does.Contain(operation));
        Assert.That(Interface.OwnedOperations.ToList(), Does.Contain(operation));
        Assert.That(operation.Owner, Is.EqualTo(Interface));
        Assert.That(operation.Interface, Is.EqualTo(Interface));
    }
    
}