using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NmapToolKit.Application.Exceptions
{
  public class IpAProcessException : Exception
  {
    public IpAProcessException()
    {
    }

    public IpAProcessException(string? message) : base(message)
    {
    }

    public IpAProcessException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected IpAProcessException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}
