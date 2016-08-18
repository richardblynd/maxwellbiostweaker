// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class UCPerfTableControl : UserControl, ComponenteDaTela
{
    private List<UCPerfTableEntryControl> _EntryControlList = new List<UCPerfTableEntryControl>();
    private PerfTable _PerfTable;
    private IContainer components;
    private UCPerfTableEntryControl perfTableEntryControl1;
    private Label lblTopSpace;

    internal PerfTable PerfTable
    {
        get
        {
            return this._PerfTable;
        }
        set
        {
            this.Reset();
            this._PerfTable = value;
            this.UpdateData();
        }
    }

    public event EventHandler AnyTextChanged;

    public UCPerfTableControl()
    {
        this.InitializeComponent();
    }

    public bool AreP0AndP2MMemoryClocksSame()
    {
        List<UCPerfTableEntryControl> list = Enumerable.ToList<UCPerfTableEntryControl>(Enumerable.Where<UCPerfTableEntryControl>(this._EntryControlList, e =>
        {
            if (e.PerfEntry != null)
                return Enumerable.Contains<byte>(new byte[1], e.PerfEntry.Caption);
            return false;
        }));
        if (list.Count == 1)
            return true;
        if (list.Count <= 1)
            return false;
        uint memoryClock = list[0].GetMemoryClock();
        uint num1 = memoryClock;
        int num2 = 1;
        foreach (UCPerfTableEntryControl obj in list)
        {
            num1 += obj.GetMemoryClock();
            ++num2;
        }
        return num1 / num2 == memoryClock;
    }

    public uint GetP0AndP2MemoryClock()
    {
        if (!this.AreP0AndP2MMemoryClocksSame())
            return 0U;
        UCPerfTableEntryControl obj = Enumerable.FirstOrDefault<UCPerfTableEntryControl>(Enumerable.Where<UCPerfTableEntryControl>(this._EntryControlList, e =>
        {
            if (e.PerfEntry != null)
                return Enumerable.Contains<byte>(new byte[1], e.PerfEntry.Caption);
            return false;
        }));
        if (obj == null)
            return 0U;
        return obj.GetMemoryClock();
    }

    public void SetP0AndP2MemoryClock(uint clock)
    {
        if (!this.AreP0AndP2MMemoryClocksSame())
            return;
        foreach (UCPerfTableEntryControl obj in Enumerable.ToList<UCPerfTableEntryControl>(Enumerable.Where<UCPerfTableEntryControl>(this._EntryControlList, e =>
        {
            if (e.PerfEntry != null)
                return Enumerable.Contains<byte>(new byte[1], e.PerfEntry.Caption);
            return false;
        })))
            obj.SetMemoryClock(clock);
    }

    public void ApplyChanges()
    {
        if (this.PerfTable == null)
            return;
        foreach (UCPerfTableEntryControl obj in this._EntryControlList)
            obj.ApplyChanges();
    }

    public void Reset()
    {
        this.AnyTextChanged = null;
        this._PerfTable = null;
        this.InternalReset();
    }

    private void InternalReset()
    {
        foreach (UCPerfTableEntryControl obj in this._EntryControlList)
            obj.Reset();
        this.Controls.Clear();
        this.Enabled = false;
    }

    private void UpdateData()
    {
        this.InternalReset();
        if (this.PerfTable == null)
            return;
        this.Enabled = true;
        int num = this.lblTopSpace.Top + this.lblTopSpace.Height + 1;
        this._EntryControlList = new List<UCPerfTableEntryControl>();
        foreach (Voltage obj1 in Enumerable.ToList<Voltage>(Enumerable.OrderBy<Voltage, byte>(Enumerable.Where<Voltage>(this.PerfTable.Voltages, e => !e.PE004), e => e.Caption)))
        {
            UCPerfTableEntryControl obj2 = new UCPerfTableEntryControl();
            obj2.PerfEntry = obj1;
            obj2.Left = 0;
            obj2.Top = num;
            obj2.OnAnyTextChanged += new EventHandler(this.ctrl_OnAnyTextChanged);
            this.Controls.Add(obj2);
            this._EntryControlList.Add(obj2);
            num += obj2.Height;
        }
    }

    private void ctrl_OnAnyTextChanged(object sender, EventArgs e)
    {
        if (this.AnyTextChanged == null)
            return;
        this.AnyTextChanged(sender, e);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.perfTableEntryControl1 = new UCPerfTableEntryControl();
        this.lblTopSpace = new Label();
        this.SuspendLayout();
        this.perfTableEntryControl1.Location = new Point(0, 17);
        this.perfTableEntryControl1.Name = "perfTableEntryControl1";
        this.perfTableEntryControl1.Size = new Size(411, 55);
        this.perfTableEntryControl1.TabIndex = 0;
        this.lblTopSpace.AutoSize = true;
        this.lblTopSpace.Location = new Point(115, 0);
        this.lblTopSpace.Name = "lblTopSpace";
        this.lblTopSpace.Size = new Size(24, 13);
        this.lblTopSpace.TabIndex = 76;
        this.lblTopSpace.Text = "Min";
        this.lblTopSpace.Visible = false;
        this.AutoScaleDimensions = new SizeF(6f, 13f);
        //this.AutoScaleMode = AutoScaleMode.Font;
        this.Controls.Add(this.lblTopSpace);
        this.Controls.Add(this.perfTableEntryControl1);
        this.Name = "PerfTableControl";
        this.Size = new Size(416, 238);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
