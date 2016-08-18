// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

public class UCPerfTableEntryControl : UserControl, ComponenteDaTela
{
    private readonly Hashtable _Controls;
    private Voltage _PerfEntry;
    private IContainer components;
    private TextBox tb00_8;
    private TextBox tb00_7;
    private TextBox tb00_6;
    private TextBox tb00_5;
    private TextBox tb00_4;
    private TextBox tb00_3;
    private TextBox tb00_2;
    private TextBox tb00_1;
    private TextBox tb00_0;
    private Label lblProfileCaption;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;

    internal Voltage PerfEntry
    {
        get
        {
            return this._PerfEntry;
        }
        set
        {
            this.Reset();
            this._PerfEntry = value;
            this.UpdateData();
        }
    }

    public event EventHandler OnAnyTextChanged;

    public UCPerfTableEntryControl()
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

    public uint GetMemoryClock()
    {
        if (this.PerfEntry == null || this.PerfEntry.PE004 || this.PerfEntry.PE005 < 4)
            return 0U;
        return Convert.ToUInt32(this.Ctrl(string.Format("tb00_{0}", 3)).Text);
    }

    public void SetMemoryClock(uint clock)
    {
        if (this.PerfEntry == null || this.PerfEntry.PE004 || this.PerfEntry.PE005 < 4)
            return;
        this.Ctrl(string.Format("tb00_{0}", 3)).Text = clock.ToString();
    }

    public void ApplyChanges()
    {
        if (this.PerfEntry == null)
            return;
        for (int index = 0; index < this.PerfEntry.PE005; ++index)
        {
            if (!this.PerfEntry.PE004 && index < 9)
            {
                Control control = this.Ctrl(string.Format("tb00_{0}", index));
                this.PerfEntry.FE007[index].PE001 = Convert.ToUInt32(control.Text);
            }
        }
    }

    public void Reset()
    {
        this.OnAnyTextChanged = null;
        this._PerfEntry = null;
        this.InternalReset();
    }

    private void InternalReset()
    {
        this.lblProfileCaption.Text = "Profile";
        for (int index = 0; index < 9; ++index)
        {
            Control control = this.Ctrl(string.Format("tb00_{0}", index));
            control.Text = "";
            control.BackColor = SystemColors.Window;
            control.Enabled = false;
        }
        this.Enabled = false;
    }

    private void UpdateData()
    {
        this.InternalReset();
        if (this.PerfEntry == null)
            return;
        this.Enabled = !this.PerfEntry.PE004;
        this.lblProfileCaption.Text = this.PerfEntry.PE004 ? "Profile" : string.Format("P{0:00} - Profile", this.PerfEntry.Caption);
        for (int index = 0; index < this.PerfEntry.PE005; ++index)
        {
            if (!this.PerfEntry.PE004 && index < 9)
            {
                Control control = this.Ctrl(string.Format("tb00_{0}", index));
                control.Text = this.PerfEntry.FE007[index].PE001.ToString();
                control.Enabled = true;
                if (!this.PerfEntry.FE007[index].PE003)
                    control.BackColor = Color.LemonChiffon;
            }
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
        this.tb00_8 = new System.Windows.Forms.TextBox();
        this.tb00_7 = new System.Windows.Forms.TextBox();
        this.tb00_6 = new System.Windows.Forms.TextBox();
        this.tb00_5 = new System.Windows.Forms.TextBox();
        this.tb00_4 = new System.Windows.Forms.TextBox();
        this.tb00_3 = new System.Windows.Forms.TextBox();
        this.tb00_2 = new System.Windows.Forms.TextBox();
        this.tb00_1 = new System.Windows.Forms.TextBox();
        this.tb00_0 = new System.Windows.Forms.TextBox();
        this.lblProfileCaption = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.label7 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.label9 = new System.Windows.Forms.Label();
        this.label10 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // tb00_8
        // 
        this.tb00_8.Location = new System.Drawing.Point(358, 28);
        this.tb00_8.Name = "tb00_8";
        this.tb00_8.Size = new System.Drawing.Size(42, 20);
        this.tb00_8.TabIndex = 57;
        this.tb00_8.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tb00_7
        // 
        this.tb00_7.Location = new System.Drawing.Point(276, 28);
        this.tb00_7.Name = "tb00_7";
        this.tb00_7.Size = new System.Drawing.Size(42, 20);
        this.tb00_7.TabIndex = 56;
        this.tb00_7.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tb00_6
        // 
        this.tb00_6.Location = new System.Drawing.Point(194, 28);
        this.tb00_6.Name = "tb00_6";
        this.tb00_6.Size = new System.Drawing.Size(42, 20);
        this.tb00_6.TabIndex = 55;
        this.tb00_6.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tb00_5
        // 
        this.tb00_5.Location = new System.Drawing.Point(113, 28);
        this.tb00_5.Name = "tb00_5";
        this.tb00_5.Size = new System.Drawing.Size(42, 20);
        this.tb00_5.TabIndex = 54;
        this.tb00_5.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tb00_4
        // 
        this.tb00_4.Location = new System.Drawing.Point(31, 28);
        this.tb00_4.Name = "tb00_4";
        this.tb00_4.Size = new System.Drawing.Size(42, 20);
        this.tb00_4.TabIndex = 52;
        this.tb00_4.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tb00_3
        // 
        this.tb00_3.Location = new System.Drawing.Point(358, 2);
        this.tb00_3.Name = "tb00_3";
        this.tb00_3.Size = new System.Drawing.Size(42, 20);
        this.tb00_3.TabIndex = 51;
        this.tb00_3.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tb00_2
        // 
        this.tb00_2.Location = new System.Drawing.Point(276, 2);
        this.tb00_2.Name = "tb00_2";
        this.tb00_2.Size = new System.Drawing.Size(42, 20);
        this.tb00_2.TabIndex = 50;
        this.tb00_2.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tb00_1
        // 
        this.tb00_1.Location = new System.Drawing.Point(194, 2);
        this.tb00_1.Name = "tb00_1";
        this.tb00_1.Size = new System.Drawing.Size(42, 20);
        this.tb00_1.TabIndex = 49;
        this.tb00_1.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // tb00_0
        // 
        this.tb00_0.Location = new System.Drawing.Point(113, 2);
        this.tb00_0.Name = "tb00_0";
        this.tb00_0.Size = new System.Drawing.Size(42, 20);
        this.tb00_0.TabIndex = 48;
        this.tb00_0.TextChanged += new System.EventHandler(this.AnyTextChanged);
        // 
        // lblProfileCaption
        // 
        this.lblProfileCaption.AutoSize = true;
        this.lblProfileCaption.Location = new System.Drawing.Point(3, 5);
        this.lblProfileCaption.Name = "lblProfileCaption";
        this.lblProfileCaption.Size = new System.Drawing.Size(67, 13);
        this.lblProfileCaption.TabIndex = 46;
        this.lblProfileCaption.Text = "P00 - Profile:";
        // 
        // label1
        // 
        this.label1.Location = new System.Drawing.Point(76, 5);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(36, 13);
        this.label1.TabIndex = 59;
        this.label1.Text = "GPC";
        this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label2
        // 
        this.label2.Location = new System.Drawing.Point(156, 5);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(37, 13);
        this.label2.TabIndex = 60;
        this.label2.Text = "XBAR";
        this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label3
        // 
        this.label3.Location = new System.Drawing.Point(237, 5);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(38, 13);
        this.label3.TabIndex = 59;
        this.label3.Text = "L2C";
        this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label4
        // 
        this.label4.Location = new System.Drawing.Point(319, 5);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(38, 13);
        this.label4.TabIndex = 60;
        this.label4.Text = "DDR";
        this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label5
        // 
        this.label5.Location = new System.Drawing.Point(2, 31);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(28, 13);
        this.label5.TabIndex = 60;
        this.label5.Text = "SYS";
        this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label6
        // 
        this.label6.Location = new System.Drawing.Point(74, 31);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(38, 13);
        this.label6.TabIndex = 59;
        this.label6.Text = "HUB";
        this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label7
        // 
        this.label7.Location = new System.Drawing.Point(156, 31);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(37, 13);
        this.label7.TabIndex = 60;
        this.label7.Text = "MSD";
        this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label8
        // 
        this.label8.Location = new System.Drawing.Point(237, 31);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(38, 13);
        this.label8.TabIndex = 59;
        this.label8.Text = "PWR";
        this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label9
        // 
        this.label9.Location = new System.Drawing.Point(319, 31);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(38, 13);
        this.label9.TabIndex = 60;
        this.label9.Text = "DISP";
        this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // label10
        // 
        this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.label10.Location = new System.Drawing.Point(3, 56);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(398, 1);
        this.label10.TabIndex = 61;
        // 
        // CE02D
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.label10);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label9);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label8);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.tb00_8);
        this.Controls.Add(this.tb00_7);
        this.Controls.Add(this.tb00_6);
        this.Controls.Add(this.tb00_5);
        this.Controls.Add(this.tb00_4);
        this.Controls.Add(this.tb00_3);
        this.Controls.Add(this.tb00_2);
        this.Controls.Add(this.tb00_1);
        this.Controls.Add(this.tb00_0);
        this.Controls.Add(this.lblProfileCaption);
        this.Name = "CE02D";
        this.Size = new System.Drawing.Size(405, 64);
        this.ResumeLayout(false);
        this.PerformLayout();

    }
}
