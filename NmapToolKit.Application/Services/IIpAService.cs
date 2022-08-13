using NmapToolKit.Application.Models.Dtos.IpA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NmapToolKit.Application.Services
{
  public interface IIpAService
  {
    Task<BaseIpAInfos[]?> GetSelfIpConf();
  }
}
