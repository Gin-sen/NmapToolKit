using NmapToolKit.Application.Models.Dtos.Nmap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NmapToolKit.Application.Services
{
  public interface INmapService
  {

    Task<Nmaprun?> RunNmapScanListOnTarget(string target);
  }
}
