using System.Collections.Generic;

namespace CompareMultipleSources
{
  public class ValuesWithSources<TType, TSources>
  {
    protected Dictionary<TSources, TType> Values = new Dictionary<TSources, TType>();

    public TType this[TSources source]
    {
      get { return SourceValue(source); }
      set { AddSource(source, value); }
    }

    public void AddSource(TSources source, TType value)
    {
      Values[source] = value;
    }

    public TType SourceValue(TSources source)
    {
      try
      {
        return Values[source];
      }
      catch (KeyNotFoundException)
      {
        return default(TType);
      }
    }

    public TType SourceValue(TSources source, TType defaultValue)
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
