namespace Uml.Tests;

public class ClassSpecTests
{
    public IClass Class { get; set; }

    public IModel Model { get; set; }

    [SetUp]
    public void Setup()
    {
        Model = ModelFactory.Create();
        Class = Model.CreateClass("TestClass");
    }

    [Test]
    public void CreateAttribute()
    {
        Assert.That(Class, Is.Not.Null);
        var attribute = Class.CreateAttribute("TestAttribute", Model.String);
        Assert.That(attribute, Is.Not.Null);

        Assert.That(attribute.Name, Is.EqualTo("TestAttribute"));
        Assert.That(Class.OwnedElements.ToList(), Does.Contain(attribute));
        Assert.That(Class.OwnedMembers.ToList(), Does.Contain(attribute));
        Assert.That(Class.OwnedAttributes.ToList(), Does.Contain(attribute));
        Assert.That(attribute.Owner, Is.EqualTo(Class));
        Assert.That(attribute.Class, Is.EqualTo(Class));
    }

    [Test]
    public void CreateOperation()
    {
        Assert.That(Class, Is.Not.Null);
        var operation = Class.CreateOperation("TestOperation");
        Assert.That(operation, Is.Not.Null);

        Assert.That(operation.Name, Is.EqualTo("TestOperation"));
        Assert.That(Class.OwnedElements.ToList(), Does.Contain(operation));
        Assert.That(Class.OwnedMembers.ToList(), Does.Contain(operation));
        Assert.That(Class.OwnedOperations.ToList(), Does.Contain(operation));
        Assert.That(operation.Owner, Is.EqualTo(Class));
        Assert.That(operation.Class, Is.EqualTo(Class));
    }
}