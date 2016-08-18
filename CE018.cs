// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;

internal class CE018 : CE000
{
  private new const int FE000 = 0;
  private const int FE001 = 3;
  private readonly uint FE002;

  public string PE000
  {
    get
    {
      return CE027.E002(base.E001, base.E000, (int) this.FE002);
    }
  }

  public byte PE001
  {
    get
    {
      return (byte) (15 - (BitConverter.ToUInt16(base.E001, base.E000) >> 5));
    }
  }

  public byte PE002
  {
    get
    {
      return base.E001[base.E000 + 3];
    }
    set
    {
      base.E001[base.E000 + 3] = value;
    }
  }

  public CE018(byte[] param0, int param1, uint param2)
    : base(param0, param1)
  {
    this.FE002 = param2;
  }
}
