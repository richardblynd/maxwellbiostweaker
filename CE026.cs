// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.Collections.Generic;

internal class PerfTable : CE000
{
    private new const int FE000 = 1;
    private const int FE001 = 2;
    private const int FE002 = 3;
    private const int FE003 = 4;
    private const int FE004 = 5;
    public readonly List<Voltage> Voltages;

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
            return base.E001[base.E000 + 5];
        }
    }

    public byte E004
    {
        get
        {
            return base.E001[base.E000 + 3];
        }
    }

    public byte E005
    {
        get
        {
            return base.E001[base.E000 + 4];
        }
    }

    public uint E006
    {
        get
        {
            return this.E002 + this.E004 * (uint)this.E005;
        }
    }

    public uint E007
    {
        get
        {
            return this.PE001 + this.E006 * this.E003;
        }
    }

    public PerfTable(byte[] param0, int param1)
        : base(param0, param1)
    {
        this.Voltages = this.E000();
    }

    private List<Voltage> E000()
    {
        List<Voltage> list = new List<Voltage>();
        for (int index = 0; index < FE003; ++index)
        {
            int num = base.E000 + (int)(this.PE001 + this.E006 * index);
            list.Add(new Voltage(base.E001, num, this.E002, this.E005, this.E004));
        }
        return list;
    }
}
