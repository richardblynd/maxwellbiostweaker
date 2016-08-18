// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class RomHeader : CE000
{
    private static byte[] E00A = new byte[4]
    {
        80,
        77,
        73,
        68
    };

    private new const int FE000 = 24;
    private const int FE001 = 84;
    private const int FE002 = 56;
    private const int FE003 = 8;
    private const int FE004 = 134;
    private const int FE005 = 57;
    private const int FE006 = 223;
    private const int FE007 = 14;
    private const int FE008 = 290;
    private const int FE009 = 35;
    public readonly CE02B E00B;
    private int? E00C;

    private new int E000
    {
        get
        {
            if (!this.E00C.HasValue)
                this.E00C = new int?(CE027.E000(base.E001, RomHeader.E00A, base.E000, false, new byte?()) - (114 + base.E000));
            return this.E00C.Value;
        }
    }

    public int E001
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + 24);
        }
    }

    public string E002
    {
        get
        {
            return CE027.E001(base.E001, base.E000 + 56, 8);
        }
    }

    public ushort E003
    {
        get
        {
            return BitConverter.ToUInt16(base.E001, base.E000 + 84);
        }
    }

    public string E004
    {
        get
        {
            return CE027.E001(base.E001, base.E000 + this.E000 + 134, 57);
        }
    }

    public string E005
    {
        get
        {
            return CE027.E001(base.E001, base.E000 + this.E000 + 223, 14);
        }
    }

    public string E006
    {
        get
        {
            return CE027.E001(base.E001, base.E000 + this.E000 + 290, 35);
        }
    }

    public RomHeader(byte[] param0, int param1)
        : base(param0, param1)
    {
        this.E00B = new CE02B(param0, param1 + this.E001);
    }
}
