// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class FanSettings : CE000
{
    private new const int FE000 = 2;
    private const int FE001 = 3;
    private const int FE002 = 14;
    private const int FE003 = 16;

    public bool PE000
    {
        get
        {
            return true;
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
            return base.E001[base.E000 + this.PE001 + 2];
        }
        set
        {
            base.E001[base.E000 + FE001 + 2] = value;
        }
    }

    public byte PE003
    {
        get
        {
            return base.E001[base.E000 + this.PE001 + 3];
        }
        set
        {
            base.E001[base.E000 + FE001 + 3] = value;
        }
    }

    public ushort PE004
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + this.PE001 + 14);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + this.PE001 + 14);
        }
    }

    public ushort PE005
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + this.PE001 + 16);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + this.PE001 + 16);
        }
    }

    public FanSettings(byte[] param0, int param1)
        : base(param0, param1)
    {
    }
}
