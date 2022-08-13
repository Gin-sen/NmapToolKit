using System;
using System.Xml.Serialization;

namespace NmapToolKit.Application.Helpers
{
  public static class XmlHelper
  {
    public static T FromXml<T>(this string value)
    {
      using TextReader reader = new StringReader(value);
      return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
    }
  }
}
