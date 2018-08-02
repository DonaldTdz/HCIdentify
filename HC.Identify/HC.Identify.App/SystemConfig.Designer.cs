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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "中软接口IP:";
            // 
            // txt_ZRIP
            // 
            this.txt_ZRIP.Location = new System.Drawing.Point(283, 199);
            this.txt_ZRIP.Name = "txt_ZRIP";
            this.txt_ZRIP.Size = new System.Drawing.Size(174, 21);
            this.txt_ZRIP.TabIndex = 1;
            // 
            // check_isActionzr
            // 
            this.check_isActionzr.AutoSize = true;
            this.check_isActionzr.Location = new System.Drawing.Point(610, 203);
            this.check_isActionzr.Name = "check_isActionzr";
            this.check_isActionzr.Size = new System.Drawing.Size(72, 16);
            this.check_isActionzr.TabIndex = 2;
            this.check_isActionzr.Text = "是否启用";
            this.check_isActionzr.UseVisualStyleBackColor = true;
            // 
            // txt_ZRPort
            // 
            this.txt_ZRPort.Location = new System.Drawing.Point(518, 198);
            this.txt_ZRPort.Name = "txt_ZRPort";
            this.txt_ZRPort.Size = new System.Drawing.Size(60, 21);
            this.txt_ZRPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "条码系统IP:";
            // 
            // txt_brandIP
            // 
            this.txt_brandIP.Location = new System.Drawing.Point(283, 262);
            this.txt_brandIP.Name = "txt_brandIP";
            this.txt_brandIP.Size = new System.Drawing.Size(174, 21);
            this.txt_brandIP.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "端口";
            // 
            // txt_brandPort
            // 
            this.txt_brandPort.Location = new System.Drawing.Point(518, 262);
            this.txt_brandPort.Name = "txt_brandPort";
            this.txt_brandPort.Size = new System.Drawing.Size(60, 21);
            this.txt_brandPort.TabIndex = 8;
            // 
            // check_isActionBr
            // 
            this.check_isActionBr.AutoSize = true;
            this.check_isActionBr.Location = new System.Drawing.Point(610, 264);
            this.check_isActionBr.Name = "check_isActionBr";
            this.check_isActionBr.Size = new System.Drawing.Size(72, 16);
            this.check_isActionBr.TabIndex = 9;
            this.check_isActionBr.Text = "是否启用";
            this.check_isActionBr.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(335, 489);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(86, 39);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(468, 489);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 39);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // SystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 591);
            this.Controls.Add(this.btn_Cancel);
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
        private System.Windows.Forms.Button btn_Cancel;
    }
}