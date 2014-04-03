namespace PrecisionRep
{
    partial class PreciRepMainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ResetButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.playerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dPSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimitBreak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aADamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dotDamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hitCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.critCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.missCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hitRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.critRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aACountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doTCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.damageBaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.preciRepDataSet1 = new PrecisionRep.PreciRepDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentTargetLabel = new System.Windows.Forms.Label();
            this.FocusTargetLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logHexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logBodyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srcNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srcBuffsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destBuffsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParsingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.preciRepDataSet2 = new PrecisionRep.PreciRepDataSet();
            this.RefleshButton = new System.Windows.Forms.Button();
            this.openTestFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preciRepDataSet1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParsingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preciRepDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(12, 12);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "リセット";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(888, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(61, 18);
            this.toolStripStatusLabel1.Text = "コマンド:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerNameDataGridViewTextBoxColumn,
            this.jobDataGridViewTextBoxColumn,
            this.dPSDataGridViewTextBoxColumn,
            this.totalDamageDataGridViewTextBoxColumn,
            this.LimitBreak,
            this.dDamageDataGridViewTextBoxColumn,
            this.aADamageDataGridViewTextBoxColumn,
            this.dotDamageDataGridViewTextBoxColumn,
            this.hitCountDataGridViewTextBoxColumn,
            this.critCountDataGridViewTextBoxColumn,
            this.missCountDataGridViewTextBoxColumn,
            this.hitRateDataGridViewTextBoxColumn,
            this.critRateDataGridViewTextBoxColumn,
            this.dDCountDataGridViewTextBoxColumn,
            this.aACountDataGridViewTextBoxColumn,
            this.doTCountDataGridViewTextBoxColumn,
            this.damageBaseDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.RepBindingSource;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(874, 420);
            this.dataGridView1.TabIndex = 3;
            // 
            // playerNameDataGridViewTextBoxColumn
            // 
            this.playerNameDataGridViewTextBoxColumn.DataPropertyName = "PlayerName";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.playerNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.playerNameDataGridViewTextBoxColumn.HeaderText = "PlayerName";
            this.playerNameDataGridViewTextBoxColumn.Name = "playerNameDataGridViewTextBoxColumn";
            this.playerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jobDataGridViewTextBoxColumn
            // 
            this.jobDataGridViewTextBoxColumn.DataPropertyName = "Job";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.jobDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.jobDataGridViewTextBoxColumn.HeaderText = "Job";
            this.jobDataGridViewTextBoxColumn.Name = "jobDataGridViewTextBoxColumn";
            this.jobDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dPSDataGridViewTextBoxColumn
            // 
            this.dPSDataGridViewTextBoxColumn.DataPropertyName = "DPS";
            this.dPSDataGridViewTextBoxColumn.HeaderText = "DPS";
            this.dPSDataGridViewTextBoxColumn.Name = "dPSDataGridViewTextBoxColumn";
            this.dPSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDamageDataGridViewTextBoxColumn
            // 
            this.totalDamageDataGridViewTextBoxColumn.DataPropertyName = "TotalDamage";
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.totalDamageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.totalDamageDataGridViewTextBoxColumn.HeaderText = "TotalDamage";
            this.totalDamageDataGridViewTextBoxColumn.Name = "totalDamageDataGridViewTextBoxColumn";
            this.totalDamageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // LimitBreak
            // 
            this.LimitBreak.DataPropertyName = "LimitBreak";
            this.LimitBreak.HeaderText = "LimitBreak";
            this.LimitBreak.Name = "LimitBreak";
            this.LimitBreak.ReadOnly = true;
            // 
            // dDamageDataGridViewTextBoxColumn
            // 
            this.dDamageDataGridViewTextBoxColumn.DataPropertyName = "DDamage";
            dataGridViewCellStyle12.Format = "N0";
            this.dDamageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.dDamageDataGridViewTextBoxColumn.HeaderText = "DDamage";
            this.dDamageDataGridViewTextBoxColumn.Name = "dDamageDataGridViewTextBoxColumn";
            this.dDamageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aADamageDataGridViewTextBoxColumn
            // 
            this.aADamageDataGridViewTextBoxColumn.DataPropertyName = "AADamage";
            dataGridViewCellStyle13.Format = "N0";
            this.aADamageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.aADamageDataGridViewTextBoxColumn.HeaderText = "AADamage";
            this.aADamageDataGridViewTextBoxColumn.Name = "aADamageDataGridViewTextBoxColumn";
            this.aADamageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dotDamageDataGridViewTextBoxColumn
            // 
            this.dotDamageDataGridViewTextBoxColumn.DataPropertyName = "DotDamage";
            dataGridViewCellStyle14.Format = "N0";
            this.dotDamageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.dotDamageDataGridViewTextBoxColumn.HeaderText = "DotDamage";
            this.dotDamageDataGridViewTextBoxColumn.Name = "dotDamageDataGridViewTextBoxColumn";
            this.dotDamageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hitCountDataGridViewTextBoxColumn
            // 
            this.hitCountDataGridViewTextBoxColumn.DataPropertyName = "HitCount";
            this.hitCountDataGridViewTextBoxColumn.HeaderText = "HitCount";
            this.hitCountDataGridViewTextBoxColumn.Name = "hitCountDataGridViewTextBoxColumn";
            this.hitCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // critCountDataGridViewTextBoxColumn
            // 
            this.critCountDataGridViewTextBoxColumn.DataPropertyName = "CritCount";
            this.critCountDataGridViewTextBoxColumn.HeaderText = "CritCount";
            this.critCountDataGridViewTextBoxColumn.Name = "critCountDataGridViewTextBoxColumn";
            this.critCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // missCountDataGridViewTextBoxColumn
            // 
            this.missCountDataGridViewTextBoxColumn.DataPropertyName = "MissCount";
            this.missCountDataGridViewTextBoxColumn.HeaderText = "MissCount";
            this.missCountDataGridViewTextBoxColumn.Name = "missCountDataGridViewTextBoxColumn";
            this.missCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hitRateDataGridViewTextBoxColumn
            // 
            this.hitRateDataGridViewTextBoxColumn.DataPropertyName = "HitRate";
            this.hitRateDataGridViewTextBoxColumn.HeaderText = "HitRate";
            this.hitRateDataGridViewTextBoxColumn.Name = "hitRateDataGridViewTextBoxColumn";
            this.hitRateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // critRateDataGridViewTextBoxColumn
            // 
            this.critRateDataGridViewTextBoxColumn.DataPropertyName = "CritRate";
            this.critRateDataGridViewTextBoxColumn.HeaderText = "CritRate";
            this.critRateDataGridViewTextBoxColumn.Name = "critRateDataGridViewTextBoxColumn";
            this.critRateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dDCountDataGridViewTextBoxColumn
            // 
            this.dDCountDataGridViewTextBoxColumn.DataPropertyName = "DDCount";
            this.dDCountDataGridViewTextBoxColumn.HeaderText = "DDCount";
            this.dDCountDataGridViewTextBoxColumn.Name = "dDCountDataGridViewTextBoxColumn";
            this.dDCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aACountDataGridViewTextBoxColumn
            // 
            this.aACountDataGridViewTextBoxColumn.DataPropertyName = "AACount";
            this.aACountDataGridViewTextBoxColumn.HeaderText = "AACount";
            this.aACountDataGridViewTextBoxColumn.Name = "aACountDataGridViewTextBoxColumn";
            this.aACountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doTCountDataGridViewTextBoxColumn
            // 
            this.doTCountDataGridViewTextBoxColumn.DataPropertyName = "DoTCount";
            this.doTCountDataGridViewTextBoxColumn.HeaderText = "DoTCount";
            this.doTCountDataGridViewTextBoxColumn.Name = "doTCountDataGridViewTextBoxColumn";
            this.doTCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // damageBaseDataGridViewTextBoxColumn
            // 
            this.damageBaseDataGridViewTextBoxColumn.DataPropertyName = "DamageBase";
            this.damageBaseDataGridViewTextBoxColumn.HeaderText = "DamageBase";
            this.damageBaseDataGridViewTextBoxColumn.Name = "damageBaseDataGridViewTextBoxColumn";
            this.damageBaseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RepBindingSource
            // 
            this.RepBindingSource.DataMember = "RepEssential";
            this.RepBindingSource.DataSource = this.preciRepDataSet1;
            // 
            // preciRepDataSet1
            // 
            this.preciRepDataSet1.DataSetName = "PreciRepDataSet";
            this.preciRepDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Target";
            // 
            // CurrentTargetLabel
            // 
            this.CurrentTargetLabel.AutoSize = true;
            this.CurrentTargetLabel.Location = new System.Drawing.Point(137, 9);
            this.CurrentTargetLabel.Name = "CurrentTargetLabel";
            this.CurrentTargetLabel.Size = new System.Drawing.Size(29, 12);
            this.CurrentTargetLabel.TabIndex = 5;
            this.CurrentTargetLabel.Text = "none";
            // 
            // FocusTargetLabel
            // 
            this.FocusTargetLabel.AutoSize = true;
            this.FocusTargetLabel.Location = new System.Drawing.Point(137, 27);
            this.FocusTargetLabel.Name = "FocusTargetLabel";
            this.FocusTargetLabel.Size = new System.Drawing.Size(29, 12);
            this.FocusTargetLabel.TabIndex = 7;
            this.FocusTargetLabel.Text = "none";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Focus";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(326, 51);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(27, 12);
            this.LocationLabel.TabIndex = 8;
            this.LocationLabel.Text = "(0,0)";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(888, 452);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(880, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rep";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(880, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parsing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.dateTimeDataGridViewTextBoxColumn,
            this.logTypeDataGridViewTextBoxColumn,
            this.logHexDataGridViewTextBoxColumn,
            this.logBodyDataGridViewTextBoxColumn,
            this.srcNameDataGridViewTextBoxColumn,
            this.repTypeDataGridViewTextBoxColumn,
            this.numDataGridViewTextBoxColumn,
            this.srcBuffsDataGridViewTextBoxColumn,
            this.destBuffsDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.ParsingBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(874, 420);
            this.dataGridView2.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateTimeDataGridViewTextBoxColumn
            // 
            this.dateTimeDataGridViewTextBoxColumn.DataPropertyName = "DateTime";
            dataGridViewCellStyle16.Format = "T";
            dataGridViewCellStyle16.NullValue = null;
            this.dateTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.dateTimeDataGridViewTextBoxColumn.HeaderText = "DateTime";
            this.dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
            this.dateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logTypeDataGridViewTextBoxColumn
            // 
            this.logTypeDataGridViewTextBoxColumn.DataPropertyName = "LogType";
            this.logTypeDataGridViewTextBoxColumn.HeaderText = "LogType";
            this.logTypeDataGridViewTextBoxColumn.Name = "logTypeDataGridViewTextBoxColumn";
            this.logTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logHexDataGridViewTextBoxColumn
            // 
            this.logHexDataGridViewTextBoxColumn.DataPropertyName = "LogHex";
            this.logHexDataGridViewTextBoxColumn.HeaderText = "LogHex";
            this.logHexDataGridViewTextBoxColumn.Name = "logHexDataGridViewTextBoxColumn";
            this.logHexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logBodyDataGridViewTextBoxColumn
            // 
            this.logBodyDataGridViewTextBoxColumn.DataPropertyName = "LogBody";
            this.logBodyDataGridViewTextBoxColumn.HeaderText = "LogBody";
            this.logBodyDataGridViewTextBoxColumn.Name = "logBodyDataGridViewTextBoxColumn";
            this.logBodyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // srcNameDataGridViewTextBoxColumn
            // 
            this.srcNameDataGridViewTextBoxColumn.DataPropertyName = "SrcName";
            this.srcNameDataGridViewTextBoxColumn.HeaderText = "SrcName";
            this.srcNameDataGridViewTextBoxColumn.Name = "srcNameDataGridViewTextBoxColumn";
            this.srcNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // repTypeDataGridViewTextBoxColumn
            // 
            this.repTypeDataGridViewTextBoxColumn.DataPropertyName = "RepType";
            this.repTypeDataGridViewTextBoxColumn.HeaderText = "RepType";
            this.repTypeDataGridViewTextBoxColumn.Name = "repTypeDataGridViewTextBoxColumn";
            this.repTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numDataGridViewTextBoxColumn
            // 
            this.numDataGridViewTextBoxColumn.DataPropertyName = "Num";
            this.numDataGridViewTextBoxColumn.HeaderText = "Num";
            this.numDataGridViewTextBoxColumn.Name = "numDataGridViewTextBoxColumn";
            this.numDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // srcBuffsDataGridViewTextBoxColumn
            // 
            this.srcBuffsDataGridViewTextBoxColumn.DataPropertyName = "SrcBuffs";
            this.srcBuffsDataGridViewTextBoxColumn.HeaderText = "SrcBuffs";
            this.srcBuffsDataGridViewTextBoxColumn.Name = "srcBuffsDataGridViewTextBoxColumn";
            this.srcBuffsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // destBuffsDataGridViewTextBoxColumn
            // 
            this.destBuffsDataGridViewTextBoxColumn.DataPropertyName = "DestBuffs";
            this.destBuffsDataGridViewTextBoxColumn.HeaderText = "DestBuffs";
            this.destBuffsDataGridViewTextBoxColumn.Name = "destBuffsDataGridViewTextBoxColumn";
            this.destBuffsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ParsingBindingSource
            // 
            this.ParsingBindingSource.DataMember = "ParsingReport";
            this.ParsingBindingSource.DataSource = this.preciRepDataSet2;
            this.ParsingBindingSource.Filter = "";
            // 
            // preciRepDataSet2
            // 
            this.preciRepDataSet2.DataSetName = "PreciRepDataSet";
            this.preciRepDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RefleshButton
            // 
            this.RefleshButton.Location = new System.Drawing.Point(214, 45);
            this.RefleshButton.Name = "RefleshButton";
            this.RefleshButton.Size = new System.Drawing.Size(75, 23);
            this.RefleshButton.TabIndex = 10;
            this.RefleshButton.Text = "ログ更新";
            this.RefleshButton.UseVisualStyleBackColor = true;
            this.RefleshButton.Click += new System.EventHandler(this.RefreshLogButton_Click);
            // 
            // openTestFileDialog
            // 
            this.openTestFileDialog.FileName = "openFileDialog1";
            // 
            // PreciRepMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 530);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.RefleshButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.FocusTargetLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CurrentTargetLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ResetButton);
            this.Name = "PreciRepMainForm";
            this.Text = "PreciRep";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreciRepMainForm_FormClosing);
            this.Load += new System.EventHandler(this.PreciRepMainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preciRepDataSet1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ParsingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preciRepDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource RepBindingSource;
        private PreciRepDataSet preciRepDataSet1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CurrentTargetLabel;
        private System.Windows.Forms.Label FocusTargetLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource ParsingBindingSource;
        private PreciRepDataSet preciRepDataSet2;
        private System.Windows.Forms.Button RefleshButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dPSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimitBreak;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aADamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dotDamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hitCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn critCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn missCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hitRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn critRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aACountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doTCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn damageBaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logHexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logBodyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn repTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcBuffsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destBuffsDataGridViewTextBoxColumn;
        private System.Windows.Forms.OpenFileDialog openTestFileDialog;
    }
}