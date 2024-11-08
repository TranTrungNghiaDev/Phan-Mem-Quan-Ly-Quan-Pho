﻿namespace QuanLyQuanPho
{
    partial class fTableManager
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
            menuStrip1 = new MenuStrip();
            adminToolStripMenuItem = new ToolStripMenuItem();
            thôngTinTàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem1 = new ToolStripMenuItem();
            panel2 = new Panel();
            lsvBill = new ListView();
            panel3 = new Panel();
            cbxSwitchTable = new ComboBox();
            btnSwitchTable = new Button();
            nmDiscount = new NumericUpDown();
            btnDiscount = new Button();
            btnCheckOut = new Button();
            panel4 = new Panel();
            nmQuantityFood = new NumericUpDown();
            btnAddFood = new Button();
            cbxFood = new ComboBox();
            cbxCategoryFood = new ComboBox();
            flpTable = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmDiscount).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmQuantityFood).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, thôngTinTàiKhoảnToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(801, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(55, 20);
            adminToolStripMenuItem.Text = "Admin";
            adminToolStripMenuItem.Click += adminToolStripMenuItem_Click;
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngXuấtToolStripMenuItem, đăngXuấtToolStripMenuItem1 });
            thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            thôngTinTàiKhoảnToolStripMenuItem.Size = new Size(122, 20);
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(170, 22);
            đăngXuấtToolStripMenuItem.Text = "Thông tin cá nhân";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem1
            // 
            đăngXuấtToolStripMenuItem1.Name = "đăngXuấtToolStripMenuItem1";
            đăngXuấtToolStripMenuItem1.Size = new Size(170, 22);
            đăngXuấtToolStripMenuItem1.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem1.Click += đăngXuấtToolStripMenuItem1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(lsvBill);
            panel2.Location = new Point(411, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(374, 264);
            panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            lsvBill.Location = new Point(3, 3);
            lsvBill.Name = "lsvBill";
            lsvBill.Size = new Size(371, 249);
            lsvBill.TabIndex = 0;
            lsvBill.UseCompatibleStateImageBehavior = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(cbxSwitchTable);
            panel3.Controls.Add(btnSwitchTable);
            panel3.Controls.Add(nmDiscount);
            panel3.Controls.Add(btnDiscount);
            panel3.Controls.Add(btnCheckOut);
            panel3.Location = new Point(411, 380);
            panel3.Name = "panel3";
            panel3.Size = new Size(374, 57);
            panel3.TabIndex = 3;
            // 
            // cbxSwitchTable
            // 
            cbxSwitchTable.FormattingEnabled = true;
            cbxSwitchTable.Location = new Point(5, 31);
            cbxSwitchTable.Name = "cbxSwitchTable";
            cbxSwitchTable.Size = new Size(83, 23);
            cbxSwitchTable.TabIndex = 7;
            // 
            // btnSwitchTable
            // 
            btnSwitchTable.Location = new Point(3, 3);
            btnSwitchTable.Name = "btnSwitchTable";
            btnSwitchTable.Size = new Size(85, 25);
            btnSwitchTable.TabIndex = 6;
            btnSwitchTable.Text = "Chuyển bàn";
            btnSwitchTable.UseVisualStyleBackColor = true;
            // 
            // nmDiscount
            // 
            nmDiscount.Location = new Point(144, 30);
            nmDiscount.Name = "nmDiscount";
            nmDiscount.Size = new Size(85, 23);
            nmDiscount.TabIndex = 5;
            nmDiscount.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDiscount
            // 
            btnDiscount.Location = new Point(144, 3);
            btnDiscount.Name = "btnDiscount";
            btnDiscount.Size = new Size(85, 25);
            btnDiscount.TabIndex = 4;
            btnDiscount.Text = "Giảm giá";
            btnDiscount.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(286, 3);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(85, 52);
            btnCheckOut.TabIndex = 3;
            btnCheckOut.Text = "Thanh toán";
            btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(nmQuantityFood);
            panel4.Controls.Add(btnAddFood);
            panel4.Controls.Add(cbxFood);
            panel4.Controls.Add(cbxCategoryFood);
            panel4.Location = new Point(414, 34);
            panel4.Name = "panel4";
            panel4.Size = new Size(371, 70);
            panel4.TabIndex = 4;
            // 
            // nmQuantityFood
            // 
            nmQuantityFood.Location = new Point(323, 31);
            nmQuantityFood.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nmQuantityFood.Name = "nmQuantityFood";
            nmQuantityFood.Size = new Size(45, 23);
            nmQuantityFood.TabIndex = 3;
            nmQuantityFood.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(232, 12);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(85, 52);
            btnAddFood.TabIndex = 2;
            btnAddFood.Text = "Thêm món";
            btnAddFood.UseVisualStyleBackColor = true;
            // 
            // cbxFood
            // 
            cbxFood.FormattingEnabled = true;
            cbxFood.Location = new Point(13, 41);
            cbxFood.Name = "cbxFood";
            cbxFood.Size = new Size(213, 23);
            cbxFood.TabIndex = 1;
            // 
            // cbxCategoryFood
            // 
            cbxCategoryFood.FormattingEnabled = true;
            cbxCategoryFood.Location = new Point(13, 12);
            cbxCategoryFood.Name = "cbxCategoryFood";
            cbxCategoryFood.Size = new Size(213, 23);
            cbxCategoryFood.TabIndex = 0;
            // 
            // flpTable
            // 
            flpTable.Location = new Point(17, 34);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(388, 403);
            flpTable.TabIndex = 5;
            // 
            // fTableManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 449);
            Controls.Add(flpTable);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "fTableManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý quán phở";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nmDiscount).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nmQuantityFood).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem1;
        private Panel panel2;
        private ListView lsvBill;
        private Panel panel3;
        private Panel panel4;
        private ComboBox cbxCategoryFood;
        private NumericUpDown nmQuantityFood;
        private Button btnAddFood;
        private ComboBox cbxFood;
        private Button btnCheckOut;
        private FlowLayoutPanel flpTable;
        private NumericUpDown nmDiscount;
        private Button btnDiscount;
        private ComboBox cbxSwitchTable;
        private Button btnSwitchTable;
    }
}