// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class CE024 : CE000
{
    private new readonly int FE000;
    private readonly int FE001;

    public string PE000
    {
        get
        {
            return CE027.E002(base.E001, base.E000, this.FE000);
        }
    }

    public uint PE001
    {
        get
        {
            return this.PE002 & 8191U;
        }
        set
        {
            this.PE002 = this.PE002 & 57344U | value;
        }
    }

    public uint PE002
    {
        get
        {
            return BitConverter.ToUInt32(base.E001, base.E000 + this.FE001);
        }
        set
        {
            CE027.E003(value, base.E001, base.E000 + this.FE001);
        }
    }

    public bool PE003
    {
        get
        {
            return (int)this.PE001 == (int)this.PE002;
        }
    }

    public CE024(byte[] param0, int param1, int param2)
        : base(param0, param1)
    {
        this.FE000 = param2;
        this.FE001 = param2 - 4;
    }
}
