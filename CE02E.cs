// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class UCMemoryClock : UserControl
{
  private UCPerfTableControl _PerfTableControl;
  private bool settingNumValue;
  private bool updating;
  private IContainer components;
  private NumericUpDown numMemoryClock;
  private Label lblMemoryClock;

  internal UCPerfTableControl PerfTableControl
  {
    get
    {
      return this._PerfTableControl;
    }
    set
    {
      this._PerfTableControl = value;
      this.Init();
    }
  }

  public UCMemoryClock()
  {
    this.InitializeComponent();
  }

  private void Init()
  {
    if (this.PerfTableControl == null)
      return;
    this.PerfTableControl.AnyTextChanged += new EventHandler(this.PerfTableControl_AnyTextChanged);
    this.UpdateControl();
  }

  private void PerfTableControl_AnyTextChanged(object sender, EventArgs e)
  {
    if (this.updating)
      return;
    this.UpdateControl();
  }

  private void Reset()
  {
    this.SetNumValue(0U);
    this.numMemoryClock.Maximum = new Decimal(8191);
    this.numMemoryClock.Increment = new Decimal(4);
    this.Enabled = false;
  }

  private void UpdateControl()
  {
    this.Reset();
    if (this.PerfTableControl == null || !this.PerfTableControl.AreP0AndP2MMemoryClocksSame())
      return;
    this.SetNumValue(this.PerfTableControl.GetP0AndP2MemoryClock());
    this.Enabled = true;
  }

  private void SetNumValue(uint val)
  {
    this.settingNumValue = true;
    this.numMemoryClock.Value = val;
    this.settingNumValue = false;
  }

  private void numMemoryCLock_ValueChanged(object sender, EventArgs e)
  {
    if (this.PerfTableControl == null || !this.Enabled || this.settingNumValue)
      return;
    this.updating = true;
    this.PerfTableControl.SetP0AndP2MemoryClock(Convert.ToUInt32(this.numMemoryClock.Value));
    this.updating = false;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
            this.numMemoryClock = new System.Windows.Forms.NumericUpDown();
            this.lblMemoryClock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMemoryClock)).BeginInit();
            this.SuspendLayout();
            // 
            // numMemoryClock
            // 
            this.numMemoryClock.Location = new System.Drawing.Point(103, 4);
            this.numMemoryClock.Name = "numMemoryClock";
            this.numMemoryClock.Size = new System.Drawing.Size(85, 20);
            this.numMemoryClock.TabIndex = 0;
            this.numMemoryClock.ValueChanged += new System.EventHandler(this.numMemoryCLock_ValueChanged);
            // 
            // lblMemoryClock
            // 
            this.lblMemoryClock.AutoSize = true;
            this.lblMemoryClock.Location = new System.Drawing.Point(3, 6);
            this.lblMemoryClock.Name = "lblMemoryClock";
            this.lblMemoryClock.Size = new System.Drawing.Size(74, 13);
            this.lblMemoryClock.TabIndex = 3;
            this.lblMemoryClock.Text = "Memory Clock";
            // 
            // UCMemoryClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMemoryClock);
            this.Controls.Add(this.numMemoryClock);
            this.Name = "UCMemoryClock";
            this.Size = new System.Drawing.Size(407, 28);
            ((System.ComponentModel.ISupportInitialize)(this.numMemoryClock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

  }
}
