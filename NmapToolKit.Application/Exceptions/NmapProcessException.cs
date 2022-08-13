using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NmapToolKit.Application.Exceptions
{
  public class NmapProcessException : Exception
  {
    public NmapProcessException()
    {
    }

    public NmapProcessException(string? message) : base(message)
    {
    }

    public NmapProcessException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NmapProcessException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}
