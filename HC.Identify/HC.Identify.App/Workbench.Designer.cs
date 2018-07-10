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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cvsInSightDisplay1 = new Cognex.InSight.Controls.Display.CvsInSightDisplay();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_dowload = new System.Windows.Forms.Button();
            this.combo_area = new System.Windows.Forms.ComboBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_lasthouse = new System.Windows.Forms.Button();
            this.btn_nexthouse = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lab_notcheck = new System.Windows.Forms.Label();
            this.lab_check = new System.Windows.Forms.Label();
            this.lab_notcheck_title = new System.Windows.Forms.Label();
            this.lab_cheked_title = new System.Windows.Forms.Label();
            this.lab_num = new System.Windows.Forms.Label();
            this.lab_houseNum = new System.Windows.Forms.Label();
            this.lab_num_title = new System.Windows.Forms.Label();
            this.lab_houseNum_title = new System.Windows.Forms.Label();
            this.lab_retaName = new System.Windows.Forms.Label();
            this.lab_areaName = new System.Windows.Forms.Label();
            this.lab_retaName_title = new System.Windows.Forms.Label();
            this.lab_areaName_title = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lab_readRate = new System.Windows.Forms.Label();
            this.lab_readRate_title = new System.Windows.Forms.Label();
            this.lab_unRead = new System.Windows.Forms.Label();
            this.lab_unRead_title = new System.Windows.Forms.Label();
            this.lab_alreadyRead = new System.Windows.Forms.Label();
            this.lab_alreadyRead_title = new System.Windows.Forms.Label();
            this.ab_checkAmount = new System.Windows.Forms.Label();
            this.lab_checkAmount_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_nextnHose = new System.Windows.Forms.Label();
            this.lab_nextHose = new System.Windows.Forms.Label();
            this.lab_lastlHose = new System.Windows.Forms.Label();
            this.lab_lastHose = new System.Windows.Forms.Label();
            this.lab_nextnHose_title = new System.Windows.Forms.Label();
            this.lab_lastlHose_title = new System.Windows.Forms.Label();
            this.lab_nextHose_title = new System.Windows.Forms.Label();
            this.lab_lastHose_title = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 467);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cvsInSightDisplay1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "相机界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cvsInSightDisplay1
            // 
            this.cvsInSightDisplay1.DefaultTextScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplay.TextScaleModeType.Proportional;
            this.cvsInSightDisplay1.DialogIcon = null;
            this.cvsInSightDisplay1.Location = new System.Drawing.Point(3, 0);
            this.cvsInSightDisplay1.Name = "cvsInSightDisplay1";
            this.cvsInSightDisplay1.PreferredCropScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplayCropScaleMode.Default;
            this.cvsInSightDisplay1.Size = new System.Drawing.Size(427, 331);
            this.cvsInSightDisplay1.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(8, 346);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(638, 87);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "匹配结果";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(7, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 24);
            this.label13.TabIndex = 2;
            this.label13.Text = "6901028227704  ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Green;
            this.label15.Location = new System.Drawing.Point(517, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 24);
            this.label15.TabIndex = 4;
            this.label15.Text = "匹配正常";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(217, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(186, 24);
            this.label14.TabIndex = 3;
            this.label14.Text = "天子(千里江山)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(436, 9);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 322);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "[14:41:25]：6901028227704 ";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "订单列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_dowload);
            this.groupBox1.Controls.Add(this.combo_area);
            this.groupBox1.Location = new System.Drawing.Point(671, 5);
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
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(671, 80);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(100, 40);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            // 
            // btn_lasthouse
            // 
            this.btn_lasthouse.Location = new System.Drawing.Point(792, 80);
            this.btn_lasthouse.Name = "btn_lasthouse";
            this.btn_lasthouse.Size = new System.Drawing.Size(80, 40);
            this.btn_lasthouse.TabIndex = 3;
            this.btn_lasthouse.Text = "上一户";
            this.btn_lasthouse.UseVisualStyleBackColor = true;
            this.btn_lasthouse.Click += new System.EventHandler(this.btn_lasthouse_Click);
            // 
            // btn_nexthouse
            // 
            this.btn_nexthouse.Location = new System.Drawing.Point(892, 80);
            this.btn_nexthouse.Name = "btn_nexthouse";
            this.btn_nexthouse.Size = new System.Drawing.Size(80, 40);
            this.btn_nexthouse.TabIndex = 4;
            this.btn_nexthouse.Text = "下一户";
            this.btn_nexthouse.UseVisualStyleBackColor = true;
            this.btn_nexthouse.Click += new System.EventHandler(this.btn_nexthouse_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lab_notcheck);
            this.groupBox2.Controls.Add(this.lab_check);
            this.groupBox2.Controls.Add(this.lab_notcheck_title);
            this.groupBox2.Controls.Add(this.lab_cheked_title);
            this.groupBox2.Controls.Add(this.lab_num);
            this.groupBox2.Controls.Add(this.lab_houseNum);
            this.groupBox2.Controls.Add(this.lab_num_title);
            this.groupBox2.Controls.Add(this.lab_houseNum_title);
            this.groupBox2.Controls.Add(this.lab_retaName);
            this.groupBox2.Controls.Add(this.lab_areaName);
            this.groupBox2.Controls.Add(this.lab_retaName_title);
            this.groupBox2.Controls.Add(this.lab_areaName_title);
            this.groupBox2.Location = new System.Drawing.Point(671, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 141);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批次订单信息";
            // 
            // lab_notcheck
            // 
            this.lab_notcheck.AutoSize = true;
            this.lab_notcheck.Location = new System.Drawing.Point(253, 112);
            this.lab_notcheck.Name = "lab_notcheck";
            this.lab_notcheck.Size = new System.Drawing.Size(11, 12);
            this.lab_notcheck.TabIndex = 7;
            this.lab_notcheck.Text = "8";
            // 
            // lab_check
            // 
            this.lab_check.AutoSize = true;
            this.lab_check.Location = new System.Drawing.Point(61, 113);
            this.lab_check.Name = "lab_check";
            this.lab_check.Size = new System.Drawing.Size(11, 12);
            this.lab_check.TabIndex = 7;
            this.lab_check.Text = "2";
            // 
            // lab_notcheck_title
            // 
            this.lab_notcheck_title.AutoSize = true;
            this.lab_notcheck_title.Location = new System.Drawing.Point(197, 113);
            this.lab_notcheck_title.Name = "lab_notcheck_title";
            this.lab_notcheck_title.Size = new System.Drawing.Size(53, 12);
            this.lab_notcheck_title.TabIndex = 6;
            this.lab_notcheck_title.Text = "未检量：";
            // 
            // lab_cheked_title
            // 
            this.lab_cheked_title.AutoSize = true;
            this.lab_cheked_title.Location = new System.Drawing.Point(8, 112);
            this.lab_cheked_title.Name = "lab_cheked_title";
            this.lab_cheked_title.Size = new System.Drawing.Size(53, 12);
            this.lab_cheked_title.TabIndex = 6;
            this.lab_cheked_title.Text = "已检量：";
            // 
            // lab_num
            // 
            this.lab_num.AutoSize = true;
            this.lab_num.Location = new System.Drawing.Point(252, 90);
            this.lab_num.Name = "lab_num";
            this.lab_num.Size = new System.Drawing.Size(0, 12);
            this.lab_num.TabIndex = 3;
            // 
            // lab_houseNum
            // 
            this.lab_houseNum.AutoSize = true;
            this.lab_houseNum.Location = new System.Drawing.Point(58, 88);
            this.lab_houseNum.Name = "lab_houseNum";
            this.lab_houseNum.Size = new System.Drawing.Size(0, 12);
            this.lab_houseNum.TabIndex = 5;
            // 
            // lab_num_title
            // 
            this.lab_num_title.AutoSize = true;
            this.lab_num_title.Location = new System.Drawing.Point(197, 89);
            this.lab_num_title.Name = "lab_num_title";
            this.lab_num_title.Size = new System.Drawing.Size(53, 12);
            this.lab_num_title.TabIndex = 1;
            this.lab_num_title.Text = "订单量：";
            // 
            // lab_houseNum_title
            // 
            this.lab_houseNum_title.AutoSize = true;
            this.lab_houseNum_title.Location = new System.Drawing.Point(7, 87);
            this.lab_houseNum_title.Name = "lab_houseNum_title";
            this.lab_houseNum_title.Size = new System.Drawing.Size(53, 12);
            this.lab_houseNum_title.TabIndex = 4;
            this.lab_houseNum_title.Text = "户  号：";
            // 
            // lab_retaName
            // 
            this.lab_retaName.AutoSize = true;
            this.lab_retaName.Location = new System.Drawing.Point(62, 59);
            this.lab_retaName.Name = "lab_retaName";
            this.lab_retaName.Size = new System.Drawing.Size(0, 12);
            this.lab_retaName.TabIndex = 3;
            // 
            // lab_areaName
            // 
            this.lab_areaName.AutoSize = true;
            this.lab_areaName.Location = new System.Drawing.Point(56, 26);
            this.lab_areaName.Name = "lab_areaName";
            this.lab_areaName.Size = new System.Drawing.Size(0, 12);
            this.lab_areaName.TabIndex = 2;
            // 
            // lab_retaName_title
            // 
            this.lab_retaName_title.AutoSize = true;
            this.lab_retaName_title.Location = new System.Drawing.Point(7, 59);
            this.lab_retaName_title.Name = "lab_retaName_title";
            this.lab_retaName_title.Size = new System.Drawing.Size(53, 12);
            this.lab_retaName_title.TabIndex = 1;
            this.lab_retaName_title.Text = "客  户：";
            // 
            // lab_areaName_title
            // 
            this.lab_areaName_title.AutoSize = true;
            this.lab_areaName_title.Location = new System.Drawing.Point(7, 26);
            this.lab_areaName_title.Name = "lab_areaName_title";
            this.lab_areaName_title.Size = new System.Drawing.Size(53, 12);
            this.lab_areaName_title.TabIndex = 0;
            this.lab_areaName_title.Text = "线  路：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lab_readRate);
            this.groupBox3.Controls.Add(this.lab_readRate_title);
            this.groupBox3.Controls.Add(this.lab_unRead);
            this.groupBox3.Controls.Add(this.lab_unRead_title);
            this.groupBox3.Controls.Add(this.lab_alreadyRead);
            this.groupBox3.Controls.Add(this.lab_alreadyRead_title);
            this.groupBox3.Controls.Add(this.ab_checkAmount);
            this.groupBox3.Controls.Add(this.lab_checkAmount_title);
            this.groupBox3.Location = new System.Drawing.Point(671, 376);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 82);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "汇总";
            // 
            // lab_readRate
            // 
            this.lab_readRate.AutoSize = true;
            this.lab_readRate.Location = new System.Drawing.Point(211, 57);
            this.lab_readRate.Name = "lab_readRate";
            this.lab_readRate.Size = new System.Drawing.Size(23, 12);
            this.lab_readRate.TabIndex = 7;
            this.lab_readRate.Text = "80%";
            // 
            // lab_readRate_title
            // 
            this.lab_readRate_title.AutoSize = true;
            this.lab_readRate_title.Location = new System.Drawing.Point(152, 58);
            this.lab_readRate_title.Name = "lab_readRate_title";
            this.lab_readRate_title.Size = new System.Drawing.Size(53, 12);
            this.lab_readRate_title.TabIndex = 6;
            this.lab_readRate_title.Text = "读取率：";
            // 
            // lab_unRead
            // 
            this.lab_unRead.AutoSize = true;
            this.lab_unRead.Location = new System.Drawing.Point(73, 58);
            this.lab_unRead.Name = "lab_unRead";
            this.lab_unRead.Size = new System.Drawing.Size(17, 12);
            this.lab_unRead.TabIndex = 5;
            this.lab_unRead.Text = "20";
            // 
            // lab_unRead_title
            // 
            this.lab_unRead_title.AutoSize = true;
            this.lab_unRead_title.Location = new System.Drawing.Point(10, 57);
            this.lab_unRead_title.Name = "lab_unRead_title";
            this.lab_unRead_title.Size = new System.Drawing.Size(53, 12);
            this.lab_unRead_title.TabIndex = 4;
            this.lab_unRead_title.Text = "未读取：";
            // 
            // lab_alreadyRead
            // 
            this.lab_alreadyRead.AutoSize = true;
            this.lab_alreadyRead.Location = new System.Drawing.Point(209, 31);
            this.lab_alreadyRead.Name = "lab_alreadyRead";
            this.lab_alreadyRead.Size = new System.Drawing.Size(17, 12);
            this.lab_alreadyRead.TabIndex = 3;
            this.lab_alreadyRead.Text = "80";
            // 
            // lab_alreadyRead_title
            // 
            this.lab_alreadyRead_title.AutoSize = true;
            this.lab_alreadyRead_title.Location = new System.Drawing.Point(151, 31);
            this.lab_alreadyRead_title.Name = "lab_alreadyRead_title";
            this.lab_alreadyRead_title.Size = new System.Drawing.Size(53, 12);
            this.lab_alreadyRead_title.TabIndex = 2;
            this.lab_alreadyRead_title.Text = "已读取：";
            // 
            // ab_checkAmount
            // 
            this.ab_checkAmount.AutoSize = true;
            this.ab_checkAmount.Location = new System.Drawing.Point(70, 33);
            this.ab_checkAmount.Name = "ab_checkAmount";
            this.ab_checkAmount.Size = new System.Drawing.Size(23, 12);
            this.ab_checkAmount.TabIndex = 1;
            this.ab_checkAmount.Text = "100";
            // 
            // lab_checkAmount_title
            // 
            this.lab_checkAmount_title.AutoSize = true;
            this.lab_checkAmount_title.Location = new System.Drawing.Point(10, 32);
            this.lab_checkAmount_title.Name = "lab_checkAmount_title";
            this.lab_checkAmount_title.Size = new System.Drawing.Size(53, 12);
            this.lab_checkAmount_title.TabIndex = 0;
            this.lab_checkAmount_title.Text = "检查量：";
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
            this.panel1.Location = new System.Drawing.Point(672, 286);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 75);
            this.panel1.TabIndex = 7;
            // 
            // lab_nextnHose
            // 
            this.lab_nextnHose.AutoSize = true;
            this.lab_nextnHose.Location = new System.Drawing.Point(226, 49);
            this.lab_nextnHose.Name = "lab_nextnHose";
            this.lab_nextnHose.Size = new System.Drawing.Size(47, 12);
            this.lab_nextnHose.TabIndex = 7;
            this.lab_nextnHose.Text = "label31";
            // 
            // lab_nextHose
            // 
            this.lab_nextHose.AutoSize = true;
            this.lab_nextHose.Location = new System.Drawing.Point(62, 49);
            this.lab_nextHose.Name = "lab_nextHose";
            this.lab_nextHose.Size = new System.Drawing.Size(47, 12);
            this.lab_nextHose.TabIndex = 6;
            this.lab_nextHose.Text = "label30";
            // 
            // lab_lastlHose
            // 
            this.lab_lastlHose.AutoSize = true;
            this.lab_lastlHose.Location = new System.Drawing.Point(224, 15);
            this.lab_lastlHose.Name = "lab_lastlHose";
            this.lab_lastlHose.Size = new System.Drawing.Size(47, 12);
            this.lab_lastlHose.TabIndex = 5;
            this.lab_lastlHose.Text = "label29";
            // 
            // lab_lastHose
            // 
            this.lab_lastHose.AutoSize = true;
            this.lab_lastHose.Location = new System.Drawing.Point(60, 16);
            this.lab_lastHose.Name = "lab_lastHose";
            this.lab_lastHose.Size = new System.Drawing.Size(47, 12);
            this.lab_lastHose.TabIndex = 4;
            this.lab_lastHose.Text = "label28";
            // 
            // lab_nextnHose_title
            // 
            this.lab_nextnHose_title.AutoSize = true;
            this.lab_nextnHose_title.Location = new System.Drawing.Point(153, 50);
            this.lab_nextnHose_title.Name = "lab_nextnHose_title";
            this.lab_nextnHose_title.Size = new System.Drawing.Size(65, 12);
            this.lab_nextnHose_title.TabIndex = 3;
            this.lab_nextnHose_title.Text = "下下一户：";
            // 
            // lab_lastlHose_title
            // 
            this.lab_lastlHose_title.AutoSize = true;
            this.lab_lastlHose_title.Location = new System.Drawing.Point(152, 16);
            this.lab_lastlHose_title.Name = "lab_lastlHose_title";
            this.lab_lastlHose_title.Size = new System.Drawing.Size(65, 12);
            this.lab_lastlHose_title.TabIndex = 2;
            this.lab_lastlHose_title.Text = "上上一户：";
            // 
            // lab_nextHose_title
            // 
            this.lab_nextHose_title.AutoSize = true;
            this.lab_nextHose_title.Location = new System.Drawing.Point(11, 50);
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
            // Workbench
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 476);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_nexthouse);
            this.Controls.Add(this.btn_lasthouse);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Workbench";
            this.Text = "工作台";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_dowload;
        private System.Windows.Forms.ComboBox combo_area;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_lasthouse;
        private System.Windows.Forms.Button btn_nexthouse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lab_retaName;
        private System.Windows.Forms.Label lab_areaName;
        private System.Windows.Forms.Label lab_retaName_title;
        private System.Windows.Forms.Label lab_areaName_title;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lab_num;
        private System.Windows.Forms.Label lab_num_title;
        private System.Windows.Forms.Label lab_notcheck;
        private System.Windows.Forms.Label lab_notcheck_title;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lab_check;
        private System.Windows.Forms.Label lab_cheked_title;
        private System.Windows.Forms.Label lab_houseNum;
        private System.Windows.Forms.Label lab_houseNum_title;
        private System.Windows.Forms.Label lab_readRate;
        private System.Windows.Forms.Label lab_readRate_title;
        private System.Windows.Forms.Label lab_unRead;
        private System.Windows.Forms.Label lab_unRead_title;
        private System.Windows.Forms.Label lab_alreadyRead;
        private System.Windows.Forms.Label lab_alreadyRead_title;
        private System.Windows.Forms.Label ab_checkAmount;
        private System.Windows.Forms.Label lab_checkAmount_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab_nextnHose_title;
        private System.Windows.Forms.Label lab_lastlHose_title;
        private System.Windows.Forms.Label lab_nextHose_title;
        private System.Windows.Forms.Label lab_lastHose_title;
        private Cognex.InSight.Controls.Display.CvsInSightDisplay cvsInSightDisplay1;
        private System.Windows.Forms.Label lab_nextnHose;
        private System.Windows.Forms.Label lab_nextHose;
        private System.Windows.Forms.Label lab_lastlHose;
        private System.Windows.Forms.Label lab_lastHose;
    }
}