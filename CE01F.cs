// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.Collections.Generic;

internal class CE01F : CE000
{
    private new const int FE000 = 1;
    private const int FE001 = 2;
    private const int FE002 = 3;
    private const int FE003 = 4;
    private const int FE004 = 5;
    private const int FE005 = 15;
    private const int FE006 = 16;
    private const int FE007 = 17;
    public readonly List<CE01E> FE008;

    public string PE000
    {
        get
        {
            return CE027.E002(base.E001, base.E000, FE001);
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
            return base.E001[base.E000 + 5];
        }
    }

    public byte PE004
    {
        get
        {
            return base.E001[base.E000 + 3];
        }
    }

    public byte PE005
    {
        get
        {
            return base.E001[base.E000 + 4];
        }
    }

    public uint PE006
    {
        get
        {
            return this.PE002 + this.PE004 * (uint)this.PE005;
        }
    }

    public uint PE007
    {
        get
        {
            return this.PE001 + this.PE006 * this.PE003;
        }
    }

    public byte PE008
    {
        get
        {
            return base.E001[base.E000 + 15];
        }
        set
        {
            base.E001[base.E000 + 15] = value;
        }
    }

    public byte PE009
    {
        get
        {
            return base.E001[base.E000 + 16];
        }
        set
        {
            base.E001[base.E000 + 16] = value;
        }
    }

    public byte PE00A
    {
        get
        {
            return base.E001[base.E000 + 17];
        }
        set
        {
            base.E001[base.E000 + 17] = value;
        }
    }

    public CE01F(byte[] param0, int param1)
        : base(param0, param1)
    {
        this.FE008 = this.ME000();
    }

    private List<CE01E> ME000()
    {
        List<CE01E> list = new List<CE01E>();
        for (int index = 0; index < FE003; ++index)
        {
            int num = base.E000 + (int)(this.PE001 + this.PE006 * index);
            list.Add(new CE01E(base.E001, num, this.PE002, this.PE005, this.PE004));
        }
        return list;
    }
}
