// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections.Generic;

internal class BoostProfileEntry : CE000
{
    private new const int FE000 = 0;
    private const int FE001 = 1;
    private const int FE002 = 2;
    private const int FE003 = 4;
    private readonly uint FE004;
    private readonly uint FE005;
    private readonly uint FE006;
    private readonly uint FE007;
    public readonly List<CE01B> FE008;

    public string PE000
    {
        get
        {
            return CE027.E002(base.E001, base.E000, (int)this.FE004);
        }
    }

    public bool PE001
    {
        get
        {
            return PE002 == byte.MaxValue;
        }
    }

    public byte PE002
    {
        get
        {
            return (byte)(15 - (BitConverter.ToUInt16(base.E001, base.E000) >> 5));
        }
    }

    public ushort PE003
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + 2);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + 2);
        }
    }

    public ushort PE004
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + 4);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + 4);
        }
    }

    public BoostProfileEntry(byte[] param0, int param1, uint param2, uint param3, uint param4)
        : base(param0, param1)
    {
        this.FE004 = param2;
        this.FE005 = param3;
        this.FE006 = param4;
        this.FE007 = param2 + param3 * param4;
        this.FE008 = this.E000();
    }

    private List<CE01B> E000()
    {
        List<CE01B> list = new List<CE01B>();
        
        for (int index = 0; (long)index < (long)this.FE005; ++index)
            list.Add(new CE01B(base.E001, base.E000 + (int)this.FE004 + index * (int)this.FE006, (int)this.FE006));

        return list;
    }
}
