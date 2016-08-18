// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class CE034 : UserControl
{
    private bool updating;
    private IContainer components;
    private TextBox tbClock;
    private NumericUpDown numClockSelector;

    public new string Text
    {
        get
        {
            return this.tbClock.Text;
        }
        set
        {
            this.tbClock.Text = value;
            this.UpdateClockSelector();
        }
    }

    public bool StepAllowed
    {
        get
        {
            return this.numClockSelector.Enabled;
        }
    }

    public CE034()
    {
        this.InitializeComponent();
        this.InitClockSelector();
    }

    private void InitClockSelector()
    {
        int width = this.numClockSelector.Width;
        this.numClockSelector.Width = (int)Math.Floor((this.numClockSelector.Height + 16.0) / 2.0);
        this.numClockSelector.Left += width - this.numClockSelector.Width;
        this.tbClock.Width += width - this.numClockSelector.Width;
        this.numClockSelector.Maximum = CE00D.PE000.Count - 1;
        this.numClockSelector.Increment = new Decimal(1);
    }

    private void UpdateClockSelector()
    {
        this.updating = true;
        if (string.IsNullOrEmpty(this.tbClock.Text))
            this.numClockSelector.Value = new Decimal(0);
        ushort num1 = CE00D.E006(this.tbClock.Text);
        foreach (ushort num2 in CE00D.PE000)
        {
            if (num1 <= num2)
            {
                this.numClockSelector.Value = CE00D.PE000.IndexOf(num2);
                break;
            }
        }
        this.numClockSelector.Enabled = CE00D.PE000.IndexOf(num1) >= 0;
        this.updating = false;
    }

    private void numClockSelector_ValueChanged(object sender, EventArgs e)
    {
        if (this.updating)
            return;
        this.tbClock.Text = CE00D.E005(CE00D.PE000[(int)this.numClockSelector.Value]);
    }

    private void tbClock_TextChanged(object sender, EventArgs e)
    {
        this.UpdateClockSelector();
    }

    internal void AddStep()
    {
        if (!this.StepAllowed)
            return;
        ++this.numClockSelector.Value;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.tbClock = new System.Windows.Forms.TextBox();
        this.numClockSelector = new System.Windows.Forms.NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)(this.numClockSelector)).BeginInit();
        this.SuspendLayout();
        // 
        // tbClock
        // 
        this.tbClock.Location = new System.Drawing.Point(1, 1);
        this.tbClock.Name = "tbClock";
        this.tbClock.Size = new System.Drawing.Size(66, 20);
        this.tbClock.TabIndex = 0;
        this.tbClock.TextChanged += new System.EventHandler(this.tbClock_TextChanged);
        // 
        // numClockSelector
        // 
        this.numClockSelector.Location = new System.Drawing.Point(69, 1);
        this.numClockSelector.Name = "numClockSelector";
        this.numClockSelector.ReadOnly = true;
        this.numClockSelector.Size = new System.Drawing.Size(18, 20);
        this.numClockSelector.TabIndex = 1;
        this.numClockSelector.TabStop = false;
        this.numClockSelector.ValueChanged += new System.EventHandler(this.numClockSelector_ValueChanged);
        // 
        // CE034
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.Controls.Add(this.numClockSelector);
        this.Controls.Add(this.tbClock);
        this.Name = "CE034";
        this.Size = new System.Drawing.Size(90, 23);
        ((System.ComponentModel.ISupportInitialize)(this.numClockSelector)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }
}
