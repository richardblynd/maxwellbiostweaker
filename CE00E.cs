// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class UCBoostConfigControl : UserControl, ComponenteDaTela
{
    private List<UCboostConfigEntryControl> _EntryControlList = new List<UCboostConfigEntryControl>();
    private BoostProfile _BoostProfile;
    private IContainer components;
    private Label lblMax1;
    private Label lblMin1;
    private UCboostConfigEntryControl boostConfigEntryControl1;
    private Label lblMin2;
    private Label lblMax2;

    internal BoostProfile BoostProfile
    {
        get
        {
            return _BoostProfile;
        }
        set
        {
            Reset();
            _BoostProfile = value;
            UpdateData();
        }
    }

    public event EventHandler AnyTextChanged;

    public UCBoostConfigControl()
    {
        InitializeComponent();
    }

    public void ApplyChanges()
    {
        if (BoostProfile == null)
            return;
        
        foreach (UCboostConfigEntryControl obj in _EntryControlList)
            obj.ApplyChanges();
    }

    public void Reset()
    {
        _BoostProfile = null;
        AnyTextChanged = null;
        InternalReset();
    }

    private void InternalReset()
    {
        foreach (UCboostConfigEntryControl obj in _EntryControlList)
            obj.Reset();
        for (int index = Controls.Count - 1; index >= 0; --index)
        {
            if (Controls[index] is UCboostConfigEntryControl)
                Controls.RemoveAt(index);
        }
        Enabled = false;
    }

    public bool AreP0AndP2MaxClocksSame()
    {
        foreach (UCboostConfigEntryControl obj in _EntryControlList.Where(e =>
        {
            if (e.BoostProfileEntry == null)
                return false;
            return new byte[2]
            {
                0,
                2
            }.Contains(e.BoostProfileEntry.PE002);
        }))
        {
            if (!obj.AreAllMaxClocksEqual())
                return false;
        }
        return true;
    }

    public ushort GetP0AndP2MaxClock()
    {
        if (!AreP0AndP2MaxClocksSame())
            return 0;
        
        UCboostConfigEntryControl obj = _EntryControlList.Where(e =>
        {
            if (e.BoostProfileEntry != null)
                return (int)e.BoostProfileEntry.PE002 == 0;
            return false;
        }).FirstOrDefault();
        
        if (obj == null)
            return 0;
        
        return obj.GetAllMaxClock();
    }

    public void SetP0AndP2MaxClock(ushort clock)
    {
        if (!AreP0AndP2MaxClocksSame())
            return;

        foreach (UCboostConfigEntryControl obj in _EntryControlList.Where(e =>
        {
            if (e.BoostProfileEntry == null)
                return false;
            
            return new byte[2]
            {
                0,
                2
            }.Contains(e.BoostProfileEntry.PE002);
        }))
        
        obj.SetAllMaxClock(clock);
    }

    private void UpdateData()
    {
        InternalReset();
        
        if (BoostProfile == null)
            return;
        
        Enabled = true;
        
        int num = lblMin1.Top + lblMin1.Height + 1;
        
        _EntryControlList = new List<UCboostConfigEntryControl>();
        
        foreach (var boostProfileEntry in BoostProfile.FE005.Where(e => !e.PE001).OrderBy(e => e.PE002).ToList())
        {
            var boostConfigEntryControl = new UCboostConfigEntryControl
            {
                BoostProfileEntry = boostProfileEntry,
                Left = 0,
                Top = num
            };

            boostConfigEntryControl.OnAnyTextChanged += ctrl_OnTextChanged;

            Controls.Add(boostConfigEntryControl);
            _EntryControlList.Add(boostConfigEntryControl);

            num += boostConfigEntryControl.Height;
        }
    }

    private void ctrl_OnTextChanged(object sender, EventArgs e)
    {
        if (AnyTextChanged == null)
            return;
        AnyTextChanged(sender, e);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.lblMax1 = new System.Windows.Forms.Label();
            this.lblMin1 = new System.Windows.Forms.Label();
            this.lblMin2 = new System.Windows.Forms.Label();
            this.lblMax2 = new System.Windows.Forms.Label();
            this.boostConfigEntryControl1 = new UCboostConfigEntryControl();
            this.SuspendLayout();
            // 
            // lblMax1
            // 
            this.lblMax1.AutoSize = true;
            this.lblMax1.Location = new System.Drawing.Point(200, 0);
            this.lblMax1.Name = "lblMax1";
            this.lblMax1.Size = new System.Drawing.Size(27, 13);
            this.lblMax1.TabIndex = 76;
            this.lblMax1.Text = "Max";
            // 
            // lblMin1
            // 
            this.lblMin1.AutoSize = true;
            this.lblMin1.Location = new System.Drawing.Point(120, 0);
            this.lblMin1.Name = "lblMin1";
            this.lblMin1.Size = new System.Drawing.Size(24, 13);
            this.lblMin1.TabIndex = 75;
            this.lblMin1.Text = "Min";
            // 
            // lblMin2
            // 
            this.lblMin2.AutoSize = true;
            this.lblMin2.Location = new System.Drawing.Point(284, 0);
            this.lblMin2.Name = "lblMin2";
            this.lblMin2.Size = new System.Drawing.Size(24, 13);
            this.lblMin2.TabIndex = 75;
            this.lblMin2.Text = "Min";
            // 
            // lblMax2
            // 
            this.lblMax2.AutoSize = true;
            this.lblMax2.Location = new System.Drawing.Point(364, 0);
            this.lblMax2.Name = "lblMax2";
            this.lblMax2.Size = new System.Drawing.Size(27, 13);
            this.lblMax2.TabIndex = 76;
            this.lblMax2.Text = "Max";
            // 
            // boostConfigEntryControl1
            // 
            this.boostConfigEntryControl1.Location = new System.Drawing.Point(0, 14);
            this.boostConfigEntryControl1.Name = "boostConfigEntryControl1";
            this.boostConfigEntryControl1.Size = new System.Drawing.Size(404, 51);
            this.boostConfigEntryControl1.TabIndex = 81;
            // 
            // UCBoostConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boostConfigEntryControl1);
            this.Controls.Add(this.lblMax2);
            this.Controls.Add(this.lblMax1);
            this.Controls.Add(this.lblMin2);
            this.Controls.Add(this.lblMin1);
            this.Name = "UCBoostConfigControl";
            this.Size = new System.Drawing.Size(417, 306);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
