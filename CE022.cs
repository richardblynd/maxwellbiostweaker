// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class PowerEntry : CE000
{
    private new const int FE000 = 2;
    private const int FE001 = 6;
    private const int FE002 = 10;
    private readonly int FE003;

    public string PE000
    {
        get
        {
            return CE027.E002(base.E001, base.E000, this.FE003);
        }
    }

    public uint Min
    {
        get
        {
            return BitConverter.ToUInt32(base.E001, base.E000 + 2);
        }
        set
        {
            CE027.E003(value, base.E001, base.E000 + 2);
        }
    }

    public uint Def
    {
        get
        {
            return BitConverter.ToUInt32(base.E001, base.E000 + 6);
        }
        set
        {
            CE027.E003(value, base.E001, base.E000 + 6);
        }
    }

    public uint Max
    {
        get
        {
            return BitConverter.ToUInt32(base.E001, base.E000 + 10);
        }
        set
        {
            CE027.E003(value, base.E001, base.E000 + 10);
        }
    }

    public PowerEntry(byte[] param0, int param1, int param2)
        : base(param0, param1)
    {
        this.FE003 = param2;
    }
}
