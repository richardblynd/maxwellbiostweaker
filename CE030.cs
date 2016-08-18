// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.Diagnostics;
using System.IO;
using System.Reflection;

internal class NvFlashHelper
{
    private string DiretorioLocal
    {
        get
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        }
    }

    private string NvFlash
    {
        get
        {
            return Path.Combine(this.DiretorioLocal, "nvflash.exe");
        }
    }

    public bool ExisteNvFlash
    {
        get
        {
            return File.Exists(this.NvFlash);
        }
    }

    public string BaixarBiosDaGPU()
    {
        Process process = new Process();
        process.StartInfo = new ProcessStartInfo(this.NvFlash, "--save gpu0.rom");
        process.StartInfo.Verb = "runas";
        process.Start();
        process.WaitForExit();
        return Path.Combine(this.DiretorioLocal, "gpu0.rom");
    }

    public void SubirBiosParaGPU(string param0)
    {
        Process process = new Process();
        process.StartInfo = new ProcessStartInfo(this.NvFlash, string.Format("-6 \"{0}\"", param0));
        process.StartInfo.Verb = "runas";
        process.Start();
        process.WaitForExit();
    }
}
