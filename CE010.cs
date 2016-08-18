// Decompiled with JetBrains decompiler
// Type: 
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using MaxwellBiosTweaker.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class UCBoostClocks : UserControl, ComponenteDaTela, INotifyPropertyChanged
{
    private float _RowCount = 17f;
    private Color _YellowBackColor = Color.FromArgb(byte.MaxValue, 235, 156);
    private Color _YellowForeColor = Color.FromArgb(156, 101, 0);
    private Color _GreenBackColor = Color.FromArgb(198, 239, 206);
    private Color _GreenForeColor = Color.FromArgb(0, 97, 0);
    private BoostTable _BoostTable;
    private List<ushort> _SliderClocks;
    private IContainer components;
    private LvClocks lvClocks;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    private ColumnHeader columnHeader7;
    private ColumnHeader columnHeader8;
    private ColumnHeader columnHeader9;
    private ColumnHeader columnHeader10;
    private ColumnHeader columnHeader11;
    private ColumnHeader columnHeader12;
    private BoostLimit scMaxTableClock;
    private Label lblIndexWidth;
    private Label lblClockWidth;
    private ContextMenuStrip cmsBoostTable;
    private ToolStripMenuItem fixInvalidClocksToolStripMenuItem;

    internal BoostTable BoostTable
    {
        get
        {
            return this._BoostTable;
        }
        set
        {
            this._BoostTable = value;
            this.UpdateData(false);
        }
    }

    public bool StepAllowed
    {
        get
        {
            if (this.SliderEnabled)
                return this.SliderPosition < this.SliderMaximum;
            return false;
        }
    }

    public int SliderPosition
    {
        get
        {
            return this.scMaxTableClock.SliderPosition;
        }
        set
        {
            this.scMaxTableClock.SliderPosition = value;
            this.NotifyPropertyChanged("");
        }
    }

    public int SliderMaximum
    {
        get
        {
            return this.scMaxTableClock.SliderMaximum;
        }
        set
        {
            this.scMaxTableClock.SliderMaximum = value;
            this.NotifyPropertyChanged("");
        }
    }

    public bool SliderEnabled
    {
        get
        {
            return this.scMaxTableClock.Enabled;
        }
        set
        {
            this.scMaxTableClock.Enabled = value;
            this.NotifyPropertyChanged("");
        }
    }

    public string SliderText
    {
        get
        {
            return this.scMaxTableClock.ValueText;
        }
        set
        {
            this.scMaxTableClock.ValueText = value;
            this.NotifyPropertyChanged("");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public UCBoostClocks()
    {
        this.InitializeComponent();
    }

    public void ApplyChanges()
    {
        if (this.BoostTable == null || !this.Enabled)
            return;
        byte maxBoostIndex = this.GetMaxBoostIndex();
        int splitIndex = this.GetSplitIndex(maxBoostIndex);
        for (int index = maxBoostIndex; index > splitIndex; --index)
        {
            ListViewItem.ListViewSubItem itemByIndex = this.GetItemByIndex(index, true);
            this._BoostTable.BoostClocks[index].Frequency = CE00D.E006(itemByIndex.Text);
        }
    }

    public void Reset()
    {
        this.BoostTable = null;
        this.InternalReset();
    }

    private void InternalReset()
    {
        this.lvClocks.Clear();
        this.SliderText = "";
        this.SliderEnabled = false;
    }

    private void UpdateData(bool overrideinvalid = false)
    {
        this.InternalReset();
        if (this.BoostTable == null)
            return;
        bool flag = overrideinvalid || this.AllClocksValid();
        this.SliderEnabled = flag;
        this.FillClockTableView(!overrideinvalid);
        if (!flag)
            return;
        this.InitSliderClocks();
    }

    private bool AllClocksValid()
    {
        byte maxBoostIndex = this.GetMaxBoostIndex();
        int splitIndex = this.GetSplitIndex(maxBoostIndex);
        if (maxBoostIndex > splitIndex)
        {
            for (int index = maxBoostIndex; index > splitIndex; --index)
            {
                if (CE00D.PE000.IndexOf(this.BoostTable.BoostClocks[index].Frequency) == -1)
                    return false;
            }
        }
        else
        {
            for (int index = maxBoostIndex; index < splitIndex; ++index)
            {
                if (CE00D.PE000.IndexOf(this.BoostTable.BoostClocks[index].Frequency) == -1)
                    return false;
            }
        }
        return true;
    }

    private void InitTableView()
    {
        this.lvClocks.Clear();
        int num = (int)Math.Floor(this.BoostTable.BoostClocks.Count / (double)this._RowCount) + 2;
        List<string> list = new List<string>();
        for (int index = 0; index < num; ++index)
        {
            this.lvClocks.Columns.Add("", this.lblIndexWidth.Width, HorizontalAlignment.Right);
            this.lvClocks.Columns.Add("", this.lblClockWidth.Width, HorizontalAlignment.Right);
            list.Add("");
            list.Add("");
        }
        string[] items = list.ToArray();
        for (int index = 0; (double)index < (double)this._RowCount; ++index)
            this.lvClocks.Items.Add(new ListViewItem(items)).UseItemStyleForSubItems = false;
    }

    private ListViewItem.ListViewSubItem GetItemByIndex(int index, bool getValueColumn)
    {
        int num = (int)Math.Floor(index / (double)this._RowCount);
        int index1 = (int)Math.Floor(index - this._RowCount * (double)num);
        if (getValueColumn)
            return this.lvClocks.Items[index1].SubItems[num * 2 + 1];
        return this.lvClocks.Items[index1].SubItems[num * 2];
    }

    private int GetSplitIndex(byte maxBoostClockIndex)
    {
        int num1 = Enumerable.Min<CE018, byte>(Enumerable.Where<CE018>(this.BoostTable.FE005, b => (int)b.PE002 > 0), b => b.PE002);
        if (num1 == maxBoostClockIndex)
            num1 = Enumerable.Min<CE018, byte>(this.BoostTable.FE005, b => b.PE002);
        int num2 = Enumerable.Max<BoostClock, ushort>(this.BoostTable.BoostClocks, c => c.Frequency);
        int num3 = 0;
        for (int index = maxBoostClockIndex; index > 0; --index)
        {
            ushort num4 = this.BoostTable.BoostClocks[index].Frequency;
            if (num3 != 0 && num2 - num4 > num3 + 5)
            {
                num1 = index;
                break;
            }
            if (index <= num1 && index < maxBoostClockIndex)
            {
                num1 = index;
                break;
            }
            num3 = num2 - num4;
            num2 = num4;
        }
        return num1;
    }

    private byte GetMaxBoostIndex()
    {
        return Enumerable.First<byte>(Enumerable.Select<CE018, byte>(Enumerable.Where<CE018>(this.BoostTable.FE005, b => (int)b.PE001 == 0), b => b.PE002));
    }

    private void FillClockTableView(bool showInvalid)
    {
        byte maxBoostIndex = this.GetMaxBoostIndex();
        IEnumerable<int> source = Enumerable.Select<CE018, int>(this.BoostTable.FE005, p => (int)p.PE002);
        int splitIndex = this.GetSplitIndex(maxBoostIndex);
        this.InitTableView();
        for (int index = 0; index < this.BoostTable.BoostClocks.Count; ++index)
        {
            ListViewItem.ListViewSubItem itemByIndex1 = this.GetItemByIndex(index, false);
            ListViewItem.ListViewSubItem itemByIndex2 = this.GetItemByIndex(index, true);
            ushort num = this.BoostTable.BoostClocks[index].Frequency;
            itemByIndex1.Text = index.ToString("00");
            itemByIndex2.Text = CE00D.E005(num);
            if (index > splitIndex && index <= maxBoostIndex)
            {
                itemByIndex1.BackColor = this._YellowBackColor;
                itemByIndex2.BackColor = this._YellowBackColor;
                itemByIndex1.ForeColor = this._YellowForeColor;
                itemByIndex2.ForeColor = this._YellowForeColor;
            }
            if (Enumerable.Contains<int>(source, index))
            {
                itemByIndex1.BackColor = this._GreenBackColor;
                itemByIndex2.BackColor = this._GreenBackColor;
                itemByIndex1.ForeColor = this._GreenForeColor;
                itemByIndex2.ForeColor = this._GreenForeColor;
            }
            if (showInvalid && maxBoostIndex > splitIndex && (index > splitIndex && index <= maxBoostIndex) && CE00D.PE000.IndexOf(num) == -1)
                itemByIndex2.Font = new Font(itemByIndex2.Font, FontStyle.Strikeout);
            if (showInvalid && splitIndex > maxBoostIndex && (index >= maxBoostIndex && index < splitIndex) && CE00D.PE000.IndexOf(num) == -1)
                itemByIndex2.Font = new Font(itemByIndex2.Font, FontStyle.Strikeout);
        }
    }

    private void InitSliderClocks()
    {
        byte maxBoostIndex = this.GetMaxBoostIndex();
        int splitIndex = this.GetSplitIndex(maxBoostIndex);
        ushort num1 = CE00D.E006(this.GetItemByIndex(maxBoostIndex, true).Text);
        ushort num2 = CE00D.E006(this.GetItemByIndex(splitIndex, true).Text);
        int num3 = CE00D.E006(this.GetItemByIndex(splitIndex + 1, true).Text);
        List<ushort> list = new List<ushort>();
        foreach (ushort num4 in CE00D.PE000)
        {
            if (num4 >= num2)
                list.Add(num4);
        }
        int num5 = 0;
        for (int index = 0; index < list.Count; ++index)
        {
            if (list[index] == num1)
            {
                num5 = index;
                break;
            }
        }
        for (int index = num5; index >= 0; --index)
        {
            if (maxBoostIndex - splitIndex - index > 0)
                list.RemoveAt(index);
        }
        this._SliderClocks = list;
        this.InitSlider();
    }

    private void InitSlider()
    {
        ushort num1 = CE00D.E006(this.GetItemByIndex(this.GetMaxBoostIndex(), true).Text);
        this.SliderMaximum = this._SliderClocks.Count - 1;
        int num2 = this._SliderClocks.IndexOf(num1);
        if (num2 < 0)
            return;
        this.SliderPosition = num2;
    }

    private string GetClockString(int index)
    {
        if (this._SliderClocks == null)
            return "";
        return string.Format("{0} MHz", CE00D.E005(this._SliderClocks[index]));
    }

    private void ShiftClockTableMaxBoost(ushort maxBoost)
    {
        byte maxBoostIndex = this.GetMaxBoostIndex();
        int splitIndex = this.GetSplitIndex(maxBoostIndex);
        int index1 = CE00D.PE000.IndexOf(maxBoost);
        if (maxBoostIndex > splitIndex)
        {
            for (int index2 = maxBoostIndex; index2 > splitIndex; --index2)
            {
                this.GetItemByIndex(index2, true).Text = CE00D.E005(CE00D.PE000[index1]);
                --index1;
            }
        }
        else
        {
            for (int index2 = maxBoostIndex; index2 < splitIndex; ++index2)
            {
                this.GetItemByIndex(index2, true).Text = CE00D.E005(CE00D.PE000[index1]);
                ++index1;
            }
        }
    }

    private void scMaxTableClock_OnScroll(object sender, EventArgs e)
    {
        if (this._SliderClocks == null)
            return;
        this.SliderText = this.GetClockString(this.SliderPosition);
        this.ShiftClockTableMaxBoost(this._SliderClocks[this.SliderPosition]);
    }

    internal void AddStep()
    {
        if (!this.StepAllowed)
            return;
        ++this.SliderPosition;
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (this.PropertyChanged == null)
            return;
        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    private void fixInvalidClocksToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.UpdateData(true);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && this.components != null)
            this.components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "01",
            "2012"}, -1);
            this.lblIndexWidth = new System.Windows.Forms.Label();
            this.lblClockWidth = new System.Windows.Forms.Label();
            this.cmsBoostTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fixInvalidClocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scMaxTableClock = new BoostLimit();
            this.lvClocks = new LvClocks();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.cmsBoostTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIndexWidth
            // 
            this.lblIndexWidth.Location = new System.Drawing.Point(308, 115);
            this.lblIndexWidth.Name = "lblIndexWidth";
            this.lblIndexWidth.Size = new System.Drawing.Size(26, 23);
            this.lblIndexWidth.TabIndex = 3;
            this.lblIndexWidth.Text = "IndexWidth";
            this.lblIndexWidth.Visible = false;
            // 
            // lblClockWidth
            // 
            this.lblClockWidth.Location = new System.Drawing.Point(308, 143);
            this.lblClockWidth.Name = "lblClockWidth";
            this.lblClockWidth.Size = new System.Drawing.Size(54, 23);
            this.lblClockWidth.TabIndex = 4;
            this.lblClockWidth.Text = "ClockWidth";
            this.lblClockWidth.Visible = false;
            // 
            // cmsBoostTable
            // 
            this.cmsBoostTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixInvalidClocksToolStripMenuItem});
            this.cmsBoostTable.Name = "cmsBoostTable";
            this.cmsBoostTable.Size = new System.Drawing.Size(163, 26);
            // 
            // fixInvalidClocksToolStripMenuItem
            // 
            this.fixInvalidClocksToolStripMenuItem.Name = "fixInvalidClocksToolStripMenuItem";
            this.fixInvalidClocksToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.fixInvalidClocksToolStripMenuItem.Text = "Fix invalid clocks";
            this.fixInvalidClocksToolStripMenuItem.Click += new System.EventHandler(this.fixInvalidClocksToolStripMenuItem_Click);
            // 
            // scMaxTableClock
            // 
            this.scMaxTableClock.Caption = "Max Table Clock";
            this.scMaxTableClock.Location = new System.Drawing.Point(5, 297);
            this.scMaxTableClock.Name = "scMaxTableClock";
            this.scMaxTableClock.Size = new System.Drawing.Size(404, 28);
            this.scMaxTableClock.SliderMaximum = 97;
            this.scMaxTableClock.SliderPosition = 67;
            this.scMaxTableClock.TabIndex = 1;
            this.scMaxTableClock.ValueText = "";
            this.scMaxTableClock.ValueTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scMaxTableClock.OnScroll += new System.EventHandler(this.scMaxTableClock_OnScroll);
            // 
            // lvClocks
            // 
            this.lvClocks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lvClocks.ContextMenuStrip = this.cmsBoostTable;
            this.lvClocks.GridLines = true;
            this.lvClocks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvClocks.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvClocks.Location = new System.Drawing.Point(3, 3);
            this.lvClocks.MultiSelect = false;
            this.lvClocks.Name = "lvClocks";
            this.lvClocks.Scrollable = false;
            this.lvClocks.Size = new System.Drawing.Size(410, 292);
            this.lvClocks.TabIndex = 0;
            this.lvClocks.UseCompatibleStateImageBehavior = false;
            this.lvClocks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 20;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 44;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 24;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 44;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 24;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 44;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 24;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 44;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 24;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Width = 44;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 24;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Width = 44;
            // 
            // UCBoostClocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblClockWidth);
            this.Controls.Add(this.lblIndexWidth);
            this.Controls.Add(this.scMaxTableClock);
            this.Controls.Add(this.lvClocks);
            this.Name = "UCBoostClocks";
            this.Size = new System.Drawing.Size(416, 330);
            this.cmsBoostTable.ResumeLayout(false);
            this.ResumeLayout(false);

    }
}
