// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.Collections.Generic;

internal class CE013
{
    public static readonly List<uint> PE000 = CE013.E001();

    public static bool E000(uint param0)
    {
        if ((int)param0 == 0)
            return false;
        return CE013.PE000.Contains(param0);
    }

    private static List<uint> E001()
    {
        List<uint> list = new List<uint>();
        list.Add(0U);
        uint num1 = 1600000U;
        uint num2 = 600000U;
        while (num2 <= num1)
        {
            list.Add(num2);
            num2 += 6250U;
        }
        return list;
    }
}
