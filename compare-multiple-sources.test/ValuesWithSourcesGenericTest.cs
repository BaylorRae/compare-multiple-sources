using NUnit.Framework;

namespace CompareMultipleSources.Test
{
  [TestFixture]
  public class ValuesWithSourcesGenericTest
  {
    private ExampleValues _exampleValues;

    [SetUp]
    public void SetUp()
    {
      _exampleValues = new ExampleValues();
    }

    [Test]
    public void ItStoresValueForSource()
    {
      _exampleValues.AddSource(ExampleSources.Music, "music");
      Assert.That(_exampleValues.SourceValue(ExampleSources.Music), Is.EqualTo("music"));
    }

    [Test]
    public void ItStoresValueForMultipleSources()
    {
      _exampleValues.AddSource(ExampleSources.Music, "music");
      _exampleValues.AddSource(ExampleSources.Movie, "movie");
      Assert.That(_exampleValues.SourceValue(ExampleSources.Movie), Is.EqualTo("movie"));
    }

    [Test]
    public void ItAllowsSquareBracketSetter()
    {
      _exampleValues[ExampleSources.Movie] = "movie";
      Assert.That(_exampleValues.SourceValue(ExampleSources.Movie), Is.EqualTo("movie"));
    }

    [Test]
    public void ItAllowsSquareBracketGetter()
    {
      _exampleValues.AddSource(ExampleSources.Music, "music");
      Assert.That(_exampleValues[ExampleSources.Music], Is.EqualTo("music"));
    }

    [Test]
    public void ItDefaultsToNull()
    {
      Assert.That(_exampleValues.SourceValue(ExampleSources.FooBar), Is.EqualTo(null));
    }

    [Test]
    public void ItReturnsDefinedDefaultValue()
    {
      Assert.That(_exampleValues.SourceValue(ExampleSources.FooBar, "N/A"), Is.EqualTo("N/A"));
    }

    [Test]
    public void ItAllowsATypeToBeAssigned()
    {
      var stringValues = new ExampleValues<string>();
      stringValues[ExampleSources.Movie] = "movie-name";
      Assert.That(stringValues[ExampleSources.Movie], Is.TypeOf(typeof(string)));
    }

    [Test]
    public void ItAllowsCustomClass()
    {
      var classValues = new ExampleValues<Walrus>();
      classValues[ExampleSources.FooBar] = new Walrus();
      Assert.That(classValues[ExampleSources.FooBar], Is.TypeOf(typeof(Walrus)));
    }

    internal enum ExampleSources
    {
      Music,
      Movie,
      FooBar
    }

    internal class ExampleValues : ValuesWithSources<ExampleSources>
    {}

    internal class ExampleValues<T> : ValuesWithSources<T, ExampleSources>
    { }

    internal class Walrus
    {}
  }
}
