// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.Collections.Generic;

internal class VoltageTable : CE000
{
    private new const int FE000 = 1;
    private const int FE001 = 2;
    private const int FE002 = 3;
    private const int FE003 = 8;
    private const int FE004 = 7;
    public readonly List<VoltageEntry> ListaVoltagens;

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

    public byte PE002
    {
        get
        {
            return base.E001[base.E000 + 2];
        }
    }

    public byte PE003
    {
        get
        {
            return base.E001[base.E000 + 3];
        }
    }

    public byte PE004
    {
        get
        {
            if (8 >= this.PE001)
                return byte.MaxValue;
            return base.E001[base.E000 + 8];
        }
    }

    public byte PE005
    {
        get
        {
            if (7 >= this.PE001)
                return byte.MaxValue;
            return base.E001[base.E000 + 7];
        }
    }

    public VoltageTable(byte[] param0, int param1)
        : base(param0, param1)
    {
        this.ListaVoltagens = this.E000();
    }

    private List<VoltageEntry> E000()
    {
        List<VoltageEntry> list = new List<VoltageEntry>();
        for (int index = 0; index < (int)this.PE003; ++index)
        {
            int num = base.E000 + (this.PE001 + this.PE002 * index);
            list.Add(new VoltageEntry(base.E001, num, this.PE002));
        }
        return list;
    }
}
