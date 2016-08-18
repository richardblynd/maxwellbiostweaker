// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

internal class LinhaBios : CE000
{
    private readonly byte[] PE002 = new byte[5]
  {
    byte.MaxValue,
    184,
    66,
    73,
    84
  };
    public readonly RomHeader RomHeader;
    public readonly CE001 FE001;
    public readonly PerfTable PerfTable;
    public readonly PowerTable PowerTable;
    public readonly VoltageTable VoltageTable;
    public readonly CE01F FE006;
    public readonly BoostProfile BoostProfile;
    public readonly BoostTable BoostTable;
    public readonly FanSettings FanSettings;
    public readonly FanSettings2 FanSettings2;
    public readonly TempTargets TempTargets;

    public byte ImageChecksum
    {
        get
        {
            return base.E001[base.E000 + this.RomHeader.E00B.PE004 - 1];
        }
        set
        {
            base.E001[base.E000 + this.RomHeader.E00B.PE004 - 1] = value;
        }
    }

    public LinhaBios(byte[] param0, int param1)
        : base(param0, param1)
    {
        this.RomHeader = new RomHeader(param0, param1);
        int num = CE027.E000(param0, this.PE002, param1, false, new byte?(0));
        
        if (this.E003(num))
            this.FE001 = new CE001(param0, num, param1);

        if (this.FE001 == null || !this.FE001.PE004 || !this.PE000(this.RomHeader.E00B.PE002))
            return;

        if (this.E003(this.FE001.FE004.PE001))
            this.PerfTable = new PerfTable(param0, this.FE001.FE004.PE001);

        if (this.E003(this.FE001.FE004.PE005))
            this.PowerTable = new PowerTable(param0, this.FE001.FE004.PE005);

        if (this.E003(this.FE001.FE004.PE004))
            this.VoltageTable = new VoltageTable(param0, this.FE001.FE004.PE004);

        if (this.E003(this.FE001.FE004.PE006))
            this.BoostProfile = new BoostProfile(param0, this.FE001.FE004.PE006);

        if (this.E003(this.FE001.FE004.PE007))
            this.BoostTable = new BoostTable(param0, this.FE001.FE004.PE007);

        if (this.E003(this.FE001.FE004.PE008))
            this.FE006 = new CE01F(param0, this.FE001.FE004.PE008);

        if (this.E003(this.FE001.FE004.PE002))
            this.FanSettings = new FanSettings(param0, this.FE001.FE004.PE002);

        if (this.E003(this.FE001.FE004.PE003))
            this.FanSettings2 = new FanSettings2(param0, this.FE001.FE004.PE003);

        if (!this.E003(this.FE001.FE004.PE009))
            return;
        
        this.TempTargets = new TempTargets(param0, this.FE001.FE004.PE009);
    }

    private bool PE000(ushort E000)
    {
        return true;
    }

    public void ObterImageChecksum()
    {
        this.ImageChecksum = this.GenerateChecksum();
    }

    public byte GenerateChecksum()
    {
        ulong num = 0UL;
        for (int index = base.E000; index < base.E000 + this.RomHeader.E00B.PE004 - 1; ++index)
            num += base.E001[index];
        return (byte)(byte.MaxValue - (ulong)((long)num - 1L & byte.MaxValue));
    }

    private bool E003(int param0)
    {
        if (param0 != -1 && param0 > base.E000)
            return param0 < base.E000 + this.RomHeader.E00B.PE004;
        return false;
    }
}
