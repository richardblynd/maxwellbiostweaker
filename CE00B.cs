using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

public class UCVoltageTable : UserControl, ComponenteDaTela
{
    private List<UCVoltageLine> _EntryControlList = new List<UCVoltageLine>();
    private BoostTable _BoostTable;
    private PerfTable _PerfTable;
    private VoltageTable _VoltageTable;
    private IContainer components;

    internal BoostTable BoostTable
    {
        get
        {
            return _BoostTable;
        }
        set
        {
            _BoostTable = value;
            UpdateData();
        }
    }

    internal PerfTable PerfTable
    {
        get
        {
            return _PerfTable;
        }
        set
        {
            _PerfTable = value;
            UpdateData();
        }
    }

    internal VoltageTable VoltageTable
    {
        get
        {
            return _VoltageTable;
        }
        set
        {
            Reset();
            _VoltageTable = value;
            UpdateData();
        }
    }

    public UCVoltageTable()
    {
        InitializeComponent();
    }

    public void ApplyChanges()
    {
        if (VoltageTable == null)
            return;
        foreach (var obj in _EntryControlList)
            obj.ApplyChanges();
    }

    public void Reset()
    {
        _VoltageTable = null;
        InternalReset();
    }

    private void InternalReset()
    {
        foreach (var obj in _EntryControlList)
            obj.Reset();
        Controls.Clear();
        Enabled = false;
    }

    private void UpdateData()
    {
        InternalReset();

        if (PerfTable == null || VoltageTable == null)
            return;

        Enabled = true;

        var num = 4;

        _EntryControlList = new List<UCVoltageLine>();

        for (var vid = 0; vid < VoltageTable.ListaVoltagens.Count; ++vid)
        {
            var voltagem = VoltageTable.ListaVoltagens[vid];

            if (CE013.E000(voltagem.From) && CE013.E000(voltagem.To))
            {
                var voltageLine = new UCVoltageLine
                {
                    VoltageEntry = voltagem,
                    Left = 0,
                    Top = num,
                    Caption = GetCaption(vid)
                };

                Controls.Add(voltageLine);

                _EntryControlList.Add(voltageLine);

                num += voltageLine.Height + 4;
            }
        }
    }

    private string GetCaption(int vid)
    {
        if (PerfTable == null)
            return "";

        var list1 = PerfTable.Voltages.Where(param0 => (int)param0.Index == vid).OrderBy(p => p.Caption).Select(p => string.Format("P{0:00}", p.Caption)).ToList();

        if (list1.Count >= 1)
            return string.Join(",", list1.ToArray());

        if (BoostTable != null)
        {
            var list2 = GetBoostClockIndex(vid).Select(x => string.Format("{0:00}", x)).ToList();

            if (list2.Count > 0)
                return "CLK " + string.Join(",", list2.ToArray());
        }

        return "";
    }

    private int[] GetBoostClockIndex(int vid)
    {
        var list = new List<int>();

        for (var index = 0; index < BoostTable.BoostClocks.Count; ++index)
        {
            if (BoostTable.BoostClocks[index].Index == vid && BoostTable.BoostClocks[index].Frequency > 0)
                list.Add(index);
        }

        return list.ToArray();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // UCVoltageTable
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        Name = "UCVoltageTable";
        Size = new System.Drawing.Size(416, 238);
        ResumeLayout(false);

    }
}
