// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class BoostClock : CE000
{
    private new const int FE000 = 0;
    private const int FE001 = 4;
    private readonly int FE002;

    public string PE000
    {
        get
        {
            return CE027.E002(base.E001, base.E000, this.FE002);
        }
    }

    public ushort Frequency
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000);
        }
    }

    public byte Index
    {
        get
        {
            return base.E001[base.E000 + 4];
        }
        set
        {
            base.E001[base.E000 + 4] = value;
        }
    }

    public BoostClock(byte[] param0, int param1, int param2)
        : base(param0, param1)
    {
        this.FE002 = param2;
    }
}
