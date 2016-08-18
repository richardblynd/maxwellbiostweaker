// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.Collections.Generic;

internal class PowerTable : CE000
{
    private new const int FE000 = 1;
    private const int FE001 = 2;
    private const int FE002 = 3;
    private const int FE003 = 10;
    private const int FE004 = 9;
    public readonly List<PowerEntry> ListPowerEntries;

    public string PE000
    {
        get
        {
            return CE027.E002(base.E001, base.E000, this.PE001);
        }
    }

    public byte PE001
    {
        get
        {
            return base.E001[base.E000 + 1];
        }
    }

    public byte E002
    {
        get
        {
            return base.E001[base.E000 + 2];
        }
    }

    public byte E003
    {
        get
        {
            return base.E001[base.E000 + 3];
        }
    }

    public byte E004
    {
        get
        {
            return base.E001[base.E000 + 10];
        }
    }

    public byte E005
    {
        get
        {
            return base.E001[base.E000 + 9];
        }
    }

    public PowerTable(byte[] param0, int param1)
        : base(param0, param1)
    {
        this.ListPowerEntries = this.E000();
    }

    private List<PowerEntry> E000()
    {
        List<PowerEntry> list = new List<PowerEntry>();
        
        for (int index = 0; index < (int)this.E003; ++index)
        {
            int num = base.E000 + (this.PE001 + this.E002 * index);
            list.Add(new PowerEntry(base.E001, num, this.E002));
        }
        return list;
    }
}
