// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using MaxwellBiosTweaker.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class UCCabecalho : UserControl
{
    private RomHeader _RomHeader;
    private string _FileName;
    private byte _ImageChecksum;
    private byte _GeneratedChecksum;
    private IContainer components;
    private Label lblChkSum;
    private Label lChkSum;
    private Label lblFilename;
    private Label lFilename;
    private Label lblDate;
    private Label lDate;
    private Label lblSubVendor;
    private Label lSubVendor;
    private Label lblDevID;
    private Label lDevID;
    private Label lblBIOS;
    private Label lBIOS;
    private Label lblGPU;
    private Label lGPU;
    private Label lblName;
    private Label lName;
    private Label lImgBack;

    internal RomHeader RomHeader
    {
        get
        {
            return this._RomHeader;
        }
        set
        {
            this._RomHeader = value;
            this.UpdateDisplay();
        }
    }

    public string FileName
    {
        get
        {
            return this._FileName;
        }
        set
        {
            this._FileName = value;
            this.UpdateDisplay();
        }
    }

    public byte ImageChecksum
    {
        get
        {
            return this._ImageChecksum;
        }
        set
        {
            this._ImageChecksum = value;
            this.UpdateDisplay();
        }
    }

    public byte GeneratedChecksum
    {
        get
        {
            return this._GeneratedChecksum;
        }
        set
        {
            this._GeneratedChecksum = value;
            this.UpdateDisplay();
        }
    }

    public UCCabecalho()
    {
        this.InitializeComponent();
    }

    private string TranslateSubVendor(uint ID)
    {
        uint num = ID & ushort.MaxValue;
        if (num <= 5218U)
        {
            if (num <= 4221U)
            {
                if (num <= 4156U)
                {
                    if (num <= 4121U)
                    {
                        if ((int)num == 3601)
                            return "HP (0E11)";
                        if ((int)num == 4116)
                            return "IBM (1014)";
                        if ((int)num == 4121)
                            return "Elitegroup (1019)";
                    }
                    else
                    {
                        if ((int)num == 4133)
                            return "ACER (1025)";
                        if ((int)num == 4136)
                            return "DELL (1028)";
                        if ((int)num == 4156)
                            return "HP (103C)";
                    }
                }
                else if (num <= 4173U)
                {
                    if ((int)num == 4163)
                        return "ASUS (1043)";
                    if ((int)num == 4168)
                        return "ELSA (1048)";
                    if ((int)num == 4173)
                        return "SONY (104D)";
                }
                else
                {
                    if ((int)num == 4187)
                        return "Foxconn (105B)";
                    if ((int)num == 4203)
                        return "Apple (106B)";
                    if ((int)num == 4221)
                        return "Leadtek (107D)";
                }
            }
            else if (num <= 4354U)
            {
                if (num <= 4276U)
                {
                    if ((int)num == 4242)
                        return "Diamond (1092)";
                    if ((int)num == 4272)
                        return "Gainward (10B0)";
                    if ((int)num == 4276)
                        return "STB (10B4)";
                }
                else
                {
                    if ((int)num == 4303)
                        return "Fujitsu (10CF)";
                    if ((int)num == 4318)
                        return "NVIDIA (10DE)";
                    if ((int)num == 4354)
                        return "Creative (1102)";
                }
            }
            else if (num <= 5053U)
            {
                if ((int)num == 4473)
                    return "Toshiba (1179)";
                if ((int)num == 5020)
                    return "Quantum (139C)";
                if ((int)num == 5053)
                    return "SHARP (13BD)";
            }
            else
            {
                if ((int)num == 5197)
                    return "Samsung (144D)";
                if ((int)num == 5208)
                    return "Gigabyte (1458)";
                if ((int)num == 5218)
                    return "MSI (1462)";
            }
        }
        else if (num <= 6058U)
        {
            if (num <= 5464U)
            {
                if (num <= 5312U)
                {
                    if ((int)num == 5243)
                        return "ABit (147B)";
                    if ((int)num == 5295)
                        return "Guillemot (14AF)";
                    if ((int)num == 5312)
                        return "Compal (14C0)";
                }
                else
                {
                    if ((int)num == 5445)
                        return "Visiontek (1545)";
                    if ((int)num == 5460)
                        return "Prolink (1554)";
                    if ((int)num == 5464)
                        return "Schenker (1558)";
                }
            }
            else if (num <= 5565U)
            {
                if ((int)num == 5477)
                    return "Biostar (1565)";
                if ((int)num == 5481)
                    return "Palit (1569)";
                if ((int)num == 5565)
                    return "DFI (15BD)";
            }
            else
            {
                switch (num)
                {
                    case 5761U:
                        return "Herkules (1681)";
                    case 5762U:
                        return "XFX (1682)";
                    case 5963U:
                        return "Sapphire (174B)";
                    case 6058U:
                        return "Lenovo (17AA)";
                }
            }
        }
        else if (num <= 6860U)
        {
            if (num <= 6510U)
            {
                if ((int)num == 6080)
                    return "Wistron (17C0)";
                if ((int)num == 6217)
                    return "ASRock (1849)";
                if ((int)num == 6510)
                    return "PNY (196E)";
            }
            else
            {
                if ((int)num == 6618)
                    return "Zotac (19DA)";
                if ((int)num == 6641)
                    return "BFG (19F1)";
                if ((int)num == 6860)
                    return "Point of View (1ACC)";
            }
        }
        else if (num <= 14402U)
        {
            if ((int)num == 6931)
                return "Jaton (1B13)";
            if ((int)num == 6988)
                return "KFA\x00B2 (1B4C)";
            if ((int)num == 14402)
                return "EVGA (3842)";
        }
        else
        {
            if ((int)num == 19539)
                return "SBS (4C53)";
            if ((int)num == 29559)
                return "Colorful (7377)";
            if ((int)num == 41120)
                return "AOpen (A0A0)";
        }
        return "Unknown (" + (ID & ushort.MaxValue).ToString("X4") + ")";
    }

    private void UpdateDisplay()
    {
        if (this.RomHeader == null)
            return;
        this.lblName.Text = this.RomHeader.E004.Replace("\r\n", " ");
        this.lblGPU.Text = this.RomHeader.E006;
        this.lblBIOS.Text = this.RomHeader.E005;
        this.lblDevID.Text = string.Format("{0:X4} - {1:X4}", this.RomHeader.E00B.PE001, this.RomHeader.E00B.PE002);
        this.lblSubVendor.Text = this.TranslateSubVendor(this.RomHeader.E003);
        this.lblDate.Text = this.RomHeader.E002;
        this.lblChkSum.Text = string.Format("{0:X2} - [{1:X2}]", this.ImageChecksum, this.GeneratedChecksum);
        if (this.ImageChecksum == this.GeneratedChecksum)
            this.lblChkSum.BackColor = Color.LightGreen;
        else
            this.lblChkSum.BackColor = Color.LightCoral;
        this.lblFilename.Text = this.FileName;
    }

    public void ResetDisplay(bool unsupported = false)
    {
        this.lblName.Text = unsupported ? "Unsupported Device" : "";
        this.lblGPU.Text = "";
        this.lblBIOS.Text = "";
        this.lblDevID.Text = "";
        this.lblSubVendor.Text = "";
        this.lblDate.Text = "";
        this.lblFilename.Text = "";
        this.lblChkSum.Text = "";
        this.lblChkSum.BackColor = SystemColors.Control;
    }

    private void lImgBack_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawImage(Resources.E002, -1, -2, this.lImgBack.Width, this.lImgBack.Height);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.lblChkSum = new System.Windows.Forms.Label();
            this.lChkSum = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lFilename = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lDate = new System.Windows.Forms.Label();
            this.lblSubVendor = new System.Windows.Forms.Label();
            this.lSubVendor = new System.Windows.Forms.Label();
            this.lblDevID = new System.Windows.Forms.Label();
            this.lDevID = new System.Windows.Forms.Label();
            this.lblBIOS = new System.Windows.Forms.Label();
            this.lBIOS = new System.Windows.Forms.Label();
            this.lblGPU = new System.Windows.Forms.Label();
            this.lGPU = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.lImgBack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChkSum
            // 
            this.lblChkSum.BackColor = System.Drawing.SystemColors.Control;
            this.lblChkSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChkSum.Location = new System.Drawing.Point(63, 117);
            this.lblChkSum.Name = "lblChkSum";
            this.lblChkSum.Size = new System.Drawing.Size(86, 20);
            this.lblChkSum.TabIndex = 46;
            this.lblChkSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lChkSum
            // 
            this.lChkSum.Location = new System.Drawing.Point(3, 121);
            this.lChkSum.Name = "lChkSum";
            this.lChkSum.Size = new System.Drawing.Size(57, 13);
            this.lChkSum.TabIndex = 45;
            this.lChkSum.Text = "Checksum";
            this.lChkSum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFilename
            // 
            this.lblFilename.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFilename.Location = new System.Drawing.Point(203, 117);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(242, 20);
            this.lblFilename.TabIndex = 44;
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lFilename
            // 
            this.lFilename.Location = new System.Drawing.Point(150, 121);
            this.lFilename.Name = "lFilename";
            this.lFilename.Size = new System.Drawing.Size(52, 13);
            this.lFilename.TabIndex = 43;
            this.lFilename.Text = "Filename";
            this.lFilename.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDate
            // 
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDate.Location = new System.Drawing.Point(63, 59);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(86, 20);
            this.lblDate.TabIndex = 42;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDate
            // 
            this.lDate.Location = new System.Drawing.Point(30, 63);
            this.lDate.Name = "lDate";
            this.lDate.Size = new System.Drawing.Size(30, 13);
            this.lDate.TabIndex = 41;
            this.lDate.Text = "Date";
            this.lDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSubVendor
            // 
            this.lblSubVendor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubVendor.Location = new System.Drawing.Point(203, 87);
            this.lblSubVendor.Name = "lblSubVendor";
            this.lblSubVendor.Size = new System.Drawing.Size(136, 20);
            this.lblSubVendor.TabIndex = 40;
            this.lblSubVendor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSubVendor
            // 
            this.lSubVendor.Location = new System.Drawing.Point(150, 91);
            this.lSubVendor.Name = "lSubVendor";
            this.lSubVendor.Size = new System.Drawing.Size(52, 13);
            this.lSubVendor.TabIndex = 39;
            this.lSubVendor.Text = "Vendor";
            this.lSubVendor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDevID
            // 
            this.lblDevID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDevID.Location = new System.Drawing.Point(63, 87);
            this.lblDevID.Name = "lblDevID";
            this.lblDevID.Size = new System.Drawing.Size(86, 20);
            this.lblDevID.TabIndex = 38;
            this.lblDevID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDevID
            // 
            this.lDevID.Location = new System.Drawing.Point(5, 91);
            this.lDevID.Name = "lDevID";
            this.lDevID.Size = new System.Drawing.Size(55, 13);
            this.lDevID.TabIndex = 37;
            this.lDevID.Text = "Device ID";
            this.lDevID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBIOS
            // 
            this.lblBIOS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBIOS.Location = new System.Drawing.Point(203, 59);
            this.lblBIOS.Name = "lblBIOS";
            this.lblBIOS.Size = new System.Drawing.Size(136, 20);
            this.lblBIOS.TabIndex = 36;
            this.lblBIOS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lBIOS
            // 
            this.lBIOS.Location = new System.Drawing.Point(150, 63);
            this.lBIOS.Name = "lBIOS";
            this.lBIOS.Size = new System.Drawing.Size(52, 13);
            this.lBIOS.TabIndex = 35;
            this.lBIOS.Text = "Version";
            this.lBIOS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGPU
            // 
            this.lblGPU.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGPU.Location = new System.Drawing.Point(63, 31);
            this.lblGPU.Name = "lblGPU";
            this.lblGPU.Size = new System.Drawing.Size(276, 20);
            this.lblGPU.TabIndex = 34;
            this.lblGPU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lGPU
            // 
            this.lGPU.Location = new System.Drawing.Point(25, 35);
            this.lGPU.Name = "lGPU";
            this.lGPU.Size = new System.Drawing.Size(35, 13);
            this.lGPU.TabIndex = 33;
            this.lGPU.Text = "Board";
            this.lGPU.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName.Location = new System.Drawing.Point(63, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(382, 20);
            this.lblName.TabIndex = 31;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lName
            // 
            this.lName.Location = new System.Drawing.Point(25, 7);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 30;
            this.lName.Text = "Name";
            this.lName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lImgBack
            // 
            this.lImgBack.AllowDrop = true;
            this.lImgBack.BackColor = System.Drawing.SystemColors.Control;
            this.lImgBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lImgBack.Location = new System.Drawing.Point(345, 31);
            this.lImgBack.Name = "lImgBack";
            this.lImgBack.Size = new System.Drawing.Size(100, 77);
            this.lImgBack.TabIndex = 32;
            this.lImgBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lImgBack.Paint += new System.Windows.Forms.PaintEventHandler(this.lImgBack_Paint);
            // 
            // UCCabecalho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblChkSum);
            this.Controls.Add(this.lChkSum);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.lFilename);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lDate);
            this.Controls.Add(this.lblSubVendor);
            this.Controls.Add(this.lSubVendor);
            this.Controls.Add(this.lblDevID);
            this.Controls.Add(this.lDevID);
            this.Controls.Add(this.lblBIOS);
            this.Controls.Add(this.lBIOS);
            this.Controls.Add(this.lblGPU);
            this.Controls.Add(this.lGPU);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lImgBack);
            this.Name = "UCCabecalho";
            this.Size = new System.Drawing.Size(450, 143);
            this.ResumeLayout(false);

    }
}
