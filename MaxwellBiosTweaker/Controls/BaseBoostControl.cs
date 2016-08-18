// Decompiled with JetBrains decompiler
// Type: MaxwellBiosTweaker.Controls.BaseBoostControl
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MaxwellBiosTweaker.Controls
{
    public class UCBaseBoostControl : UserControl, ComponenteDaTela
    {
        private CE01F FE000;
        private IContainer FE001;
        private Label FE002;
        private Label FE003;
        private CE034 FE004;
        private CE034 FE005;
        private CE034 FE006;
        private Label FE007;
        private ComboBox FE008;
        private ComboBox FE009;
        private ComboBox FE00A;
        private Label FE00B;
        private Label FE00C;
        private Label FE00D;

        internal CE01F PE000
        {
            get
            {
                return this.FE000;
            }
            set
            {
                this.FE000 = value;
                this.E001(true);
            }
        }

        public bool StepAllowed
        {
            get
            {
                if (this.FE004.StepAllowed && this.FE005.StepAllowed)
                    return this.FE006.StepAllowed;
                return false;
            }
        }

        public UCBaseBoostControl()
        {
            this.E00B();
        }

        public void ApplyChanges()
        {
            if (this.FE000 == null)
                return;
            if (this.FE000.PE009 != byte.MaxValue && this.FE005.Enabled)
                this.FE000.FE008[this.FE000.PE009].FE005[0].PE001 = CE00D.E006(this.FE005.Text);
            if (this.FE000.PE00A != byte.MaxValue && this.FE004.Enabled)
                this.FE000.FE008[this.FE000.PE00A].FE005[0].PE001 = CE00D.E006(this.FE004.Text);
            if (this.FE000.PE008 == byte.MaxValue || !this.FE006.Enabled)
                return;
            this.FE000.FE008[this.FE000.PE008].FE005[0].PE001 = CE00D.E006(this.FE006.Text);
        }

        public void Reset()
        {
            this.FE000 = null;
            this.E000();
        }

        private void E000()
        {
            this.FE004.Text = "";
            this.FE004.Enabled = false;
            this.FE005.Text = "";
            this.FE005.Enabled = false;
            this.FE006.Text = "";
            this.FE006.Enabled = false;
        }

        private void E001(bool param0 = true)
        {
            this.E000();
            if (this.FE000 == null)
                return;
            if (param0)
                this.E002();
            if (this.FE000.PE00A != byte.MaxValue)
            {
                this.FE004.Text = CE00D.E005(this.FE000.FE008[this.FE000.PE00A].FE005[0].PE001);
                this.FE004.Enabled = true;
            }
            if (this.FE000.PE008 != byte.MaxValue)
            {
                this.FE006.Text = CE00D.E005(this.FE000.FE008[this.FE000.PE008].FE005[0].PE001);
                this.FE006.Enabled = this.FE000.PE008 != this.FE000.PE00A;
            }
            if (this.FE000.PE009 == byte.MaxValue)
                return;
            this.FE005.Text = CE00D.E005(this.FE000.FE008[this.FE000.PE009].FE005[0].PE001);
            this.FE005.Enabled = this.FE000.PE009 != this.FE000.PE00A && this.FE000.PE009 != this.FE000.PE008;
        }

        private void E002()
        {
            List<string> list1 = new List<string>();
            List<int> list2 = this.E003();
            for (int index = 0; index < list2.Count; ++index)
                list1.Add(string.Format("Entry #{0}", list2[index]));
            list1.Add("Disabled");
            byte num1 = this.FE000.PE00A;
            this.FE008.Items.Clear();
            this.FE008.Items.AddRange(list1.ToArray());
            this.FE008.SelectedIndex = (int)num1 != (int)byte.MaxValue ? this.E004(num1) : list1.Count - 1;
            byte num2 = this.FE000.PE009;
            this.FE009.Items.Clear();
            this.FE009.Items.AddRange(list1.ToArray());
            this.FE009.SelectedIndex = (int)num2 != (int)byte.MaxValue ? this.E004(num2) : list1.Count - 1;
            byte num3 = this.FE000.PE008;
            this.FE00A.Items.Clear();
            this.FE00A.Items.AddRange(list1.ToArray());
            this.FE00A.SelectedIndex = (int)num3 != (int)byte.MaxValue ? this.E004(num3) : list1.Count - 1;
        }

        private List<int> E003()
        {
            List<int> list = new List<int>();
            for (int index = 0; index < this.FE000.FE008.Count; index++)
            {
                if (this.FE000.FE008[index].PE001 == 0)
                    list.Add(index);
            }
            return list;
        }

        private int E004(int param0)
        {
            List<int> list = this.E003();

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index] == param0)
                    return index;
            }
            return -1;
        }

        private byte E005(int param0)
        {
            List<int> list = this.E003();
            if (param0 < list.Count)
                return (byte)list[param0];
            return byte.MaxValue;
        }

        internal void E006()
        {
            if (!this.StepAllowed)
                return;
            this.FE004.AddStep();
            this.FE005.AddStep();
            this.FE006.AddStep();
        }

        private void E007(object param0, EventArgs param1)
        {
        }

        private void E008(object param0, EventArgs param1)
        {
            this.FE000.PE00A = this.E005(this.FE008.SelectedIndex);
            this.E001(false);
        }

        private void E009(object param0, EventArgs param1)
        {
            this.FE000.PE009 = this.E005(this.FE009.SelectedIndex);
            this.E001(false);
        }

        private void E00A(object param0, EventArgs param1)
        {
            this.FE000.PE008 = this.E005(this.FE00A.SelectedIndex);
            this.E001(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.FE001 != null)
                this.FE001.Dispose();
            base.Dispose(disposing);
        }

        private void E00B()
        {
            this.FE002 = new Label();
            this.FE003 = new Label();
            this.FE007 = new Label();
            this.FE008 = new ComboBox();
            this.FE009 = new ComboBox();
            this.FE00A = new ComboBox();
            this.FE00B = new Label();
            this.FE00C = new Label();
            this.FE00D = new Label();
            this.FE006 = new CE034();
            this.FE005 = new CE034();
            this.FE004 = new CE034();
            this.SuspendLayout();
            this.FE002.AutoSize = true;
            this.FE002.Location = new Point(3, 59);
            this.FE002.Name = "lblTurboBoost";
            this.FE002.Size = new Size(64, 13);
            this.FE002.TabIndex = 30;
            this.FE002.Text = "Boost Entry:";
            this.FE003.AutoSize = true;
            this.FE003.Location = new Point(3, 4);
            this.FE003.Name = "lblBase";
            this.FE003.Size = new Size(86, 13);
            this.FE003.TabIndex = 31;
            this.FE003.Text = "TDP Base Entry:";
            this.FE007.AutoSize = true;
            this.FE007.Location = new Point(3, 31);
            this.FE007.Name = "lbl3dBoost";
            this.FE007.Size = new Size(78, 13);
            this.FE007.TabIndex = 33;
            this.FE007.Text = "3D Base Entry:";
            this.FE008.DropDownStyle = ComboBoxStyle.DropDownList;
            this.FE008.FormattingEnabled = true;
            this.FE008.Location = new Point(103, 1);
            this.FE008.Name = "cbBaseClockIndex";
            this.FE008.Size = new Size(86, 21);
            this.FE008.TabIndex = 34;
            this.FE008.SelectedIndexChanged += new EventHandler(this.E008);
            this.FE009.DropDownStyle = ComboBoxStyle.DropDownList;
            this.FE009.FormattingEnabled = true;
            this.FE009.Location = new Point(103, 56);
            this.FE009.Name = "cbTuboBoostIndex";
            this.FE009.Size = new Size(86, 21);
            this.FE009.TabIndex = 34;
            this.FE009.SelectedIndexChanged += new EventHandler(this.E009);
            this.FE00A.DropDownStyle = ComboBoxStyle.DropDownList;
            this.FE00A.FormattingEnabled = true;
            this.FE00A.Location = new Point(103, 28);
            this.FE00A.Name = "cb3dBoostIndex";
            this.FE00A.Size = new Size(86, 21);
            this.FE00A.TabIndex = 34;
            this.FE00A.SelectedIndexChanged += new EventHandler(this.E00A);
            this.FE00B.AutoSize = true;
            this.FE00B.Location = new Point(217, 31);
            this.FE00B.Name = "label1";
            this.FE00B.Size = new Size(81, 13);
            this.FE00B.TabIndex = 41;
            this.FE00B.Text = "3D Base Clock:";
            this.FE00C.AutoSize = true;
            this.FE00C.Location = new Point(217, 59);
            this.FE00C.Name = "label2";
            this.FE00C.Size = new Size(67, 13);
            this.FE00C.TabIndex = 39;
            this.FE00C.Text = "Boost Clock:";
            this.FE00D.AutoSize = true;
            this.FE00D.Location = new Point(217, 4);
            this.FE00D.Name = "label3";
            this.FE00D.Size = new Size(89, 13);
            this.FE00D.TabIndex = 40;
            this.FE00D.Text = "TDP Base Clock:";
            this.FE006.Location = new Point(313, 27);
            this.FE006.Name = "tb3dBoostClock";
            this.FE006.Size = new Size(90, 23);
            this.FE006.TabIndex = 32;
            this.FE005.Location = new Point(313, 55);
            this.FE005.Name = "tbTurboBoostClock";
            this.FE005.Size = new Size(90, 23);
            this.FE005.TabIndex = 1;
            this.FE004.Location = new Point(313, 0);
            this.FE004.Name = "tbBaseClock";
            this.FE004.Size = new Size(90, 23);
            this.FE004.TabIndex = 0;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.FE00B);
            this.Controls.Add(this.FE00C);
            this.Controls.Add(this.FE00D);
            this.Controls.Add(this.FE00A);
            this.Controls.Add(this.FE009);
            this.Controls.Add(this.FE008);
            this.Controls.Add(this.FE006);
            this.Controls.Add(this.FE007);
            this.Controls.Add(this.FE005);
            this.Controls.Add(this.FE004);
            this.Controls.Add(this.FE002);
            this.Controls.Add(this.FE003);
            this.Name = "BaseBoostControl";
            this.Size = new Size(407, 79);
            this.Load += new EventHandler(this.E007);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
