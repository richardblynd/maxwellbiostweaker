// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class CE01D : CE000
{
  private new readonly int FE000;

  public string PE000
  {
    get
    {
      return CE027.E002(this.E001, base.E000, this.FE000);
    }
  }

  public ushort PE001
  {
    get
    {
      return BitConverter.ToUInt16(E001, base.E000);
    }
    set
    {
      CE027.E004(value, E001, base.E000);
    }
  }

  public CE01D(byte[] param0, int param1, int param2)
    : base(param0, param1)
  {
    this.FE000 = param2;
  }
}
