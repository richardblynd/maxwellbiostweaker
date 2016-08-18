// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class UCTempTargets : UserControl, ComponenteDaTela
{
    private TempTargets _TempTargets;
    private IContainer components;
    private NumericUpDown numDefault;
    private Label lblDefault;
    private NumericUpDown numMax;
    private Label lblMax;

    internal TempTargets TempTargets
    {
        get
        {
            return this._TempTargets;
        }
        set
        {
            this._TempTargets = value;
            this.UpdateData();
        }
    }

    public UCTempTargets()
    {
        this.InitializeComponent();
        
        NumericUpDown numericUpDown1 = this.numDefault;
        int[] bits1 = new int[4];
        bits1[0] = sbyte.MaxValue;
        Decimal num1 = new Decimal(bits1);
        numericUpDown1.Maximum = num1;

        
        NumericUpDown numericUpDown2 = this.numMax;
        int[] bits2 = new int[4];
        bits2[0] = sbyte.MaxValue;
        Decimal num2 = new Decimal(bits2);
        numericUpDown2.Maximum = num2;
    }

    public void ApplyChanges()
    {
        if (this.TempTargets == null || !this.TempTargets.PE001)
            return;
        this.TempTargets.E002 = Convert.ToUInt16(this.numDefault.Value * new Decimal(32));
        this.TempTargets.E004 = Convert.ToUInt16(this.numMax.Value * new Decimal(32));
    }

    public void Reset()
    {
        this.TempTargets = null;
        this.InternalReset();
    }

    private void InternalReset()
    {
        this.numDefault.Minimum = new Decimal(0);
        this.numDefault.Value = new Decimal(0);
        this.numMax.Minimum = new Decimal(0);
        this.numMax.Value = new Decimal(0);
        this.Enabled = false;
    }

    private void UpdateData()
    {
        this.InternalReset();
        if (this.TempTargets == null || !this.TempTargets.PE001)
            return;
        this.Enabled = true;
        this.numDefault.Value = this.TempTargets.E002 / new Decimal(32);
        this.numDefault.Minimum = this.TempTargets.E003 / new Decimal(32);
        this.numMax.Value = this.TempTargets.E004 / new Decimal(32);
        this.numMax.Minimum = this.TempTargets.E003 / new Decimal(32);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.numDefault = new System.Windows.Forms.NumericUpDown();
            this.lblDefault = new System.Windows.Forms.Label();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.lblMax = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            this.SuspendLayout();
            // 
            // numDefault
            // 
            this.numDefault.DecimalPlaces = 2;
            this.numDefault.Increment = new decimal(new int[] {
            3125,
            0,
            0,
            327680});
            this.numDefault.Location = new System.Drawing.Point(103, 3);
            this.numDefault.Name = "numDefault";
            this.numDefault.Size = new System.Drawing.Size(85, 20);
            this.numDefault.TabIndex = 28;
            // 
            // lblDefault
            // 
            this.lblDefault.AutoSize = true;
            this.lblDefault.Location = new System.Drawing.Point(3, 5);
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(71, 13);
            this.lblDefault.TabIndex = 31;
            this.lblDefault.Text = "Temp Target:";
            // 
            // numMax
            // 
            this.numMax.DecimalPlaces = 2;
            this.numMax.Increment = new decimal(new int[] {
            3125,
            0,
            0,
            327680});
            this.numMax.Location = new System.Drawing.Point(314, 3);
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(86, 20);
            this.numMax.TabIndex = 28;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(217, 5);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(94, 13);
            this.lblMax.TabIndex = 31;
            this.lblMax.Text = "Max Temp Target:";
            // 
            // UCTempTargets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblDefault);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.numDefault);
            this.Name = "UCTempTargets";
            this.Size = new System.Drawing.Size(406, 25);
            ((System.ComponentModel.ISupportInitialize)(this.numDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        //this.numDefault = new NumericUpDown();
        //this.lblDefault = new Label();
        //this.numMax = new NumericUpDown();
        //this.lblMax = new Label();
        //this.numDefault.BeginInit();
        //this.numMax.BeginInit();
        //this.SuspendLayout();
        //this.numDefault.DecimalPlaces = 2;
        //this.numDefault.Increment = new Decimal(new int[4]
        //{
        //    3125,
        //    0,
        //    0,
        //    327680
        //});
        
        //this.numDefault.Location = new Point(103, 3);
        //NumericUpDown numericUpDown1 = this.numDefault;
        //int[] bits1 = new int[4];
        //bits1[0] = (int)sbyte.MaxValue;
        //Decimal num1 = new Decimal(bits1);
        
        ////numericUpDown1.Maximum = num1;
        
        //this.numDefault.Name = "numDefault";
        //this.numDefault.Size = new Size(85, 20);
        //this.numDefault.TabIndex = 28;
        //this.lblDefault.AutoSize = true;
        //this.lblDefault.Location = new Point(3, 5);
        //this.lblDefault.Name = "lblDefault";
        //this.lblDefault.Size = new Size(71, 13);
        //this.lblDefault.TabIndex = 31;
        //this.lblDefault.Text = "Temp Target:";
        //this.numMax.DecimalPlaces = 2;
        //this.numMax.Increment = new Decimal(new int[4]
        //{
        //    3125,
        //    0,
        //    0,
        //    327680
        //});
        
        //this.numMax.Location = new Point(314, 3);
        //NumericUpDown numericUpDown2 = this.numMax;
        //int[] bits2 = new int[4];
        //bits2[0] = (int)sbyte.MaxValue;
        //Decimal num2 = new Decimal(bits2);
        
        ////numericUpDown2.Maximum = num2;
        
        //this.numMax.Name = "numMax";
        //this.numMax.Size = new Size(86, 20);
        //this.numMax.TabIndex = 28;
        //this.lblMax.AutoSize = true;
        //this.lblMax.Location = new Point(217, 5);
        //this.lblMax.Name = "lblMax";
        //this.lblMax.Size = new Size(94, 13);
        //this.lblMax.TabIndex = 31;
        //this.lblMax.Text = "Max Temp Target:";
        //this.AutoScaleDimensions = new SizeF(6f, 13f);
        
        ////this.AutoScaleMode = AutoScaleMode.Font;
        
        //this.Controls.Add((Control)this.lblMax);
        //this.Controls.Add((Control)this.lblDefault);
        //this.Controls.Add((Control)this.numMax);
        //this.Controls.Add((Control)this.numDefault);
        //this.Name = "TempTargetControl";
        //this.Size = new Size(406, 25);
        //this.numDefault.EndInit();
        //this.numMax.EndInit();
        //this.ResumeLayout(false);
        //this.PerformLayout();
    
}
