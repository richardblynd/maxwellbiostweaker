// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.Collections.Generic;
using System.IO;

internal class Bios
{
    private byte[] PE0000 = new byte[2]
    {
        85,
        170
    };

    public readonly string caminhoArquivo;
    public readonly byte[] arquivoEmBytes;
    public readonly List<LinhaBios> linhasDaBios;

    public bool PE000
    {
        get
        {
            if (this.linhasDaBios.Count > 0)
                return this.linhasDaBios[0].PerfTable != null;
            return false;
        }
    }

    public bool PossuiFanSettings
    {
        get
        {
            if (this.linhasDaBios.Count > 0)
                return this.linhasDaBios[0].FanSettings != null;
            return false;
        }
    }

    public bool PossuiPowerTable
    {
        get
        {
            if (this.linhasDaBios.Count > 0)
                return this.linhasDaBios[0].PowerTable != null;
            return false;
        }
    }

    public bool PE003
    {
        get
        {
            if (this.linhasDaBios.Count > 0)
                return this.linhasDaBios[0].VoltageTable != null;
            return false;
        }
    }

    public bool PossuiBoostProfile
    {
        get
        {
            if (this.linhasDaBios.Count > 0)
                return this.linhasDaBios[0].BoostProfile != null;
            return false;
        }
    }

    public Bios(string param0)
    {
        this.caminhoArquivo = param0;
        this.arquivoEmBytes = File.ReadAllBytes(param0);
        this.linhasDaBios = this.LerBios();
    }

    private List<LinhaBios> LerBios()
    {
        List<LinhaBios> list = new List<LinhaBios>();
        
        int num = CE027.E000(this.arquivoEmBytes, this.PE0000, 0, false, new byte?());
        
        if (num > -1)
        {
            RomHeader obj;
            do
            {
                obj = new RomHeader(this.arquivoEmBytes, num);
                if (obj.E00B.PE000)
                {
                    list.Add(new LinhaBios(this.arquivoEmBytes, num));
                    num += obj.E00B.PE004;
                }
                else
                    break;
            }
            while (!obj.E00B.PE005);
        }
        return list;
    }

    public void EscreverBios(string param0)
    {
        foreach (LinhaBios obj in this.linhasDaBios)
            obj.ObterImageChecksum();

        File.WriteAllBytes(param0, this.arquivoEmBytes);
    }
}
