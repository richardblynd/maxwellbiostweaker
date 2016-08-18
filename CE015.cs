// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class BoostLimit : UserControl
{
    private IContainer components;
    private TrackBar trbSlider;
    private Label lValueCaption;
    private Label lblValueText;

    public ContentAlignment ValueTextAlign
    {
        get
        {
            return this.lblValueText.TextAlign;
        }
        set
        {
            this.lblValueText.TextAlign = value;
        }
    }

    public string Caption
    {
        get
        {
            return this.lValueCaption.Text;
        }
        set
        {
            this.lValueCaption.Text = value;
        }
    }

    public string ValueText
    {
        get
        {
            return this.lblValueText.Text;
        }
        set
        {
            this.lblValueText.Text = value;
        }
    }

    public int SliderPosition
    {
        get
        {
            return this.trbSlider.Value;
        }
        set
        {
            this.trbSlider.Value = value;
            if (this.OnScroll == null)
                return;
            this.OnScroll(this, new EventArgs());
        }
    }

    public int SliderMaximum
    {
        get
        {
            return this.trbSlider.Maximum;
        }
        set
        {
            this.trbSlider.Maximum = value;
        }
    }

    public event EventHandler OnScroll;

    public BoostLimit()
    {
        this.InitializeComponent();
        this.trbSlider.Scroll += new EventHandler(this.trbSlider_Scroll);
    }

    private void trbSlider_Scroll(object sender, EventArgs e)
    {
        if (this.OnScroll == null)
            return;
        this.OnScroll(this, e);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.trbSlider = new System.Windows.Forms.TrackBar();
        this.lValueCaption = new System.Windows.Forms.Label();
        this.lblValueText = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.trbSlider)).BeginInit();
        this.SuspendLayout();
        // 
        // trbSlider
        // 
        this.trbSlider.AutoSize = false;
        this.trbSlider.Location = new System.Drawing.Point(214, -1);
        this.trbSlider.Maximum = 97;
        this.trbSlider.Name = "trbSlider";
        this.trbSlider.Size = new System.Drawing.Size(195, 32);
        this.trbSlider.TabIndex = 0;
        this.trbSlider.Value = 67;
        // 
        // lValueCaption
        // 
        this.lValueCaption.AutoSize = true;
        this.lValueCaption.Location = new System.Drawing.Point(3, 7);
        this.lValueCaption.Name = "lValueCaption";
        this.lValueCaption.Size = new System.Drawing.Size(66, 13);
        this.lValueCaption.TabIndex = 26;
        this.lValueCaption.Text = "Max Voltage";
        // 
        // lblValueText
        // 
        this.lblValueText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.lblValueText.Location = new System.Drawing.Point(103, 4);
        this.lblValueText.Name = "lblValueText";
        this.lblValueText.Size = new System.Drawing.Size(86, 20);
        this.lblValueText.TabIndex = 27;
        this.lblValueText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // BoostLimit
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.trbSlider);
        this.Controls.Add(this.lValueCaption);
        this.Controls.Add(this.lblValueText);
        this.Name = "BoostLimit";
        this.Size = new System.Drawing.Size(410, 30);
        ((System.ComponentModel.ISupportInitialize)(this.trbSlider)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }
}
