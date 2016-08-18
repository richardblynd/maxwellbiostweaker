// Decompiled with JetBrains decompiler
// Type: MaxwellBiosTweaker.Properties.Resources
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MaxwellBiosTweaker.Properties
{
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [DebuggerNonUserCode]
    [CompilerGenerated]
    internal class Resources
    {
        private static ResourceManager FE000;
        private static CultureInfo FE001;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager PE000
        {
            get
            {
                if (object.ReferenceEquals(Resources.FE000, null))
                    Resources.FE000 = new ResourceManager("MaxwellBiosTweaker.Properties.Resources", typeof(Resources).Assembly);
                return Resources.FE000;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo PE001
        {
            get
            {
                return Resources.FE001;
            }
            set
            {
                Resources.FE001 = value;
            }
        }

        internal static Bitmap E002
        {
            get
            {
                return (Bitmap)Resources.PE000.GetObject("nv_logo1", Resources.FE001);
            }
        }

        internal Resources()
        {
        }
    }
}
