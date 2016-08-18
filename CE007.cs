// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class UCBoostLimitHelperControl : UserControl
{
    private UCBoostConfigControl _BoostConfigControl;
    private bool settingTargetCLocks;
    private bool settingSliderPosition;
    private IContainer components;
    private BoostLimit scBoostLimit;

    internal UCBoostConfigControl BoostConfigControl
    {
        get
        {
            return this._BoostConfigControl;
        }
        set
        {
            this._BoostConfigControl = value;
            this.Init();
        }
    }

    public UCBoostLimitHelperControl()
    {
        this.InitializeComponent();
    }

    private void Init()
    {
        if (this.BoostConfigControl == null)
            return;
        this.BoostConfigControl.AnyTextChanged += new EventHandler(this.BoostConfigControl_OnTextChanged);
        this.scBoostLimit.SliderMaximum = CE00D.PE000.Count - 1;
        this.UpdateControl();
    }

    private void BoostConfigControl_OnTextChanged(object sender, EventArgs e)
    {
        if (this.settingTargetCLocks)
            return;
        this.UpdateControl();
    }

    private void Reset()
    {
        this.scBoostLimit.ValueText = "";
        this.SetSlider(0);
        this.Enabled = false;
    }

    private void UpdateControl()
    {
        this.Reset();
        if (this.BoostConfigControl == null || !this.BoostConfigControl.AreP0AndP2MaxClocksSame())
            return;
        int val = CE00D.PE000.IndexOf(this.BoostConfigControl.GetP0AndP2MaxClock());
        if (val == -1)
            return;
        this.SetSlider(val);
        this.UpdateSliderText();
        this.Enabled = true;
    }

    private void UpdateSliderText()
    {
        this.scBoostLimit.ValueText = string.Format("{0} MHz", CE00D.E005(CE00D.PE000[this.scBoostLimit.SliderPosition]));
    }

    private void SetSlider(int val)
    {
        this.settingSliderPosition = true;
        this.scBoostLimit.SliderPosition = val;
        this.settingSliderPosition = false;
    }

    private void sliderControl1_OnScroll(object sender, EventArgs e)
    {
        if (this.BoostConfigControl == null || !this.Enabled || this.settingSliderPosition)
            return;
        this.UpdateSliderText();
        this.settingTargetCLocks = true;
        this.BoostConfigControl.SetP0AndP2MaxClock(CE00D.PE000[this.scBoostLimit.SliderPosition]);
        this.settingTargetCLocks = false;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.scBoostLimit = new BoostLimit();
            this.SuspendLayout();
            // 
            // scBoostLimit
            // 
            this.scBoostLimit.Caption = "Boost Limit";
            this.scBoostLimit.Location = new System.Drawing.Point(0, 0);
            this.scBoostLimit.Name = "scBoostLimit";
            this.scBoostLimit.Size = new System.Drawing.Size(404, 28);
            this.scBoostLimit.SliderMaximum = 97;
            this.scBoostLimit.SliderPosition = 67;
            this.scBoostLimit.TabIndex = 0;
            this.scBoostLimit.ValueText = "";
            this.scBoostLimit.ValueTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scBoostLimit.OnScroll += new System.EventHandler(this.sliderControl1_OnScroll);
            // 
            // UCBoostLimitHelperControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scBoostLimit);
            this.Name = "UCBoostLimitHelperControl";
            this.Size = new System.Drawing.Size(405, 27);
            this.ResumeLayout(false);

    }
}
