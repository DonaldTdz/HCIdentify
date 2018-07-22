namespace HC.Identify.App
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolFrameStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolFrameStatusVal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolRunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolRunStatusVal = new System.Windows.Forms.ToolStripStatusLabel();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统配置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.视觉配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作手册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(45, 36);
            this.toolStripButton1.Text = "工作台";
            this.toolStripButton1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(56, 36);
            this.toolStripButton2.Text = "批次调整";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(56, 36);
            this.toolStripButton3.Text = "模板维护";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(34, 36);
            this.toolStripButton4.Text = "异常";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFrameStatus,
            this.toolFrameStatusVal,
            this.toolStripStatusLabel1,
            this.toolRunStatus,
            this.toolRunStatusVal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolFrameStatus
            // 
            this.toolFrameStatus.Name = "toolFrameStatus";
            this.toolFrameStatus.Size = new System.Drawing.Size(68, 17);
            this.toolFrameStatus.Text = "相机未连接";
            // 
            // toolFrameStatusVal
            // 
            this.toolFrameStatusVal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFrameStatusVal.Image = ((System.Drawing.Image)(resources.GetObject("toolFrameStatusVal.Image")));
            this.toolFrameStatusVal.Name = "toolFrameStatusVal";
            this.toolFrameStatusVal.Size = new System.Drawing.Size(16, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(144, 17);
            this.toolStripStatusLabel1.Text = "                                  ";
            // 
            // toolRunStatus
            // 
            this.toolRunStatus.Name = "toolRunStatus";
            this.toolRunStatus.Size = new System.Drawing.Size(68, 17);
            this.toolRunStatus.Text = "运行状态：";
            // 
            // toolRunStatusVal
            // 
            this.toolRunStatusVal.ForeColor = System.Drawing.Color.Gray;
            this.toolRunStatusVal.Image = ((System.Drawing.Image)(resources.GetObject("toolRunStatusVal.Image")));
            this.toolRunStatusVal.Name = "toolRunStatusVal";
            this.toolRunStatusVal.Size = new System.Drawing.Size(60, 17);
            this.toolRunStatusVal.Text = "未开始";
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统配置ToolStripMenuItem,
            this.系统配置ToolStripMenuItem1,
            this.视觉配置ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.系统管理ToolStripMenuItem.Text = "系统";
            // 
            // 系统配置ToolStripMenuItem
            // 
            this.系统配置ToolStripMenuItem.Name = "系统配置ToolStripMenuItem";
            this.系统配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.系统配置ToolStripMenuItem.Text = "系统用户";
            // 
            // 系统配置ToolStripMenuItem1
            // 
            this.系统配置ToolStripMenuItem1.Name = "系统配置ToolStripMenuItem1";
            this.系统配置ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.系统配置ToolStripMenuItem1.Text = "系统配置";
            // 
            // 视觉配置ToolStripMenuItem
            // 
            this.视觉配置ToolStripMenuItem.Name = "视觉配置ToolStripMenuItem";
            this.视觉配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.视觉配置ToolStripMenuItem.Text = "视觉配置";
            this.视觉配置ToolStripMenuItem.Click += new System.EventHandler(this.视觉配置ToolStripMenuItem_Click);
            // 
            // 数据查询ToolStripMenuItem
            // 
            this.数据查询ToolStripMenuItem.Name = "数据查询ToolStripMenuItem";
            this.数据查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据查询ToolStripMenuItem.Text = "数据查询";
            // 
            // 切换用户ToolStripMenuItem
            // 
            this.切换用户ToolStripMenuItem.Name = "切换用户ToolStripMenuItem";
            this.切换用户ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.切换用户ToolStripMenuItem.Text = "切换用户";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作手册ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 操作手册ToolStripMenuItem
            // 
            this.操作手册ToolStripMenuItem.Name = "操作手册ToolStripMenuItem";
            this.操作手册ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.操作手册ToolStripMenuItem.Text = "操作手册";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.关于ToolStripMenuItem.Text = "关于本系统";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统管理ToolStripMenuItem,
            this.数据查询ToolStripMenuItem,
            this.切换用户ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 681);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视觉识别控制系统";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统配置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 视觉配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 切换用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作手册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolFrameStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolFrameStatusVal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolRunStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolRunStatusVal;
    }
}

