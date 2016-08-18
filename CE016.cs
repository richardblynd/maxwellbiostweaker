// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.Collections.Generic;

internal class BoostTable : CE000
{
    private new const int FE000 = 1;
    private const int FE001 = 2;
    private const int FE002 = 3;
    private const int FE003 = 4;
    private const int FE004 = 5;
    public readonly List<CE018> FE005;
    public readonly List<BoostClock> BoostClocks;

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
            return base.E001[base.E000 + 4];
        }
    }

    public byte PE005
    {
        get
        {
            return base.E001[base.E000 + 5];
        }
    }

    public BoostTable(byte[] param0, int param1)
        : base(param0, param1)
    {
        this.FE005 = this.E000();
        this.BoostClocks = this.E001();
    }

    private List<CE018> E000()
    {
        List<CE018> list = new List<CE018>();
        for (int index = 0; index < (int)this.PE003; ++index)
        {
            int num = base.E000 + (this.PE001 + this.PE002 * index);
            list.Add(new CE018(base.E001, num, this.PE002));
        }
        return list;
    }

    private List<BoostClock> E001()
    {
        List<BoostClock> list = new List<BoostClock>();
        for (int index = 0; index < (int)this.PE005; ++index)
        {
            int num = base.E000 + (this.PE001 + this.PE002 * this.PE003 + this.PE004 * index);
            list.Add(new BoostClock(base.E001, num, this.PE004));
        }
        return list;
    }
}
