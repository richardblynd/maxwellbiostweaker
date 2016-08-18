// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Text;

internal static class CE027
{

    internal static int E000(this byte[] param0, byte[] param1, int param2 = 0, bool param3 = false, byte? param4 = null)
  {
    for (int index1 = param2; index1 < param0.Length; index1++)
    {
      if (param1[0] == param0[index1] && param0.Length - index1 >= param1.Length)
      {
        bool flag = true;
        for (int index2 = 1; index2 < param1.Length && flag; ++index2)
        {
          byte num2 = param0[index1 + index2];
          if (num2 != param1[index2] && (param3 && index2 == param1.Length - 1 && (num2 & 63) != param1[index2] || !param3))
          {
            if (param4.HasValue)
            {
              byte? nullable = param4;
              int num3 = param1[index2];
              if (((int) nullable.GetValueOrDefault() != num3 ? 1 : (!nullable.HasValue ? 1 : 0)) != 0)
                goto label_7;
            }
            if (param4.HasValue)
              continue;
label_7:
            flag = false;
            break;
          }
        }
        if (flag)
          return index1;
      }
    }
    return -1;
    }

    internal static string E001(this byte[] param0, int param1, int param2)
    {
        string @string = Encoding.ASCII.GetString(param0, param1, param2);
        int length = @string.IndexOf(char.MinValue);
        if (length > -1)
            return @string.Substring(0, length).Trim();
        return @string.Trim();
    }

    internal static string E002(this byte[] param0, int param1, int param2)
    {
        int num = 0;
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = param1; index < param1 + param2; ++index)
        {
            //if (num % 16 == 0)
            //    stringBuilder.AppendLine();
            stringBuilder.Append(param0[index].ToString("X2"));
            ++num;
        }

        byte[] data = FromHex(stringBuilder.ToString().Trim());
        var convertido = Encoding.ASCII.GetString(data); 
        
        return stringBuilder.ToString().Trim();
    }

    public static byte[] FromHex(string hex)
    {
        hex = hex.Replace("-", "");
        byte[] raw = new byte[hex.Length / 2];
        for (int i = 0; i < raw.Length; i++)
        {
            raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return raw;
    }

    internal static void E003(this uint param0, byte[] param1, int param2)
    {
        byte[] bytes = BitConverter.GetBytes(param0);
        Buffer.BlockCopy(bytes, 0, param1, param2, bytes.Length);
    }

    internal static void E004(this ushort param0, byte[] param1, int param2)
    {
        byte[] bytes = BitConverter.GetBytes(param0);
        Buffer.BlockCopy(bytes, 0, param1, param2, bytes.Length);
    }
}
