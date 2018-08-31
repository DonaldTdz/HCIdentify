namespace HC.Identify.App
{
    partial class SystemConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ZRIP = new System.Windows.Forms.TextBox();
            this.check_isActionzr = new System.Windows.Forms.CheckBox();
            this.txt_ZRPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_brandIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_brandPort = new System.Windows.Forms.TextBox();
            this.check_isActionBr = new System.Windows.Forms.CheckBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lab_Photo = new System.Windows.Forms.Label();
            this.ck_photo = new System.Windows.Forms.CheckBox();
            this.lab_debug = new System.Windows.Forms.Label();
            this.check_debug = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSleepTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ckOrderSeq = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "中软接口IP：";
            // 
            // txt_ZRIP
            // 
            this.txt_ZRIP.Location = new System.Drawing.Point(421, 123);
            this.txt_ZRIP.Name = "txt_ZRIP";
            this.txt_ZRIP.Size = new System.Drawing.Size(174, 21);
            this.txt_ZRIP.TabIndex = 1;
            // 
            // check_isActionzr
            // 
            this.check_isActionzr.AutoSize = true;
            this.check_isActionzr.Location = new System.Drawing.Point(826, 128);
            this.check_isActionzr.Name = "check_isActionzr";
            this.check_isActionzr.Size = new System.Drawing.Size(72, 16);
            this.check_isActionzr.TabIndex = 2;
            this.check_isActionzr.Text = "是否启用";
            this.check_isActionzr.UseVisualStyleBackColor = true;
            // 
            // txt_ZRPort
            // 
            this.txt_ZRPort.Location = new System.Drawing.Point(684, 123);
            this.txt_ZRPort.Name = "txt_ZRPort";
            this.txt_ZRPort.Size = new System.Drawing.Size(60, 21);
            this.txt_ZRPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(649, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "条码相机IP：";
            // 
            // txt_brandIP
            // 
            this.txt_brandIP.Location = new System.Drawing.Point(421, 180);
            this.txt_brandIP.Name = "txt_brandIP";
            this.txt_brandIP.Size = new System.Drawing.Size(174, 21);
            this.txt_brandIP.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(649, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "端口";
            // 
            // txt_brandPort
            // 
            this.txt_brandPort.Location = new System.Drawing.Point(684, 180);
            this.txt_brandPort.Name = "txt_brandPort";
            this.txt_brandPort.Size = new System.Drawing.Size(60, 21);
            this.txt_brandPort.TabIndex = 8;
            // 
            // check_isActionBr
            // 
            this.check_isActionBr.AutoSize = true;
            this.check_isActionBr.Location = new System.Drawing.Point(826, 182);
            this.check_isActionBr.Name = "check_isActionBr";
            this.check_isActionBr.Size = new System.Drawing.Size(72, 16);
            this.check_isActionBr.TabIndex = 9;
            this.check_isActionBr.Text = "是否启用";
            this.check_isActionBr.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(550, 446);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(86, 39);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lab_Photo
            // 
            this.lab_Photo.AutoSize = true;
            this.lab_Photo.Location = new System.Drawing.Point(649, 237);
            this.lab_Photo.Name = "lab_Photo";
            this.lab_Photo.Size = new System.Drawing.Size(65, 12);
            this.lab_Photo.TabIndex = 11;
            this.lab_Photo.Text = "视觉相机：";
            // 
            // ck_photo
            // 
            this.ck_photo.AutoSize = true;
            this.ck_photo.Location = new System.Drawing.Point(826, 232);
            this.ck_photo.Name = "ck_photo";
            this.ck_photo.Size = new System.Drawing.Size(72, 16);
            this.ck_photo.TabIndex = 12;
            this.ck_photo.Text = "是否启用";
            this.ck_photo.UseVisualStyleBackColor = true;
            // 
            // lab_debug
            // 
            this.lab_debug.AutoSize = true;
            this.lab_debug.Location = new System.Drawing.Point(292, 291);
            this.lab_debug.Name = "lab_debug";
            this.lab_debug.Size = new System.Drawing.Size(65, 12);
            this.lab_debug.TabIndex = 13;
            this.lab_debug.Text = "调试模式：";
            // 
            // check_debug
            // 
            this.check_debug.AutoSize = true;
            this.check_debug.Location = new System.Drawing.Point(421, 290);
            this.check_debug.Name = "check_debug";
            this.check_debug.Size = new System.Drawing.Size(72, 16);
            this.check_debug.TabIndex = 14;
            this.check_debug.Text = "是否启用";
            this.check_debug.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "视觉相机等待时间：";
            // 
            // txtSleepTime
            // 
            this.txtSleepTime.Location = new System.Drawing.Point(421, 230);
            this.txtSleepTime.Name = "txtSleepTime";
            this.txtSleepTime.Size = new System.Drawing.Size(100, 21);
            this.txtSleepTime.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(527, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "ms";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(649, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "订单顺序模式：";
            // 
            // ckOrderSeq
            // 
            this.ckOrderSeq.AutoSize = true;
            this.ckOrderSeq.Location = new System.Drawing.Point(826, 291);
            this.ckOrderSeq.Name = "ckOrderSeq";
            this.ckOrderSeq.Size = new System.Drawing.Size(72, 16);
            this.ckOrderSeq.TabIndex = 19;
            this.ckOrderSeq.Text = "是否启用";
            this.ckOrderSeq.UseVisualStyleBackColor = true;
            // 
            // SystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 611);
            this.Controls.Add(this.ckOrderSeq);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSleepTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.check_debug);
            this.Controls.Add(this.lab_debug);
            this.Controls.Add(this.ck_photo);
            this.Controls.Add(this.lab_Photo);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.check_isActionBr);
            this.Controls.Add(this.txt_brandPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_brandIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ZRPort);
            this.Controls.Add(this.check_isActionzr);
            this.Controls.Add(this.txt_ZRIP);
            this.Controls.Add(this.label1);
            this.Name = "SystemConfig";
            this.Text = "SystemConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ZRIP;
        private System.Windows.Forms.CheckBox check_isActionzr;
        private System.Windows.Forms.TextBox txt_ZRPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_brandIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_brandPort;
        private System.Windows.Forms.CheckBox check_isActionBr;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lab_Photo;
        private System.Windows.Forms.CheckBox ck_photo;
        private System.Windows.Forms.Label lab_debug;
        private System.Windows.Forms.CheckBox check_debug;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSleepTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ckOrderSeq;
    }
}