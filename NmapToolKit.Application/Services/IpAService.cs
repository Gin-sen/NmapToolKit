using NmapToolKit.Application.Models.Dtos.IpA;
using NmapToolKit.Application.Processes.IpA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NmapToolKit.Application.Services
{
  public class IpAService : IIpAService
  {
    public async Task<BaseIpAInfos[]?> GetSelfIpConf()
    {
      using (BaseIpAProcess myProcess = new BaseIpAProcess("ip"))
      {
        string str = await myProcess.Run();
        return JsonSerializer.Deserialize<BaseIpAInfos[]>(str);
      }
    }
  }
}
