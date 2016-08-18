// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

internal static class CE00D
{
    private static readonly NumberFormatInfo FE000 = CE00D.E000();
    private static readonly List<ushort> FE001 = CE00D.E002();
    private static readonly List<ushort> FE002 = CE00D.E003();
    public static readonly Dictionary<byte, string> FE003;

    public static List<ushort> PE000 { get; private set; }

    static CE00D()
    {
        CE00D.PE000 = CE00D.FE001;
        CE00D.FE003 = CE00D.E004();
    }

    private static NumberFormatInfo E000()
    {
        return new NumberFormatInfo()
        {
            NumberDecimalSeparator = "."
        };
    }

    public static void E001(List<ushort> param0_1)
    {
        //TODO: esse método ta cagado
        int num1 = param0_1.Count(param0_2 => FE002.Contains(param0_2));

        List<ushort> list = param0_1;
        // ISSUE: reference to a compiler-generated field
        
        if (x == null)
        {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: method pointer
            x = xx;
        }

        // ISSUE: reference to a compiler-generated field
        Func<ushort, bool> predicate = x;
        int num2 = list.Count(predicate);
        //PE000 = num1 > num2 ? FE002 : FE001;
    }

    private static bool xx(ushort arg)
    {
        return true;
    }

    private static List<ushort> E002()
    {
        List<ushort> list = new List<ushort>();
        for (int index = 0; index < 140; ++index)
            list.Add((ushort)(811 + index * 25 + Math.Floor(index * 5.0 / 16.0)));
        return list;
    }

    private static List<ushort> E003()
    {
        List<ushort> list = new List<ushort>();
        for (int index = 0; index < 117; ++index)
            list.Add((ushort)(602 + index * 26 + Math.Floor(index * 5.0 / 39.0)));
        return list;
    }

    private static Dictionary<byte, string> E004()
    {
        return new Dictionary<byte, string>()
    {
      {
        0,
        "GPC"
      },
      {
        1,
        "XBAR"
      },
      {
        2,
        "L2C"
      },
      {
        3,
        "DDR"
      },
      {
        4,
        "SYS"
      },
      {
        5,
        "HUB"
      },
      {
        6,
        "MSD"
      },
      {
        7,
        "PWR"
      },
      {
        8,
        "DISP"
      }
    };
    }

    public static string E005(ushort param0)
    {
        return (param0 / 2f).ToString("0.0", CE00D.FE000);
    }

    public static ushort E006(string param0)
    {
        if (string.IsNullOrEmpty(param0))
            return 0;
        return (ushort)Math.Round(Convert.ToDecimal(param0, CE00D.FE000) * new Decimal(2));
    }

    public static Func<ushort, bool> x { get; set; }

    public static object PE008 { get; set; }
}
