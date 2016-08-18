// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

public class UCboostConfigEntryControl : UserControl, ComponenteDaTela
{
    private readonly Hashtable _Controls;
    private BoostProfileEntry _BoostProfileEntry;
    private IContainer components;
    private TextBox tbBoostMax0Clock2;
    private TextBox tbBoostMin0Clock2;
    private TextBox tbBoostMax0Clock1;
    private TextBox tbBoostMin0Clock1;
    private TextBox tbBoostMax0Clock0;
    private TextBox tbBoostMin0Clock0;
    private TextBox tbProfileBoostMax0;
    private TextBox tbProfileBoostMin0;
    private Label lblProfileBoost0;
    private Label lblBoostProfileMinClock;
    private Label lblBoostProfileMaxClock;
    private Label lblBoostProfileMinClock0;
    private Label lblBoostProfileMaxClock0;
    private Label lblBoostProfileMinClock1;
    private Label lblBoostProfileMaxClock1;
    private Label lblBoostProfileMinClock2;
    private Label lblBoostProfileMaxClock2;
    private Label label10;

    internal BoostProfileEntry BoostProfileEntry
    {
        get
        {
            return this._BoostProfileEntry;
        }
        set
        {
            this.Reset();
            this._BoostProfileEntry = value;
            this.UpdateData();
        }
    }

    public event EventHandler OnAnyTextChanged;

    public UCboostConfigEntryControl()
    {
        this.InitializeComponent();
        this._Controls = this.GetControlHashTable();
    }

    private Hashtable GetControlHashTable()
    {
        Hashtable hashtable = new Hashtable();
        foreach (Control control in (ArrangedElementCollection)this.Controls)
            hashtable.Add(control.Name, control);
        return hashtable;
    }

    private Control Ctrl(string name)
    {
        return (Control)this._Controls[name];
    }

    public bool AreAllMaxClocksEqual()
    {
        if (this.BoostProfileEntry == null)
            return false;
        ushort num1 = CE00D.E006(this.tbProfileBoostMax0.Text);
        int num2 = 1;
        ushort num3 = num1;
        for (int index = 0; index < this.BoostProfileEntry.FE008.Count && index < 3; ++index)
        {
            num3 += CE00D.E006(this.Ctrl(string.Format("tbBoostMax0Clock{0}", index)).Text);
            ++num2;
        }
        return num3 / num2 == num1;
    }

    public ushort GetAllMaxClock()
    {
        if (!this.AreAllMaxClocksEqual())
            return 0;
        return CE00D.E006(this.tbProfileBoostMax0.Text);
    }

    public void SetAllMaxClock(ushort clock)
    {
        if (this.BoostProfileEntry == null)
            return;
        this.tbProfileBoostMax0.Text = CE00D.E005(clock);
        for (int index = 0; index < this.BoostProfileEntry.FE008.Count && index < 3; ++index)
            this.Ctrl(string.Format("tbBoostMax0Clock{0}", index)).Text = CE00D.E005(clock);
    }

    public void ApplyChanges()
    {
        if (this.BoostProfileEntry == null)
            return;
        this.BoostProfileEntry.PE003 = CE00D.E006(this.tbProfileBoostMin0.Text);
        this.BoostProfileEntry.PE004 = CE00D.E006(this.tbProfileBoostMax0.Text);
        List<CE01B> list = Enumerable.ToList<CE01B>(Enumerable.OrderBy<CE01B, byte>(this.BoostProfileEntry.FE008, c => c.PE001));
        for (int index = 0; index < list.Count && index < 3; ++index)
        {
            CE01B obj = list[index];
            obj.PE003 = CE00D.E006(this.Ctrl(string.Format("tbBoostMin0Clock{0}", index)).Text);
            obj.PE004 = CE00D.E006(this.Ctrl(string.Format("tbBoostMax0Clock{0}", index)).Text);
        }
    }

    public void Reset()
    {
        this._BoostProfileEntry = null;
        this.OnAnyTextChanged = null;
        this.InternalReset();
    }

    private void InternalReset()
    {
        this.tbProfileBoostMin0.Text = "";
        this.tbProfileBoostMax0.Text = "";
        this.lblProfileBoost0.Text = "";
        for (int index = 0; index < 3; ++index)
        {
            Control control1 = this.Ctrl(string.Format("tbBoostMin0Clock{0}", index));
            Control control2 = this.Ctrl(string.Format("tbBoostMax0Clock{0}", index));
            control1.Enabled = false;
            control2.Enabled = false;
            control1.Text = "";
            control2.Text = "";
        }
        this.Enabled = false;
    }

    private void UpdateData()
    {
        this.InternalReset();
        if (this.BoostProfileEntry == null)
            return;
        this.Enabled = true;
        this.tbProfileBoostMin0.Text = CE00D.E005(this.BoostProfileEntry.PE003);
        this.tbProfileBoostMax0.Text = CE00D.E005(this.BoostProfileEntry.PE004);
        this.lblProfileBoost0.Text = string.Format("P{0:00} - Profile", this.BoostProfileEntry.PE002);
        List<CE01B> list = Enumerable.ToList<CE01B>(Enumerable.OrderBy<CE01B, byte>(this.BoostProfileEntry.FE008, c => c.PE001));
        for (int index = 0; index < list.Count && index < 3; ++index)
        {
            CE01B obj = list[index];
            Control control1 = this.Ctrl(string.Format("tbBoostMin0Clock{0}", index));
            Control control2 = this.Ctrl(string.Format("tbBoostMax0Clock{0}", index));
            this.Ctrl(string.Format("lblBoostProfileMinClock{0}", index));
            this.Ctrl(string.Format("lblBoostProfileMaxClock{0}", index));
            control1.Enabled = true;
            control2.Enabled = true;
            control1.Text = CE00D.E005(obj.PE003);
            control2.Text = CE00D.E005(obj.PE004);
        }
    }

    private void AnyTextChanged(object sender, EventArgs e)
    {
        if (this.OnAnyTextChanged == null)
            return;
        this.OnAnyTextChanged(sender, e);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.tbBoostMax0Clock2 = new System.Windows.Forms.TextBox();
        this.tbBoostMin0Clock2 = new System.Windows.Forms.TextBox();
        this.tbBoostMax0Clock1 = new System.Windows.Forms.TextBox();
        this.tbBoostMin0Clock1 = new System.Windows.Forms.TextBox();
        this.tbBoostMax0Clock0 = new System.Windows.Forms.TextBox();
        this.tbBoostMin0Clock0 = new System.Windows.Forms.TextBox();
        this.tbProfileBoostMax0 = new System.Windows.Forms.TextBox();
        this.tbProfileBoostMin0 = new System.Windows.Forms.TextBox();
        this.lblProfileBoost0 = new System.Windows.Forms.Label();
        this.lblBoostProfileMinClock = new System.Windows.Forms.Label();
        this.lblBoostProfileMaxClock = new System.Windows.Forms.Label();
        this.lblBoostProfileMinClock0 = new System.Windows.Forms.Label();
        this.lblBoostProfileMaxClock0 = new System.Windows.Forms.Label();
        this.lblBoostProfileMinClock1 = new System.Windows.Forms.Label();
        this.lblBoostProfileMaxClock1 = new System.Windows.Forms.Label();
        this.lblBoostProfileMinClock2 = new System.Windows.Forms.Label();
        this.lblBoostProfileMaxClock2 = new System.Windows.Forms.Label();
        this.label10 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // tbBoostMax0Clock2
        // 
        this.tbBoostMax0Clock2.Location = new System.Drawing.Point(357, 28);
        this.tbBoostMax0Clock2.Name = "tbBoostMax0Clock2";
        this.tbBoostMax0Clock2.Size = new System.Drawing.Size(42, 20);
        this.tbBoostMax0Clock2.TabIndex = 68;
        this.tbBoostMax0Clock2.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tbBoostMin0Clock2
        // 
        this.tbBoostMin0Clock2.Location = new System.Drawing.Point(276, 28);
        this.tbBoostMin0Clock2.Name = "tbBoostMin0Clock2";
        this.tbBoostMin0Clock2.Size = new System.Drawing.Size(42, 20);
        this.tbBoostMin0Clock2.TabIndex = 67;
        this.tbBoostMin0Clock2.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tbBoostMax0Clock1
        // 
        this.tbBoostMax0Clock1.Location = new System.Drawing.Point(194, 28);
        this.tbBoostMax0Clock1.Name = "tbBoostMax0Clock1";
        this.tbBoostMax0Clock1.Size = new System.Drawing.Size(42, 20);
        this.tbBoostMax0Clock1.TabIndex = 66;
        this.tbBoostMax0Clock1.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tbBoostMin0Clock1
        // 
        this.tbBoostMin0Clock1.Location = new System.Drawing.Point(113, 28);
        this.tbBoostMin0Clock1.Name = "tbBoostMin0Clock1";
        this.tbBoostMin0Clock1.Size = new System.Drawing.Size(42, 20);
        this.tbBoostMin0Clock1.TabIndex = 65;
        this.tbBoostMin0Clock1.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tbBoostMax0Clock0
        // 
        this.tbBoostMax0Clock0.Location = new System.Drawing.Point(357, 2);
        this.tbBoostMax0Clock0.Name = "tbBoostMax0Clock0";
        this.tbBoostMax0Clock0.Size = new System.Drawing.Size(42, 20);
        this.tbBoostMax0Clock0.TabIndex = 64;
        this.tbBoostMax0Clock0.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tbBoostMin0Clock0
        // 
        this.tbBoostMin0Clock0.Location = new System.Drawing.Point(276, 2);
        this.tbBoostMin0Clock0.Name = "tbBoostMin0Clock0";
        this.tbBoostMin0Clock0.Size = new System.Drawing.Size(42, 20);
        this.tbBoostMin0Clock0.TabIndex = 63;
        this.tbBoostMin0Clock0.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tbProfileBoostMax0
        // 
        this.tbProfileBoostMax0.Location = new System.Drawing.Point(194, 2);
        this.tbProfileBoostMax0.Name = "tbProfileBoostMax0";
        this.tbProfileBoostMax0.Size = new System.Drawing.Size(42, 20);
        this.tbProfileBoostMax0.TabIndex = 62;
        this.tbProfileBoostMax0.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tbProfileBoostMin0
        // 
        this.tbProfileBoostMin0.Location = new System.Drawing.Point(113, 2);
        this.tbProfileBoostMin0.Name = "tbProfileBoostMin0";
        this.tbProfileBoostMin0.Size = new System.Drawing.Size(42, 20);
        this.tbProfileBoostMin0.TabIndex = 61;
        this.tbProfileBoostMin0.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // lblProfileBoost0
        // 
        this.lblProfileBoost0.AutoSize = true;
        this.lblProfileBoost0.Location = new System.Drawing.Point(3, 5);
        this.lblProfileBoost0.Name = "lblProfileBoost0";
        this.lblProfileBoost0.Size = new System.Drawing.Size(67, 13);
        this.lblProfileBoost0.TabIndex = 56;
        this.lblProfileBoost0.Text = "P00 - Profile:";
        // 
        // lblBoostProfileMinClock
        // 
        this.lblBoostProfileMinClock.Location = new System.Drawing.Point(74, 5);
        this.lblBoostProfileMinClock.Name = "lblBoostProfileMinClock";
        this.lblBoostProfileMinClock.Size = new System.Drawing.Size(38, 13);
        this.lblBoostProfileMinClock.TabIndex = 82;
        this.lblBoostProfileMinClock.Text = "GPC";
        this.lblBoostProfileMinClock.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // lblBoostProfileMaxClock
        // 
        this.lblBoostProfileMaxClock.Location = new System.Drawing.Point(156, 5);
        this.lblBoostProfileMaxClock.Name = "lblBoostProfileMaxClock";
        this.lblBoostProfileMaxClock.Size = new System.Drawing.Size(37, 13);
        this.lblBoostProfileMaxClock.TabIndex = 82;
        this.lblBoostProfileMaxClock.Text = "GPC";
        this.lblBoostProfileMaxClock.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // lblBoostProfileMinClock0
        // 
        this.lblBoostProfileMinClock0.Location = new System.Drawing.Point(237, 5);
        this.lblBoostProfileMinClock0.Name = "lblBoostProfileMinClock0";
        this.lblBoostProfileMinClock0.Size = new System.Drawing.Size(38, 13);
        this.lblBoostProfileMinClock0.TabIndex = 80;
        this.lblBoostProfileMinClock0.Text = "L2C";
        this.lblBoostProfileMinClock0.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // lblBoostProfileMaxClock0
        // 
        this.lblBoostProfileMaxClock0.Location = new System.Drawing.Point(319, 5);
        this.lblBoostProfileMaxClock0.Name = "lblBoostProfileMaxClock0";
        this.lblBoostProfileMaxClock0.Size = new System.Drawing.Size(37, 13);
        this.lblBoostProfileMaxClock0.TabIndex = 80;
        this.lblBoostProfileMaxClock0.Text = "L2C";
        this.lblBoostProfileMaxClock0.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // lblBoostProfileMinClock1
        // 
        this.lblBoostProfileMinClock1.Location = new System.Drawing.Point(74, 31);
        this.lblBoostProfileMinClock1.Name = "lblBoostProfileMinClock1";
        this.lblBoostProfileMinClock1.Size = new System.Drawing.Size(38, 13);
        this.lblBoostProfileMinClock1.TabIndex = 83;
        this.lblBoostProfileMinClock1.Text = "XBAR";
        this.lblBoostProfileMinClock1.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // lblBoostProfileMaxClock1
        // 
        this.lblBoostProfileMaxClock1.Location = new System.Drawing.Point(156, 31);
        this.lblBoostProfileMaxClock1.Name = "lblBoostProfileMaxClock1";
        this.lblBoostProfileMaxClock1.Size = new System.Drawing.Size(37, 13);
        this.lblBoostProfileMaxClock1.TabIndex = 83;
        this.lblBoostProfileMaxClock1.Text = "XBAR";
        this.lblBoostProfileMaxClock1.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // lblBoostProfileMinClock2
        // 
        this.lblBoostProfileMinClock2.Location = new System.Drawing.Point(237, 31);
        this.lblBoostProfileMinClock2.Name = "lblBoostProfileMinClock2";
        this.lblBoostProfileMinClock2.Size = new System.Drawing.Size(38, 13);
        this.lblBoostProfileMinClock2.TabIndex = 87;
        this.lblBoostProfileMinClock2.Text = "SYS";
        this.lblBoostProfileMinClock2.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // lblBoostProfileMaxClock2
        // 
        this.lblBoostProfileMaxClock2.Location = new System.Drawing.Point(319, 31);
        this.lblBoostProfileMaxClock2.Name = "lblBoostProfileMaxClock2";
        this.lblBoostProfileMaxClock2.Size = new System.Drawing.Size(37, 13);
        this.lblBoostProfileMaxClock2.TabIndex = 87;
        this.lblBoostProfileMaxClock2.Text = "SYS";
        this.lblBoostProfileMaxClock2.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label10
        // 
        this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.label10.Location = new System.Drawing.Point(3, 56);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(398, 1);
        this.label10.TabIndex = 88;
        // 
        // UCboostConfigEntryControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.label10);
        this.Controls.Add(this.lblBoostProfileMaxClock2);
        this.Controls.Add(this.lblBoostProfileMinClock2);
        this.Controls.Add(this.lblBoostProfileMaxClock0);
        this.Controls.Add(this.lblBoostProfileMinClock0);
        this.Controls.Add(this.lblBoostProfileMaxClock1);
        this.Controls.Add(this.lblBoostProfileMinClock1);
        this.Controls.Add(this.lblBoostProfileMaxClock);
        this.Controls.Add(this.lblBoostProfileMinClock);
        this.Controls.Add(this.tbBoostMax0Clock2);
        this.Controls.Add(this.tbBoostMin0Clock2);
        this.Controls.Add(this.tbBoostMax0Clock1);
        this.Controls.Add(this.tbBoostMin0Clock1);
        this.Controls.Add(this.tbBoostMax0Clock0);
        this.Controls.Add(this.tbBoostMin0Clock0);
        this.Controls.Add(this.tbProfileBoostMax0);
        this.Controls.Add(this.tbProfileBoostMin0);
        this.Controls.Add(this.lblProfileBoost0);
        this.Name = "UCboostConfigEntryControl";
        this.Size = new System.Drawing.Size(404, 64);
        this.ResumeLayout(false);
        this.PerformLayout();

    }
}
