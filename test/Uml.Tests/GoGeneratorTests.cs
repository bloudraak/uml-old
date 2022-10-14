using Uml.Generators.Go;

namespace Uml.Tests;

public class GoGeneratorTests
{
    private string? OutputPath { get; set; }

    private string? BasePath { get; set; }


    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, nameof(GoGeneratorTests));
        if (Directory.Exists(path)) Directory.Delete(path, true);
        Directory.CreateDirectory(path);
        BasePath = path;
    }

    [SetUp]
    public void RunBeforeEveryTest()
    {
        var testName = TestContext.CurrentContext.Test.Name;
        var testPath = testName.Replace(".", Path.PathSeparator.ToString());
        OutputPath = Path.Combine(BasePath, testPath);
        Directory.CreateDirectory(OutputPath);
    }

    [Test]
    public void Example()
    {
        var model = ModelFactory.Create();
        var package = model.CreatePackage("MyPackage");

        IProfileManager profileManager = model.ProfileManager;
        IProfile profile = profileManager.GetProfile("Go");
        IProfileInstance profileInstance = package.ApplyProfile(profile);
        var class1 = package.CreateClass("Class1");
        var class2 = package.CreateClass("Class2");
        var class3 = package.CreateClass("Class3");
        var interface1 = package.CreateInterface("Interface1");
        var interface2 = package.CreateInterface("Interface2");
        var interface3 = package.CreateInterface("Interface3");
    }


    [Test]
    public void EmptyModel()
    {
        var model = ModelFactory.Create();

        var generator = new GoGenerator(model);
        generator.OutputDirectory = OutputPath;
        generator.Generate();
    }

    [Test]
    public void EmptyPackage()
    {
        var model = ModelFactory.Create();
        var package = model.CreatePackage("MyPackage");

        var generator = new GoGenerator(model);
        generator.OutputDirectory = OutputPath;
        generator.Generate();
    }

    [Test]
    public void WithInterface()
    {
        var model = ModelFactory.Create();
        var package = model.CreatePackage("MyPackage");
        var i = package.CreateInterface("MyInterface");
        i.CreateAttribute("MyAttribute", model.String);
        i.CreateOperation("MyOperation");


        var generator = new GoGenerator(model);
        generator.OutputDirectory = OutputPath;
        generator.Generate();
    }

    [Test]
    public void WithClass()
    {
        var model = ModelFactory.Create();
        var package = model.CreatePackage("MyPackage");
        var i = package.CreateClass("MyClass");
        i.CreateAttribute("MyAttribute", model.String);
        i.CreateOperation("MyOperation");


        var generator = new GoGenerator(model);
        generator.OutputDirectory = OutputPath;
        generator.Generate();
    }
}