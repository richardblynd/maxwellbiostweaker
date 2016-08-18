// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class CE01B : CE000
{
  private new const int FE000 = 0;
  private const int FE001 = 1;
  private const int FE002 = 2;
  private const int FE003 = 4;
  private readonly int FE004;

  public string PE000
  {
    get
    {
      return CE027.E002(base.E001, base.E000, this.FE004);
    }
  }

  public byte PE001
  {
    get
    {
      return base.E001[base.E000];
    }
    set
    {
      base.E001[base.E000] = value;
    }
  }

  public byte PE002
  {
    get
    {
      return base.E001[base.E000 + 1];
    }
    set
    {
      base.E001[base.E000 + 1] = value;
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

  public CE01B(byte[] param0, int param1, int param2)
    : base(param0, param1)
  {
    this.FE004 = param2;
  }
}
