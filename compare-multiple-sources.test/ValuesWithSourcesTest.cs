using NUnit.Framework;

namespace CompareMultipleSources.Test
{
  [TestFixture]
  public class ValuesWithSourcesTest
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
    public void ItDefaultsToNull()
    {
      Assert.That(_exampleValues.SourceValue(ExampleSources.FooBar), Is.EqualTo(null));
    }

    [Test]
    public void ItReturnsDefinedDefaultValue()
    {
      Assert.That(_exampleValues.SourceValue(ExampleSources.FooBar, "N/A"), Is.EqualTo("N/A"));
    }

    internal enum ExampleSources
    {
      Music,
      Movie,
      FooBar
    }

    internal class ExampleValues : ValuesWithSources<ExampleSources>
    {}
  }
}
