// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections.Generic;

internal class CE004 : CE000
{
    private new readonly int FE000;
    public readonly List<uint> FE001;

    public string PE000
    {
        get
        {
            return CE027.E002(base.E001, base.E000, this.FE000);
        }
    }

    public int PE001
    {
        get
        {
            if (0 >= this.FE001.Count)
                return -1;
            return (int)this.FE001[0];
        }
    }

    public int PE002
    {
        get
        {
            if (22 >= this.FE001.Count)
                return -1;
            return (int)this.FE001[22];
        }
    }

    public int PE003
    {
        get
        {
            if (23 >= this.FE001.Count)
                return -1;
            return (int)this.FE001[23];
        }
    }

    public int PE004
    {
        get
        {
            if (8 >= this.FE001.Count)
                return -1;
            return (int)this.FE001[8];
        }
    }

    public int PE005
    {
        get
        {
            if (11 >= this.FE001.Count)
                return -1;
            return (int)this.FE001[11];
        }
    }

    public int PE006
    {
        get
        {
            if (12 >= this.FE001.Count)
                return -1;
            return (int)this.FE001[12];
        }
    }

    public int PE007
    {
        get
        {
            if (13 >= this.FE001.Count)
                return -1;
            return (int)this.FE001[13];
        }
    }

    public int PE008
    {
        get
        {
            if (14 >= this.FE001.Count)
                return -1;
            return (int)this.FE001[14];
        }
    }

    public int PE009
    {
        get
        {
            if (20 >= this.FE001.Count)
                return -1;

            return (int)this.FE001[20];
        }
    }

    public CE004(byte[] param0, int param1, int param2, int param3)
        : base(param0, param1)
    {
        this.FE000 = param2;
        this.FE001 = this.ME000(param3);
    }

    private List<uint> ME000(int param0)
    {
        List<uint> list = new List<uint>();

        for (int index = 0; (double)index < Math.Floor(this.FE000 / 4.0); ++index)
            list.Add((uint)param0 + BitConverter.ToUInt32(base.E001, base.E000 + index * 4));

        return list;
    }
}
