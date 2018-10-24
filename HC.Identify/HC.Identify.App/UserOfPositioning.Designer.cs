namespace HC.Identify.App
{
    partial class UserOfPositioning
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
            this.button1 = new System.Windows.Forms.Button();
            this.labRetailerName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labCode = new System.Windows.Forms.Label();
            this.labOrderNum = new System.Windows.Forms.Label();
            this.labIndex = new System.Windows.Forms.Label();
            this.labNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSerNum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "零售户名：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定定位";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labRetailerName
            // 
            this.labRetailerName.AutoSize = true;
            this.labRetailerName.Location = new System.Drawing.Point(71, 34);
            this.labRetailerName.Name = "labRetailerName";
            this.labRetailerName.Size = new System.Drawing.Size(53, 12);
            this.labRetailerName.TabIndex = 3;
            this.labRetailerName.Text = "某某超市";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "零售户编码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "订单号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "顺序号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "订单量：";
            // 
            // labCode
            // 
            this.labCode.AutoSize = true;
            this.labCode.Location = new System.Drawing.Point(342, 34);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(23, 12);
            this.labCode.TabIndex = 8;
            this.labCode.Text = "123";
            // 
            // labOrderNum
            // 
            this.labOrderNum.AutoSize = true;
            this.labOrderNum.Location = new System.Drawing.Point(73, 64);
            this.labOrderNum.Name = "labOrderNum";
            this.labOrderNum.Size = new System.Drawing.Size(23, 12);
            this.labOrderNum.TabIndex = 9;
            this.labOrderNum.Text = "123";
            // 
            // labIndex
            // 
            this.labIndex.AutoSize = true;
            this.labIndex.Location = new System.Drawing.Point(344, 63);
            this.labIndex.Name = "labIndex";
            this.labIndex.Size = new System.Drawing.Size(17, 12);
            this.labIndex.TabIndex = 10;
            this.labIndex.Text = "12";
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Location = new System.Drawing.Point(73, 99);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(11, 12);
            this.labNum.TabIndex = 11;
            this.labNum.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "定位烟序号：";
            // 
            // txtSerNum
            // 
            this.txtSerNum.Location = new System.Drawing.Point(188, 131);
            this.txtSerNum.Name = "txtSerNum";
            this.txtSerNum.Size = new System.Drawing.Size(100, 21);
            this.txtSerNum.TabIndex = 13;
            this.txtSerNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // UserOfPositioning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 241);
            this.Controls.Add(this.txtSerNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labNum);
            this.Controls.Add(this.labIndex);
            this.Controls.Add(this.labOrderNum);
            this.Controls.Add(this.labCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labRetailerName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "UserOfPositioning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "零售户定位";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labRetailerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labCode;
        private System.Windows.Forms.Label labOrderNum;
        private System.Windows.Forms.Label labIndex;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSerNum;
    }
}