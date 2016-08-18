// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class FanSettings2 : CE000
{
    public bool E000
    {
        get
        {
            return true;
        }
    }

    public byte E001
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
            return base.E001[base.E000 + this.E001 + 17];
        }
        set
        {
            base.E001[base.E000 + this.E001 + 17] = value;
        }
    }

    public byte E003
    {
        get
        {
            return base.E001[base.E000 + this.E001 + 18];
        }
        set
        {
            base.E001[base.E000 + this.E001 + 18] = value;
        }
    }

    public byte E004
    {
        get
        {
            return base.E001[base.E000 + this.E001 + 19];
        }
        set
        {
            base.E001[base.E000 + this.E001 + 19] = value;
        }
    }

    public ushort E005
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + this.E001 + 21);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + this.E001 + 21);
        }
    }

    public ushort E006
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + this.E001 + 23);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + this.E001 + 23);
        }
    }

    public ushort E007
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + this.E001 + 25);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + this.E001 + 25);
        }
    }

    public ushort E008
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + this.E001 + 27);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + this.E001 + 27);
        }
    }

    public ushort E009
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + this.E001 + 29);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + this.E001 + 29);
        }
    }

    public ushort E00A
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + this.E001 + 31);
        }
        set
        {
            CE027.E004(value, base.E001, base.E000 + this.E001 + 31);
        }
    }

    public FanSettings2(byte[] param0, int param1)
        : base(param0, param1)
    {
    }
}
