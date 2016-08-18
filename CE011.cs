// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class UCFanRange : UserControl, ComponenteDaTela
{
    private FanSettings _FanSettings;
    private FanSettings2 _FanSettings2;
    private IContainer components;
    private Label lblFanMax;
    private Label lblFanMin;
    private NumericUpDown numFanMax;
    private NumericUpDown numFanMin;
    private Label lblFanMaxRpm;
    private Label lblFanMinRpm;
    private NumericUpDown numFanMaxRpm;
    private NumericUpDown numFanMinRpm;
    private NumericUpDown numRpm1;
    private Label label1;
    private NumericUpDown numTemp2;
    private Label lblRpm12;
    private NumericUpDown numRpm2;
    private Label label3;
    private NumericUpDown numTemp3;
    private Label lblRpm14;
    private NumericUpDown numRpm3;
    private Label lblRpm15;
    private NumericUpDown numPercent1;
    private Label label4;
    private NumericUpDown numPercent2;
    private Label label5;
    private NumericUpDown numPercent3;
    private Label label6;
    private NumericUpDown numTemp1;
    private Label lblRpm10;

    internal FanSettings FanSettings
    {
        get
        {
            return this._FanSettings;
        }
        set
        {
            this._FanSettings = value;
            this.UpdateData();
        }
    }

    internal FanSettings2 FanSettings2
    {
        get
        {
            return this._FanSettings2;
        }
        set
        {
            this._FanSettings2 = value;
            this.UpdateData();
        }
    }

    public UCFanRange()
    {
        this.InitializeComponent();

        NumericUpDown numericUpDown1 = this.numFanMax;
        int[] bits1 = new int[4];
        bits1[0] = byte.MaxValue;
        Decimal num1 = new Decimal(bits1);
        numericUpDown1.Maximum = num1;

        NumericUpDown numericUpDown2 = this.numFanMin;
        int[] bits2 = new int[4];
        bits2[0] = byte.MaxValue;
        Decimal num2 = new Decimal(bits2);
        numericUpDown2.Maximum = num2;

        NumericUpDown numericUpDown3 = this.numFanMaxRpm;
        int[] bits3 = new int[4];
        bits3[0] = ushort.MaxValue;
        Decimal num3 = new Decimal(bits3);
        numericUpDown3.Maximum = num3;

        NumericUpDown numericUpDown4 = this.numFanMinRpm;
        int[] bits4 = new int[4];
        bits4[0] = ushort.MaxValue;
        Decimal num4 = new Decimal(bits4);
        numericUpDown4.Maximum = num4;

        NumericUpDown numericUpDown5 = this.numRpm1;
        int[] bits5 = new int[4];
        bits5[0] = ushort.MaxValue;
        Decimal num5 = new Decimal(bits5);
        numericUpDown5.Maximum = num5;

        NumericUpDown numericUpDown6 = this.numTemp2;
        int[] bits6 = new int[4];
        bits6[0] = sbyte.MaxValue;
        Decimal num6 = new Decimal(bits6);
        numericUpDown6.Maximum = num6;

        NumericUpDown numericUpDown7 = this.numRpm2;
        int[] bits7 = new int[4];
        bits7[0] = ushort.MaxValue;
        Decimal num7 = new Decimal(bits7);
        numericUpDown7.Maximum = num7;

        NumericUpDown numericUpDown8 = this.numTemp3;
        int[] bits8 = new int[4];
        bits8[0] = sbyte.MaxValue;
        Decimal num8 = new Decimal(bits8);
        numericUpDown8.Maximum = num8;

        NumericUpDown numericUpDown9 = this.numRpm3;
        int[] bits9 = new int[4];
        bits9[0] = ushort.MaxValue;
        Decimal num9 = new Decimal(bits9);
        numericUpDown9.Maximum = num9;

        NumericUpDown numericUpDown10 = this.numPercent1;
        int[] bits10 = new int[4];
        bits10[0] = byte.MaxValue;
        Decimal num10 = new Decimal(bits10);
        numericUpDown10.Maximum = num10;

        NumericUpDown numericUpDown11 = this.numPercent2;
        int[] bits11 = new int[4];
        bits11[0] = byte.MaxValue;
        Decimal num11 = new Decimal(bits11);
        numericUpDown11.Maximum = num11;

        NumericUpDown numericUpDown12 = this.numPercent3;
        int[] bits12 = new int[4];
        bits12[0] = byte.MaxValue;
        Decimal num12 = new Decimal(bits12);
        numericUpDown12.Maximum = num12;

        NumericUpDown numericUpDown13 = this.numTemp1;
        int[] bits13 = new int[4];
        bits13[0] = sbyte.MaxValue;
        Decimal num13 = new Decimal(bits13);
        numericUpDown13.Maximum = num13;
    }

    public void ApplyChanges()
    {
        if (this.FanSettings == null || !this.FanSettings.PE000 || (this.FanSettings2 == null || !this.FanSettings2.E000))
            return;
        this.FanSettings.PE002 = Convert.ToByte(this.numFanMin.Value);
        this.FanSettings.PE003 = Convert.ToByte(this.numFanMax.Value);
        this.FanSettings.PE004 = Convert.ToUInt16(this.numFanMinRpm.Value);
        this.FanSettings.PE005 = Convert.ToUInt16(this.numFanMaxRpm.Value);
        this.FanSettings2.E002 = Convert.ToByte(this.numPercent1.Value);
        this.FanSettings2.E003 = Convert.ToByte(this.numPercent2.Value);
        this.FanSettings2.E004 = Convert.ToByte(this.numPercent3.Value);
        this.FanSettings2.E006 = Convert.ToUInt16(this.numRpm1.Value);
        this.FanSettings2.E008 = Convert.ToUInt16(this.numRpm2.Value);
        this.FanSettings2.E00A = Convert.ToUInt16(this.numRpm3.Value);
        this.FanSettings2.E005 = Convert.ToUInt16(this.numTemp1.Value * new Decimal(32));
        this.FanSettings2.E007 = Convert.ToUInt16(this.numTemp2.Value * new Decimal(32));
        this.FanSettings2.E009 = Convert.ToUInt16(this.numTemp3.Value * new Decimal(32));
    }

    public void Reset()
    {
        this.FanSettings = null;
        this.InternalReset();
    }

    private void InternalReset()
    {
        this.numFanMin.Value = new Decimal(0);
        this.numFanMax.Value = new Decimal(0);
        this.numFanMinRpm.Value = new Decimal(0);
        this.numFanMaxRpm.Value = new Decimal(0);
        this.numRpm1.Value = new Decimal(0);
        this.numTemp2.Value = new Decimal(0);
        this.numRpm2.Value = new Decimal(0);
        this.numTemp3.Value = new Decimal(0);
        this.numRpm3.Value = new Decimal(0);
        this.numPercent1.Value = new Decimal(0);
        this.numPercent2.Value = new Decimal(0);
        this.numPercent3.Value = new Decimal(0);
        this.numTemp1.Value = new Decimal(0);
        this.Enabled = false;
    }

    private void UpdateData()
    {
        this.InternalReset();
        if (this.FanSettings == null || !this.FanSettings.PE000 || (this.FanSettings2 == null || !this.FanSettings2.E000))
            return;
        this.Enabled = true;
        this.numFanMin.Value = this.FanSettings.PE002;
        this.numFanMax.Value = this.FanSettings.PE003;
        this.numFanMinRpm.Value = this.FanSettings.PE004;
        this.numFanMaxRpm.Value = this.FanSettings.PE005;
        this.numRpm1.Value = this.FanSettings2.E006;
        this.numRpm2.Value = this.FanSettings2.E008;
        this.numRpm3.Value = this.FanSettings2.E00A;
        this.numPercent1.Value = this.FanSettings2.E002;
        this.numPercent2.Value = this.FanSettings2.E003;
        this.numPercent3.Value = this.FanSettings2.E004;
        this.numTemp1.Value = this.FanSettings2.E005 / new Decimal(32);
        this.numTemp2.Value = this.FanSettings2.E007 / new Decimal(32);
        this.numTemp3.Value = this.FanSettings2.E009 / new Decimal(32);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.lblFanMax = new System.Windows.Forms.Label();
            this.lblFanMin = new System.Windows.Forms.Label();
            this.numFanMax = new System.Windows.Forms.NumericUpDown();
            this.numFanMin = new System.Windows.Forms.NumericUpDown();
            this.lblFanMaxRpm = new System.Windows.Forms.Label();
            this.lblFanMinRpm = new System.Windows.Forms.Label();
            this.numFanMaxRpm = new System.Windows.Forms.NumericUpDown();
            this.numFanMinRpm = new System.Windows.Forms.NumericUpDown();
            this.numRpm1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numTemp2 = new System.Windows.Forms.NumericUpDown();
            this.lblRpm12 = new System.Windows.Forms.Label();
            this.numRpm2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numTemp3 = new System.Windows.Forms.NumericUpDown();
            this.lblRpm14 = new System.Windows.Forms.Label();
            this.numRpm3 = new System.Windows.Forms.NumericUpDown();
            this.lblRpm15 = new System.Windows.Forms.Label();
            this.numPercent1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numPercent2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numPercent3 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numTemp1 = new System.Windows.Forms.NumericUpDown();
            this.lblRpm10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numFanMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFanMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFanMaxRpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFanMinRpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRpm1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRpm2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRpm3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemp1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFanMax
            // 
            this.lblFanMax.AutoSize = true;
            this.lblFanMax.Location = new System.Drawing.Point(8, 106);
            this.lblFanMax.Name = "lblFanMax";
            this.lblFanMax.Size = new System.Drawing.Size(44, 13);
            this.lblFanMax.TabIndex = 26;
            this.lblFanMax.Text = "PER02:";
            // 
            // lblFanMin
            // 
            this.lblFanMin.AutoSize = true;
            this.lblFanMin.Location = new System.Drawing.Point(8, 84);
            this.lblFanMin.Name = "lblFanMin";
            this.lblFanMin.Size = new System.Drawing.Size(44, 13);
            this.lblFanMin.TabIndex = 27;
            this.lblFanMin.Text = "PER01:";
            // 
            // numFanMax
            // 
            this.numFanMax.Location = new System.Drawing.Point(55, 104);
            this.numFanMax.Name = "numFanMax";
            this.numFanMax.Size = new System.Drawing.Size(78, 20);
            this.numFanMax.TabIndex = 1;
            // 
            // numFanMin
            // 
            this.numFanMin.Location = new System.Drawing.Point(55, 82);
            this.numFanMin.Name = "numFanMin";
            this.numFanMin.Size = new System.Drawing.Size(78, 20);
            this.numFanMin.TabIndex = 0;
            // 
            // lblFanMaxRpm
            // 
            this.lblFanMaxRpm.AutoSize = true;
            this.lblFanMaxRpm.Location = new System.Drawing.Point(278, 106);
            this.lblFanMaxRpm.Name = "lblFanMaxRpm";
            this.lblFanMaxRpm.Size = new System.Drawing.Size(46, 13);
            this.lblFanMaxRpm.TabIndex = 30;
            this.lblFanMaxRpm.Text = "RPM02:";
            // 
            // lblFanMinRpm
            // 
            this.lblFanMinRpm.AutoSize = true;
            this.lblFanMinRpm.Location = new System.Drawing.Point(278, 84);
            this.lblFanMinRpm.Name = "lblFanMinRpm";
            this.lblFanMinRpm.Size = new System.Drawing.Size(46, 13);
            this.lblFanMinRpm.TabIndex = 31;
            this.lblFanMinRpm.Text = "RPM01:";
            // 
            // numFanMaxRpm
            // 
            this.numFanMaxRpm.Location = new System.Drawing.Point(325, 104);
            this.numFanMaxRpm.Name = "numFanMaxRpm";
            this.numFanMaxRpm.Size = new System.Drawing.Size(78, 20);
            this.numFanMaxRpm.TabIndex = 29;
            // 
            // numFanMinRpm
            // 
            this.numFanMinRpm.Location = new System.Drawing.Point(325, 82);
            this.numFanMinRpm.Name = "numFanMinRpm";
            this.numFanMinRpm.Size = new System.Drawing.Size(78, 20);
            this.numFanMinRpm.TabIndex = 28;
            // 
            // numRpm1
            // 
            this.numRpm1.Location = new System.Drawing.Point(55, 1);
            this.numRpm1.Name = "numRpm1";
            this.numRpm1.Size = new System.Drawing.Size(78, 20);
            this.numRpm1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "RPM11:";
            // 
            // numTemp2
            // 
            this.numTemp2.DecimalPlaces = 2;
            this.numTemp2.Increment = new decimal(new int[] {
            3125,
            0,
            0,
            327680});
            this.numTemp2.Location = new System.Drawing.Point(191, 24);
            this.numTemp2.Name = "numTemp2";
            this.numTemp2.Size = new System.Drawing.Size(78, 20);
            this.numTemp2.TabIndex = 28;
            // 
            // lblRpm12
            // 
            this.lblRpm12.AutoSize = true;
            this.lblRpm12.Location = new System.Drawing.Point(142, 26);
            this.lblRpm12.Name = "lblRpm12";
            this.lblRpm12.Size = new System.Drawing.Size(45, 13);
            this.lblRpm12.TabIndex = 31;
            this.lblRpm12.Text = "TMP12:";
            // 
            // numRpm2
            // 
            this.numRpm2.Location = new System.Drawing.Point(191, 1);
            this.numRpm2.Name = "numRpm2";
            this.numRpm2.Size = new System.Drawing.Size(78, 20);
            this.numRpm2.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "RPM12:";
            // 
            // numTemp3
            // 
            this.numTemp3.DecimalPlaces = 2;
            this.numTemp3.Increment = new decimal(new int[] {
            3125,
            0,
            0,
            327680});
            this.numTemp3.Location = new System.Drawing.Point(325, 24);
            this.numTemp3.Name = "numTemp3";
            this.numTemp3.Size = new System.Drawing.Size(78, 20);
            this.numTemp3.TabIndex = 28;
            // 
            // lblRpm14
            // 
            this.lblRpm14.AutoSize = true;
            this.lblRpm14.Location = new System.Drawing.Point(276, 26);
            this.lblRpm14.Name = "lblRpm14";
            this.lblRpm14.Size = new System.Drawing.Size(45, 13);
            this.lblRpm14.TabIndex = 31;
            this.lblRpm14.Text = "TMP13:";
            // 
            // numRpm3
            // 
            this.numRpm3.Location = new System.Drawing.Point(325, 1);
            this.numRpm3.Name = "numRpm3";
            this.numRpm3.Size = new System.Drawing.Size(78, 20);
            this.numRpm3.TabIndex = 28;
            // 
            // lblRpm15
            // 
            this.lblRpm15.AutoSize = true;
            this.lblRpm15.Location = new System.Drawing.Point(276, 3);
            this.lblRpm15.Name = "lblRpm15";
            this.lblRpm15.Size = new System.Drawing.Size(46, 13);
            this.lblRpm15.TabIndex = 31;
            this.lblRpm15.Text = "RPM13:";
            // 
            // numPercent1
            // 
            this.numPercent1.Location = new System.Drawing.Point(55, 47);
            this.numPercent1.Name = "numPercent1";
            this.numPercent1.Size = new System.Drawing.Size(78, 20);
            this.numPercent1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "PER11:";
            // 
            // numPercent2
            // 
            this.numPercent2.Location = new System.Drawing.Point(191, 47);
            this.numPercent2.Name = "numPercent2";
            this.numPercent2.Size = new System.Drawing.Size(78, 20);
            this.numPercent2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "PER12:";
            // 
            // numPercent3
            // 
            this.numPercent3.Location = new System.Drawing.Point(325, 47);
            this.numPercent3.Name = "numPercent3";
            this.numPercent3.Size = new System.Drawing.Size(78, 20);
            this.numPercent3.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "PER13:";
            // 
            // numTemp1
            // 
            this.numTemp1.DecimalPlaces = 2;
            this.numTemp1.Increment = new decimal(new int[] {
            3125,
            0,
            0,
            327680});
            this.numTemp1.Location = new System.Drawing.Point(55, 24);
            this.numTemp1.Name = "numTemp1";
            this.numTemp1.Size = new System.Drawing.Size(78, 20);
            this.numTemp1.TabIndex = 1;
            // 
            // lblRpm10
            // 
            this.lblRpm10.AutoSize = true;
            this.lblRpm10.Location = new System.Drawing.Point(7, 26);
            this.lblRpm10.Name = "lblRpm10";
            this.lblRpm10.Size = new System.Drawing.Size(45, 13);
            this.lblRpm10.TabIndex = 26;
            this.lblRpm10.Text = "TMP11:";
            // 
            // UCFanRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFanMaxRpm);
            this.Controls.Add(this.lblRpm15);
            this.Controls.Add(this.lblRpm14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRpm12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFanMinRpm);
            this.Controls.Add(this.numFanMaxRpm);
            this.Controls.Add(this.numRpm3);
            this.Controls.Add(this.numTemp3);
            this.Controls.Add(this.numRpm2);
            this.Controls.Add(this.numTemp2);
            this.Controls.Add(this.numRpm1);
            this.Controls.Add(this.numFanMinRpm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRpm10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFanMax);
            this.Controls.Add(this.lblFanMin);
            this.Controls.Add(this.numPercent3);
            this.Controls.Add(this.numPercent2);
            this.Controls.Add(this.numTemp1);
            this.Controls.Add(this.numPercent1);
            this.Controls.Add(this.numFanMax);
            this.Controls.Add(this.numFanMin);
            this.Name = "UCFanRange";
            this.Size = new System.Drawing.Size(406, 137);
            ((System.ComponentModel.ISupportInitialize)(this.numFanMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFanMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFanMaxRpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFanMinRpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRpm1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRpm2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRpm3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemp1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    //    this.lblFanMax = new Label();
    //    this.lblFanMin = new Label();
    //    this.numFanMax = new NumericUpDown();
    //    this.numFanMin = new NumericUpDown();
    //    this.lblFanMaxRpm = new Label();
    //    this.lblFanMinRpm = new Label();
    //    this.numFanMaxRpm = new NumericUpDown();
    //    this.numFanMinRpm = new NumericUpDown();
    //    this.numRpm1 = new NumericUpDown();
    //    this.label1 = new Label();
    //    this.numTemp2 = new NumericUpDown();
    //    this.lblRpm12 = new Label();
    //    this.numRpm2 = new NumericUpDown();
    //    this.label3 = new Label();
    //    this.numTemp3 = new NumericUpDown();
    //    this.lblRpm14 = new Label();
    //    this.numRpm3 = new NumericUpDown();
    //    this.lblRpm15 = new Label();
    //    this.numPercent1 = new NumericUpDown();
    //    this.label4 = new Label();
    //    this.numPercent2 = new NumericUpDown();
    //    this.label5 = new Label();
    //    this.numPercent3 = new NumericUpDown();
    //    this.label6 = new Label();
    //    this.numTemp1 = new NumericUpDown();
    //    this.lblRpm10 = new Label();
    //    this.numFanMax.BeginInit();
    //    this.numFanMin.BeginInit();
    //    this.numFanMaxRpm.BeginInit();
    //    this.numFanMinRpm.BeginInit();
    //    this.numRpm1.BeginInit();
    //    this.numTemp2.BeginInit();
    //    this.numRpm2.BeginInit();
    //    this.numTemp3.BeginInit();
    //    this.numRpm3.BeginInit();
    //    this.numPercent1.BeginInit();
    //    this.numPercent2.BeginInit();
    //    this.numPercent3.BeginInit();
    //    this.numTemp1.BeginInit();
    //    this.SuspendLayout();
    //    this.lblFanMax.AutoSize = true;
    //    this.lblFanMax.Location = new Point(8, 106);
    //    this.lblFanMax.Name = "lblFanMax";
    //    this.lblFanMax.Size = new Size(44, 13);
    //    this.lblFanMax.TabIndex = 26;
    //    this.lblFanMax.Text = "PER02:";
    //    this.lblFanMin.AutoSize = true;
    //    this.lblFanMin.Location = new Point(8, 84);
    //    this.lblFanMin.Name = "lblFanMin";
    //    this.lblFanMin.Size = new Size(44, 13);
    //    this.lblFanMin.TabIndex = 27;
    //    this.lblFanMin.Text = "PER01:";
    //    this.numFanMax.Location = new Point(55, 104);
        
    //    //NumericUpDown numericUpDown1 = this.numFanMax;
    //    //int[] bits1 = new int[4];
    //    //bits1[0] = (int)byte.MaxValue;
    //    //Decimal num1 = new Decimal(bits1);
    //    //numericUpDown1.Maximum = num1;

    //    this.numFanMax.Name = "numFanMax";
    //    this.numFanMax.Size = new Size(78, 20);
    //    this.numFanMax.TabIndex = 1;
    //    this.numFanMin.Location = new Point(55, 82);
        
    //    //NumericUpDown numericUpDown2 = this.numFanMin;
    //    //int[] bits2 = new int[4];
    //    //bits2[0] = (int)byte.MaxValue;
    //    //Decimal num2 = new Decimal(bits2);
    //    //numericUpDown2.Maximum = num2;
        
    //    this.numFanMin.Name = "numFanMin";
    //    this.numFanMin.Size = new Size(78, 20);
    //    this.numFanMin.TabIndex = 0;
    //    this.lblFanMaxRpm.AutoSize = true;
    //    this.lblFanMaxRpm.Location = new Point(278, 106);
    //    this.lblFanMaxRpm.Name = "lblFanMaxRpm";
    //    this.lblFanMaxRpm.Size = new Size(46, 13);
    //    this.lblFanMaxRpm.TabIndex = 30;
    //    this.lblFanMaxRpm.Text = "RPM02:";
    //    this.lblFanMinRpm.AutoSize = true;
    //    this.lblFanMinRpm.Location = new Point(278, 84);
    //    this.lblFanMinRpm.Name = "lblFanMinRpm";
    //    this.lblFanMinRpm.Size = new Size(46, 13);
    //    this.lblFanMinRpm.TabIndex = 31;
    //    this.lblFanMinRpm.Text = "RPM01:";
    //    this.numFanMaxRpm.Location = new Point(325, 104);
        
    //    //NumericUpDown numericUpDown3 = this.numFanMaxRpm;
    //    //int[] bits3 = new int[4];
    //    //bits3[0] = (int)ushort.MaxValue;
    //    //Decimal num3 = new Decimal(bits3);
    //    //numericUpDown3.Maximum = num3;
        
    //    this.numFanMaxRpm.Name = "numFanMaxRpm";
    //    this.numFanMaxRpm.Size = new Size(78, 20);
    //    this.numFanMaxRpm.TabIndex = 29;
    //    this.numFanMinRpm.Location = new Point(325, 82);
        
    //    //NumericUpDown numericUpDown4 = this.numFanMinRpm;
    //    //int[] bits4 = new int[4];
    //    //bits4[0] = (int)ushort.MaxValue;
    //    //Decimal num4 = new Decimal(bits4);
    //    //numericUpDown4.Maximum = num4;
        
    //    this.numFanMinRpm.Name = "numFanMinRpm";
    //    this.numFanMinRpm.Size = new Size(78, 20);
    //    this.numFanMinRpm.TabIndex = 28;
    //    this.numRpm1.Location = new Point(55, 1);
        
    //    //NumericUpDown numericUpDown5 = this.numRpm1;
    //    //int[] bits5 = new int[4];
    //    //bits5[0] = (int)ushort.MaxValue;
    //    //Decimal num5 = new Decimal(bits5);
    //    //numericUpDown5.Maximum = num5;
        
    //    this.numRpm1.Name = "numRpm1";
    //    this.numRpm1.Size = new Size(78, 20);
    //    this.numRpm1.TabIndex = 28;
    //    this.label1.AutoSize = true;
    //    this.label1.Location = new Point(6, 3);
    //    this.label1.Name = "label1";
    //    this.label1.Size = new Size(46, 13);
    //    this.label1.TabIndex = 31;
    //    this.label1.Text = "RPM11:";
    //    this.numTemp2.DecimalPlaces = 2;
    //    this.numTemp2.Increment = new Decimal(new int[4]
    //{
    //  3125,
    //  0,
    //  0,
    //  327680
    //});
    //    this.numTemp2.Location = new Point(191, 24);
        
    //    //NumericUpDown numericUpDown6 = this.numTemp2;
    //    //int[] bits6 = new int[4];
    //    //bits6[0] = (int)sbyte.MaxValue;
    //    //Decimal num6 = new Decimal(bits6);
    //    //numericUpDown6.Maximum = num6;
        
    //    this.numTemp2.Name = "numTemp2";
    //    this.numTemp2.Size = new Size(78, 20);
    //    this.numTemp2.TabIndex = 28;
    //    this.lblRpm12.AutoSize = true;
    //    this.lblRpm12.Location = new Point(142, 26);
    //    this.lblRpm12.Name = "lblRpm12";
    //    this.lblRpm12.Size = new Size(45, 13);
    //    this.lblRpm12.TabIndex = 31;
    //    this.lblRpm12.Text = "TMP12:";
    //    this.numRpm2.Location = new Point(191, 1);
        
    //    //NumericUpDown numericUpDown7 = this.numRpm2;
    //    //int[] bits7 = new int[4];
    //    //bits7[0] = (int)ushort.MaxValue;
    //    //Decimal num7 = new Decimal(bits7);
    //    //numericUpDown7.Maximum = num7;

    //    this.numRpm2.Name = "numRpm2";
    //    this.numRpm2.Size = new Size(78, 20);
    //    this.numRpm2.TabIndex = 28;
    //    this.label3.AutoSize = true;
    //    this.label3.Location = new Point(141, 3);
    //    this.label3.Name = "label3";
    //    this.label3.Size = new Size(46, 13);
    //    this.label3.TabIndex = 31;
    //    this.label3.Text = "RPM12:";
    //    this.numTemp3.DecimalPlaces = 2;
    //    this.numTemp3.Increment = new Decimal(new int[4]
    //{
    //  3125,
    //  0,
    //  0,
    //  327680
    //});
    //    this.numTemp3.Location = new Point(325, 24);
        
    //    //NumericUpDown numericUpDown8 = this.numTemp3;
    //    //int[] bits8 = new int[4];
    //    //bits8[0] = (int)sbyte.MaxValue;
    //    //Decimal num8 = new Decimal(bits8);
    //    //numericUpDown8.Maximum = num8;
        
    //    this.numTemp3.Name = "numTemp3";
    //    this.numTemp3.Size = new Size(78, 20);
    //    this.numTemp3.TabIndex = 28;
    //    this.lblRpm14.AutoSize = true;
    //    this.lblRpm14.Location = new Point(276, 26);
    //    this.lblRpm14.Name = "lblRpm14";
    //    this.lblRpm14.Size = new Size(45, 13);
    //    this.lblRpm14.TabIndex = 31;
    //    this.lblRpm14.Text = "TMP13:";
    //    this.numRpm3.Location = new Point(325, 1);
        
    //    //NumericUpDown numericUpDown9 = this.numRpm3;
    //    //int[] bits9 = new int[4];
    //    //bits9[0] = (int)ushort.MaxValue;
    //    //Decimal num9 = new Decimal(bits9);
    //    //numericUpDown9.Maximum = num9;
        
    //    this.numRpm3.Name = "numRpm3";
    //    this.numRpm3.Size = new Size(78, 20);
    //    this.numRpm3.TabIndex = 28;
    //    this.lblRpm15.AutoSize = true;
    //    this.lblRpm15.Location = new Point(276, 3);
    //    this.lblRpm15.Name = "lblRpm15";
    //    this.lblRpm15.Size = new Size(46, 13);
    //    this.lblRpm15.TabIndex = 31;
    //    this.lblRpm15.Text = "RPM13:";
    //    this.numPercent1.Location = new Point(55, 47);
        
    //    //NumericUpDown numericUpDown10 = this.numPercent1;
    //    //int[] bits10 = new int[4];
    //    //bits10[0] = (int)byte.MaxValue;
    //    //Decimal num10 = new Decimal(bits10);
    //    //numericUpDown10.Maximum = num10;
        
    //    this.numPercent1.Name = "numPercent1";
    //    this.numPercent1.Size = new Size(78, 20);
    //    this.numPercent1.TabIndex = 1;
    //    this.label4.AutoSize = true;
    //    this.label4.Location = new Point(8, 49);
    //    this.label4.Name = "label4";
    //    this.label4.Size = new Size(44, 13);
    //    this.label4.TabIndex = 26;
    //    this.label4.Text = "PER11:";
    //    this.numPercent2.Location = new Point(191, 47);
        
    //    //NumericUpDown numericUpDown11 = this.numPercent2;
    //    //int[] bits11 = new int[4];
    //    //bits11[0] = (int)byte.MaxValue;
    //    //Decimal num11 = new Decimal(bits11);
    //    //numericUpDown11.Maximum = num11;
        
    //    this.numPercent2.Name = "numPercent2";
    //    this.numPercent2.Size = new Size(78, 20);
    //    this.numPercent2.TabIndex = 1;
    //    this.label5.AutoSize = true;
    //    this.label5.Location = new Point(143, 49);
    //    this.label5.Name = "label5";
    //    this.label5.Size = new Size(44, 13);
    //    this.label5.TabIndex = 26;
    //    this.label5.Text = "PER12:";
    //    this.numPercent3.Location = new Point(325, 47);
        
    //    //NumericUpDown numericUpDown12 = this.numPercent3;
    //    //int[] bits12 = new int[4];
    //    //bits12[0] = (int)byte.MaxValue;
    //    //Decimal num12 = new Decimal(bits12);
    //    //numericUpDown12.Maximum = num12;
        
    //    this.numPercent3.Name = "numPercent3";
    //    this.numPercent3.Size = new Size(78, 20);
    //    this.numPercent3.TabIndex = 1;
    //    this.label6.AutoSize = true;
    //    this.label6.Location = new Point(278, 49);
    //    this.label6.Name = "label6";
    //    this.label6.Size = new Size(44, 13);
    //    this.label6.TabIndex = 26;
    //    this.label6.Text = "PER13:";
    //    this.numTemp1.DecimalPlaces = 2;
    //    this.numTemp1.Increment = new Decimal(new int[4]
    //{
    //  3125,
    //  0,
    //  0,
    //  327680
    //});
    //    this.numTemp1.Location = new Point(55, 24);
        
    //    //NumericUpDown numericUpDown13 = this.numTemp1;
    //    //int[] bits13 = new int[4];
    //    //bits13[0] = (int)sbyte.MaxValue;
    //    //Decimal num13 = new Decimal(bits13);
    //    //numericUpDown13.Maximum = num13;
        
    //    this.numTemp1.Name = "numTemp1";
    //    this.numTemp1.Size = new Size(78, 20);
    //    this.numTemp1.TabIndex = 1;
    //    this.lblRpm10.AutoSize = true;
    //    this.lblRpm10.Location = new Point(7, 26);
    //    this.lblRpm10.Name = "lblRpm10";
    //    this.lblRpm10.Size = new Size(45, 13);
    //    this.lblRpm10.TabIndex = 26;
    //    this.lblRpm10.Text = "TMP11:";
    //    this.AutoScaleDimensions = new SizeF(6f, 13f);
    //    //this.AutoScaleMode = AutoScaleMode.Font;
    //    this.Controls.Add((Control)this.lblFanMaxRpm);
    //    this.Controls.Add((Control)this.lblRpm15);
    //    this.Controls.Add((Control)this.lblRpm14);
    //    this.Controls.Add((Control)this.label3);
    //    this.Controls.Add((Control)this.lblRpm12);
    //    this.Controls.Add((Control)this.label1);
    //    this.Controls.Add((Control)this.lblFanMinRpm);
    //    this.Controls.Add((Control)this.numFanMaxRpm);
    //    this.Controls.Add((Control)this.numRpm3);
    //    this.Controls.Add((Control)this.numTemp3);
    //    this.Controls.Add((Control)this.numRpm2);
    //    this.Controls.Add((Control)this.numTemp2);
    //    this.Controls.Add((Control)this.numRpm1);
    //    this.Controls.Add((Control)this.numFanMinRpm);
    //    this.Controls.Add((Control)this.label6);
    //    this.Controls.Add((Control)this.label5);
    //    this.Controls.Add((Control)this.lblRpm10);
    //    this.Controls.Add((Control)this.label4);
    //    this.Controls.Add((Control)this.lblFanMax);
    //    this.Controls.Add((Control)this.lblFanMin);
    //    this.Controls.Add((Control)this.numPercent3);
    //    this.Controls.Add((Control)this.numPercent2);
    //    this.Controls.Add((Control)this.numTemp1);
    //    this.Controls.Add((Control)this.numPercent1);
    //    this.Controls.Add((Control)this.numFanMax);
    //    this.Controls.Add((Control)this.numFanMin);
    //    this.Name = "FanRangeControl";
    //    this.Size = new Size(406, 137);
    //    this.numFanMax.EndInit();
    //    this.numFanMin.EndInit();
    //    this.numFanMaxRpm.EndInit();
    //    this.numFanMinRpm.EndInit();
    //    this.numRpm1.EndInit();
    //    this.numTemp2.EndInit();
    //    this.numRpm2.EndInit();
    //    this.numTemp3.EndInit();
    //    this.numRpm3.EndInit();
    //    this.numPercent1.EndInit();
    //    this.numPercent2.EndInit();
    //    this.numPercent3.EndInit();
    //    this.numTemp1.EndInit();
    //    this.ResumeLayout(false);
    //    this.PerformLayout();


}
