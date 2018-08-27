namespace HC.Identify.App
{
    partial class VisionProSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisionProSetting));
            this.cogToolBlockEditV2 = new Cognex.VisionPro.ToolBlock.CogToolBlockEditV2();
            this.cogRecordDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.btnToolSetting = new System.Windows.Forms.Button();
            this.btnLiveDisplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSpecBox = new System.Windows.Forms.ComboBox();
            this.groupImgSaveBox = new System.Windows.Forms.GroupBox();
            this.txtCurrentImgFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveImgFileName = new System.Windows.Forms.Button();
            this.txtImgFileName = new System.Windows.Forms.TextBox();
            this.btnOpenImg = new System.Windows.Forms.Button();
            this.txtImgPath = new System.Windows.Forms.TextBox();
            this.groupSetBox = new System.Windows.Forms.GroupBox();
            this.chkShowPic = new System.Windows.Forms.CheckBox();
            this.chkSimulation = new System.Windows.Forms.CheckBox();
            this.chkAutoSaveImage = new System.Windows.Forms.CheckBox();
            this.chkAutoSaveData = new System.Windows.Forms.CheckBox();
            this.chkCamTrigOn = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBack = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnRegisterSpec = new System.Windows.Forms.Button();
            this.btnReRun = new System.Windows.Forms.Button();
            this.txtCurrentSpec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUseTime = new System.Windows.Forms.TextBox();
            this.txtMatchSpec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblResultDesc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMatchRun = new System.Windows.Forms.Button();
            this.btnReMatchRun = new System.Windows.Forms.Button();
            this.btn_Recover = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay)).BeginInit();
            this.groupImgSaveBox.SuspendLayout();
            this.groupSetBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cogToolBlockEditV2
            // 
            this.cogToolBlockEditV2.AllowDrop = true;
            this.cogToolBlockEditV2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cogToolBlockEditV2.ContextMenuCustomizer = null;
            this.cogToolBlockEditV2.Location = new System.Drawing.Point(4, 3);
            this.cogToolBlockEditV2.Margin = new System.Windows.Forms.Padding(2);
            this.cogToolBlockEditV2.MinimumSize = new System.Drawing.Size(367, 0);
            this.cogToolBlockEditV2.Name = "cogToolBlockEditV2";
            this.cogToolBlockEditV2.ShowNodeToolTips = true;
            this.cogToolBlockEditV2.Size = new System.Drawing.Size(676, 584);
            this.cogToolBlockEditV2.SuspendElectricRuns = false;
            this.cogToolBlockEditV2.TabIndex = 7;
            this.cogToolBlockEditV2.Visible = false;
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
            this.cogRecordDisplay.Location = new System.Drawing.Point(4, 3);
            this.cogRecordDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.cogRecordDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay.Name = "cogRecordDisplay";
            this.cogRecordDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay.OcxState")));
            this.cogRecordDisplay.Size = new System.Drawing.Size(814, 608);
            this.cogRecordDisplay.TabIndex = 6;
            // 
            // btnToolSetting
            // 
            this.btnToolSetting.Location = new System.Drawing.Point(869, 12);
            this.btnToolSetting.Name = "btnToolSetting";
            this.btnToolSetting.Size = new System.Drawing.Size(99, 30);
            this.btnToolSetting.TabIndex = 8;
            this.btnToolSetting.Text = "工具设置";
            this.btnToolSetting.UseVisualStyleBackColor = true;
            this.btnToolSetting.Click += new System.EventHandler(this.btnToolSetting_Click);
            // 
            // btnLiveDisplay
            // 
            this.btnLiveDisplay.Location = new System.Drawing.Point(1178, 12);
            this.btnLiveDisplay.Name = "btnLiveDisplay";
            this.btnLiveDisplay.Size = new System.Drawing.Size(99, 30);
            this.btnLiveDisplay.TabIndex = 9;
            this.btnLiveDisplay.Text = "连续取像";
            this.btnLiveDisplay.UseVisualStyleBackColor = true;
            this.btnLiveDisplay.Click += new System.EventHandler(this.btnLiveDisplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(875, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "已注册型号：";
            // 
            // comboSpecBox
            // 
            this.comboSpecBox.FormattingEnabled = true;
            this.comboSpecBox.Location = new System.Drawing.Point(1110, 58);
            this.comboSpecBox.Name = "comboSpecBox";
            this.comboSpecBox.Size = new System.Drawing.Size(167, 20);
            this.comboSpecBox.TabIndex = 11;
            // 
            // groupImgSaveBox
            // 
            this.groupImgSaveBox.Controls.Add(this.txtCurrentImgFileName);
            this.groupImgSaveBox.Controls.Add(this.label2);
            this.groupImgSaveBox.Controls.Add(this.btnSaveImgFileName);
            this.groupImgSaveBox.Controls.Add(this.txtImgFileName);
            this.groupImgSaveBox.Controls.Add(this.btnOpenImg);
            this.groupImgSaveBox.Controls.Add(this.txtImgPath);
            this.groupImgSaveBox.Location = new System.Drawing.Point(869, 86);
            this.groupImgSaveBox.Name = "groupImgSaveBox";
            this.groupImgSaveBox.Size = new System.Drawing.Size(408, 106);
            this.groupImgSaveBox.TabIndex = 12;
            this.groupImgSaveBox.TabStop = false;
            this.groupImgSaveBox.Text = "图像存储";
            // 
            // txtCurrentImgFileName
            // 
            this.txtCurrentImgFileName.Location = new System.Drawing.Point(241, 79);
            this.txtCurrentImgFileName.Name = "txtCurrentImgFileName";
            this.txtCurrentImgFileName.Size = new System.Drawing.Size(162, 21);
            this.txtCurrentImgFileName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "当前图像文件名：";
            // 
            // btnSaveImgFileName
            // 
            this.btnSaveImgFileName.Location = new System.Drawing.Point(241, 50);
            this.btnSaveImgFileName.Name = "btnSaveImgFileName";
            this.btnSaveImgFileName.Size = new System.Drawing.Size(110, 23);
            this.btnSaveImgFileName.TabIndex = 3;
            this.btnSaveImgFileName.Text = "输入文件名存图";
            this.btnSaveImgFileName.UseVisualStyleBackColor = true;
            this.btnSaveImgFileName.Click += new System.EventHandler(this.btnSaveImgFileName_Click);
            // 
            // txtImgFileName
            // 
            this.txtImgFileName.Location = new System.Drawing.Point(8, 49);
            this.txtImgFileName.Name = "txtImgFileName";
            this.txtImgFileName.Size = new System.Drawing.Size(148, 21);
            this.txtImgFileName.TabIndex = 2;
            // 
            // btnOpenImg
            // 
            this.btnOpenImg.Location = new System.Drawing.Point(241, 21);
            this.btnOpenImg.Name = "btnOpenImg";
            this.btnOpenImg.Size = new System.Drawing.Size(111, 23);
            this.btnOpenImg.TabIndex = 1;
            this.btnOpenImg.Text = "选择图片位置";
            this.btnOpenImg.UseVisualStyleBackColor = true;
            this.btnOpenImg.Click += new System.EventHandler(this.btnOpenImg_Click);
            // 
            // txtImgPath
            // 
            this.txtImgPath.Location = new System.Drawing.Point(7, 21);
            this.txtImgPath.Name = "txtImgPath";
            this.txtImgPath.Size = new System.Drawing.Size(149, 21);
            this.txtImgPath.TabIndex = 0;
            // 
            // groupSetBox
            // 
            this.groupSetBox.Controls.Add(this.chkShowPic);
            this.groupSetBox.Controls.Add(this.chkSimulation);
            this.groupSetBox.Controls.Add(this.chkAutoSaveImage);
            this.groupSetBox.Controls.Add(this.chkAutoSaveData);
            this.groupSetBox.Controls.Add(this.chkCamTrigOn);
            this.groupSetBox.Location = new System.Drawing.Point(869, 202);
            this.groupSetBox.Name = "groupSetBox";
            this.groupSetBox.Size = new System.Drawing.Size(408, 92);
            this.groupSetBox.TabIndex = 13;
            this.groupSetBox.TabStop = false;
            this.groupSetBox.Text = "参数设置";
            // 
            // chkShowPic
            // 
            this.chkShowPic.AutoSize = true;
            this.chkShowPic.Location = new System.Drawing.Point(241, 43);
            this.chkShowPic.Name = "chkShowPic";
            this.chkShowPic.Size = new System.Drawing.Size(72, 16);
            this.chkShowPic.TabIndex = 4;
            this.chkShowPic.Text = "显示图形";
            this.chkShowPic.UseVisualStyleBackColor = true;
            // 
            // chkSimulation
            // 
            this.chkSimulation.AutoSize = true;
            this.chkSimulation.Location = new System.Drawing.Point(241, 21);
            this.chkSimulation.Name = "chkSimulation";
            this.chkSimulation.Size = new System.Drawing.Size(48, 16);
            this.chkSimulation.TabIndex = 3;
            this.chkSimulation.Text = "仿真";
            this.chkSimulation.UseVisualStyleBackColor = true;
            this.chkSimulation.CheckStateChanged += new System.EventHandler(this.chkSimulation_CheckStateChanged);
            // 
            // chkAutoSaveImage
            // 
            this.chkAutoSaveImage.AutoSize = true;
            this.chkAutoSaveImage.Location = new System.Drawing.Point(13, 69);
            this.chkAutoSaveImage.Name = "chkAutoSaveImage";
            this.chkAutoSaveImage.Size = new System.Drawing.Size(72, 16);
            this.chkAutoSaveImage.TabIndex = 2;
            this.chkAutoSaveImage.Text = "自动存图";
            this.chkAutoSaveImage.UseVisualStyleBackColor = true;
            // 
            // chkAutoSaveData
            // 
            this.chkAutoSaveData.AutoSize = true;
            this.chkAutoSaveData.Location = new System.Drawing.Point(13, 45);
            this.chkAutoSaveData.Name = "chkAutoSaveData";
            this.chkAutoSaveData.Size = new System.Drawing.Size(72, 16);
            this.chkAutoSaveData.TabIndex = 1;
            this.chkAutoSaveData.Text = "保存数据";
            this.chkAutoSaveData.UseVisualStyleBackColor = true;
            // 
            // chkCamTrigOn
            // 
            this.chkCamTrigOn.AutoSize = true;
            this.chkCamTrigOn.Location = new System.Drawing.Point(13, 21);
            this.chkCamTrigOn.Name = "chkCamTrigOn";
            this.chkCamTrigOn.Size = new System.Drawing.Size(96, 16);
            this.chkCamTrigOn.TabIndex = 0;
            this.chkCamTrigOn.Text = "相机外部模式";
            this.chkCamTrigOn.UseVisualStyleBackColor = true;
            this.chkCamTrigOn.CheckedChanged += new System.EventHandler(this.chkCamTrigOn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBack);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnRegisterSpec);
            this.groupBox1.Controls.Add(this.btnReRun);
            this.groupBox1.Controls.Add(this.txtCurrentSpec);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(869, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 114);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "产品型号注册";
            // 
            // chkBack
            // 
            this.chkBack.AutoSize = true;
            this.chkBack.Location = new System.Drawing.Point(241, 86);
            this.chkBack.Name = "chkBack";
            this.chkBack.Size = new System.Drawing.Size(48, 16);
            this.chkBack.TabIndex = 5;
            this.chkBack.Text = "后退";
            this.chkBack.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(13, 79);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(118, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "运行或下一张";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnRegisterSpec
            // 
            this.btnRegisterSpec.Location = new System.Drawing.Point(241, 50);
            this.btnRegisterSpec.Name = "btnRegisterSpec";
            this.btnRegisterSpec.Size = new System.Drawing.Size(90, 23);
            this.btnRegisterSpec.TabIndex = 3;
            this.btnRegisterSpec.Text = "注册当前产品";
            this.btnRegisterSpec.UseVisualStyleBackColor = true;
            this.btnRegisterSpec.Click += new System.EventHandler(this.btnRegisterSpec_Click);
            // 
            // btnReRun
            // 
            this.btnReRun.Location = new System.Drawing.Point(13, 50);
            this.btnReRun.Name = "btnReRun";
            this.btnReRun.Size = new System.Drawing.Size(118, 23);
            this.btnReRun.TabIndex = 2;
            this.btnReRun.Text = "重新运行";
            this.btnReRun.UseVisualStyleBackColor = true;
            this.btnReRun.Click += new System.EventHandler(this.btnReRun_Click);
            // 
            // txtCurrentSpec
            // 
            this.txtCurrentSpec.Location = new System.Drawing.Point(241, 12);
            this.txtCurrentSpec.Name = "txtCurrentSpec";
            this.txtCurrentSpec.Size = new System.Drawing.Size(132, 21);
            this.txtCurrentSpec.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "输入当前型号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtUseTime);
            this.groupBox2.Controls.Add(this.txtMatchSpec);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblResultDesc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnMatchRun);
            this.groupBox2.Controls.Add(this.btnReMatchRun);
            this.groupBox2.Location = new System.Drawing.Point(869, 434);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 136);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "型号匹配";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "毫秒";
            // 
            // txtUseTime
            // 
            this.txtUseTime.Location = new System.Drawing.Point(86, 102);
            this.txtUseTime.Name = "txtUseTime";
            this.txtUseTime.Size = new System.Drawing.Size(119, 21);
            this.txtUseTime.TabIndex = 7;
            // 
            // txtMatchSpec
            // 
            this.txtMatchSpec.Location = new System.Drawing.Point(85, 62);
            this.txtMatchSpec.Name = "txtMatchSpec";
            this.txtMatchSpec.Size = new System.Drawing.Size(120, 21);
            this.txtMatchSpec.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "运行时间：";
            // 
            // lblResultDesc
            // 
            this.lblResultDesc.AutoSize = true;
            this.lblResultDesc.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResultDesc.ForeColor = System.Drawing.Color.Green;
            this.lblResultDesc.Location = new System.Drawing.Point(209, 68);
            this.lblResultDesc.Name = "lblResultDesc";
            this.lblResultDesc.Size = new System.Drawing.Size(25, 15);
            this.lblResultDesc.TabIndex = 4;
            this.lblResultDesc.Text = "OK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "匹配型号：";
            // 
            // btnMatchRun
            // 
            this.btnMatchRun.Location = new System.Drawing.Point(241, 20);
            this.btnMatchRun.Name = "btnMatchRun";
            this.btnMatchRun.Size = new System.Drawing.Size(99, 23);
            this.btnMatchRun.TabIndex = 1;
            this.btnMatchRun.Text = "单次运行";
            this.btnMatchRun.UseVisualStyleBackColor = true;
            this.btnMatchRun.Click += new System.EventHandler(this.btnMatchRun_Click);
            // 
            // btnReMatchRun
            // 
            this.btnReMatchRun.Location = new System.Drawing.Point(12, 20);
            this.btnReMatchRun.Name = "btnReMatchRun";
            this.btnReMatchRun.Size = new System.Drawing.Size(99, 23);
            this.btnReMatchRun.TabIndex = 0;
            this.btnReMatchRun.Text = "重新运行";
            this.btnReMatchRun.UseVisualStyleBackColor = true;
            this.btnReMatchRun.Click += new System.EventHandler(this.btnReMatchRun_Click);
            // 
            // btn_Recover
            // 
            this.btn_Recover.Location = new System.Drawing.Point(869, 575);
            this.btn_Recover.Name = "btn_Recover";
            this.btn_Recover.Size = new System.Drawing.Size(99, 32);
            this.btn_Recover.TabIndex = 16;
            this.btn_Recover.Text = "恢复默认设置";
            this.btn_Recover.UseVisualStyleBackColor = true;
            this.btn_Recover.Click += new System.EventHandler(this.btn_Recover_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(1178, 575);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(99, 32);
            this.btn_Save.TabIndex = 17;
            this.btn_Save.Text = "保存当前设置";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // VisionProSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 611);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Recover);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupSetBox);
            this.Controls.Add(this.groupImgSaveBox);
            this.Controls.Add(this.comboSpecBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLiveDisplay);
            this.Controls.Add(this.btnToolSetting);
            this.Controls.Add(this.cogToolBlockEditV2);
            this.Controls.Add(this.cogRecordDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VisionProSetting";
            this.Text = "视觉配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VisionProSetting_FormClosing);
            this.Load += new System.EventHandler(this.VisionProSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay)).EndInit();
            this.groupImgSaveBox.ResumeLayout(false);
            this.groupImgSaveBox.PerformLayout();
            this.groupSetBox.ResumeLayout(false);
            this.groupSetBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogToolBlockEditV2;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay;
        private System.Windows.Forms.Button btnToolSetting;
        private System.Windows.Forms.Button btnLiveDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboSpecBox;
        private System.Windows.Forms.GroupBox groupImgSaveBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveImgFileName;
        private System.Windows.Forms.TextBox txtImgFileName;
        private System.Windows.Forms.Button btnOpenImg;
        private System.Windows.Forms.TextBox txtImgPath;
        private System.Windows.Forms.GroupBox groupSetBox;
        private System.Windows.Forms.CheckBox chkShowPic;
        private System.Windows.Forms.CheckBox chkSimulation;
        private System.Windows.Forms.CheckBox chkAutoSaveImage;
        private System.Windows.Forms.CheckBox chkAutoSaveData;
        private System.Windows.Forms.CheckBox chkCamTrigOn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCurrentSpec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnRegisterSpec;
        private System.Windows.Forms.Button btnReRun;
        private System.Windows.Forms.CheckBox chkBack;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblResultDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMatchRun;
        private System.Windows.Forms.Button btnReMatchRun;
        private System.Windows.Forms.TextBox txtCurrentImgFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUseTime;
        private System.Windows.Forms.TextBox txtMatchSpec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Recover;
        private System.Windows.Forms.Button btn_Save;
    }
}