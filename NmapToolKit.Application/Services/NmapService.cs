using NmapToolKit.Application.Helpers;
using NmapToolKit.Application.Models.Dtos.Nmap;
using NmapToolKit.Application.Processes.Nmap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NmapToolKit.Application.Services
{
  public class NmapService : INmapService
  {
    public async Task<Nmaprun?> RunNmapScanListOnTarget(string target)
    {
      using (BaseNmapProcess myProcess = string.IsNullOrWhiteSpace(target) ? new BaseNmapProcess("nmap") : new BaseNmapProcess("nmap", target))
      {
        string str = await myProcess.Run();
        return XmlHelper.FromXml<Nmaprun>(str);
      }
    }
  }
}
