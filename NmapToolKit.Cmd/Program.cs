using NmapToolKit.Application.Helpers;
using NmapToolKit.Application.Models.Dtos.IpA;
using NmapToolKit.Application.Models.Dtos.Nmap;
using NmapToolKit.Application.Processes.IpA;
using NmapToolKit.Application.Processes.Nmap;
using System.Diagnostics;
using System.Text.Json;
using System.Xml.Serialization;

namespace NmapToolKit.Cmd
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      try
      {
        //using (BaseIpAProcess myProcess = new BaseIpAProcess("ip"))
        //{
        //  string str = await myProcess.Run();

        //  BaseIpAInfos[]? result = JsonSerializer.Deserialize<BaseIpAInfos[]>(str);

        //  Console.WriteLine($"Taille {result?.Length}");
        //}
        using (BaseNmapProcess myProcess = new BaseNmapProcess("nmap", "basic-nginx"))
        {
          string str = await myProcess.Run();
          var test = XmlHelper.FromXml<Nmaprun>(str);
          Console.WriteLine(str);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}