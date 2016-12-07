using System.Collections.Generic;

namespace CompareMultipleSources
{
  public abstract class ValuesWithSources<T>
  {
    protected Dictionary<T, object> Values = new Dictionary<T, object>();

    public object this[T source]
    {
      get { return SourceValue(source); }
      set { AddSource(source, value); }
    }

    public void AddSource(T source, object value)
    {
      Values[source] = value;
    }

    public object SourceValue(T source, object defaultValue = null)
    {
      try
      {
        return Values[source];
      }
      catch (KeyNotFoundException)
      {
        return defaultValue;
      }
    }
  }
}
