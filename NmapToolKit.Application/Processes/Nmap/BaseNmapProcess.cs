using NmapToolKit.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NmapToolKit.Application.Processes.Nmap
{
  public class BaseNmapProcess : Process
  {
    /// <summary>
    /// Chemin de l'éxécutable Nmap
    /// </summary>
    private readonly string NMAP_BIN;

    /// <summary>
    /// Chemin de l'éxécutable Nmap
    /// </summary>
    private readonly string TARGET;

    /// <summary>
    /// Output
    /// </summary>
    private string Output = string.Empty;

    private readonly StreamWriter errorStream = new StreamWriter("error.txt");

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
    public BaseNmapProcess(string nmapBin = "nmap", string target = "basic-nginx")
    {
      NMAP_BIN = nmapBin;
      TARGET = target;

      StartInfo = new ProcessStartInfo();

      StartInfo.UseShellExecute = false;
      StartInfo.RedirectStandardError = true;
      StartInfo.RedirectStandardOutput = true;
      //      StartInfo.RedirectStandardInput = true;
      //      StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      StartInfo.CreateNoWindow = true;
      StartInfo.ErrorDialog = false;
      StartInfo.FileName = NMAP_BIN;
      // Configuration des sorties
      ErrorDataReceived += (o, e) =>
      {
        if (!String.IsNullOrEmpty(e.Data))
        {
          errorStream.WriteLine(e.Data);
        }
        else
        {
          if (FirstTriggered != false)
          {
            ErrorTriggered = true;
          }
        }
        FirstTriggered = true;
      };
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
       StartInfo.Arguments = $"-sL -oX - {TARGET}";

        // Execution du la ligne de commande
        this.Start();

        this.BeginErrorReadLine();
        Output = this.StandardOutput.ReadToEnd();
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
        throw new NmapProcessException("test");
      return await Task.FromResult(Output);
    }
  }
}
