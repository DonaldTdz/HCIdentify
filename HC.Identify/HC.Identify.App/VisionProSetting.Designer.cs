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
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.chkAutoSaveImage = new System.Windows.Forms.CheckBox();
            this.chkAutoSaveData = new System.Windows.Forms.CheckBox();
            this.chkCamTrigOnv = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCurrentSpec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUseTime = new System.Windows.Forms.TextBox();
            this.txtMatchSpec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblResultDesc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
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
            this.cogToolBlockEditV2.Size = new System.Drawing.Size(610, 497);
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
            this.cogRecordDisplay.Size = new System.Drawing.Size(707, 547);
            this.cogRecordDisplay.TabIndex = 6;
            // 
            // btnToolSetting
            // 
            this.btnToolSetting.Location = new System.Drawing.Point(723, 13);
            this.btnToolSetting.Name = "btnToolSetting";
            this.btnToolSetting.Size = new System.Drawing.Size(80, 30);
            this.btnToolSetting.TabIndex = 8;
            this.btnToolSetting.Text = "工具设置";
            this.btnToolSetting.UseVisualStyleBackColor = true;
            this.btnToolSetting.Click += new System.EventHandler(this.btnToolSetting_Click);
            // 
            // btnLiveDisplay
            // 
            this.btnLiveDisplay.Location = new System.Drawing.Point(876, 12);
            this.btnLiveDisplay.Name = "btnLiveDisplay";
            this.btnLiveDisplay.Size = new System.Drawing.Size(80, 30);
            this.btnLiveDisplay.TabIndex = 9;
            this.btnLiveDisplay.Text = "连续取像";
            this.btnLiveDisplay.UseVisualStyleBackColor = true;
            this.btnLiveDisplay.Click += new System.EventHandler(this.btnLiveDisplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(724, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "已注册型号：";
            // 
            // comboSpecBox
            // 
            this.comboSpecBox.FormattingEnabled = true;
            this.comboSpecBox.Location = new System.Drawing.Point(813, 61);
            this.comboSpecBox.Name = "comboSpecBox";
            this.comboSpecBox.Size = new System.Drawing.Size(146, 20);
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
            this.groupImgSaveBox.Location = new System.Drawing.Point(723, 93);
            this.groupImgSaveBox.Name = "groupImgSaveBox";
            this.groupImgSaveBox.Size = new System.Drawing.Size(249, 106);
            this.groupImgSaveBox.TabIndex = 12;
            this.groupImgSaveBox.TabStop = false;
            this.groupImgSaveBox.Text = "图像存储";
            // 
            // txtCurrentImgFileName
            // 
            this.txtCurrentImgFileName.Location = new System.Drawing.Point(117, 78);
            this.txtCurrentImgFileName.Name = "txtCurrentImgFileName";
            this.txtCurrentImgFileName.Size = new System.Drawing.Size(124, 21);
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
            this.btnSaveImgFileName.Location = new System.Drawing.Point(131, 49);
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
            this.txtImgFileName.Size = new System.Drawing.Size(110, 21);
            this.txtImgFileName.TabIndex = 2;
            // 
            // btnOpenImg
            // 
            this.btnOpenImg.Location = new System.Drawing.Point(130, 19);
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
            this.txtImgPath.Size = new System.Drawing.Size(111, 21);
            this.txtImgPath.TabIndex = 0;
            // 
            // groupSetBox
            // 
            this.groupSetBox.Controls.Add(this.checkBox5);
            this.groupSetBox.Controls.Add(this.checkBox4);
            this.groupSetBox.Controls.Add(this.chkAutoSaveImage);
            this.groupSetBox.Controls.Add(this.chkAutoSaveData);
            this.groupSetBox.Controls.Add(this.chkCamTrigOnv);
            this.groupSetBox.Location = new System.Drawing.Point(723, 206);
            this.groupSetBox.Name = "groupSetBox";
            this.groupSetBox.Size = new System.Drawing.Size(249, 92);
            this.groupSetBox.TabIndex = 13;
            this.groupSetBox.TabStop = false;
            this.groupSetBox.Text = "参数设置";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(131, 45);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 16);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "显示图形";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(131, 21);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "仿真";
            this.checkBox4.UseVisualStyleBackColor = true;
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
            // chkCamTrigOnv
            // 
            this.chkCamTrigOnv.AutoSize = true;
            this.chkCamTrigOnv.Location = new System.Drawing.Point(13, 21);
            this.chkCamTrigOnv.Name = "chkCamTrigOnv";
            this.chkCamTrigOnv.Size = new System.Drawing.Size(96, 16);
            this.chkCamTrigOnv.TabIndex = 0;
            this.chkCamTrigOnv.Text = "相机外部模式";
            this.chkCamTrigOnv.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.txtCurrentSpec);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(723, 313);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 112);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "产品型号注册";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(170, 83);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(48, 16);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "后退";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 80);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "运行或下一张";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(144, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "注册当前产品";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "重新运行";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtCurrentSpec
            // 
            this.txtCurrentSpec.Location = new System.Drawing.Point(103, 18);
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
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(723, 432);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 118);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "型号匹配";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "毫秒";
            // 
            // txtUseTime
            // 
            this.txtUseTime.Location = new System.Drawing.Point(84, 83);
            this.txtUseTime.Name = "txtUseTime";
            this.txtUseTime.Size = new System.Drawing.Size(119, 21);
            this.txtUseTime.TabIndex = 7;
            // 
            // txtMatchSpec
            // 
            this.txtMatchSpec.Location = new System.Drawing.Point(83, 51);
            this.txtMatchSpec.Name = "txtMatchSpec";
            this.txtMatchSpec.Size = new System.Drawing.Size(120, 21);
            this.txtMatchSpec.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 86);
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
            this.lblResultDesc.Location = new System.Drawing.Point(207, 54);
            this.lblResultDesc.Name = "lblResultDesc";
            this.lblResultDesc.Size = new System.Drawing.Size(25, 15);
            this.lblResultDesc.TabIndex = 4;
            this.lblResultDesc.Text = "OK";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "匹配型号：";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(134, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(99, 23);
            this.button7.TabIndex = 1;
            this.button7.Text = "单次运行";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(17, 21);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "重新运行";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // VisionProSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
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
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox chkAutoSaveImage;
        private System.Windows.Forms.CheckBox chkAutoSaveData;
        private System.Windows.Forms.CheckBox chkCamTrigOnv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCurrentSpec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblResultDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtCurrentImgFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUseTime;
        private System.Windows.Forms.TextBox txtMatchSpec;
        private System.Windows.Forms.Label label7;
    }
}