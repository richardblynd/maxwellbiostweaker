// Decompiled with JetBrains decompiler
// Type: MaxwellBiosTweaker.frmMBT
// Assembly: MaxwellBiosTweaker, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null
// MVID: 18FF3EAF-C0B5-4490-9850-453411C15390
// Assembly location: D:\Instalações\Placa de Vídeo\Overclock\gtx-970-980-power-limiter-mod\Maxwe ll Bios Tweaker 1.36\MaxwellBiosTweaker.exe

using MaxwellBiosTweaker.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MaxwellBiosTweaker
{
    public class frmMBT : Form
    {
        [StructLayout(LayoutKind.Explicit, Size = 5, Pack = 1)]
        private struct Estrutura
        {
        }

        private NvFlashHelper nvFlashHelper = new NvFlashHelper();
        private readonly List<ComponenteDaTela> componentesDaTela;
        private Bios Bios;
        private IContainer E003;
        private GroupBox gbInfo;
        private TabControl tabControl;
        private TabPage tpClockStates;
        private Button btnOpen;
        private Button btnSave;
        private Button btnSaveAs;
        private TabPage tpBoostStates;
        private TabPage tpBoostTable;
        private TabPage tpCommon;
        private UCFanRange frcFanRange;
        private UCPerfTableControl ptcPerfTable;
        private Panel panel3;
        private GroupBox groupBox1;
        private GroupBox gbFanControl;
        private Panel panel2;
        private GroupBox groupBox2;
        private Panel panel4;
        private GroupBox groupBox4;
        private Panel panel5;
        private GroupBox groupBox5;
        private UCBoostClocks btcBoostClocks;
        private UCBoostConfigControl boostConfigControl;
        private UCBoostLimitHelperControl blhBoostLimiterHelperControl;
        private Button btnRead;
        private Button btnFlash;
        private UCMemoryClock mchMemoryClock;
        private Button btnGpuCLockOffsetHelper;
        private Button btnVoltToClock;
        private TabPage tpPowerTable;
        private Panel panel1;
        private GroupBox groupBox6;
        private UCPowerTable ptcPowerTable;
        private TabPage tpVoltageTable;
        private Panel panel6;
        private GroupBox groupBox3;
        private UCVoltageTable vtcVoltageTable;
        private Button btBITEntires;
        private Button btCompare;
        private UCCabecalho hcHeader;
        private UCBaseBoostControl bbcBaseBoost;
        private UCTempTargets ttcTempTargets;

        public frmMBT()
        {
            this.InitializeComponent();
            this.componentesDaTela = this.ComponentesDaTela();
            Application.Idle += this.HabilitaDesabilitaBtnGpuCLockOffsetHelper;
        }

        private void HabilitaDesabilitaBtnGpuCLockOffsetHelper(object param0, EventArgs param1)
        {
            this.btnGpuCLockOffsetHelper.Enabled = this.bbcBaseBoost.StepAllowed && this.btcBoostClocks.StepAllowed;
        }

        private List<ComponenteDaTela> ComponentesDaTela()
        {
            return new List<ComponenteDaTela>()
            {
                frcFanRange,
                bbcBaseBoost,
                ptcPerfTable,
                btcBoostClocks,
                boostConfigControl,
                ptcPowerTable,
                vtcVoltageTable,
                ttcTempTargets
            };
        }

        private void LimparTela()
        {
            this.tabControl.TabPages.Clear();
            this.hcHeader.ResetDisplay(false);
            foreach (ComponenteDaTela obj in this.componentesDaTela)
                obj.Reset();
            this.tabControl.Enabled = false;
        }

        private void AbrirBios(string param0_1)
        {
            this.LimparTela();
            this.Bios = new Bios(param0_1);

            if (this.Bios.PE000)
            {
                LinhaBios linhaBios = this.Bios.linhasDaBios[0];
                this.hcHeader.RomHeader = linhaBios.RomHeader;
                this.hcHeader.FileName = new FileInfo(param0_1).Name;
                this.hcHeader.ImageChecksum = linhaBios.ImageChecksum;
                this.hcHeader.GeneratedChecksum = linhaBios.GenerateChecksum();

                if (linhaBios.BoostTable != null)
                    CE00D.E001(linhaBios.BoostTable.BoostClocks.Select(param0_2 => param0_2.Frequency).ToList());

                this.tabControl.TabPages.Add(this.tpCommon);
                this.bbcBaseBoost.PE000 = linhaBios.FE006;

                if (this.Bios.PE003)
                {
                    this.vtcVoltageTable.BoostTable = linhaBios.BoostTable;
                    this.vtcVoltageTable.PerfTable = linhaBios.PerfTable;
                    this.vtcVoltageTable.VoltageTable = linhaBios.VoltageTable;
                    this.tabControl.TabPages.Add(this.tpVoltageTable);
                }

                if (this.Bios.PossuiFanSettings)
                {
                    this.frcFanRange.FanSettings = linhaBios.FanSettings;
                    this.frcFanRange.FanSettings2 = linhaBios.FanSettings2;
                }

                if (this.Bios.PossuiPowerTable)
                {
                    this.ptcPowerTable.PowerTable = linhaBios.PowerTable;
                    this.tabControl.TabPages.Add(this.tpPowerTable);
                }

                this.tabControl.TabPages.Add(this.tpBoostTable);

                if (this.Bios.PossuiBoostProfile)
                {
                    this.boostConfigControl.BoostProfile = linhaBios.BoostProfile;
                    this.blhBoostLimiterHelperControl.BoostConfigControl = this.boostConfigControl;
                    this.tabControl.TabPages.Add(this.tpBoostStates);
                }

                this.ptcPerfTable.PerfTable = linhaBios.PerfTable;
                this.mchMemoryClock.PerfTableControl = this.ptcPerfTable;
                this.ttcTempTargets.TempTargets = linhaBios.TempTargets;
                this.tabControl.TabPages.Add(this.tpClockStates);
                this.btcBoostClocks.BoostTable = linhaBios.BoostTable;
                this.tabControl.Enabled = true;
            }
            else
                this.hcHeader.ResetDisplay(true);
        }

        private void SalvarArquivoBios(string param0)
        {
            if (this.Bios == null || !this.Bios.PE000)
                return;

            this.Bios.EscreverBios(param0);
        }

        private void AplicarAlteracoes()
        {
            try
            {
                if (this.Bios == null || !this.Bios.PE000)
                    return;
                foreach (ComponenteDaTela obj in this.componentesDaTela)
                    obj.ApplyChanges();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Error - Not Applied");
            }
        }

        private void Load_Form(object param0, EventArgs param1)
        {
            this.LimparTela();
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = string.Format("Maxwell II BIOS Tweaker v{0}.{1}{2}", version.Major, version.Minor, version.Build);
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1 && (commandLineArgs[1].ToLower().EndsWith(".bin") || commandLineArgs[1].ToLower().EndsWith(".rom")))
                this.AbrirBios(commandLineArgs[1]);
            
            //this.btnFlash.Visible = false;
            //this.btnRead.Visible = false;
            //this.btnVoltToClock.Visible = false;
        }

        private void btnOpen_Click(object param0, EventArgs param1)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.rom";
            openFileDialog.Filter = "BIOS Files|*.rom;*.bin";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.AbrirBios(openFileDialog.FileName);
        }

        private void btnSave_Click(object param0, EventArgs param1)
        {
            if (this.Bios == null || !this.Bios.PE000)
                return;
            this.AplicarAlteracoes();
            this.SalvarArquivoBios(this.Bios.caminhoArquivo);
            this.AbrirBios(this.Bios.caminhoArquivo);
        }

        private void btnSaveAs_Click(object param0, EventArgs param1)
        {
            if (this.Bios == null || !this.Bios.PE000)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "*.rom";
            saveFileDialog.Filter = "BIOS ROM|*.rom";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.AplicarAlteracoes();
            this.SalvarArquivoBios(saveFileDialog.FileName);
            this.AbrirBios(saveFileDialog.FileName);
        }

        private void DragDrop_Event(object param0, DragEventArgs param1)
        {
            string[] strArray = (string[])param1.Data.GetData(DataFormats.FileDrop);
            if (strArray.Length != 1)
                return;
            this.AbrirBios(strArray[0]);
        }

        private void DragEnter_Event(object param0, DragEventArgs param1)
        {
            if (param1.Data.GetDataPresent(DataFormats.FileDrop))
                param1.Effect = DragDropEffects.Copy;
            else
                param1.Effect = DragDropEffects.None;
        }

        private void btnFlash_Click(object param0, EventArgs param1)
        {
            if (this.Bios == null || !this.Bios.PE000)
                return;
            this.AplicarAlteracoes();
            this.SalvarArquivoBios(this.Bios.caminhoArquivo);
            this.nvFlashHelper.SubirBiosParaGPU(this.Bios.caminhoArquivo);
        }

        private void btnRead_Click(object param0, EventArgs param1)
        {
            this.AbrirBios(this.nvFlashHelper.BaixarBiosDaGPU());
        }

        private void btnGpuCLockOffsetHelper_Click(object param0, EventArgs param1)
        {
            if (!this.bbcBaseBoost.StepAllowed || !this.btcBoostClocks.StepAllowed)
                return;
            this.bbcBaseBoost.E006();
            this.btcBoostClocks.AddStep();
        }

        private void btnVoltToClock_Click(object param0, EventArgs param1)
        {
            if (this.Bios == null || !this.Bios.PE000)
                return;
            
            LinhaBios obj = this.Bios.linhasDaBios[0];
            
            StringBuilder stringBuilder = new StringBuilder();

            for (int index = 0; index < obj.BoostTable.BoostClocks.Count; ++index)
                stringBuilder.AppendLine(this.ME010(index));

            int num = (int)MessageBox.Show(stringBuilder.ToString());
        }

        private string ME010(int param0)
        {
            //TODO: COMENTEI TUDO MÉTODO É USADO EM UM LUGAR AONDE O MÉTODO QUE USA ELE NÃO É USADO

            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            //frmMBT.Estrutura obj1 = new frmMBT.Estrutura();
            var obj2 = this.Bios.linhasDaBios[0];
            
            // ISSUE: reference to a compiler-generated field
            var E000 = obj2.BoostTable.BoostClocks[param0];
            
            // ISSUE: reference to a compiler-generated field
            var obj3 = obj2.VoltageTable.ListaVoltagens[E000.Index];
            
            // ISSUE: reference to a compiler-generated method
            Voltage obj4 = obj2.PerfTable.Voltages.Where(x).FirstOrDefault();
            
            string str = "";
            if (obj4 != null)
                str = string.Format(" => P{0:00}", obj4.Caption);
            
            // ISSUE: reference to a compiler-generated field
            return string.Format("[{0}] {1:0000.0}MHz @ [{2}] {3}mV - {4}mV {5}", (object)param0.ToString("00"), (object)(E000.Frequency / 2f).ToString("0000.0"), (object)E000.Index.ToString("00"), (object)(obj3.From / 1000f).ToString("0000.0000"), (object)(obj3.To / 1000f).ToString("0000.0000"), (object)str);
            
            //return "";
        }

        private bool x(Voltage arg)
        {
            return true;
        }
        
        private void hcHeader_DoubleClick(object param0, EventArgs param1)
        {
            int num = (int)MessageBox.Show("Header");
        }

        private void KeyDown_Event(object param0, KeyEventArgs param1)
        {
        }

        private void btBITEntires_Click(object param0, EventArgs param1)
        {

        }

        private void btCompare_Click(object param0, EventArgs param1)
        {

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.E003 != null)
                E003.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.btCompare = new System.Windows.Forms.Button();
            this.btBITEntires = new System.Windows.Forms.Button();
            this.btnVoltToClock = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpBoostTable = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tpClockStates = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tpBoostStates = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tpCommon = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbFanControl = new System.Windows.Forms.GroupBox();
            this.btnGpuCLockOffsetHelper = new System.Windows.Forms.Button();
            this.tpPowerTable = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tpVoltageTable = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnFlash = new System.Windows.Forms.Button();
            this.btcBoostClocks = new UCBoostClocks();
            this.ptcPerfTable = new UCPerfTableControl();
            this.boostConfigControl = new UCBoostConfigControl();
            this.frcFanRange = new UCFanRange();
            this.bbcBaseBoost = new MaxwellBiosTweaker.Controls.UCBaseBoostControl();
            this.ttcTempTargets = new UCTempTargets();
            this.mchMemoryClock = new UCMemoryClock();
            this.blhBoostLimiterHelperControl = new UCBoostLimitHelperControl();
            this.ptcPowerTable = new UCPowerTable();
            this.vtcVoltageTable = new UCVoltageTable();
            this.hcHeader = new UCCabecalho();
            this.gbInfo.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpBoostTable.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpClockStates.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tpBoostStates.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tpCommon.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbFanControl.SuspendLayout();
            this.tpPowerTable.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tpVoltageTable.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                                 | System.Windows.Forms.AnchorStyles.Right;
            this.gbInfo.Controls.Add(this.hcHeader);
            this.gbInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbInfo.Location = new System.Drawing.Point(9, 1);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(466, 161);
            this.gbInfo.TabIndex = 8;
            this.gbInfo.TabStop = false;
            // 
            // btCompare
            // 
            this.btCompare.Location = new System.Drawing.Point(181, 563);
            this.btCompare.Name = "btCompare";
            this.btCompare.Size = new System.Drawing.Size(87, 23);
            this.btCompare.TabIndex = 28;
            this.btCompare.Text = "Compare";
            this.btCompare.UseVisualStyleBackColor = true;
            this.btCompare.Click += this.btCompare_Click;
            // 
            // btBITEntires
            // 
            this.btBITEntires.Location = new System.Drawing.Point(370, 563);
            this.btBITEntires.Name = "btBITEntires";
            this.btBITEntires.Size = new System.Drawing.Size(104, 24);
            this.btBITEntires.TabIndex = 27;
            this.btBITEntires.Text = "BIT Entires";
            this.btBITEntires.UseVisualStyleBackColor = true;
            this.btBITEntires.Click += this.btBITEntires_Click;
            // 
            // btnVoltToClock
            // 
            this.btnVoltToClock.Location = new System.Drawing.Point(270, 563);
            this.btnVoltToClock.Name = "btnVoltToClock";
            this.btnVoltToClock.Size = new System.Drawing.Size(95, 24);
            this.btnVoltToClock.TabIndex = 26;
            this.btnVoltToClock.Text = "VoltToClock";
            this.btnVoltToClock.UseVisualStyleBackColor = true;
            this.btnVoltToClock.Click += this.btnVoltToClock_Click;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                      | System.Windows.Forms.AnchorStyles.Left) 
                                     | System.Windows.Forms.AnchorStyles.Right;
            this.tabControl.Controls.Add(this.tpBoostTable);
            this.tabControl.Controls.Add(this.tpClockStates);
            this.tabControl.Controls.Add(this.tpBoostStates);
            this.tabControl.Controls.Add(this.tpCommon);
            this.tabControl.Controls.Add(this.tpPowerTable);
            this.tabControl.Controls.Add(this.tpVoltageTable);
            this.tabControl.Enabled = false;
            this.tabControl.Location = new System.Drawing.Point(9, 169);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(470, 392);
            this.tabControl.TabIndex = 9;
            // 
            // tpBoostTable
            // 
            this.tpBoostTable.Controls.Add(this.panel2);
            this.tpBoostTable.Location = new System.Drawing.Point(4, 22);
            this.tpBoostTable.Name = "tpBoostTable";
            this.tpBoostTable.Padding = new System.Windows.Forms.Padding(3);
            this.tpBoostTable.Size = new System.Drawing.Size(462, 366);
            this.tpBoostTable.TabIndex = 6;
            this.tpBoostTable.Text = "Boost Table";
            this.tpBoostTable.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                  | System.Windows.Forms.AnchorStyles.Left) 
                                 | System.Windows.Forms.AnchorStyles.Right;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 363);
            this.panel2.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btcBoostClocks);
            this.groupBox2.Location = new System.Drawing.Point(14, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 343);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Boost Clocks";
            // 
            // tpClockStates
            // 
            this.tpClockStates.Controls.Add(this.panel4);
            this.tpClockStates.Location = new System.Drawing.Point(4, 22);
            this.tpClockStates.Name = "tpClockStates";
            this.tpClockStates.Padding = new System.Windows.Forms.Padding(3);
            this.tpClockStates.Size = new System.Drawing.Size(462, 366);
            this.tpClockStates.TabIndex = 0;
            this.tpClockStates.Text = "Clock States";
            this.tpClockStates.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                  | System.Windows.Forms.AnchorStyles.Left) 
                                 | System.Windows.Forms.AnchorStyles.Right;
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Location = new System.Drawing.Point(1, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(460, 368);
            this.panel4.TabIndex = 25;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ptcPerfTable);
            this.groupBox4.Location = new System.Drawing.Point(14, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(429, 343);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Clock States";
            // 
            // tpBoostStates
            // 
            this.tpBoostStates.Controls.Add(this.panel5);
            this.tpBoostStates.Location = new System.Drawing.Point(4, 22);
            this.tpBoostStates.Name = "tpBoostStates";
            this.tpBoostStates.Padding = new System.Windows.Forms.Padding(3);
            this.tpBoostStates.Size = new System.Drawing.Size(462, 366);
            this.tpBoostStates.TabIndex = 4;
            this.tpBoostStates.Tag = "";
            this.tpBoostStates.Text = "Boost States";
            this.tpBoostStates.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                  | System.Windows.Forms.AnchorStyles.Left) 
                                 | System.Windows.Forms.AnchorStyles.Right;
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.groupBox5);
            this.panel5.Location = new System.Drawing.Point(1, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(460, 368);
            this.panel5.TabIndex = 26;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.boostConfigControl);
            this.groupBox5.Location = new System.Drawing.Point(14, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(429, 346);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Boost States";
            // 
            // tpCommon
            // 
            this.tpCommon.Controls.Add(this.panel3);
            this.tpCommon.Location = new System.Drawing.Point(4, 22);
            this.tpCommon.Name = "tpCommon";
            this.tpCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tpCommon.Size = new System.Drawing.Size(462, 366);
            this.tpCommon.TabIndex = 7;
            this.tpCommon.Text = "Common";
            this.tpCommon.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                  | System.Windows.Forms.AnchorStyles.Left) 
                                 | System.Windows.Forms.AnchorStyles.Right;
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.gbFanControl);
            this.panel3.Location = new System.Drawing.Point(1, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 361);
            this.panel3.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.frcFanRange);
            this.groupBox1.Location = new System.Drawing.Point(14, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 148);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fan Control (Experimental)";
            // 
            // gbFanControl
            // 
            this.gbFanControl.Controls.Add(this.bbcBaseBoost);
            this.gbFanControl.Controls.Add(this.ttcTempTargets);
            this.gbFanControl.Controls.Add(this.btnGpuCLockOffsetHelper);
            this.gbFanControl.Controls.Add(this.mchMemoryClock);
            this.gbFanControl.Controls.Add(this.blhBoostLimiterHelperControl);
            this.gbFanControl.Location = new System.Drawing.Point(14, 13);
            this.gbFanControl.Name = "gbFanControl";
            this.gbFanControl.Size = new System.Drawing.Size(429, 182);
            this.gbFanControl.TabIndex = 0;
            this.gbFanControl.TabStop = false;
            this.gbFanControl.Text = "Basic Clock Settings";
            // 
            // btnGpuCLockOffsetHelper
            // 
            this.btnGpuCLockOffsetHelper.Location = new System.Drawing.Point(225, 155);
            this.btnGpuCLockOffsetHelper.Name = "btnGpuCLockOffsetHelper";
            this.btnGpuCLockOffsetHelper.Size = new System.Drawing.Size(187, 21);
            this.btnGpuCLockOffsetHelper.TabIndex = 3;
            this.btnGpuCLockOffsetHelper.Text = "GPU Clock Offset + 13MHz";
            this.btnGpuCLockOffsetHelper.UseVisualStyleBackColor = true;
            this.btnGpuCLockOffsetHelper.Click += this.btnGpuCLockOffsetHelper_Click;
            // 
            // tpPowerTable
            // 
            this.tpPowerTable.Controls.Add(this.panel1);
            this.tpPowerTable.Location = new System.Drawing.Point(4, 22);
            this.tpPowerTable.Name = "tpPowerTable";
            this.tpPowerTable.Padding = new System.Windows.Forms.Padding(3);
            this.tpPowerTable.Size = new System.Drawing.Size(462, 366);
            this.tpPowerTable.TabIndex = 8;
            this.tpPowerTable.Text = "Power Table";
            this.tpPowerTable.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                  | System.Windows.Forms.AnchorStyles.Left) 
                                 | System.Windows.Forms.AnchorStyles.Right;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 365);
            this.panel1.TabIndex = 24;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ptcPowerTable);
            this.groupBox6.Location = new System.Drawing.Point(14, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(429, 344);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Power Table";
            // 
            // tpVoltageTable
            // 
            this.tpVoltageTable.Controls.Add(this.panel6);
            this.tpVoltageTable.Location = new System.Drawing.Point(4, 22);
            this.tpVoltageTable.Name = "tpVoltageTable";
            this.tpVoltageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tpVoltageTable.Size = new System.Drawing.Size(462, 366);
            this.tpVoltageTable.TabIndex = 9;
            this.tpVoltageTable.Text = "Voltage Table";
            this.tpVoltageTable.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                                  | System.Windows.Forms.AnchorStyles.Left) 
                                 | System.Windows.Forms.AnchorStyles.Right;
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.groupBox3);
            this.panel6.Location = new System.Drawing.Point(1, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(460, 362);
            this.panel6.TabIndex = 25;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.vtcVoltageTable);
            this.groupBox3.Location = new System.Drawing.Point(14, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(429, 343);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Voltage Table";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnOpen.Location = new System.Drawing.Point(9, 589);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open BIOS";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += this.btnOpen_Click;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Location = new System.Drawing.Point(95, 589);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save BIOS";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += this.btnSave_Click;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveAs.Location = new System.Drawing.Point(181, 589);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(100, 23);
            this.btnSaveAs.TabIndex = 2;
            this.btnSaveAs.Text = "Save BIOS As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += this.btnSaveAs_Click;
            // 
            // btnRead
            // 
            this.btnRead.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnRead.Location = new System.Drawing.Point(341, 589);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(64, 23);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "ReadBios";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += this.btnRead_Click;
            // 
            // btnFlash
            // 
            this.btnFlash.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnFlash.Location = new System.Drawing.Point(411, 589);
            this.btnFlash.Name = "btnFlash";
            this.btnFlash.Size = new System.Drawing.Size(64, 23);
            this.btnFlash.TabIndex = 4;
            this.btnFlash.Text = "FlashBios";
            this.btnFlash.UseVisualStyleBackColor = true;
            this.btnFlash.Click += this.btnFlash_Click;
            // 
            // btcBoostClocks
            // 
            this.btcBoostClocks.Location = new System.Drawing.Point(6, 19);
            this.btcBoostClocks.Name = "btcBoostClocks";
            this.btcBoostClocks.Size = new System.Drawing.Size(413, 318);
            this.btcBoostClocks.SliderEnabled = true;
            this.btcBoostClocks.SliderMaximum = 97;
            this.btcBoostClocks.SliderPosition = 67;
            this.btcBoostClocks.SliderText = "";
            this.btcBoostClocks.TabIndex = 0;
            // 
            // ptcPerfTable
            // 
            this.ptcPerfTable.Location = new System.Drawing.Point(7, 14);
            this.ptcPerfTable.Name = "ptcPerfTable";
            this.ptcPerfTable.Size = new System.Drawing.Size(415, 323);
            this.ptcPerfTable.TabIndex = 94;
            // 
            // boostConfigControl
            // 
            this.boostConfigControl.Location = new System.Drawing.Point(7, 14);
            this.boostConfigControl.Name = "boostConfigControl";
            this.boostConfigControl.Size = new System.Drawing.Size(415, 326);
            this.boostConfigControl.TabIndex = 0;
            // 
            // frcFanRange
            // 
            this.frcFanRange.Location = new System.Drawing.Point(7, 19);
            this.frcFanRange.Name = "frcFanRange";
            this.frcFanRange.Size = new System.Drawing.Size(409, 125);
            this.frcFanRange.TabIndex = 0;
            // 
            // bbcBaseBoost
            // 
            this.bbcBaseBoost.Location = new System.Drawing.Point(7, 19);
            this.bbcBaseBoost.Name = "bbcBaseBoost";
            this.bbcBaseBoost.Size = new System.Drawing.Size(409, 82);
            this.bbcBaseBoost.TabIndex = 0;
            // 
            // ttcTempTargets
            // 
            this.ttcTempTargets.Location = new System.Drawing.Point(7, 99);
            this.ttcTempTargets.Name = "ttcTempTargets";
            this.ttcTempTargets.Size = new System.Drawing.Size(409, 25);
            this.ttcTempTargets.TabIndex = 4;
            // 
            // mchMemoryClock
            // 
            this.mchMemoryClock.Location = new System.Drawing.Point(7, 151);
            this.mchMemoryClock.Name = "mchMemoryClock";
            this.mchMemoryClock.Size = new System.Drawing.Size(198, 28);
            this.mchMemoryClock.TabIndex = 2;
            // 
            // blhBoostLimiterHelperControl
            // 
            this.blhBoostLimiterHelperControl.Location = new System.Drawing.Point(7, 125);
            this.blhBoostLimiterHelperControl.Name = "blhBoostLimiterHelperControl";
            this.blhBoostLimiterHelperControl.Size = new System.Drawing.Size(405, 27);
            this.blhBoostLimiterHelperControl.TabIndex = 1;
            // 
            // ptcPowerTable
            // 
            this.ptcPowerTable.AutoScroll = true;
            this.ptcPowerTable.Location = new System.Drawing.Point(7, 19);
            this.ptcPowerTable.Name = "ptcPowerTable";
            this.ptcPowerTable.Size = new System.Drawing.Size(416, 319);
            this.ptcPowerTable.TabIndex = 0;
            // 
            // vtcVoltageTable
            // 
            this.vtcVoltageTable.AutoScroll = true;
            this.vtcVoltageTable.Location = new System.Drawing.Point(7, 19);
            this.vtcVoltageTable.Name = "vtcVoltageTable";
            this.vtcVoltageTable.Size = new System.Drawing.Size(416, 318);
            this.vtcVoltageTable.TabIndex = 0;
            // 
            // hcHeader
            // 
            this.hcHeader.FileName = null;
            this.hcHeader.GeneratedChecksum = 0;
            this.hcHeader.ImageChecksum = 0;
            this.hcHeader.Location = new System.Drawing.Point(9, 12);
            this.hcHeader.Name = "hcHeader";
            this.hcHeader.Size = new System.Drawing.Size(450, 143);
            this.hcHeader.TabIndex = 0;
            this.hcHeader.DoubleClick += this.hcHeader_DoubleClick;
            // 
            // frmMBT
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 616);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btCompare);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnVoltToClock);
            this.Controls.Add(this.btBITEntires);
            this.Controls.Add(this.btnFlash);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.gbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(454, 528);
            this.Name = "frmMBT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maxwell BIOS Editor";
            this.Load += this.Load_Form;
            this.DragDrop += this.DragDrop_Event;
            this.DragEnter += this.DragEnter_Event;
            this.KeyDown += this.KeyDown_Event;
            this.gbInfo.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpBoostTable.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tpClockStates.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tpBoostStates.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tpCommon.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbFanControl.ResumeLayout(false);
            this.tpPowerTable.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tpVoltageTable.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }


            //ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMBT));

            //gbInfo = new GroupBox();
            //btCompare = new Button();
            //btBITEntires = new Button();
            //btnVoltToClock = new Button();
            //tabControl = new TabControl();
            //tpBoostTable = new TabPage();
            //panel2 = new Panel();
            //groupBox2 = new GroupBox();
            //tpClockStates = new TabPage();
            //panel4 = new Panel();
            //groupBox4 = new GroupBox();
            //tpBoostStates = new TabPage();
            //panel5 = new Panel();
            //groupBox5 = new GroupBox();
            //tpCommon = new TabPage();
            //panel3 = new Panel();
            //groupBox1 = new GroupBox();
            //gbFanControl = new GroupBox();
            //btnGpuCLockOffsetHelper = new Button();
            //tpPowerTable = new TabPage();
            //panel1 = new Panel();
            //groupBox6 = new GroupBox();
            //tpVoltageTable = new TabPage();
            //panel6 = new Panel();
            //groupBox3 = new GroupBox();
            //btnOpen = new Button();
            //btnSave = new Button();
            //btnSaveAs = new Button();
            
            //btnRead = new Button();
            //btnFlash = new Button();
            //btcBoostClocks = new UCBoostClocks();
            //ptcPerfTable = new UCPerfTable();
            //boostConfigControl = new UCBoostConfigControl();
            //frcFanRange = new UCFanRange();
            
            //ttcTempTargets = new UCTempTargets();
            //mchMemoryClock = new UCMemoryClock();
            //blhBoostLimiterHelperControl = new UCBoostLimitHelperControl();
            
            ////bbcBaseBoost = new BaseBoostControl();
            
            //ptcPowerTable = new UCPowerTable();
            //vtcVoltageTable = new UCVoltageTable();
           
            ////hcHeader = new UCCabecalho();

            //gbInfo.SuspendLayout();
            //tabControl.SuspendLayout();
            //tpBoostTable.SuspendLayout();
            //panel2.SuspendLayout();
            //groupBox2.SuspendLayout();
            //tpClockStates.SuspendLayout();
            //panel4.SuspendLayout();
            //groupBox4.SuspendLayout();
            //tpBoostStates.SuspendLayout();
            //panel5.SuspendLayout();
            //groupBox5.SuspendLayout();
            //tpCommon.SuspendLayout();
            //panel3.SuspendLayout();
            //groupBox1.SuspendLayout();
            //gbFanControl.SuspendLayout();
            //tpPowerTable.SuspendLayout();
            //panel1.SuspendLayout();
            //groupBox6.SuspendLayout();
            //tpVoltageTable.SuspendLayout();
            //panel6.SuspendLayout();
            //groupBox3.SuspendLayout();
            //SuspendLayout();
            //gbInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //gbInfo.Controls.Add(btCompare);
            //gbInfo.Controls.Add(btBITEntires);
            //gbInfo.Controls.Add(btnVoltToClock);
            
            ////gbInfo.Controls.Add(hcHeader);
            
            //gbInfo.FlatStyle = FlatStyle.Flat;
            //gbInfo.Location = new Point(9, 1);
            //gbInfo.Name = "gbInfo";
            //gbInfo.Size = new Size(466, 161);
            //gbInfo.TabIndex = 8;
            //gbInfo.TabStop = false;
            //btCompare.Location = new Point(362, 19);
            //btCompare.Name = "btCompare";
            //btCompare.Size = new Size(87, 23);
            //btCompare.TabIndex = 28;
            //btCompare.Text = "Compare";
            //btCompare.UseVisualStyleBackColor = true;
            //btCompare.Visible = false;
            //btCompare.Click += btCompare_Click;
            //btBITEntires.Location = new Point(345, 131);
            //btBITEntires.Name = "btBITEntires";
            //btBITEntires.Size = new Size(104, 24);
            //btBITEntires.TabIndex = 27;
            //btBITEntires.Text = "BIT Entires";
            //btBITEntires.UseVisualStyleBackColor = true;
            //btBITEntires.Visible = false;
            //btBITEntires.Click += btBITEntires_Click;
            //btnVoltToClock.Location = new Point(354, 96);
            //btnVoltToClock.Name = "btnVoltToClock";
            //btnVoltToClock.Size = new Size(95, 24);
            //btnVoltToClock.TabIndex = 26;
            //btnVoltToClock.Text = "VoltToClock";
            //btnVoltToClock.UseVisualStyleBackColor = true;
            //btnVoltToClock.Visible = false;
            //btnVoltToClock.Click += btnVoltToClock_Click;
            //tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //tabControl.Controls.Add(tpBoostTable);
            //tabControl.Controls.Add(tpClockStates);
            //tabControl.Controls.Add(tpBoostStates);
            //tabControl.Controls.Add(tpCommon);
            //tabControl.Controls.Add(tpPowerTable);
            //tabControl.Controls.Add(tpVoltageTable);
            //tabControl.Enabled = false;
            //tabControl.Location = new Point(9, 169);
            //tabControl.Name = "tcSettings";
            //tabControl.SelectedIndex = 0;
            //tabControl.Size = new Size(470, 391);
            //tabControl.TabIndex = 9;
            //tpBoostTable.Controls.Add(panel2);
            //tpBoostTable.Location = new Point(4, 22);
            //tpBoostTable.Name = "tpBoostTable";
            //tpBoostTable.Padding = new Padding(3);
            //tpBoostTable.Size = new Size(462, 365);
            //tpBoostTable.TabIndex = 6;
            //tpBoostTable.Text = "Boost Table";
            //tpBoostTable.UseVisualStyleBackColor = true;
            //panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //panel2.BackColor = SystemColors.Control;
            //panel2.BorderStyle = BorderStyle.FixedSingle;
            //panel2.Controls.Add(groupBox2);
            //panel2.Location = new Point(1, 2);
            //panel2.Name = "panel2";
            //panel2.Size = new Size(460, 362);
            //panel2.TabIndex = 25;
            //groupBox2.Controls.Add(btcBoostClocks);
            //groupBox2.Location = new Point(14, 13);
            //groupBox2.Name = "groupBox2";
            //groupBox2.Size = new Size(429, 343);
            //groupBox2.TabIndex = 39;
            //groupBox2.TabStop = false;
            //groupBox2.Text = "Boost Clocks";
            //tpClockStates.Controls.Add(panel4);
            //tpClockStates.Location = new Point(4, 22);
            //tpClockStates.Name = "tpClockStates";
            //tpClockStates.Padding = new Padding(3);
            //tpClockStates.Size = new Size(462, 365);
            //tpClockStates.TabIndex = 0;
            //tpClockStates.Text = "Clock States";
            //tpClockStates.UseVisualStyleBackColor = true;
            //panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //panel4.BackColor = SystemColors.Control;
            //panel4.BorderStyle = BorderStyle.FixedSingle;
            //panel4.Controls.Add(groupBox4);
            //panel4.Location = new Point(1, 2);
            //panel4.Name = "panel4";
            //panel4.Size = new Size(460, 367);
            //panel4.TabIndex = 25;
            //groupBox4.Controls.Add(ptcPerfTable);
            //groupBox4.Location = new Point(14, 13);
            //groupBox4.Name = "groupBox4";
            //groupBox4.Size = new Size(429, 343);
            //groupBox4.TabIndex = 39;
            //groupBox4.TabStop = false;
            //groupBox4.Text = "Clock States";
            //tpBoostStates.Controls.Add(panel5);
            //tpBoostStates.Location = new Point(4, 22);
            //tpBoostStates.Name = "tpBoostStates";
            //tpBoostStates.Padding = new Padding(3);
            //tpBoostStates.Size = new Size(462, 365);
            //tpBoostStates.TabIndex = 4;
            //tpBoostStates.Tag = (object)"";
            //tpBoostStates.Text = "Boost States";
            //tpBoostStates.UseVisualStyleBackColor = true;
            //panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //panel5.BackColor = SystemColors.Control;
            //panel5.BorderStyle = BorderStyle.FixedSingle;
            //panel5.Controls.Add(groupBox5);
            //panel5.Location = new Point(1, 2);
            //panel5.Name = "panel5";
            //panel5.Size = new Size(460, 367);
            //panel5.TabIndex = 26;
            //groupBox5.Controls.Add(boostConfigControl);
            //groupBox5.Location = new Point(14, 13);
            //groupBox5.Name = "groupBox5";
            //groupBox5.Size = new Size(429, 346);
            //groupBox5.TabIndex = 39;
            //groupBox5.TabStop = false;
            //groupBox5.Text = "Boost States";
            //tpCommon.Controls.Add(panel3);
            //tpCommon.Location = new Point(4, 22);
            //tpCommon.Name = "tpCommon";
            //tpCommon.Padding = new Padding(3);
            //tpCommon.Size = new Size(462, 365);
            //tpCommon.TabIndex = 7;
            //tpCommon.Text = "Common";
            //tpCommon.UseVisualStyleBackColor = true;
            //panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //panel3.BackColor = SystemColors.Control;
            //panel3.BorderStyle = BorderStyle.FixedSingle;
            //panel3.Controls.Add(groupBox1);
            //panel3.Controls.Add(gbFanControl);
            //panel3.Location = new Point(1, 2);
            //panel3.Name = "panel3";
            //panel3.Size = new Size(460, 360);
            //panel3.TabIndex = 24;
            //groupBox1.Controls.Add(frcFanRange);
            //groupBox1.Location = new Point(14, 202);
            //groupBox1.Name = "groupBox1";
            //groupBox1.Size = new Size(429, 148);
            //groupBox1.TabIndex = 1;
            //groupBox1.TabStop = false;
            //groupBox1.Text = "Fan Control (Experimental)";
            //gbFanControl.Controls.Add(ttcTempTargets);
            //gbFanControl.Controls.Add(btnGpuCLockOffsetHelper);
            //gbFanControl.Controls.Add(mchMemoryClock);
            //gbFanControl.Controls.Add(blhBoostLimiterHelperControl);

            ////gbFanControl.Controls.Add(bbcBaseBoost);

            //gbFanControl.Location = new Point(14, 13);
            //gbFanControl.Name = "gbFanControl";
            //gbFanControl.Size = new Size(429, 182);
            //gbFanControl.TabIndex = 0;
            //gbFanControl.TabStop = false;
            //gbFanControl.Text = "Basic Clock Settings";
            //btnGpuCLockOffsetHelper.Location = new Point(225, 155);
            //btnGpuCLockOffsetHelper.Name = "btnGpuCLockOffsetHelper";
            //btnGpuCLockOffsetHelper.Size = new Size(187, 21);
            //btnGpuCLockOffsetHelper.TabIndex = 3;
            //btnGpuCLockOffsetHelper.Text = "GPU Clock Offset + 13MHz";
            //btnGpuCLockOffsetHelper.UseVisualStyleBackColor = true;
            //btnGpuCLockOffsetHelper.Click += btnGpuCLockOffsetHelper_Click;
            //tpPowerTable.Controls.Add(panel1);
            //tpPowerTable.Location = new Point(4, 22);
            //tpPowerTable.Name = "tpPowerTable";
            //tpPowerTable.Padding = new Padding(3);
            //tpPowerTable.Size = new Size(462, 365);
            //tpPowerTable.TabIndex = 8;
            //tpPowerTable.Text = "Power Table";
            //tpPowerTable.UseVisualStyleBackColor = true;
            //panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //panel1.BackColor = SystemColors.Control;
            //panel1.BorderStyle = BorderStyle.FixedSingle;
            //panel1.Controls.Add(groupBox6);
            //panel1.Location = new Point(1, 1);
            //panel1.Name = "panel1";
            //panel1.Size = new Size(460, 364);
            //panel1.TabIndex = 24;
            //groupBox6.Controls.Add(ptcPowerTable);
            //groupBox6.Location = new Point(14, 13);
            //groupBox6.Name = "groupBox6";
            //groupBox6.Size = new Size(429, 344);
            //groupBox6.TabIndex = 0;
            //groupBox6.TabStop = false;
            //groupBox6.Text = "Power Table";
            //tpVoltageTable.Controls.Add(panel6);
            //tpVoltageTable.Location = new Point(4, 22);
            //tpVoltageTable.Name = "tpVoltageTable";
            //tpVoltageTable.Padding = new Padding(3);
            //tpVoltageTable.Size = new Size(462, 365);
            //tpVoltageTable.TabIndex = 9;
            //tpVoltageTable.Text = "Voltage Table";
            //tpVoltageTable.UseVisualStyleBackColor = true;
            //panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //panel6.BackColor = SystemColors.Control;
            //panel6.BorderStyle = BorderStyle.FixedSingle;
            //panel6.Controls.Add(groupBox3);
            //panel6.Location = new Point(1, 1);
            //panel6.Name = "panel6";
            //panel6.Size = new Size(460, 361);
            //panel6.TabIndex = 25;
            //groupBox3.Controls.Add(vtcVoltageTable);
            //groupBox3.Location = new Point(14, 13);
            //groupBox3.Name = "groupBox3";
            //groupBox3.Size = new Size(429, 343);
            //groupBox3.TabIndex = 0;
            //groupBox3.TabStop = false;
            //groupBox3.Text = "Voltage Table";
            //btnOpen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            //btnOpen.Location = new Point(9, 566);
            //btnOpen.Name = "btnOpen";
            //btnOpen.Size = new Size(80, 23);
            //btnOpen.TabIndex = 0;
            //btnOpen.Text = "Open BIOS";
            //btnOpen.UseVisualStyleBackColor = true;
            //btnOpen.Click += btnOpen_Click;
            //btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            //btnSave.Location = new Point(95, 566);
            //btnSave.Name = "btnSave";
            //btnSave.Size = new Size(80, 23);
            //btnSave.TabIndex = 1;
            //btnSave.Text = "Save BIOS";
            //btnSave.UseVisualStyleBackColor = true;
            //btnSave.Click += btnSave_Click;
            //btnSaveAs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            //btnSaveAs.Location = new Point(181, 566);
            //btnSaveAs.Name = "btnSaveAs";
            //btnSaveAs.Size = new Size(100, 23);
            //btnSaveAs.TabIndex = 2;
            //btnSaveAs.Text = "Save BIOS As";
            //btnSaveAs.UseVisualStyleBackColor = true;
            //btnSaveAs.Click += new EventHandler(this.btnSaveAs_Click);
            //btnRead.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //btnRead.Location = new Point(341, 566);
            //btnRead.Name = "btnRead";
            //btnRead.Size = new Size(64, 23);
            //btnRead.TabIndex = 3;
            //btnRead.Text = "ReadBios";
            //btnRead.UseVisualStyleBackColor = true;
            //btnRead.Click += btnRead_Click;
            //btnFlash.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //btnFlash.Location = new Point(411, 566);
            //btnFlash.Name = "btnFlash";
            //btnFlash.Size = new Size(64, 23);
            //btnFlash.TabIndex = 4;
            //btnFlash.Text = "FlashBios";
            //btnFlash.UseVisualStyleBackColor = true;
            //btnFlash.Click += btnFlash_Click;
            //btcBoostClocks.Location = new Point(6, 19);
            //btcBoostClocks.Name = "btcBoostClocks";
            //btcBoostClocks.Size = new Size(413, 318);
            //btcBoostClocks.SliderEnabled = true;
            //btcBoostClocks.SliderMaximum = 97;
            //btcBoostClocks.SliderPosition = 67;
            //btcBoostClocks.SliderText = "";
            //btcBoostClocks.TabIndex = 0;
            //ptcPerfTable.Location = new Point(7, 14);
            //ptcPerfTable.Name = "ptcPerfTable";
            //ptcPerfTable.Size = new Size(415, 323);
            //ptcPerfTable.TabIndex = 94;
            //boostConfigControl.Location = new Point(7, 14);
            //boostConfigControl.Name = "bccBoostStates";
            //boostConfigControl.Size = new Size(415, 326);
            //boostConfigControl.TabIndex = 0;
            //frcFanRange.Location = new Point(7, 19);
            //frcFanRange.Name = "frcFanRange";
            //frcFanRange.Size = new Size(409, 125);
            //frcFanRange.TabIndex = 0;
            //ttcTempTargets.Location = new Point(7, 99);
            //ttcTempTargets.Name = "ttcTempTargets";
            //ttcTempTargets.Size = new Size(409, 25);
            //ttcTempTargets.TabIndex = 4;
            //mchMemoryClock.Location = new Point(7, 151);
            //mchMemoryClock.Name = "mchMemoryClock";
            //mchMemoryClock.Size = new Size(198, 28);
            //mchMemoryClock.TabIndex = 2;
            //blhBoostLimiterHelperControl.Location = new Point(7, 125);
            //blhBoostLimiterHelperControl.Name = "blhBoostLimit";
            //blhBoostLimiterHelperControl.Size = new Size(405, 27);
            //blhBoostLimiterHelperControl.TabIndex = 1;
            
            ////bbcBaseBoost.Location = new Point(7, 19);
            ////bbcBaseBoost.Name = "bbcBaseBoost";
            ////bbcBaseBoost.Size = new Size(409, 85);
            ////bbcBaseBoost.TabIndex = 0;
            
            //ptcPowerTable.AutoScroll = true;
            //ptcPowerTable.Location = new Point(7, 19);
            //ptcPowerTable.Name = "ptcPowerTable";
            //ptcPowerTable.Size = new Size(416, 319);
            //ptcPowerTable.TabIndex = 0;
            //ptcPowerTable.KeyPress += ptcPowerTable_KeyPress;
            //vtcVoltageTable.AutoScroll = true;
            //vtcVoltageTable.Location = new Point(7, 19);
            //vtcVoltageTable.Name = "vtcVoltageTable";
            //vtcVoltageTable.Size = new Size(416, 318);
            //vtcVoltageTable.TabIndex = 0;
            
            ////hcHeader.FileName = null;
            ////hcHeader.GeneratedChecksum = 0;
            ////hcHeader.ImageChecksum = 0;
            ////hcHeader.Location = new Point(9, 14);
            ////hcHeader.Name = "hcHeader";
            ////hcHeader.Size = new Size(450, 143);
            ////hcHeader.TabIndex = 0;
            ////hcHeader.DoubleClick += hcHeader_DoubleClick;

            //AllowDrop = true;
            //AutoScaleDimensions = new SizeF(6f, 13f);

            ////AutoScaleMode = AutoScaleMode.Font;

            //ClientSize = new Size(485, 593);
            //Controls.Add(btnSaveAs);
            //Controls.Add(btnSave);
            //Controls.Add(btnFlash);
            //Controls.Add(btnRead);
            //Controls.Add(btnOpen);
            //Controls.Add(tabControl);
            //Controls.Add(gbInfo);

            ////FormBorderStyle = FormBorderStyle.Fixed3D;
            ////Icon = (Icon)componentResourceManager.GetObject("$this.Icon");

            //KeyPreview = true;
            //MaximizeBox = false;
            //MinimizeBox = false;
            //MinimumSize = new Size(454, 528);
            //Name = "frmMBT";
            //StartPosition = FormStartPosition.CenterScreen;
            //Text = "Maxwell BIOS Editor";
            //Load += Load_Form;
            //DragDrop += DragDrop_Event;
            //DragEnter += DragEnter_Event;
            //KeyDown += KeyDown_Event;
            //gbInfo.ResumeLayout(false);
            //tabControl.ResumeLayout(false);
            //tpBoostTable.ResumeLayout(false);
            //panel2.ResumeLayout(false);
            //groupBox2.ResumeLayout(false);
            //tpClockStates.ResumeLayout(false);
            //panel4.ResumeLayout(false);
            //groupBox4.ResumeLayout(false);
            //tpBoostStates.ResumeLayout(false);
            //panel5.ResumeLayout(false);
            //groupBox5.ResumeLayout(false);
            //tpCommon.ResumeLayout(false);
            //panel3.ResumeLayout(false);
            //groupBox1.ResumeLayout(false);
            //gbFanControl.ResumeLayout(false);
            //tpPowerTable.ResumeLayout(false);
            //panel1.ResumeLayout(false);
            //groupBox6.ResumeLayout(false);
            //tpVoltageTable.ResumeLayout(false);
            //panel6.ResumeLayout(false);
            //groupBox3.ResumeLayout(false);
            //ResumeLayout(false);

        //private void InicializarComponentes()
        //{
        //    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMBT));
        //    this.gbInfo = new GroupBox();
        //    this.btCompare = new Button();
        //    this.btBITEntires = new Button();
        //    this.btnVoltToClock = new Button();
        //    this.tabControl = new TabControl();
        //    this.tpBoostTable = new TabPage();
        //    this.panel2 = new Panel();
        //    this.groupBox2 = new GroupBox();
        //    this.tpClockStates = new TabPage();
        //    this.panel4 = new Panel();
        //    this.groupBox4 = new GroupBox();
        //    this.tpBoostStates = new TabPage();
        //    this.panel5 = new Panel();
        //    this.groupBox5 = new GroupBox();
        //    this.tpCommon = new TabPage();
        //    this.panel3 = new Panel();
        //    this.groupBox1 = new GroupBox();
        //    this.gbFanControl = new GroupBox();
        //    this.btnGpuCLockOffsetHelper = new Button();
        //    this.tpPowerTable = new TabPage();
        //    this.panel1 = new Panel();
        //    this.groupBox6 = new GroupBox();
        //    this.tpVoltageTable = new TabPage();
        //    this.panel6 = new Panel();
        //    this.groupBox3 = new GroupBox();
        //    this.btnOpen = new Button();
        //    this.btnSave = new Button();
        //    this.btnSaveAs = new Button();
        //    this.btnRead = new Button();
        //    this.btnFlash = new Button();
        //    this.btcBoostClocks = new UCBoostClocks();
        //    this.ptcPerfTable = new UCPerfTable();
        //    this.boostConfigControl = new UCBoostConfigControl();
        //    this.frcFanRange = new UCFanRange();
        //    this.ttcTempTargets = new UCTempTargets();
        //    this.mchMemoryClock = new UCMemoryClock();
        //    this.blhBoostLimiterHelperControl = new UCBoostLimitHelperControl();
        //    this.bbcBaseBoost = new BaseBoostControl();
        //    this.ptcPowerTable = new UCPowerTable();
        //    this.vtcVoltageTable = new UCVoltageTable();
        //    this.hcHeader = new UCCabecalho();
        //    this.gbInfo.SuspendLayout();
        //    this.tabControl.SuspendLayout();
        //    this.tpBoostTable.SuspendLayout();
        //    this.panel2.SuspendLayout();
        //    this.groupBox2.SuspendLayout();
        //    this.tpClockStates.SuspendLayout();
        //    this.panel4.SuspendLayout();
        //    this.groupBox4.SuspendLayout();
        //    this.tpBoostStates.SuspendLayout();
        //    this.panel5.SuspendLayout();
        //    this.groupBox5.SuspendLayout();
        //    this.tpCommon.SuspendLayout();
        //    this.panel3.SuspendLayout();
        //    this.groupBox1.SuspendLayout();
        //    this.gbFanControl.SuspendLayout();
        //    this.tpPowerTable.SuspendLayout();
        //    this.panel1.SuspendLayout();
        //    this.groupBox6.SuspendLayout();
        //    this.tpVoltageTable.SuspendLayout();
        //    this.panel6.SuspendLayout();
        //    this.groupBox3.SuspendLayout();
        //    this.SuspendLayout();
        //    this.gbInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        //    this.gbInfo.Controls.Add((Control)this.btCompare);
        //    this.gbInfo.Controls.Add((Control)this.btBITEntires);
        //    this.gbInfo.Controls.Add((Control)this.btnVoltToClock);
        //    this.gbInfo.Controls.Add((Control)this.hcHeader);
        //    this.gbInfo.FlatStyle = FlatStyle.Flat;
        //    this.gbInfo.Location = new Point(9, 1);
        //    this.gbInfo.Name = "gbInfo";
        //    this.gbInfo.Size = new Size(466, 161);
        //    this.gbInfo.TabIndex = 8;
        //    this.gbInfo.TabStop = false;
        //    this.btCompare.Location = new Point(362, 19);
        //    this.btCompare.Name = "btCompare";
        //    this.btCompare.Size = new Size(87, 23);
        //    this.btCompare.TabIndex = 28;
        //    this.btCompare.Text = "Compare";
        //    this.btCompare.UseVisualStyleBackColor = true;
        //    this.btCompare.Visible = false;
        //    this.btCompare.Click += new EventHandler(this.ME015);
        //    this.btBITEntires.Location = new Point(345, 131);
        //    this.btBITEntires.Name = "btBITEntires";
        //    this.btBITEntires.Size = new Size(104, 24);
        //    this.btBITEntires.TabIndex = 27;
        //    this.btBITEntires.Text = "BIT Entires";
        //    this.btBITEntires.UseVisualStyleBackColor = true;
        //    this.btBITEntires.Visible = false;
        //    this.btBITEntires.Click += new EventHandler(this.ME014);
        //    this.btnVoltToClock.Location = new Point(354, 96);
        //    this.btnVoltToClock.Name = "btnVoltToClock";
        //    this.btnVoltToClock.Size = new Size(95, 24);
        //    this.btnVoltToClock.TabIndex = 26;
        //    this.btnVoltToClock.Text = "VoltToClock";
        //    this.btnVoltToClock.UseVisualStyleBackColor = true;
        //    this.btnVoltToClock.Visible = false;
        //    this.btnVoltToClock.Click += new EventHandler(this.ME00F);
        //    this.tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        //    this.tabControl.Controls.Add((Control)this.tpBoostTable);
        //    this.tabControl.Controls.Add((Control)this.tpClockStates);
        //    this.tabControl.Controls.Add((Control)this.tpBoostStates);
        //    this.tabControl.Controls.Add((Control)this.tpCommon);
        //    this.tabControl.Controls.Add((Control)this.tpPowerTable);
        //    this.tabControl.Controls.Add((Control)this.tpVoltageTable);
        //    this.tabControl.Enabled = false;
        //    this.tabControl.Location = new Point(9, 169);
        //    this.tabControl.Name = "tcSettings";
        //    this.tabControl.SelectedIndex = 0;
        //    this.tabControl.Size = new Size(470, 391);
        //    this.tabControl.TabIndex = 9;
        //    this.tpBoostTable.Controls.Add((Control)this.panel2);
        //    this.tpBoostTable.Location = new Point(4, 22);
        //    this.tpBoostTable.Name = "tpBoostTable";
        //    this.tpBoostTable.Padding = new Padding(3);
        //    this.tpBoostTable.Size = new Size(462, 365);
        //    this.tpBoostTable.TabIndex = 6;
        //    this.tpBoostTable.Text = "Boost Table";
        //    this.tpBoostTable.UseVisualStyleBackColor = true;
        //    this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        //    this.panel2.BackColor = SystemColors.Control;
        //    this.panel2.BorderStyle = BorderStyle.FixedSingle;
        //    this.panel2.Controls.Add((Control)this.groupBox2);
        //    this.panel2.Location = new Point(1, 2);
        //    this.panel2.Name = "panel2";
        //    this.panel2.Size = new Size(460, 362);
        //    this.panel2.TabIndex = 25;
        //    this.groupBox2.Controls.Add((Control)this.btcBoostClocks);
        //    this.groupBox2.Location = new Point(14, 13);
        //    this.groupBox2.Name = "groupBox2";
        //    this.groupBox2.Size = new Size(429, 343);
        //    this.groupBox2.TabIndex = 39;
        //    this.groupBox2.TabStop = false;
        //    this.groupBox2.Text = "Boost Clocks";
        //    this.tpClockStates.Controls.Add((Control)this.panel4);
        //    this.tpClockStates.Location = new Point(4, 22);
        //    this.tpClockStates.Name = "tpClockStates";
        //    this.tpClockStates.Padding = new Padding(3);
        //    this.tpClockStates.Size = new Size(462, 365);
        //    this.tpClockStates.TabIndex = 0;
        //    this.tpClockStates.Text = "Clock States";
        //    this.tpClockStates.UseVisualStyleBackColor = true;
        //    this.panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        //    this.panel4.BackColor = SystemColors.Control;
        //    this.panel4.BorderStyle = BorderStyle.FixedSingle;
        //    this.panel4.Controls.Add((Control)this.groupBox4);
        //    this.panel4.Location = new Point(1, 2);
        //    this.panel4.Name = "panel4";
        //    this.panel4.Size = new Size(460, 367);
        //    this.panel4.TabIndex = 25;
        //    this.groupBox4.Controls.Add((Control)this.ptcPerfTable);
        //    this.groupBox4.Location = new Point(14, 13);
        //    this.groupBox4.Name = "groupBox4";
        //    this.groupBox4.Size = new Size(429, 343);
        //    this.groupBox4.TabIndex = 39;
        //    this.groupBox4.TabStop = false;
        //    this.groupBox4.Text = "Clock States";
        //    this.tpBoostStates.Controls.Add((Control)this.panel5);
        //    this.tpBoostStates.Location = new Point(4, 22);
        //    this.tpBoostStates.Name = "tpBoostStates";
        //    this.tpBoostStates.Padding = new Padding(3);
        //    this.tpBoostStates.Size = new Size(462, 365);
        //    this.tpBoostStates.TabIndex = 4;
        //    this.tpBoostStates.Tag = (object)"";
        //    this.tpBoostStates.Text = "Boost States";
        //    this.tpBoostStates.UseVisualStyleBackColor = true;
        //    this.panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        //    this.panel5.BackColor = SystemColors.Control;
        //    this.panel5.BorderStyle = BorderStyle.FixedSingle;
        //    this.panel5.Controls.Add((Control)this.groupBox5);
        //    this.panel5.Location = new Point(1, 2);
        //    this.panel5.Name = "panel5";
        //    this.panel5.Size = new Size(460, 367);
        //    this.panel5.TabIndex = 26;
        //    this.groupBox5.Controls.Add((Control)this.boostConfigControl);
        //    this.groupBox5.Location = new Point(14, 13);
        //    this.groupBox5.Name = "groupBox5";
        //    this.groupBox5.Size = new Size(429, 346);
        //    this.groupBox5.TabIndex = 39;
        //    this.groupBox5.TabStop = false;
        //    this.groupBox5.Text = "Boost States";
        //    this.tpCommon.Controls.Add((Control)this.panel3);
        //    this.tpCommon.Location = new Point(4, 22);
        //    this.tpCommon.Name = "tpCommon";
        //    this.tpCommon.Padding = new Padding(3);
        //    this.tpCommon.Size = new Size(462, 365);
        //    this.tpCommon.TabIndex = 7;
        //    this.tpCommon.Text = "Common";
        //    this.tpCommon.UseVisualStyleBackColor = true;
        //    this.panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        //    this.panel3.BackColor = SystemColors.Control;
        //    this.panel3.BorderStyle = BorderStyle.FixedSingle;
        //    this.panel3.Controls.Add((Control)this.groupBox1);
        //    this.panel3.Controls.Add((Control)this.gbFanControl);
        //    this.panel3.Location = new Point(1, 2);
        //    this.panel3.Name = "panel3";
        //    this.panel3.Size = new Size(460, 360);
        //    this.panel3.TabIndex = 24;
        //    this.groupBox1.Controls.Add((Control)this.frcFanRange);
        //    this.groupBox1.Location = new Point(14, 202);
        //    this.groupBox1.Name = "groupBox1";
        //    this.groupBox1.Size = new Size(429, 148);
        //    this.groupBox1.TabIndex = 1;
        //    this.groupBox1.TabStop = false;
        //    this.groupBox1.Text = "Fan Control (Experimental)";
        //    this.gbFanControl.Controls.Add((Control)this.ttcTempTargets);
        //    this.gbFanControl.Controls.Add((Control)this.btnGpuCLockOffsetHelper);
        //    this.gbFanControl.Controls.Add((Control)this.mchMemoryClock);
        //    this.gbFanControl.Controls.Add((Control)this.blhBoostLimiterHelperControl);
        //    this.gbFanControl.Controls.Add((Control)this.bbcBaseBoost);
        //    this.gbFanControl.Location = new Point(14, 13);
        //    this.gbFanControl.Name = "gbFanControl";
        //    this.gbFanControl.Size = new Size(429, 182);
        //    this.gbFanControl.TabIndex = 0;
        //    this.gbFanControl.TabStop = false;
        //    this.gbFanControl.Text = "Basic Clock Settings";
        //    this.btnGpuCLockOffsetHelper.Location = new Point(225, 155);
        //    this.btnGpuCLockOffsetHelper.Name = "btnGpuCLockOffsetHelper";
        //    this.btnGpuCLockOffsetHelper.Size = new Size(187, 21);
        //    this.btnGpuCLockOffsetHelper.TabIndex = 3;
        //    this.btnGpuCLockOffsetHelper.Text = "GPU Clock Offset + 13MHz";
        //    this.btnGpuCLockOffsetHelper.UseVisualStyleBackColor = true;
        //    this.btnGpuCLockOffsetHelper.Click += new EventHandler(this.btnGpuCLockOffsetHelper_Click);
        //    this.tpPowerTable.Controls.Add((Control)this.panel1);
        //    this.tpPowerTable.Location = new Point(4, 22);
        //    this.tpPowerTable.Name = "tpPowerTable";
        //    this.tpPowerTable.Padding = new Padding(3);
        //    this.tpPowerTable.Size = new Size(462, 365);
        //    this.tpPowerTable.TabIndex = 8;
        //    this.tpPowerTable.Text = "Power Table";
        //    this.tpPowerTable.UseVisualStyleBackColor = true;
        //    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        //    this.panel1.BackColor = SystemColors.Control;
        //    this.panel1.BorderStyle = BorderStyle.FixedSingle;
        //    this.panel1.Controls.Add((Control)this.groupBox6);
        //    this.panel1.Location = new Point(1, 1);
        //    this.panel1.Name = "panel1";
        //    this.panel1.Size = new Size(460, 364);
        //    this.panel1.TabIndex = 24;
        //    this.groupBox6.Controls.Add((Control)this.ptcPowerTable);
        //    this.groupBox6.Location = new Point(14, 13);
        //    this.groupBox6.Name = "groupBox6";
        //    this.groupBox6.Size = new Size(429, 344);
        //    this.groupBox6.TabIndex = 0;
        //    this.groupBox6.TabStop = false;
        //    this.groupBox6.Text = "Power Table";
        //    this.tpVoltageTable.Controls.Add((Control)this.panel6);
        //    this.tpVoltageTable.Location = new Point(4, 22);
        //    this.tpVoltageTable.Name = "tpVoltageTable";
        //    this.tpVoltageTable.Padding = new Padding(3);
        //    this.tpVoltageTable.Size = new Size(462, 365);
        //    this.tpVoltageTable.TabIndex = 9;
        //    this.tpVoltageTable.Text = "Voltage Table";
        //    this.tpVoltageTable.UseVisualStyleBackColor = true;
        //    this.panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        //    this.panel6.BackColor = SystemColors.Control;
        //    this.panel6.BorderStyle = BorderStyle.FixedSingle;
        //    this.panel6.Controls.Add((Control)this.groupBox3);
        //    this.panel6.Location = new Point(1, 1);
        //    this.panel6.Name = "panel6";
        //    this.panel6.Size = new Size(460, 361);
        //    this.panel6.TabIndex = 25;
        //    this.groupBox3.Controls.Add((Control)this.vtcVoltageTable);
        //    this.groupBox3.Location = new Point(14, 13);
        //    this.groupBox3.Name = "groupBox3";
        //    this.groupBox3.Size = new Size(429, 343);
        //    this.groupBox3.TabIndex = 0;
        //    this.groupBox3.TabStop = false;
        //    this.groupBox3.Text = "Voltage Table";
        //    this.btnOpen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        //    this.btnOpen.Location = new Point(9, 566);
        //    this.btnOpen.Name = "btnOpen";
        //    this.btnOpen.Size = new Size(80, 23);
        //    this.btnOpen.TabIndex = 0;
        //    this.btnOpen.Text = "Open BIOS";
        //    this.btnOpen.UseVisualStyleBackColor = true;
        //    this.btnOpen.Click += new EventHandler(this.btnOpen_Click);
        //    this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        //    this.btnSave.Location = new Point(95, 566);
        //    this.btnSave.Name = "btnSave";
        //    this.btnSave.Size = new Size(80, 23);
        //    this.btnSave.TabIndex = 1;
        //    this.btnSave.Text = "Save BIOS";
        //    this.btnSave.UseVisualStyleBackColor = true;
        //    this.btnSave.Click += new EventHandler(this.btnSave_Click);
        //    this.btnSaveAs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        //    this.btnSaveAs.Location = new Point(181, 566);
        //    this.btnSaveAs.Name = "btnSaveAs";
        //    this.btnSaveAs.Size = new Size(100, 23);
        //    this.btnSaveAs.TabIndex = 2;
        //    this.btnSaveAs.Text = "Save BIOS As";
        //    this.btnSaveAs.UseVisualStyleBackColor = true;
        //    this.btnSaveAs.Click += new EventHandler(this.btnSaveAs_Click);
        //    this.btnRead.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        //    this.btnRead.Location = new Point(341, 566);
        //    this.btnRead.Name = "btnRead";
        //    this.btnRead.Size = new Size(64, 23);
        //    this.btnRead.TabIndex = 3;
        //    this.btnRead.Text = "ReadBios";
        //    this.btnRead.UseVisualStyleBackColor = true;
        //    this.btnRead.Click += new EventHandler(this.btnRead_Click);
        //    this.btnFlash.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        //    this.btnFlash.Location = new Point(411, 566);
        //    this.btnFlash.Name = "btnFlash";
        //    this.btnFlash.Size = new Size(64, 23);
        //    this.btnFlash.TabIndex = 4;
        //    this.btnFlash.Text = "FlashBios";
        //    this.btnFlash.UseVisualStyleBackColor = true;
        //    this.btnFlash.Click += new EventHandler(this.btnFlash_Click);
        //    this.btcBoostClocks.Location = new Point(6, 19);
        //    this.btcBoostClocks.Name = "btcBoostClocks";
        //    this.btcBoostClocks.Size = new Size(413, 318);
        //    this.btcBoostClocks.SliderEnabled = true;
        //    this.btcBoostClocks.SliderMaximum = 97;
        //    this.btcBoostClocks.SliderPosition = 67;
        //    this.btcBoostClocks.SliderText = "";
        //    this.btcBoostClocks.TabIndex = 0;
        //    this.ptcPerfTable.Location = new Point(7, 14);
        //    this.ptcPerfTable.Name = "ptcPerfTable";
        //    this.ptcPerfTable.Size = new Size(415, 323);
        //    this.ptcPerfTable.TabIndex = 94;
        //    this.boostConfigControl.Location = new Point(7, 14);
        //    this.boostConfigControl.Name = "bccBoostStates";
        //    this.boostConfigControl.Size = new Size(415, 326);
        //    this.boostConfigControl.TabIndex = 0;
        //    this.frcFanRange.Location = new Point(7, 19);
        //    this.frcFanRange.Name = "frcFanRange";
        //    this.frcFanRange.Size = new Size(409, 125);
        //    this.frcFanRange.TabIndex = 0;
        //    this.ttcTempTargets.Location = new Point(7, 99);
        //    this.ttcTempTargets.Name = "ttcTempTargets";
        //    this.ttcTempTargets.Size = new Size(409, 25);
        //    this.ttcTempTargets.TabIndex = 4;
        //    this.mchMemoryClock.Location = new Point(7, 151);
        //    this.mchMemoryClock.Name = "mchMemoryClock";
        //    this.mchMemoryClock.Size = new Size(198, 28);
        //    this.mchMemoryClock.TabIndex = 2;
        //    this.blhBoostLimiterHelperControl.Location = new Point(7, 125);
        //    this.blhBoostLimiterHelperControl.Name = "blhBoostLimit";
        //    this.blhBoostLimiterHelperControl.Size = new Size(405, 27);
        //    this.blhBoostLimiterHelperControl.TabIndex = 1;
        //    this.bbcBaseBoost.Location = new Point(7, 19);
        //    this.bbcBaseBoost.Name = "bbcBaseBoost";
        //    this.bbcBaseBoost.Size = new Size(409, 85);
        //    this.bbcBaseBoost.TabIndex = 0;
        //    this.ptcPowerTable.AutoScroll = true;
        //    this.ptcPowerTable.Location = new Point(7, 19);
        //    this.ptcPowerTable.Name = "ptcPowerTable";
        //    this.ptcPowerTable.Size = new Size(416, 319);
        //    this.ptcPowerTable.TabIndex = 0;
        //    this.ptcPowerTable.KeyPress += new KeyPressEventHandler(this.ME012);
        //    this.vtcVoltageTable.AutoScroll = true;
        //    this.vtcVoltageTable.Location = new Point(7, 19);
        //    this.vtcVoltageTable.Name = "vtcVoltageTable";
        //    this.vtcVoltageTable.Size = new Size(416, 318);
        //    this.vtcVoltageTable.TabIndex = 0;
        //    this.hcHeader.FileName = (string)null;
        //    this.hcHeader.GeneratedChecksum = (byte)0;
        //    this.hcHeader.ImageChecksum = (byte)0;
        //    this.hcHeader.Location = new Point(9, 14);
        //    this.hcHeader.Name = "hcHeader";
        //    this.hcHeader.Size = new Size(450, 143);
        //    this.hcHeader.TabIndex = 0;
        //    this.hcHeader.DoubleClick += new EventHandler(this.ME011);
        //    this.AllowDrop = true;
        //    this.AutoScaleDimensions = new SizeF(6f, 13f);
        //    this.AutoScaleMode = AutoScaleMode.Font;
        //    this.ClientSize = new Size(485, 593);
        //    this.Controls.Add((Control)this.btnSaveAs);
        //    this.Controls.Add((Control)this.btnSave);
        //    this.Controls.Add((Control)this.btnFlash);
        //    this.Controls.Add((Control)this.btnRead);
        //    this.Controls.Add((Control)this.btnOpen);
        //    this.Controls.Add((Control)this.tabControl);
        //    this.Controls.Add((Control)this.gbInfo);
        //    this.FormBorderStyle = FormBorderStyle.Fixed3D;
        //    this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
        //    this.KeyPreview = true;
        //    this.MaximizeBox = false;
        //    this.MinimizeBox = false;
        //    this.MinimumSize = new Size(454, 528);
        //    this.Name = "frmMBT";
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    this.Text = "Maxwell BIOS Editor";
        //    this.Load += new EventHandler(this.Load_Form);
        //    this.DragDrop += new DragEventHandler(this.DragDrop_Event);
        //    this.DragEnter += new DragEventHandler(this.DragEnter_Event);
        //    this.KeyDown += new KeyEventHandler(this.ME013);
        //    this.gbInfo.ResumeLayout(false);
        //    this.tabControl.ResumeLayout(false);
        //    this.tpBoostTable.ResumeLayout(false);
        //    this.panel2.ResumeLayout(false);
        //    this.groupBox2.ResumeLayout(false);
        //    this.tpClockStates.ResumeLayout(false);
        //    this.panel4.ResumeLayout(false);
        //    this.groupBox4.ResumeLayout(false);
        //    this.tpBoostStates.ResumeLayout(false);
        //    this.panel5.ResumeLayout(false);
        //    this.groupBox5.ResumeLayout(false);
        //    this.tpCommon.ResumeLayout(false);
        //    this.panel3.ResumeLayout(false);
        //    this.groupBox1.ResumeLayout(false);
        //    this.gbFanControl.ResumeLayout(false);
        //    this.tpPowerTable.ResumeLayout(false);
        //    this.panel1.ResumeLayout(false);
        //    this.groupBox6.ResumeLayout(false);
        //    this.tpVoltageTable.ResumeLayout(false);
        //    this.panel6.ResumeLayout(false);
        //    this.groupBox3.ResumeLayout(false);
        //    this.ResumeLayout(false);
        //}
    }
}
