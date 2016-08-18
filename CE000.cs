// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

internal class CE000
{
    protected int E000;
    protected byte[] E001;

    public int PE000
    {
        get
        {
            return this.E000;
        }
    }

    public CE000(byte[] param0, int param1)
    {
        this.E000 = param1;
        this.E001 = param0;
    }
}
