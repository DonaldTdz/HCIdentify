using System.Drawing;

namespace HC.Identify.App
{
    partial class Workbench
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Workbench));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cogRecordDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblIdentifyTime = new System.Windows.Forms.Label();
            this.spendTime = new System.Windows.Forms.Label();
            this.lblIdentifiedRate = new System.Windows.Forms.Label();
            this.lblSpecText = new System.Windows.Forms.Label();
            this.lab_readRate_title = new System.Windows.Forms.Label();
            this.lblSpecResult = new System.Windows.Forms.Label();
            this.lblNoIdentifiedNum = new System.Windows.Forms.Label();
            this.lblSpecName = new System.Windows.Forms.Label();
            this.lab_unRead_title = new System.Windows.Forms.Label();
            this.lab_checkAmount_title = new System.Windows.Forms.Label();
            this.lblIdentifiedNum = new System.Windows.Forms.Label();
            this.lblIdentifyTotal = new System.Windows.Forms.Label();
            this.lab_alreadyRead_title = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_init = new System.Windows.Forms.Button();
            this.GV_orderInfo = new System.Windows.Forms.DataGridView();
            this.txt_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Specification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Matched = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Unmatched = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_dowload = new System.Windows.Forms.Button();
            this.combo_area = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btn_lasthouse = new System.Windows.Forms.Button();
            this.btn_nexthouse = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lab_houseNum = new System.Windows.Forms.Label();
            this.lab_houseNum_title = new System.Windows.Forms.Label();
            this.lab_retaName = new System.Windows.Forms.Label();
            this.lab_areaName = new System.Windows.Forms.Label();
            this.lab_retaName_title = new System.Windows.Forms.Label();
            this.lab_areaName_title = new System.Windows.Forms.Label();
            this.lab_num = new System.Windows.Forms.Label();
            this.lab_num_title = new System.Windows.Forms.Label();
            this.labOrderNotCheck = new System.Windows.Forms.Label();
            this.labOrderCheck = new System.Windows.Forms.Label();
            this.lab_notcheck_title = new System.Windows.Forms.Label();
            this.lab_cheked_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_nextnHose = new System.Windows.Forms.Label();
            this.lab_nextHose = new System.Windows.Forms.Label();
            this.lab_lastlHose = new System.Windows.Forms.Label();
            this.lab_lastHose = new System.Windows.Forms.Label();
            this.lab_nextnHose_title = new System.Windows.Forms.Label();
            this.lab_lastlHose_title = new System.Windows.Forms.Label();
            this.lab_nextHose_title = new System.Windows.Forms.Label();
            this.lab_lastHose_title = new System.Windows.Forms.Label();
            this.orderInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txtSpecHistry = new System.Windows.Forms.TextBox();
            this.group_matchOrder = new System.Windows.Forms.GroupBox();
            this.dataGrid_match = new System.Windows.Forms.DataGridView();
            this.SortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Specific = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Match = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_orderInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderInfoBindingSource)).BeginInit();
            this.group_matchOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_match)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(363, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 612);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cogRecordDisplay);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(660, 586);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "相机识别";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cogRecordDisplay
            // 
            this.cogRecordDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay.Location = new System.Drawing.Point(5, 2);
            this.cogRecordDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.cogRecordDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay.Name = "cogRecordDisplay";
            this.cogRecordDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay.OcxState")));
            this.cogRecordDisplay.Size = new System.Drawing.Size(661, 478);
            this.cogRecordDisplay.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblIdentifyTime);
            this.groupBox4.Controls.Add(this.spendTime);
            this.groupBox4.Controls.Add(this.lblIdentifiedRate);
            this.groupBox4.Controls.Add(this.lblSpecText);
            this.groupBox4.Controls.Add(this.lab_readRate_title);
            this.groupBox4.Controls.Add(this.lblSpecResult);
            this.groupBox4.Controls.Add(this.lblNoIdentifiedNum);
            this.groupBox4.Controls.Add(this.lblSpecName);
            this.groupBox4.Controls.Add(this.lab_unRead_title);
            this.groupBox4.Controls.Add(this.lab_checkAmount_title);
            this.groupBox4.Controls.Add(this.lblIdentifiedNum);
            this.groupBox4.Controls.Add(this.lblIdentifyTotal);
            this.groupBox4.Controls.Add(this.lab_alreadyRead_title);
            this.groupBox4.Location = new System.Drawing.Point(0, 485);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(666, 101);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "匹配结果";
            // 
            // lblIdentifyTime
            // 
            this.lblIdentifyTime.AutoSize = true;
            this.lblIdentifyTime.Location = new System.Drawing.Point(577, 79);
            this.lblIdentifyTime.Name = "lblIdentifyTime";
            this.lblIdentifyTime.Size = new System.Drawing.Size(11, 12);
            this.lblIdentifyTime.TabIndex = 9;
            this.lblIdentifyTime.Text = "2";
            // 
            // spendTime
            // 
            this.spendTime.AutoSize = true;
            this.spendTime.Location = new System.Drawing.Point(506, 79);
            this.spendTime.Name = "spendTime";
            this.spendTime.Size = new System.Drawing.Size(65, 12);
            this.spendTime.TabIndex = 8;
            this.spendTime.Text = "识别用时：";
            // 
            // lblIdentifiedRate
            // 
            this.lblIdentifiedRate.AutoSize = true;
            this.lblIdentifiedRate.Location = new System.Drawing.Point(469, 79);
            this.lblIdentifiedRate.Name = "lblIdentifiedRate";
            this.lblIdentifiedRate.Size = new System.Drawing.Size(11, 12);
            this.lblIdentifiedRate.TabIndex = 7;
            this.lblIdentifiedRate.Text = "2";
            // 
            // lblSpecText
            // 
            this.lblSpecText.AutoSize = true;
            this.lblSpecText.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpecText.ForeColor = System.Drawing.Color.Black;
            this.lblSpecText.Location = new System.Drawing.Point(-4, 30);
            this.lblSpecText.Name = "lblSpecText";
            this.lblSpecText.Size = new System.Drawing.Size(190, 21);
            this.lblSpecText.TabIndex = 2;
            this.lblSpecText.Text = "6901028227704  ";
            // 
            // lab_readRate_title
            // 
            this.lab_readRate_title.AutoSize = true;
            this.lab_readRate_title.Location = new System.Drawing.Point(386, 79);
            this.lab_readRate_title.Name = "lab_readRate_title";
            this.lab_readRate_title.Size = new System.Drawing.Size(77, 12);
            this.lab_readRate_title.TabIndex = 6;
            this.lab_readRate_title.Text = "识别成功率：";
            // 
            // lblSpecResult
            // 
            this.lblSpecResult.AutoSize = true;
            this.lblSpecResult.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpecResult.ForeColor = System.Drawing.Color.Green;
            this.lblSpecResult.Location = new System.Drawing.Point(467, 30);
            this.lblSpecResult.Name = "lblSpecResult";
            this.lblSpecResult.Size = new System.Drawing.Size(98, 21);
            this.lblSpecResult.TabIndex = 4;
            this.lblSpecResult.Text = "匹配正常";
            // 
            // lblNoIdentifiedNum
            // 
            this.lblNoIdentifiedNum.AutoSize = true;
            this.lblNoIdentifiedNum.Location = new System.Drawing.Point(332, 79);
            this.lblNoIdentifiedNum.Name = "lblNoIdentifiedNum";
            this.lblNoIdentifiedNum.Size = new System.Drawing.Size(11, 12);
            this.lblNoIdentifiedNum.TabIndex = 5;
            this.lblNoIdentifiedNum.Text = "2";
            // 
            // lblSpecName
            // 
            this.lblSpecName.AutoSize = true;
            this.lblSpecName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpecName.Location = new System.Drawing.Point(225, 30);
            this.lblSpecName.Name = "lblSpecName";
            this.lblSpecName.Size = new System.Drawing.Size(166, 21);
            this.lblSpecName.TabIndex = 3;
            this.lblSpecName.Text = "天子(千里江山)";
            // 
            // lab_unRead_title
            // 
            this.lab_unRead_title.AutoSize = true;
            this.lab_unRead_title.Location = new System.Drawing.Point(261, 79);
            this.lab_unRead_title.Name = "lab_unRead_title";
            this.lab_unRead_title.Size = new System.Drawing.Size(65, 12);
            this.lab_unRead_title.TabIndex = 4;
            this.lab_unRead_title.Text = "未识别数：";
            // 
            // lab_checkAmount_title
            // 
            this.lab_checkAmount_title.AutoSize = true;
            this.lab_checkAmount_title.Location = new System.Drawing.Point(3, 79);
            this.lab_checkAmount_title.Name = "lab_checkAmount_title";
            this.lab_checkAmount_title.Size = new System.Drawing.Size(65, 12);
            this.lab_checkAmount_title.TabIndex = 0;
            this.lab_checkAmount_title.Text = "识别总数：";
            // 
            // lblIdentifiedNum
            // 
            this.lblIdentifiedNum.AutoSize = true;
            this.lblIdentifiedNum.Location = new System.Drawing.Point(209, 81);
            this.lblIdentifiedNum.Name = "lblIdentifiedNum";
            this.lblIdentifiedNum.Size = new System.Drawing.Size(11, 12);
            this.lblIdentifiedNum.TabIndex = 3;
            this.lblIdentifiedNum.Text = "2";
            // 
            // lblIdentifyTotal
            // 
            this.lblIdentifyTotal.AutoSize = true;
            this.lblIdentifyTotal.Location = new System.Drawing.Point(71, 81);
            this.lblIdentifyTotal.Name = "lblIdentifyTotal";
            this.lblIdentifyTotal.Size = new System.Drawing.Size(11, 12);
            this.lblIdentifyTotal.TabIndex = 1;
            this.lblIdentifyTotal.Text = "2";
            // 
            // lab_alreadyRead_title
            // 
            this.lab_alreadyRead_title.AutoSize = true;
            this.lab_alreadyRead_title.Location = new System.Drawing.Point(138, 79);
            this.lab_alreadyRead_title.Name = "lab_alreadyRead_title";
            this.lab_alreadyRead_title.Size = new System.Drawing.Size(65, 12);
            this.lab_alreadyRead_title.TabIndex = 2;
            this.lab_alreadyRead_title.Text = "已识别数：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_init);
            this.tabPage2.Controls.Add(this.GV_orderInfo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(660, 586);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "订单明细";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_init
            // 
            this.btn_init.Location = new System.Drawing.Point(7, 18);
            this.btn_init.Name = "btn_init";
            this.btn_init.Size = new System.Drawing.Size(75, 23);
            this.btn_init.TabIndex = 1;
            this.btn_init.Text = "初始化";
            this.btn_init.UseVisualStyleBackColor = true;
            this.btn_init.Click += new System.EventHandler(this.btn_init_Click);
            // 
            // GV_orderInfo
            // 
            this.GV_orderInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GV_orderInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GV_orderInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.GV_orderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV_orderInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_Id,
            this.txt_Specification,
            this.Brand,
            this.Num,
            this.txt_UUID,
            this.txt_Matched,
            this.txt_Unmatched});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GV_orderInfo.DefaultCellStyle = dataGridViewCellStyle12;
            this.GV_orderInfo.Location = new System.Drawing.Point(7, 47);
            this.GV_orderInfo.Name = "GV_orderInfo";
            this.GV_orderInfo.RowTemplate.Height = 23;
            this.GV_orderInfo.Size = new System.Drawing.Size(645, 482);
            this.GV_orderInfo.StandardTab = true;
            this.GV_orderInfo.TabIndex = 0;
            // 
            // txt_Id
            // 
            this.txt_Id.DataPropertyName = "Id";
            this.txt_Id.HeaderText = "Id";
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_Id.Visible = false;
            // 
            // txt_Specification
            // 
            this.txt_Specification.DataPropertyName = "Specification";
            this.txt_Specification.HeaderText = "规格";
            this.txt_Specification.Name = "txt_Specification";
            this.txt_Specification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Brand
            // 
            this.Brand.DataPropertyName = "Brand";
            this.Brand.HeaderText = "条码";
            this.Brand.Name = "Brand";
            this.Brand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "Num";
            this.Num.HeaderText = "数量";
            this.Num.Name = "Num";
            this.Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txt_UUID
            // 
            this.txt_UUID.DataPropertyName = "UUID";
            this.txt_UUID.HeaderText = "UUID";
            this.txt_UUID.Name = "txt_UUID";
            this.txt_UUID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txt_UUID.Visible = false;
            // 
            // txt_Matched
            // 
            this.txt_Matched.DataPropertyName = "Matched";
            this.txt_Matched.HeaderText = "已匹配";
            this.txt_Matched.Name = "txt_Matched";
            this.txt_Matched.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txt_Unmatched
            // 
            this.txt_Unmatched.DataPropertyName = "Unmatched";
            this.txt_Unmatched.HeaderText = "未匹配";
            this.txt_Unmatched.Name = "txt_Unmatched";
            this.txt_Unmatched.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_dowload);
            this.groupBox1.Controls.Add(this.combo_area);
            this.groupBox1.Location = new System.Drawing.Point(1038, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "线路";
            // 
            // btn_dowload
            // 
            this.btn_dowload.Location = new System.Drawing.Point(221, 24);
            this.btn_dowload.Name = "btn_dowload";
            this.btn_dowload.Size = new System.Drawing.Size(75, 23);
            this.btn_dowload.TabIndex = 1;
            this.btn_dowload.Text = "下载数据";
            this.btn_dowload.UseVisualStyleBackColor = true;
            this.btn_dowload.Click += new System.EventHandler(this.btn_dowload_Click);
            // 
            // combo_area
            // 
            this.combo_area.FormattingEnabled = true;
            this.combo_area.Location = new System.Drawing.Point(10, 25);
            this.combo_area.Name = "combo_area";
            this.combo_area.Size = new System.Drawing.Size(205, 20);
            this.combo_area.TabIndex = 0;
            this.combo_area.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1039, 70);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 40);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btn_lasthouse
            // 
            this.btn_lasthouse.Location = new System.Drawing.Point(1165, 70);
            this.btn_lasthouse.Name = "btn_lasthouse";
            this.btn_lasthouse.Size = new System.Drawing.Size(80, 40);
            this.btn_lasthouse.TabIndex = 3;
            this.btn_lasthouse.Text = "上一户";
            this.btn_lasthouse.UseVisualStyleBackColor = true;
            this.btn_lasthouse.Click += new System.EventHandler(this.btn_lasthouse_Click);
            // 
            // btn_nexthouse
            // 
            this.btn_nexthouse.Location = new System.Drawing.Point(1259, 70);
            this.btn_nexthouse.Name = "btn_nexthouse";
            this.btn_nexthouse.Size = new System.Drawing.Size(80, 40);
            this.btn_nexthouse.TabIndex = 4;
            this.btn_nexthouse.Text = "下一户";
            this.btn_nexthouse.UseVisualStyleBackColor = true;
            this.btn_nexthouse.Click += new System.EventHandler(this.btn_nexthouse_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lab_houseNum);
            this.groupBox2.Controls.Add(this.lab_houseNum_title);
            this.groupBox2.Controls.Add(this.lab_retaName);
            this.groupBox2.Controls.Add(this.lab_areaName);
            this.groupBox2.Controls.Add(this.lab_retaName_title);
            this.groupBox2.Controls.Add(this.lab_areaName_title);
            this.groupBox2.Location = new System.Drawing.Point(1039, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 122);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批次订单信息";
            // 
            // lab_houseNum
            // 
            this.lab_houseNum.AutoSize = true;
            this.lab_houseNum.Location = new System.Drawing.Point(65, 99);
            this.lab_houseNum.Name = "lab_houseNum";
            this.lab_houseNum.Size = new System.Drawing.Size(11, 12);
            this.lab_houseNum.TabIndex = 5;
            this.lab_houseNum.Text = "2";
            // 
            // lab_houseNum_title
            // 
            this.lab_houseNum_title.AutoSize = true;
            this.lab_houseNum_title.Location = new System.Drawing.Point(5, 99);
            this.lab_houseNum_title.Name = "lab_houseNum_title";
            this.lab_houseNum_title.Size = new System.Drawing.Size(53, 12);
            this.lab_houseNum_title.TabIndex = 4;
            this.lab_houseNum_title.Text = "户  号：";
            // 
            // lab_retaName
            // 
            this.lab_retaName.AutoSize = true;
            this.lab_retaName.Location = new System.Drawing.Point(65, 71);
            this.lab_retaName.Name = "lab_retaName";
            this.lab_retaName.Size = new System.Drawing.Size(0, 12);
            this.lab_retaName.TabIndex = 3;
            // 
            // lab_areaName
            // 
            this.lab_areaName.AutoSize = true;
            this.lab_areaName.Location = new System.Drawing.Point(65, 38);
            this.lab_areaName.Name = "lab_areaName";
            this.lab_areaName.Size = new System.Drawing.Size(11, 12);
            this.lab_areaName.TabIndex = 2;
            this.lab_areaName.Text = "2";
            // 
            // lab_retaName_title
            // 
            this.lab_retaName_title.AutoSize = true;
            this.lab_retaName_title.Location = new System.Drawing.Point(5, 71);
            this.lab_retaName_title.Name = "lab_retaName_title";
            this.lab_retaName_title.Size = new System.Drawing.Size(53, 12);
            this.lab_retaName_title.TabIndex = 1;
            this.lab_retaName_title.Text = "客  户：";
            // 
            // lab_areaName_title
            // 
            this.lab_areaName_title.AutoSize = true;
            this.lab_areaName_title.Location = new System.Drawing.Point(5, 38);
            this.lab_areaName_title.Name = "lab_areaName_title";
            this.lab_areaName_title.Size = new System.Drawing.Size(53, 12);
            this.lab_areaName_title.TabIndex = 0;
            this.lab_areaName_title.Text = "线  路：";
            // 
            // lab_num
            // 
            this.lab_num.AutoSize = true;
            this.lab_num.Location = new System.Drawing.Point(57, 586);
            this.lab_num.Name = "lab_num";
            this.lab_num.Size = new System.Drawing.Size(11, 12);
            this.lab_num.TabIndex = 3;
            this.lab_num.Text = "2";
            // 
            // lab_num_title
            // 
            this.lab_num_title.AutoSize = true;
            this.lab_num_title.Location = new System.Drawing.Point(-2, 586);
            this.lab_num_title.Name = "lab_num_title";
            this.lab_num_title.Size = new System.Drawing.Size(53, 12);
            this.lab_num_title.TabIndex = 1;
            this.lab_num_title.Text = "订单量：";
            // 
            // labOrderNotCheck
            // 
            this.labOrderNotCheck.AutoSize = true;
            this.labOrderNotCheck.Location = new System.Drawing.Point(301, 545);
            this.labOrderNotCheck.Name = "labOrderNotCheck";
            this.labOrderNotCheck.Size = new System.Drawing.Size(11, 12);
            this.labOrderNotCheck.TabIndex = 7;
            this.labOrderNotCheck.Text = "2";
            // 
            // labOrderCheck
            // 
            this.labOrderCheck.AutoSize = true;
            this.labOrderCheck.Location = new System.Drawing.Point(57, 546);
            this.labOrderCheck.Name = "labOrderCheck";
            this.labOrderCheck.Size = new System.Drawing.Size(11, 12);
            this.labOrderCheck.TabIndex = 7;
            this.labOrderCheck.Text = "2";
            // 
            // lab_notcheck_title
            // 
            this.lab_notcheck_title.AutoSize = true;
            this.lab_notcheck_title.Location = new System.Drawing.Point(219, 545);
            this.lab_notcheck_title.Name = "lab_notcheck_title";
            this.lab_notcheck_title.Size = new System.Drawing.Size(53, 12);
            this.lab_notcheck_title.TabIndex = 6;
            this.lab_notcheck_title.Text = "未检量：";
            // 
            // lab_cheked_title
            // 
            this.lab_cheked_title.AutoSize = true;
            this.lab_cheked_title.Location = new System.Drawing.Point(-2, 546);
            this.lab_cheked_title.Name = "lab_cheked_title";
            this.lab_cheked_title.Size = new System.Drawing.Size(53, 12);
            this.lab_cheked_title.TabIndex = 6;
            this.lab_cheked_title.Text = "已检量：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lab_nextnHose);
            this.panel1.Controls.Add(this.lab_nextHose);
            this.panel1.Controls.Add(this.lab_lastlHose);
            this.panel1.Controls.Add(this.lab_lastHose);
            this.panel1.Controls.Add(this.lab_nextnHose_title);
            this.panel1.Controls.Add(this.lab_lastlHose_title);
            this.panel1.Controls.Add(this.lab_nextHose_title);
            this.panel1.Controls.Add(this.lab_lastHose_title);
            this.panel1.Location = new System.Drawing.Point(1039, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 75);
            this.panel1.TabIndex = 7;
            // 
            // lab_nextnHose
            // 
            this.lab_nextnHose.AutoSize = true;
            this.lab_nextnHose.Location = new System.Drawing.Point(206, 49);
            this.lab_nextnHose.Name = "lab_nextnHose";
            this.lab_nextnHose.Size = new System.Drawing.Size(0, 12);
            this.lab_nextnHose.TabIndex = 7;
            // 
            // lab_nextHose
            // 
            this.lab_nextHose.AutoSize = true;
            this.lab_nextHose.Location = new System.Drawing.Point(62, 49);
            this.lab_nextHose.Name = "lab_nextHose";
            this.lab_nextHose.Size = new System.Drawing.Size(0, 12);
            this.lab_nextHose.TabIndex = 6;
            // 
            // lab_lastlHose
            // 
            this.lab_lastlHose.AutoSize = true;
            this.lab_lastlHose.Location = new System.Drawing.Point(205, 17);
            this.lab_lastlHose.Name = "lab_lastlHose";
            this.lab_lastlHose.Size = new System.Drawing.Size(0, 12);
            this.lab_lastlHose.TabIndex = 5;
            // 
            // lab_lastHose
            // 
            this.lab_lastHose.AutoSize = true;
            this.lab_lastHose.Location = new System.Drawing.Point(60, 16);
            this.lab_lastHose.Name = "lab_lastHose";
            this.lab_lastHose.Size = new System.Drawing.Size(0, 12);
            this.lab_lastHose.TabIndex = 4;
            // 
            // lab_nextnHose_title
            // 
            this.lab_nextnHose_title.AutoSize = true;
            this.lab_nextnHose_title.Location = new System.Drawing.Point(152, 50);
            this.lab_nextnHose_title.Name = "lab_nextnHose_title";
            this.lab_nextnHose_title.Size = new System.Drawing.Size(53, 12);
            this.lab_nextnHose_title.TabIndex = 3;
            this.lab_nextnHose_title.Text = "下下户：";
            // 
            // lab_lastlHose_title
            // 
            this.lab_lastlHose_title.AutoSize = true;
            this.lab_lastlHose_title.Location = new System.Drawing.Point(152, 16);
            this.lab_lastlHose_title.Name = "lab_lastlHose_title";
            this.lab_lastlHose_title.Size = new System.Drawing.Size(53, 12);
            this.lab_lastlHose_title.TabIndex = 2;
            this.lab_lastlHose_title.Text = "上上户：";
            // 
            // lab_nextHose_title
            // 
            this.lab_nextHose_title.AutoSize = true;
            this.lab_nextHose_title.Location = new System.Drawing.Point(10, 50);
            this.lab_nextHose_title.Name = "lab_nextHose_title";
            this.lab_nextHose_title.Size = new System.Drawing.Size(53, 12);
            this.lab_nextHose_title.TabIndex = 1;
            this.lab_nextHose_title.Text = "下一户：";
            // 
            // lab_lastHose_title
            // 
            this.lab_lastHose_title.AutoSize = true;
            this.lab_lastHose_title.Location = new System.Drawing.Point(10, 16);
            this.lab_lastHose_title.Name = "lab_lastHose_title";
            this.lab_lastHose_title.Size = new System.Drawing.Size(53, 12);
            this.lab_lastHose_title.TabIndex = 0;
            this.lab_lastHose_title.Text = "上一户：";
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(1039, 574);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(102, 36);
            this.btn_test.TabIndex = 8;
            this.btn_test.Text = "测试";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Visible = false;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(1220, 571);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(102, 36);
            this.btn_connect.TabIndex = 9;
            this.btn_connect.Text = "重连相机扫码器";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Visible = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txtSpecHistry
            // 
            this.txtSpecHistry.Location = new System.Drawing.Point(1039, 325);
            this.txtSpecHistry.Multiline = true;
            this.txtSpecHistry.Name = "txtSpecHistry";
            this.txtSpecHistry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSpecHistry.Size = new System.Drawing.Size(301, 285);
            this.txtSpecHistry.TabIndex = 1;
            // 
            // group_matchOrder
            // 
            this.group_matchOrder.Controls.Add(this.lab_num);
            this.group_matchOrder.Controls.Add(this.labOrderNotCheck);
            this.group_matchOrder.Controls.Add(this.dataGrid_match);
            this.group_matchOrder.Controls.Add(this.lab_num_title);
            this.group_matchOrder.Controls.Add(this.lab_notcheck_title);
            this.group_matchOrder.Controls.Add(this.labOrderCheck);
            this.group_matchOrder.Controls.Add(this.lab_cheked_title);
            this.group_matchOrder.Location = new System.Drawing.Point(2, 2);
            this.group_matchOrder.Name = "group_matchOrder";
            this.group_matchOrder.Size = new System.Drawing.Size(362, 605);
            this.group_matchOrder.TabIndex = 10;
            this.group_matchOrder.TabStop = false;
            // 
            // dataGrid_match
            // 
            this.dataGrid_match.AllowUserToAddRows = false;
            this.dataGrid_match.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_match.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGrid_match.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_match.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SortNum,
            this.Id,
            this.BrandS,
            this.Specific,
            this.MatchTime,
            this.Match});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid_match.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGrid_match.Location = new System.Drawing.Point(1, 0);
            this.dataGrid_match.Name = "dataGrid_match";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.NullValue = "Index";
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid_match.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGrid_match.RowHeadersVisible = false;
            this.dataGrid_match.RowTemplate.Height = 23;
            this.dataGrid_match.Size = new System.Drawing.Size(361, 502);
            this.dataGrid_match.TabIndex = 0;
            this.dataGrid_match.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGrid_match_RowPostPaint);
            // 
            // SortNum
            // 
            this.SortNum.FillWeight = 58.37563F;
            this.SortNum.HeaderText = "";
            this.SortNum.Name = "SortNum";
            this.SortNum.Width = 23;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Id.DefaultCellStyle = dataGridViewCellStyle14;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // BrandS
            // 
            this.BrandS.DataPropertyName = "Brand";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BrandS.DefaultCellStyle = dataGridViewCellStyle15;
            this.BrandS.FillWeight = 177.204F;
            this.BrandS.HeaderText = "条码";
            this.BrandS.Name = "BrandS";
            this.BrandS.Width = 89;
            // 
            // Specific
            // 
            this.Specific.DataPropertyName = "Specification";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Specific.DefaultCellStyle = dataGridViewCellStyle16;
            this.Specific.FillWeight = 25.52285F;
            this.Specific.HeaderText = "规格";
            this.Specific.Name = "Specific";
            // 
            // MatchTime
            // 
            this.MatchTime.DataPropertyName = "MatchTime";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MatchTime.DefaultCellStyle = dataGridViewCellStyle17;
            this.MatchTime.FillWeight = 134.9363F;
            this.MatchTime.HeaderText = "匹配时间";
            this.MatchTime.Name = "MatchTime";
            this.MatchTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.MatchTime.Width = 88;
            // 
            // Match
            // 
            this.Match.DataPropertyName = "MatchStatus";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Match.DefaultCellStyle = dataGridViewCellStyle18;
            this.Match.FillWeight = 103.9612F;
            this.Match.HeaderText = "状态";
            this.Match.Name = "Match";
            this.Match.Width = 60;
            // 
            // Workbench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1344, 611);
            this.Controls.Add(this.group_matchOrder);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSpecHistry);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_nexthouse);
            this.Controls.Add(this.btn_lasthouse);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Workbench";
            this.Text = "工作台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Workbench_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Workbench_FormClosed);
            this.Load += new System.EventHandler(this.Workbench_Load);
            this.InputLanguageChanging += new System.Windows.Forms.InputLanguageChangingEventHandler(this.Workbench_InputLanguageChanging);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GV_orderInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderInfoBindingSource)).EndInit();
            this.group_matchOrder.ResumeLayout(false);
            this.group_matchOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_match)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_dowload;
        private System.Windows.Forms.ComboBox combo_area;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btn_lasthouse;
        private System.Windows.Forms.Button btn_nexthouse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lab_retaName;
        private System.Windows.Forms.Label lab_areaName;
        private System.Windows.Forms.Label lab_retaName_title;
        private System.Windows.Forms.Label lab_areaName_title;
        private System.Windows.Forms.Label lab_num;
        private System.Windows.Forms.Label lab_num_title;
        private System.Windows.Forms.Label labOrderNotCheck;
        private System.Windows.Forms.Label lab_notcheck_title;
        private System.Windows.Forms.Label lblSpecResult;
        private System.Windows.Forms.Label lblSpecName;
        private System.Windows.Forms.Label lblSpecText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labOrderCheck;
        private System.Windows.Forms.Label lab_cheked_title;
        private System.Windows.Forms.Label lab_houseNum;
        private System.Windows.Forms.Label lab_houseNum_title;
        private System.Windows.Forms.Label lblIdentifiedRate;
        private System.Windows.Forms.Label lab_readRate_title;
        private System.Windows.Forms.Label lblNoIdentifiedNum;
        private System.Windows.Forms.Label lab_unRead_title;
        private System.Windows.Forms.Label lblIdentifiedNum;
        private System.Windows.Forms.Label lab_alreadyRead_title;
        private System.Windows.Forms.Label lblIdentifyTotal;
        private System.Windows.Forms.Label lab_checkAmount_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab_nextnHose_title;
        private System.Windows.Forms.Label lab_lastlHose_title;
        private System.Windows.Forms.Label lab_nextHose_title;
        private System.Windows.Forms.Label lab_lastHose_title;
        private System.Windows.Forms.Label lab_nextnHose;
        private System.Windows.Forms.Label lab_nextHose;
        private System.Windows.Forms.Label lab_lastlHose;
        private System.Windows.Forms.Label lab_lastHose;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay;
        private System.Windows.Forms.BindingSource orderInfoBindingSource;
        private System.Windows.Forms.DataGridView GV_orderInfo;
        private System.Windows.Forms.Button btn_init;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Specification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_UUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Matched;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_Unmatched;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Label lblIdentifyTime;
        private System.Windows.Forms.Label spendTime;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txtSpecHistry;
        private System.Windows.Forms.GroupBox group_matchOrder;
        private System.Windows.Forms.DataGridView dataGrid_match;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Specific;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Match;
    }
}