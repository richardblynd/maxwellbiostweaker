// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class CE033 : UserControl, ComponenteDaTela
{
    private readonly List<uint> _VoltageLookup;
    private VoltageEntry _VoltageEntry;
    private IContainer components;
    private BoostLimit scVoltage;

    public string Caption
    {
        get
        {
            return this.scVoltage.Caption;
        }
        set
        {
            this.scVoltage.Caption = value;
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

    public CE033()
    {
        this.InitializeComponent();
        this._VoltageLookup = this.GetVoltageLookup();
    }

    private List<uint> GetVoltageLookup()
    {
        List<uint> list = new List<uint>();
        list.Add(0U);
        uint num1 = 1225000U;
        if (CE035.E000)
            num1 = 1325000U;
        uint num2 = 825000U;
        while (num2 < num1)
        {
            list.Add(num2);
            num2 += 12500U;
        }
        return list;
    }

    private void SetVoltage(int index, VoltageEntry targetEntry)
    {
        if (index <= 0 || index >= this._VoltageLookup.Count)
            return;
        targetEntry.E000(this._VoltageLookup[index]);
    }

    private int GetVoltageIndex(VoltageEntry sourceEntry)
    {
        if (sourceEntry.PE006 || sourceEntry.PE007)
        {
            for (int index = 1; index < this._VoltageLookup.Count; ++index)
            {
                if ((int)this._VoltageLookup[index] == (int)sourceEntry.From)
                    return index;
            }
        }
        return 0;
    }

    private string GetVoltageString(int index)
    {
        NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
        numberFormatInfo.NumberDecimalSeparator = ".";
        if (index != 0)
            return string.Format("{0} mV", (this._VoltageLookup[index] / 1000f).ToString("#.0", numberFormatInfo));
        if (this.VoltageEntry != null && !this.VoltageEntry.PE007 && !this.VoltageEntry.PE006)
            return string.Format("{0}-{1}", (this.VoltageEntry.From / 1000f).ToString("#.0", numberFormatInfo), (this.VoltageEntry.To / 1000f).ToString("#.0", numberFormatInfo));
        return "Keep Value";
    }

    public void Reset()
    {
        this.VoltageEntry = null;
        this.InternalReset();
    }

    private void InternalReset()
    {
        this.scVoltage.SliderMaximum = this._VoltageLookup.Count - 1;
        this.scVoltage.SliderPosition = 0;
        this.scVoltage.ValueText = "";
        this.Enabled = false;
    }

    public void ApplyChanges()
    {
        if (this.VoltageEntry == null)
            return;
        this.SetVoltage(this.scVoltage.SliderPosition, this.VoltageEntry);
    }

    private void UpdateData()
    {
        this.InternalReset();
        if (this.VoltageEntry == null)
            return;
        if (CE035.E000)
            this.Enabled = true;
        else
            this.Enabled = !this.VoltageEntry.PE001;
        this.scVoltage.SliderPosition = this.GetVoltageIndex(this.VoltageEntry);
    }

    private void scVoltage_OnScroll(object sender, EventArgs e)
    {
        this.scVoltage.ValueText = this.GetVoltageString(this.scVoltage.SliderPosition);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.scVoltage = new BoostLimit();
        this.SuspendLayout();
        // 
        // scVoltage
        // 
        this.scVoltage.Caption = "Max Voltage";
        this.scVoltage.Location = new System.Drawing.Point(-2, 0);
        this.scVoltage.Name = "scVoltage";
        this.scVoltage.Size = new System.Drawing.Size(413, 26);
        this.scVoltage.SliderMaximum = 97;
        this.scVoltage.SliderPosition = 67;
        this.scVoltage.TabIndex = 0;
        this.scVoltage.ValueText = "";
        this.scVoltage.ValueTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.scVoltage.OnScroll += new System.EventHandler(this.scVoltage_OnScroll);
        // 
        // CE033
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.scVoltage);
        this.Name = "CE033";
        this.Size = new System.Drawing.Size(411, 27);
        this.ResumeLayout(false);

    }
}
