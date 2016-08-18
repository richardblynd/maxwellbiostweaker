// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class CE031 : UserControl, ComponenteDaTela
{
    private PowerEntry _PowerEntry;
    private IContainer components;
    private Label lblMax;
    private Label lblMin;
    private Label lblDef;
    private Label lblMinPercent;
    private NumericUpDown numMin;
    private Label lblDefPercent;
    private Label lblMaxPercent;
    private NumericUpDown numDef;
    private NumericUpDown numMax;

    internal PowerEntry PowerEntry
    {
        get
        {
            return this._PowerEntry;
        }
        set
        {
            this._PowerEntry = value;
            this.UpdateData();
        }
    }

    public CE031()
    {
        this.InitializeComponent();

        NumericUpDown numericUpDown1 = this.numMin;
        int[] bits1 = new int[4];
        bits1[0] = 1000;
        Decimal num1 = new Decimal(bits1);
        numericUpDown1.Increment = num1;

        NumericUpDown numericUpDown2 = this.numMin;
        int[] bits2 = new int[4];
        bits2[0] = 9000000;
        Decimal num2 = new Decimal(bits2);
        numericUpDown2.Maximum = num2;

        NumericUpDown numericUpDown3 = this.numDef;
        int[] bits3 = new int[4];
        bits3[0] = 1000;
        Decimal num3 = new Decimal(bits3);
        numericUpDown3.Increment = num3;

        NumericUpDown numericUpDown4 = this.numDef;
        int[] bits4 = new int[4];
        bits4[0] = 9000000;
        Decimal num4 = new Decimal(bits4);
        numericUpDown4.Maximum = num4;

        NumericUpDown numericUpDown5 = this.numMax;
        int[] bits5 = new int[4];
        bits5[0] = 1000;
        Decimal num5 = new Decimal(bits5);
        numericUpDown5.Increment = num5;

        NumericUpDown numericUpDown6 = this.numMax;
        int[] bits6 = new int[4];
        bits6[0] = 9000000;
        Decimal num6 = new Decimal(bits6);
        numericUpDown6.Maximum = num6;
    }

    public void ApplyChanges()
    {
        if (this.PowerEntry == null)
            return;
        this.PowerEntry.Min = Convert.ToUInt32(this.numMin.Value);
        this.PowerEntry.Def = Convert.ToUInt32(this.numDef.Value);
        this.PowerEntry.Max = Convert.ToUInt32(this.numMax.Value);
    }

    public void Reset()
    {
        this.PowerEntry = null;
        this.InternalReset();
    }

    private void InternalReset()
    {
        this.numMin.Value = new Decimal(0);
        this.numDef.Value = new Decimal(0);
        this.numMax.Value = new Decimal(0);
        this.lblMinPercent.Text = "";
        this.lblDefPercent.Text = "";
        this.lblMaxPercent.Text = "";
        this.Enabled = false;
    }

    private void UpdateData()
    {
        this.InternalReset();
        if (this.PowerEntry == null)
            return;
        this.Enabled = true;
        this.numMin.Value = this.PowerEntry.Min;
        this.numDef.Value = this.PowerEntry.Def;
        this.numMax.Value = this.PowerEntry.Max;

        var valor = PowerEntry.PE000;

        this.CalculatePercentages();
    }

    private void CalculatePercentages()
    {
        int num1 = 0;
        int num2 = 0;
        if (this.numMin.Value > new Decimal(0) && this.numDef.Value > new Decimal(0))
            num1 = (int)Math.Round((double)this.numMin.Value / (double)this.numDef.Value * 100.0);
        if (this.numMax.Value > new Decimal(0) && this.numDef.Value > new Decimal(0))
            num2 = (int)Math.Round((double)this.numMax.Value / (double)this.numDef.Value * 100.0);
        this.lblMinPercent.Text = string.Format("{0}%", num1);
        this.lblDefPercent.Text = "100%";
        this.lblMaxPercent.Text = string.Format("{0}%", num2);
    }

    private void num_ValueChanged(object sender, EventArgs e)
    {
        this.CalculatePercentages();
    }

    private void lblMin_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblMax = new System.Windows.Forms.Label();
        this.lblMin = new System.Windows.Forms.Label();
        this.lblDef = new System.Windows.Forms.Label();
        this.lblMinPercent = new System.Windows.Forms.Label();
        this.numMin = new System.Windows.Forms.NumericUpDown();
        this.lblDefPercent = new System.Windows.Forms.Label();
        this.lblMaxPercent = new System.Windows.Forms.Label();
        this.numDef = new System.Windows.Forms.NumericUpDown();
        this.numMax = new System.Windows.Forms.NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numDef)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
        this.SuspendLayout();
        // 
        // lblMax
        // 
        this.lblMax.AutoSize = true;
        this.lblMax.Location = new System.Drawing.Point(3, 55);
        this.lblMax.Name = "lblMax";
        this.lblMax.Size = new System.Drawing.Size(55, 13);
        this.lblMax.TabIndex = 36;
        this.lblMax.Text = "Max (mW)";
        // 
        // lblMin
        // 
        this.lblMin.AutoSize = true;
        this.lblMin.Location = new System.Drawing.Point(3, 5);
        this.lblMin.Name = "lblMin";
        this.lblMin.Size = new System.Drawing.Size(52, 13);
        this.lblMin.TabIndex = 37;
        this.lblMin.Text = "Min (mW)";
        this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
        // 
        // lblDef
        // 
        this.lblDef.AutoSize = true;
        this.lblDef.Location = new System.Drawing.Point(3, 30);
        this.lblDef.Name = "lblDef";
        this.lblDef.Size = new System.Drawing.Size(52, 13);
        this.lblDef.TabIndex = 38;
        this.lblDef.Text = "Def (mW)";
        // 
        // lblMinPercent
        // 
        this.lblMinPercent.Location = new System.Drawing.Point(62, 5);
        this.lblMinPercent.Name = "lblMinPercent";
        this.lblMinPercent.Size = new System.Drawing.Size(39, 13);
        this.lblMinPercent.TabIndex = 37;
        this.lblMinPercent.Text = "71%";
        this.lblMinPercent.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // numMin
        // 
        this.numMin.Location = new System.Drawing.Point(104, 3);
        this.numMin.Name = "numMin";
        this.numMin.Size = new System.Drawing.Size(85, 20);
        this.numMin.TabIndex = 0;
        this.numMin.ValueChanged += new System.EventHandler(this.num_ValueChanged);
        // 
        // lblDefPercent
        // 
        this.lblDefPercent.Location = new System.Drawing.Point(62, 30);
        this.lblDefPercent.Name = "lblDefPercent";
        this.lblDefPercent.Size = new System.Drawing.Size(39, 13);
        this.lblDefPercent.TabIndex = 37;
        this.lblDefPercent.Text = "100%";
        this.lblDefPercent.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // lblMaxPercent
        // 
        this.lblMaxPercent.Location = new System.Drawing.Point(62, 55);
        this.lblMaxPercent.Name = "lblMaxPercent";
        this.lblMaxPercent.Size = new System.Drawing.Size(39, 13);
        this.lblMaxPercent.TabIndex = 37;
        this.lblMaxPercent.Text = "130%";
        this.lblMaxPercent.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // numDef
        // 
        this.numDef.Location = new System.Drawing.Point(104, 28);
        this.numDef.Name = "numDef";
        this.numDef.Size = new System.Drawing.Size(85, 20);
        this.numDef.TabIndex = 1;
        this.numDef.ValueChanged += new System.EventHandler(this.num_ValueChanged);
        // 
        // numMax
        // 
        this.numMax.Location = new System.Drawing.Point(104, 53);
        this.numMax.Name = "numMax";
        this.numMax.Size = new System.Drawing.Size(85, 20);
        this.numMax.TabIndex = 2;
        this.numMax.ValueChanged += new System.EventHandler(this.num_ValueChanged);
        // 
        // CE031
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.numMax);
        this.Controls.Add(this.numDef);
        this.Controls.Add(this.numMin);
        this.Controls.Add(this.lblMax);
        this.Controls.Add(this.lblMaxPercent);
        this.Controls.Add(this.lblDefPercent);
        this.Controls.Add(this.lblMinPercent);
        this.Controls.Add(this.lblMin);
        this.Controls.Add(this.lblDef);
        this.Name = "CE031";
        this.Size = new System.Drawing.Size(193, 77);
        ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numDef)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }
}
