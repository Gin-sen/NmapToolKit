using NmapToolKit.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NmapToolKit.Application.Processes.IpA
{
  public class BaseIpAProcess : Process
  {
    /// <summary>
    /// Chemin de l'éxécutable Nmap
    /// </summary>
    private readonly string IP_BIN;

    private readonly StreamWriter errorStream = new StreamWriter("error.txt");

    /// <summary>
    /// Output
    /// </summary>
    private string Output = string.Empty;

    /// <summary>
    /// True
    /// </summary>
    private bool ErrorTriggered = false;
    /// <summary>
    /// Fisrt Trigger
    /// </summary>
    private bool FirstTriggered = false;

    /// <summary>
    /// Constructeur et configuration
    /// </summary>
    public BaseIpAProcess(string ipBin = "ip")
    {
      IP_BIN = ipBin;
      StartInfo = new ProcessStartInfo();

      StartInfo.UseShellExecute = false;
      StartInfo.RedirectStandardError = true;
      StartInfo.RedirectStandardOutput = true;
//      StartInfo.RedirectStandardInput = true;
//      StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      StartInfo.CreateNoWindow = true;
      StartInfo.ErrorDialog = false;
      StartInfo.FileName = IP_BIN;
      // Configuration des sorties
      ErrorDataReceived += new((o, e) =>
      {
        if (!String.IsNullOrEmpty(e.Data))
        {
          FirstTriggered = true;
          errorStream.WriteLine(e.Data);
        }
        else
        {
          if (FirstTriggered != false)
          {
            ErrorTriggered = true;
          }
        }
      });
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> Run()
    {
      try
      {

        // Configuration de la ligne de commande
        //StartInfo.Arguments = "-h";
        StartInfo.Arguments = "-a -j a";


        // Execution du la ligne de commande
        this.Start();

        this.BeginErrorReadLine();
        string output = this.StandardOutput.ReadToEnd();
      }
      catch (Exception e)
      {

        throw;
      }
      finally
      {
        this.WaitForExit();

        errorStream.Close();

      }
      if (ErrorTriggered)
        throw new IpAProcessException("test");
      return await Task.FromResult(Output);

    }
  }
}
