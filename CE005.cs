// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class TempTargets : CE000
{
    public byte E000
    {
        get
        {
            return this.E001[base.E000 + 1];
        }
    }

    public bool PE001
    {
        get
        {
            return this.E001[this.E000 + this.E000] != 0;
        }
    }

    public ushort E002
    {
        get
        {
            return BitConverter.ToUInt16(this.E001, this.E000 + base.E000 + 2);
        }
        set
        {
            CE027.E004(value, this.E001, this.E000 + base.E000 + 2);
        }
    }

    public ushort E003
    {
        get
        {
            return BitConverter.ToUInt16(this.E001, this.E000 + base.E000 + 4);
        }
        set
        {
            CE027.E004(value, this.E001, this.E000 + base.E000 + 4);
        }
    }

    public ushort E004
    {
        get
        {
            return BitConverter.ToUInt16(this.E001, this.E000 + base.E000 + 6);
        }
        set
        {
            CE027.E004(value, this.E001, this.E000 + base.E000 + 6);
        }
    }

    public TempTargets(byte[] param0, int param1)
        : base(param0, param1)
    {
    }
}
