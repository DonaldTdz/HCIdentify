﻿using System.ComponentModel;

namespace HC.Identify.App
{
    partial class BatchAdjustment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GV_OrderSum = new System.Windows.Forms.DataGridView();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.combo_OrderSum = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GV_OrderSum)).BeginInit();
            this.SuspendLayout();
            // 
            // GV_OrderSum
            // 
            this.GV_OrderSum.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GV_OrderSum.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GV_OrderSum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GV_OrderSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV_OrderSum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.AreaName,
            this.RetailName,
            this.Sequence,
            this.Num,
            this.RIndex});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GV_OrderSum.DefaultCellStyle = dataGridViewCellStyle2;
            this.GV_OrderSum.Location = new System.Drawing.Point(12, 60);
            this.GV_OrderSum.Name = "GV_OrderSum";
            this.GV_OrderSum.RowTemplate.Height = 23;
            this.GV_OrderSum.Size = new System.Drawing.Size(960, 531);
            this.GV_OrderSum.TabIndex = 0;
            // 
            // btn_up
            // 
            this.btn_up.Location = new System.Drawing.Point(13, 12);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(75, 33);
            this.btn_up.TabIndex = 1;
            this.btn_up.Text = "向上";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_down
            // 
            this.btn_down.Location = new System.Drawing.Point(126, 12);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(75, 32);
            this.btn_down.TabIndex = 2;
            this.btn_down.Text = "向下";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // combo_OrderSum
            // 
            this.combo_OrderSum.FormattingEnabled = true;
            this.combo_OrderSum.Location = new System.Drawing.Point(254, 24);
            this.combo_OrderSum.Name = "combo_OrderSum";
            this.combo_OrderSum.Size = new System.Drawing.Size(205, 20);
            this.combo_OrderSum.TabIndex = 3;
            this.combo_OrderSum.SelectionChangeCommitted += new System.EventHandler(this.combo_OrderSum_SelectionChangeCommitted);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(883, 13);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 32);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Visible = false;
            // 
            // AreaName
            // 
            this.AreaName.DataPropertyName = "AreaName";
            this.AreaName.HeaderText = "区域";
            this.AreaName.Name = "AreaName";
            this.AreaName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RetailName
            // 
            this.RetailName.DataPropertyName = "RetailerName";
            this.RetailName.HeaderText = "零售户";
            this.RetailName.Name = "RetailName";
            this.RetailName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sequence
            // 
            this.Sequence.DataPropertyName = "Sequence";
            this.Sequence.HeaderText = "订单顺序";
            this.Sequence.Name = "Sequence";
            this.Sequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Num
            // 
            this.Num.DataPropertyName = "Num";
            this.Num.HeaderText = "数量";
            this.Num.Name = "Num";
            this.Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RIndex
            // 
            this.RIndex.DataPropertyName = "RIndex";
            this.RIndex.HeaderText = "序号";
            this.RIndex.Name = "RIndex";
            this.RIndex.Visible = false;
            // 
            // BatchAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 591);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.combo_OrderSum);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.GV_OrderSum);
            this.Name = "BatchAdjustment";
            this.Text = "批次调整";
            ((System.ComponentModel.ISupportInitialize)(this.GV_OrderSum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GV_OrderSum;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.ComboBox combo_OrderSum;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn RIndex;
    }
}