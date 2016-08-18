// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class VoltageEntry : CE000
{
    private new const int FE000 = 1;
    private const int FE001 = 2;
    private const int FE002 = 6;
    private const int FE003 = 10;
    private readonly int FE004;

    public string PE000
    {
        get
        {
            return CE027.E002(base.E001, base.E000, this.FE004);
        }
    }

    public bool PE001
    {
        get
        {
            return this.PE002 == byte.MaxValue;
        }
    }

    public byte PE002
    {
        get
        {
            return base.E001[base.E000 + 1];
        }
    }

    public uint From
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

    public uint To
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

    public uint PE005
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

    public bool PE006
    {
        get
        {
            if ((int)this.From == (int)this.To)
                return (int)this.PE005 == (int)this.From * 10;
            return false;
        }
    }

    public bool PE007
    {
        get
        {
            if ((int)this.From == (int)this.To)
                return (int)this.PE005 == (int)this.From;
            return false;
        }
    }

    public VoltageEntry(byte[] param0, int param1, int param2)
        : base(param0, param1)
    {
        this.FE004 = param2;
    }

    public void E000(uint param0)
    {
        this.From = param0;
        this.To = param0;
        this.PE005 = !this.PE007 ? param0 * 10U : param0;
        this.ME001();
    }

    private void ME001()
    {
        int num = 14;
        byte[] numArray = new byte[this.FE004 - num];
        Buffer.BlockCopy(numArray, 0, base.E001, base.E000 + num, numArray.Length);
    }
}
