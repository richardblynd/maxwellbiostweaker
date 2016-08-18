// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class UCVoltageLine : UserControl, ComponenteDaTela
{
    private ToolTip tooltip = new ToolTip();
    private List<uint> _VoltageLookup = CE013.PE000;
    private VoltageEntry _VoltageEntry;
    private IContainer components;
    private TrackBar trbSliderMin;
    private Label lValueCaption;
    private Label lblValueText;
    private TrackBar trbSliderMax;
    private CheckBox cbFixed;

    public string Caption
    {
        set
        {
            this.tooltip.SetToolTip(this.lValueCaption, value);
            this.lValueCaption.Text = this.CropCaption(value);
        }
    }

    internal VoltageEntry VoltageEntry
    {
        get
        {
            return this._VoltageEntry;
        }
        set
        {
            this._VoltageEntry = value;
            this.UpdateData();
        }
    }

    public UCVoltageLine()
    {
        this.InitializeComponent();
        this.tooltip.ShowAlways = true;
        this.tooltip.AutomaticDelay = 0;
        this.tooltip.ReshowDelay = 0;
    }

    private void SetVoltage(int indexMin, int indexMax, VoltageEntry targetEntry)
    {
        if (indexMin <= 0 || indexMax <= 0 || (indexMin >= this._VoltageLookup.Count || indexMax >= this._VoltageLookup.Count))
            return;
        targetEntry.From = this._VoltageLookup[indexMin];
        targetEntry.To = this._VoltageLookup[indexMax];
    }

    private void SetFixedVoltage(int indexMin, VoltageEntry targetEntry)
    {
        if (indexMin <= 0 || indexMin >= this._VoltageLookup.Count)
            return;
        targetEntry.E000(this._VoltageLookup[indexMin]);
    }

    private int GetVoltageIndexMin(VoltageEntry sourceEntry)
    {
        for (int index = 1; index < this._VoltageLookup.Count; ++index)
        {
            if ((int)this._VoltageLookup[index] == (int)sourceEntry.From)
                return index;
        }
        return 0;
    }

    private int GetVoltageIndexMax(VoltageEntry sourceEntry)
    {
        for (int index = 1; index < this._VoltageLookup.Count; ++index)
        {
            if ((int)this._VoltageLookup[index] == (int)sourceEntry.To)
                return index;
        }
        return 0;
    }

    private string GetVoltageString(int indexMin, int indexMax)
    {
        NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
        numberFormatInfo.NumberDecimalSeparator = ".";
        return string.Format("{0}mV - {1}mV", (this._VoltageLookup[indexMin] / 1000f).ToString("#.0", numberFormatInfo), (this._VoltageLookup[indexMax] / 1000f).ToString("#.0", numberFormatInfo));
    }

    private string CropCaption(string caption)
    {
        if (caption.Length < 7)
            return caption;
        return caption.Substring(0, 5) + "..";
    }

    public void Reset()
    {
        this.VoltageEntry = null;
        this.InternalReset();
    }

    private void InternalReset()
    {
        this.cbFixed.Checked = false;
        this.cbFixed.Visible = false;
        this.trbSliderMin.Maximum = this._VoltageLookup.Count - 1;
        this.trbSliderMax.Maximum = this._VoltageLookup.Count - 1;
        this.trbSliderMin.Value = 0;
        this.trbSliderMax.Value = 0;
        this.lblValueText.Text = "";
        this.Enabled = false;
    }

    public void ApplyChanges()
    {
        if (this.VoltageEntry == null)
            return;
        if (this.cbFixed.Checked)
            this.SetFixedVoltage(this.trbSliderMin.Value, this.VoltageEntry);
        else
            this.SetVoltage(this.trbSliderMin.Value, this.trbSliderMax.Value, this.VoltageEntry);
    }

    private void UpdateData()
    {
        this.InternalReset();
        if (this.VoltageEntry == null)
            return;
        this.Enabled = true;

        if (this.VoltageEntry.PE007 || this.VoltageEntry.PE006)
        {
            this.cbFixed.Checked = true;
            this.cbFixed.Visible = true;
        }

        this.trbSliderMax.Value = this.GetVoltageIndexMax(this.VoltageEntry);
        this.trbSliderMin.Value = this.GetVoltageIndexMin(this.VoltageEntry);
        this.lblValueText.Text = this.GetVoltageString(this.trbSliderMin.Value, this.trbSliderMax.Value);
    }

    private void trbSliderMin_Scroll(object sender, EventArgs e)
    {
        if (this.cbFixed.Checked)
            this.trbSliderMax.Value = this.trbSliderMin.Value;
        this.lblValueText.Text = this.GetVoltageString(this.trbSliderMin.Value, this.trbSliderMax.Value);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.trbSliderMin = new System.Windows.Forms.TrackBar();
        this.lValueCaption = new System.Windows.Forms.Label();
        this.lblValueText = new System.Windows.Forms.Label();
        this.trbSliderMax = new System.Windows.Forms.TrackBar();
        this.cbFixed = new System.Windows.Forms.CheckBox();
        ((System.ComponentModel.ISupportInitialize)(this.trbSliderMin)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.trbSliderMax)).BeginInit();
        this.SuspendLayout();
        // 
        // trbSliderMin
        // 
        this.trbSliderMin.AutoSize = false;
        this.trbSliderMin.Location = new System.Drawing.Point(165, -1);
        this.trbSliderMin.Maximum = 97;
        this.trbSliderMin.Name = "trbSliderMin";
        this.trbSliderMin.Size = new System.Drawing.Size(124, 32);
        this.trbSliderMin.TabIndex = 28;
        this.trbSliderMin.Value = 67;
        this.trbSliderMin.Scroll += new System.EventHandler(this.trbSliderMin_Scroll);
        // 
        // lValueCaption
        // 
        this.lValueCaption.AutoSize = true;
        this.lValueCaption.Location = new System.Drawing.Point(2, 7);
        this.lValueCaption.Name = "lValueCaption";
        this.lValueCaption.Size = new System.Drawing.Size(43, 13);
        this.lValueCaption.TabIndex = 29;
        this.lValueCaption.Text = "Voltage";
        // 
        // lblValueText
        // 
        this.lblValueText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.lblValueText.Location = new System.Drawing.Point(49, 4);
        this.lblValueText.Name = "lblValueText";
        this.lblValueText.Size = new System.Drawing.Size(117, 20);
        this.lblValueText.TabIndex = 30;
        this.lblValueText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // trbSliderMax
        // 
        this.trbSliderMax.AutoSize = false;
        this.trbSliderMax.Location = new System.Drawing.Point(283, -1);
        this.trbSliderMax.Maximum = 97;
        this.trbSliderMax.Name = "trbSliderMax";
        this.trbSliderMax.Size = new System.Drawing.Size(116, 32);
        this.trbSliderMax.TabIndex = 28;
        this.trbSliderMax.Value = 67;
        this.trbSliderMax.Scroll += new System.EventHandler(this.trbSliderMin_Scroll);
        // 
        // cbFixed
        // 
        this.cbFixed.Enabled = false;
        this.cbFixed.Location = new System.Drawing.Point(291, -1);
        this.cbFixed.Name = "cbFixed";
        this.cbFixed.Size = new System.Drawing.Size(100, 32);
        this.cbFixed.TabIndex = 31;
        this.cbFixed.Text = "Fixed Voltage";
        this.cbFixed.UseVisualStyleBackColor = true;
        // 
        // CE00A
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.cbFixed);
        this.Controls.Add(this.trbSliderMax);
        this.Controls.Add(this.trbSliderMin);
        this.Controls.Add(this.lValueCaption);
        this.Controls.Add(this.lblValueText);
        this.Name = "CE00A";
        this.Size = new System.Drawing.Size(393, 31);
        ((System.ComponentModel.ISupportInitialize)(this.trbSliderMin)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.trbSliderMax)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }
}
