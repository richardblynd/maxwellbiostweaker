// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.Collections.Generic;

internal class CE01E : CE000
{
  private new const int FE000 = 0;
  private readonly uint FE001;
  private readonly uint FE002;
  private readonly uint FE003;
  private readonly uint FE004;
  public readonly List<CE01D> FE005;

  public string PE000
  {
    get
    {
      return CE027.E002(base.E001, base.E000, (int) this.FE001);
    }
  }

  public byte PE001
  {
    get
    {
      return (byte) (15U - base.E001[base.E000]);
    }
  }

  public bool PE002
  {
    get
    {
      return base.E001[base.E000] == byte.MaxValue;
    }
  }

  public CE01E(byte[] param0, int param1, uint param2, uint param3, uint param4)
    : base(param0, param1)
  {
    this.FE001 = param2;
    this.FE002 = param3;
    this.FE003 = param4;
    this.FE004 = param2 + param3 * param4;
    this.FE005 = this.E000();
  }

  private List<CE01D> E000()
  {
    List<CE01D> list = new List<CE01D>();
    for (int index = 0; (long) index < (long) this.FE002; ++index)
      list.Add(new CE01D(base.E001, base.E000 + (int) this.FE001 + index * (int) this.FE003, (int) this.FE003));
    return list;
  }
}
