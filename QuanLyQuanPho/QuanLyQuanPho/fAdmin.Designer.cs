namespace QuanLyQuanPho
{
    partial class fAdmin
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
            tabControl1 = new TabControl();
            tpBill = new TabPage();
            panel2 = new Panel();
            btnViewBill = new Button();
            dtpEndDate = new DateTimePicker();
            dtpFromDate = new DateTimePicker();
            panel1 = new Panel();
            dgvBill = new DataGridView();
            tpFood = new TabPage();
            panel6 = new Panel();
            txbSearchFood = new TextBox();
            btnSearchFood = new Button();
            panel5 = new Panel();
            btnViewFood = new Button();
            btnEditFood = new Button();
            btnDeleteFood = new Button();
            btnAddFood = new Button();
            panel4 = new Panel();
            panel9 = new Panel();
            nudFoodPrice = new NumericUpDown();
            label3 = new Label();
            panel8 = new Panel();
            txbFoodName = new TextBox();
            label2 = new Label();
            panel10 = new Panel();
            cbxFoodCategory = new ComboBox();
            label4 = new Label();
            panel7 = new Panel();
            txbFoodId = new TextBox();
            label1 = new Label();
            panel3 = new Panel();
            dgvFood = new DataGridView();
            tpCategory = new TabPage();
            panel12 = new Panel();
            btnCategoryView = new Button();
            btnEditCategory = new Button();
            btnDeleteCategory = new Button();
            btnAddCategory = new Button();
            panel13 = new Panel();
            panel15 = new Panel();
            txbCategoryName = new TextBox();
            label6 = new Label();
            panel17 = new Panel();
            txbCategoryId = new TextBox();
            label8 = new Label();
            panel18 = new Panel();
            dgvCategory = new DataGridView();
            tpFoodTable = new TabPage();
            panel11 = new Panel();
            btnViewFoodTable = new Button();
            btnEditFoodTable = new Button();
            btnDeteleFoodTable = new Button();
            btnAddFoodTable = new Button();
            panel14 = new Panel();
            panel21 = new Panel();
            cbxFoodTableStatus = new ComboBox();
            label9 = new Label();
            panel16 = new Panel();
            txbFoodTableName = new TextBox();
            label5 = new Label();
            panel19 = new Panel();
            txbFoodTableId = new TextBox();
            label7 = new Label();
            panel20 = new Panel();
            dgwFoodTable = new DataGridView();
            tpAccount = new TabPage();
            panel23 = new Panel();
            btnViewAccount = new Button();
            btnEditAccount = new Button();
            btnDeleteAccount = new Button();
            btnAddAccount = new Button();
            panel24 = new Panel();
            btnResetPassword = new Button();
            panel26 = new Panel();
            txbDisplayNameAccount = new TextBox();
            label11 = new Label();
            panel27 = new Panel();
            cbxAccountType = new ComboBox();
            label12 = new Label();
            panel28 = new Panel();
            txbUsserName = new TextBox();
            label13 = new Label();
            panel29 = new Panel();
            dgvAccount = new DataGridView();
            tabControl1.SuspendLayout();
            tpBill.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBill).BeginInit();
            tpFood.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFoodPrice).BeginInit();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFood).BeginInit();
            tpCategory.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            panel15.SuspendLayout();
            panel17.SuspendLayout();
            panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            tpFoodTable.SuspendLayout();
            panel11.SuspendLayout();
            panel14.SuspendLayout();
            panel21.SuspendLayout();
            panel16.SuspendLayout();
            panel19.SuspendLayout();
            panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwFoodTable).BeginInit();
            tpAccount.SuspendLayout();
            panel23.SuspendLayout();
            panel24.SuspendLayout();
            panel26.SuspendLayout();
            panel27.SuspendLayout();
            panel28.SuspendLayout();
            panel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccount).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpBill);
            tabControl1.Controls.Add(tpFood);
            tabControl1.Controls.Add(tpCategory);
            tabControl1.Controls.Add(tpFoodTable);
            tabControl1.Controls.Add(tpAccount);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 0;
            // 
            // tpBill
            // 
            tpBill.Controls.Add(panel2);
            tpBill.Controls.Add(panel1);
            tpBill.Location = new Point(4, 24);
            tpBill.Name = "tpBill";
            tpBill.Padding = new Padding(3);
            tpBill.Size = new Size(768, 398);
            tpBill.TabIndex = 0;
            tpBill.Text = "Doanh thu";
            tpBill.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnViewBill);
            panel2.Controls.Add(dtpEndDate);
            panel2.Controls.Add(dtpFromDate);
            panel2.Location = new Point(6, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(756, 31);
            panel2.TabIndex = 1;
            // 
            // btnViewBill
            // 
            btnViewBill.Location = new Point(333, 5);
            btnViewBill.Name = "btnViewBill";
            btnViewBill.Size = new Size(75, 23);
            btnViewBill.TabIndex = 2;
            btnViewBill.Text = "Thống kê";
            btnViewBill.UseVisualStyleBackColor = true;
            btnViewBill.Click += btnViewBill_Click;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(553, 3);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Location = new Point(3, 3);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(200, 23);
            dtpFromDate.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvBill);
            panel1.Location = new Point(6, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(756, 349);
            panel1.TabIndex = 0;
            // 
            // dgvBill
            // 
            dgvBill.AllowUserToAddRows = false;
            dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBill.Location = new Point(-1, 0);
            dgvBill.Name = "dgvBill";
            dgvBill.Size = new Size(754, 346);
            dgvBill.TabIndex = 0;
            // 
            // tpFood
            // 
            tpFood.Controls.Add(panel6);
            tpFood.Controls.Add(panel5);
            tpFood.Controls.Add(panel4);
            tpFood.Controls.Add(panel3);
            tpFood.Location = new Point(4, 24);
            tpFood.Name = "tpFood";
            tpFood.Padding = new Padding(3);
            tpFood.Size = new Size(768, 398);
            tpFood.TabIndex = 1;
            tpFood.Text = "Thức ăn";
            tpFood.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Controls.Add(txbSearchFood);
            panel6.Controls.Add(btnSearchFood);
            panel6.Location = new Point(394, 6);
            panel6.Name = "panel6";
            panel6.Size = new Size(368, 58);
            panel6.TabIndex = 2;
            // 
            // txbSearchFood
            // 
            txbSearchFood.Location = new Point(3, 19);
            txbSearchFood.Name = "txbSearchFood";
            txbSearchFood.Size = new Size(268, 23);
            txbSearchFood.TabIndex = 5;
            // 
            // btnSearchFood
            // 
            btnSearchFood.Location = new Point(277, 3);
            btnSearchFood.Name = "btnSearchFood";
            btnSearchFood.Size = new Size(88, 52);
            btnSearchFood.TabIndex = 4;
            btnSearchFood.Text = "Tìm";
            btnSearchFood.UseVisualStyleBackColor = true;
            btnSearchFood.Click += btnSearchFood_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnViewFood);
            panel5.Controls.Add(btnEditFood);
            panel5.Controls.Add(btnDeleteFood);
            panel5.Controls.Add(btnAddFood);
            panel5.Location = new Point(6, 6);
            panel5.Name = "panel5";
            panel5.Size = new Size(382, 58);
            panel5.TabIndex = 1;
            // 
            // btnViewFood
            // 
            btnViewFood.Location = new Point(291, 3);
            btnViewFood.Name = "btnViewFood";
            btnViewFood.Size = new Size(88, 52);
            btnViewFood.TabIndex = 3;
            btnViewFood.Text = "Xem";
            btnViewFood.UseVisualStyleBackColor = true;
            btnViewFood.Click += btnViewFood_Click;
            // 
            // btnEditFood
            // 
            btnEditFood.Location = new Point(197, 3);
            btnEditFood.Name = "btnEditFood";
            btnEditFood.Size = new Size(88, 52);
            btnEditFood.TabIndex = 2;
            btnEditFood.Text = "Sửa";
            btnEditFood.UseVisualStyleBackColor = true;
            btnEditFood.Click += btnEditFood_Click;
            // 
            // btnDeleteFood
            // 
            btnDeleteFood.Location = new Point(97, 3);
            btnDeleteFood.Name = "btnDeleteFood";
            btnDeleteFood.Size = new Size(88, 52);
            btnDeleteFood.TabIndex = 1;
            btnDeleteFood.Text = "Xóa";
            btnDeleteFood.UseVisualStyleBackColor = true;
            btnDeleteFood.Click += btnDeleteFood_Click;
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(3, 3);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(88, 52);
            btnAddFood.TabIndex = 0;
            btnAddFood.Text = "Thêm";
            btnAddFood.UseVisualStyleBackColor = true;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel9);
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(panel10);
            panel4.Controls.Add(panel7);
            panel4.Location = new Point(394, 70);
            panel4.Name = "panel4";
            panel4.Size = new Size(368, 322);
            panel4.TabIndex = 1;
            // 
            // panel9
            // 
            panel9.Controls.Add(nudFoodPrice);
            panel9.Controls.Add(label3);
            panel9.Location = new Point(3, 129);
            panel9.Name = "panel9";
            panel9.Size = new Size(362, 36);
            panel9.TabIndex = 4;
            // 
            // nudFoodPrice
            // 
            nudFoodPrice.Location = new Point(127, 8);
            nudFoodPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudFoodPrice.Name = "nudFoodPrice";
            nudFoodPrice.Size = new Size(232, 23);
            nudFoodPrice.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 7);
            label3.Name = "label3";
            label3.Size = new Size(44, 19);
            label3.TabIndex = 0;
            label3.Text = "Giá :";
            // 
            // panel8
            // 
            panel8.Controls.Add(txbFoodName);
            panel8.Controls.Add(label2);
            panel8.Location = new Point(3, 45);
            panel8.Name = "panel8";
            panel8.Size = new Size(362, 36);
            panel8.TabIndex = 2;
            // 
            // txbFoodName
            // 
            txbFoodName.Location = new Point(123, 7);
            txbFoodName.Name = "txbFoodName";
            txbFoodName.Size = new Size(236, 23);
            txbFoodName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 11);
            label2.Name = "label2";
            label2.Size = new Size(86, 19);
            label2.TabIndex = 0;
            label2.Text = "Tên món :";
            // 
            // panel10
            // 
            panel10.Controls.Add(cbxFoodCategory);
            panel10.Controls.Add(label4);
            panel10.Location = new Point(3, 87);
            panel10.Name = "panel10";
            panel10.Size = new Size(362, 36);
            panel10.TabIndex = 3;
            // 
            // cbxFoodCategory
            // 
            cbxFoodCategory.FormattingEnabled = true;
            cbxFoodCategory.Location = new Point(123, 7);
            cbxFoodCategory.Name = "cbxFoodCategory";
            cbxFoodCategory.Size = new Size(236, 23);
            cbxFoodCategory.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 7);
            label4.Name = "label4";
            label4.Size = new Size(107, 19);
            label4.TabIndex = 0;
            label4.Text = "Doanh mục :";
            // 
            // panel7
            // 
            panel7.Controls.Add(txbFoodId);
            panel7.Controls.Add(label1);
            panel7.Location = new Point(3, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(362, 36);
            panel7.TabIndex = 1;
            // 
            // txbFoodId
            // 
            txbFoodId.Location = new Point(123, 7);
            txbFoodId.Name = "txbFoodId";
            txbFoodId.ReadOnly = true;
            txbFoodId.Size = new Size(236, 23);
            txbFoodId.TabIndex = 1;
            txbFoodId.TextChanged += txbFoodId_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 7);
            label1.Name = "label1";
            label1.Size = new Size(33, 19);
            label1.TabIndex = 0;
            label1.Text = "Id :";
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvFood);
            panel3.Location = new Point(6, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(382, 322);
            panel3.TabIndex = 0;
            // 
            // dgvFood
            // 
            dgvFood.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFood.Location = new Point(2, 1);
            dgvFood.Name = "dgvFood";
            dgvFood.Size = new Size(377, 318);
            dgvFood.TabIndex = 0;
            // 
            // tpCategory
            // 
            tpCategory.Controls.Add(panel12);
            tpCategory.Controls.Add(panel13);
            tpCategory.Controls.Add(panel18);
            tpCategory.Location = new Point(4, 24);
            tpCategory.Name = "tpCategory";
            tpCategory.Padding = new Padding(3);
            tpCategory.Size = new Size(768, 398);
            tpCategory.TabIndex = 2;
            tpCategory.Text = "Doanh mục";
            tpCategory.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            panel12.Controls.Add(btnCategoryView);
            panel12.Controls.Add(btnEditCategory);
            panel12.Controls.Add(btnDeleteCategory);
            panel12.Controls.Add(btnAddCategory);
            panel12.Location = new Point(6, 6);
            panel12.Name = "panel12";
            panel12.Size = new Size(382, 58);
            panel12.TabIndex = 4;
            // 
            // btnCategoryView
            // 
            btnCategoryView.Location = new Point(291, 3);
            btnCategoryView.Name = "btnCategoryView";
            btnCategoryView.Size = new Size(88, 52);
            btnCategoryView.TabIndex = 3;
            btnCategoryView.Text = "Xem";
            btnCategoryView.UseVisualStyleBackColor = true;
            // 
            // btnEditCategory
            // 
            btnEditCategory.Location = new Point(197, 3);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new Size(88, 52);
            btnEditCategory.TabIndex = 2;
            btnEditCategory.Text = "Sửa";
            btnEditCategory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(97, 3);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(88, 52);
            btnDeleteCategory.TabIndex = 1;
            btnDeleteCategory.Text = "Xóa";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(3, 3);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(88, 52);
            btnAddCategory.TabIndex = 0;
            btnAddCategory.Text = "Thêm";
            btnAddCategory.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            panel13.Controls.Add(panel15);
            panel13.Controls.Add(panel17);
            panel13.Location = new Point(394, 70);
            panel13.Name = "panel13";
            panel13.Size = new Size(368, 322);
            panel13.TabIndex = 5;
            // 
            // panel15
            // 
            panel15.Controls.Add(txbCategoryName);
            panel15.Controls.Add(label6);
            panel15.Location = new Point(3, 45);
            panel15.Name = "panel15";
            panel15.Size = new Size(362, 36);
            panel15.TabIndex = 2;
            // 
            // txbCategoryName
            // 
            txbCategoryName.Location = new Point(157, 7);
            txbCategoryName.Name = "txbCategoryName";
            txbCategoryName.Size = new Size(202, 23);
            txbCategoryName.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(16, 11);
            label6.Name = "label6";
            label6.Size = new Size(138, 19);
            label6.TabIndex = 0;
            label6.Text = "Tên doanh mục :";
            // 
            // panel17
            // 
            panel17.Controls.Add(txbCategoryId);
            panel17.Controls.Add(label8);
            panel17.Location = new Point(3, 3);
            panel17.Name = "panel17";
            panel17.Size = new Size(362, 36);
            panel17.TabIndex = 1;
            // 
            // txbCategoryId
            // 
            txbCategoryId.Location = new Point(157, 7);
            txbCategoryId.Name = "txbCategoryId";
            txbCategoryId.ReadOnly = true;
            txbCategoryId.Size = new Size(202, 23);
            txbCategoryId.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(16, 7);
            label8.Name = "label8";
            label8.Size = new Size(33, 19);
            label8.TabIndex = 0;
            label8.Text = "Id :";
            // 
            // panel18
            // 
            panel18.Controls.Add(dgvCategory);
            panel18.Location = new Point(6, 70);
            panel18.Name = "panel18";
            panel18.Size = new Size(382, 322);
            panel18.TabIndex = 3;
            // 
            // dgvCategory
            // 
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.Location = new Point(2, 1);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.Size = new Size(377, 318);
            dgvCategory.TabIndex = 0;
            // 
            // tpFoodTable
            // 
            tpFoodTable.Controls.Add(panel11);
            tpFoodTable.Controls.Add(panel14);
            tpFoodTable.Controls.Add(panel20);
            tpFoodTable.Location = new Point(4, 24);
            tpFoodTable.Name = "tpFoodTable";
            tpFoodTable.Padding = new Padding(3);
            tpFoodTable.Size = new Size(768, 398);
            tpFoodTable.TabIndex = 3;
            tpFoodTable.Text = "Bàn ăn";
            tpFoodTable.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            panel11.Controls.Add(btnViewFoodTable);
            panel11.Controls.Add(btnEditFoodTable);
            panel11.Controls.Add(btnDeteleFoodTable);
            panel11.Controls.Add(btnAddFoodTable);
            panel11.Location = new Point(6, 6);
            panel11.Name = "panel11";
            panel11.Size = new Size(382, 58);
            panel11.TabIndex = 7;
            // 
            // btnViewFoodTable
            // 
            btnViewFoodTable.Location = new Point(291, 3);
            btnViewFoodTable.Name = "btnViewFoodTable";
            btnViewFoodTable.Size = new Size(88, 52);
            btnViewFoodTable.TabIndex = 3;
            btnViewFoodTable.Text = "Xem";
            btnViewFoodTable.UseVisualStyleBackColor = true;
            // 
            // btnEditFoodTable
            // 
            btnEditFoodTable.Location = new Point(197, 3);
            btnEditFoodTable.Name = "btnEditFoodTable";
            btnEditFoodTable.Size = new Size(88, 52);
            btnEditFoodTable.TabIndex = 2;
            btnEditFoodTable.Text = "Sửa";
            btnEditFoodTable.UseVisualStyleBackColor = true;
            // 
            // btnDeteleFoodTable
            // 
            btnDeteleFoodTable.Location = new Point(97, 3);
            btnDeteleFoodTable.Name = "btnDeteleFoodTable";
            btnDeteleFoodTable.Size = new Size(88, 52);
            btnDeteleFoodTable.TabIndex = 1;
            btnDeteleFoodTable.Text = "Xóa";
            btnDeteleFoodTable.UseVisualStyleBackColor = true;
            // 
            // btnAddFoodTable
            // 
            btnAddFoodTable.Location = new Point(3, 3);
            btnAddFoodTable.Name = "btnAddFoodTable";
            btnAddFoodTable.Size = new Size(88, 52);
            btnAddFoodTable.TabIndex = 0;
            btnAddFoodTable.Text = "Thêm";
            btnAddFoodTable.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            panel14.Controls.Add(panel21);
            panel14.Controls.Add(panel16);
            panel14.Controls.Add(panel19);
            panel14.Location = new Point(394, 70);
            panel14.Name = "panel14";
            panel14.Size = new Size(368, 322);
            panel14.TabIndex = 8;
            // 
            // panel21
            // 
            panel21.Controls.Add(cbxFoodTableStatus);
            panel21.Controls.Add(label9);
            panel21.Location = new Point(3, 87);
            panel21.Name = "panel21";
            panel21.Size = new Size(362, 36);
            panel21.TabIndex = 3;
            // 
            // cbxFoodTableStatus
            // 
            cbxFoodTableStatus.FormattingEnabled = true;
            cbxFoodTableStatus.Location = new Point(117, 9);
            cbxFoodTableStatus.Name = "cbxFoodTableStatus";
            cbxFoodTableStatus.Size = new Size(242, 23);
            cbxFoodTableStatus.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(16, 11);
            label9.Name = "label9";
            label9.Size = new Size(95, 19);
            label9.TabIndex = 0;
            label9.Text = "Trạng thái :";
            // 
            // panel16
            // 
            panel16.Controls.Add(txbFoodTableName);
            panel16.Controls.Add(label5);
            panel16.Location = new Point(3, 45);
            panel16.Name = "panel16";
            panel16.Size = new Size(362, 36);
            panel16.TabIndex = 2;
            // 
            // txbFoodTableName
            // 
            txbFoodTableName.Location = new Point(116, 7);
            txbFoodTableName.Name = "txbFoodTableName";
            txbFoodTableName.Size = new Size(243, 23);
            txbFoodTableName.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 11);
            label5.Name = "label5";
            label5.Size = new Size(81, 19);
            label5.TabIndex = 0;
            label5.Text = "Tên bàn :";
            // 
            // panel19
            // 
            panel19.Controls.Add(txbFoodTableId);
            panel19.Controls.Add(label7);
            panel19.Location = new Point(3, 3);
            panel19.Name = "panel19";
            panel19.Size = new Size(362, 36);
            panel19.TabIndex = 1;
            // 
            // txbFoodTableId
            // 
            txbFoodTableId.Location = new Point(116, 7);
            txbFoodTableId.Name = "txbFoodTableId";
            txbFoodTableId.ReadOnly = true;
            txbFoodTableId.Size = new Size(243, 23);
            txbFoodTableId.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(16, 7);
            label7.Name = "label7";
            label7.Size = new Size(33, 19);
            label7.TabIndex = 0;
            label7.Text = "Id :";
            // 
            // panel20
            // 
            panel20.Controls.Add(dgwFoodTable);
            panel20.Location = new Point(6, 70);
            panel20.Name = "panel20";
            panel20.Size = new Size(382, 322);
            panel20.TabIndex = 6;
            // 
            // dgwFoodTable
            // 
            dgwFoodTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwFoodTable.Location = new Point(2, 1);
            dgwFoodTable.Name = "dgwFoodTable";
            dgwFoodTable.Size = new Size(377, 318);
            dgwFoodTable.TabIndex = 0;
            // 
            // tpAccount
            // 
            tpAccount.Controls.Add(panel23);
            tpAccount.Controls.Add(panel24);
            tpAccount.Controls.Add(panel29);
            tpAccount.Location = new Point(4, 24);
            tpAccount.Name = "tpAccount";
            tpAccount.Padding = new Padding(3);
            tpAccount.Size = new Size(768, 398);
            tpAccount.TabIndex = 4;
            tpAccount.Text = "Tài khoản";
            tpAccount.UseVisualStyleBackColor = true;
            // 
            // panel23
            // 
            panel23.Controls.Add(btnViewAccount);
            panel23.Controls.Add(btnEditAccount);
            panel23.Controls.Add(btnDeleteAccount);
            panel23.Controls.Add(btnAddAccount);
            panel23.Location = new Point(6, 6);
            panel23.Name = "panel23";
            panel23.Size = new Size(382, 58);
            panel23.TabIndex = 4;
            // 
            // btnViewAccount
            // 
            btnViewAccount.Location = new Point(291, 3);
            btnViewAccount.Name = "btnViewAccount";
            btnViewAccount.Size = new Size(88, 52);
            btnViewAccount.TabIndex = 3;
            btnViewAccount.Text = "Xem";
            btnViewAccount.UseVisualStyleBackColor = true;
            // 
            // btnEditAccount
            // 
            btnEditAccount.Location = new Point(197, 3);
            btnEditAccount.Name = "btnEditAccount";
            btnEditAccount.Size = new Size(88, 52);
            btnEditAccount.TabIndex = 2;
            btnEditAccount.Text = "Sửa";
            btnEditAccount.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.Location = new Point(97, 3);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(88, 52);
            btnDeleteAccount.TabIndex = 1;
            btnDeleteAccount.Text = "Xóa";
            btnDeleteAccount.UseVisualStyleBackColor = true;
            // 
            // btnAddAccount
            // 
            btnAddAccount.Location = new Point(3, 3);
            btnAddAccount.Name = "btnAddAccount";
            btnAddAccount.Size = new Size(88, 52);
            btnAddAccount.TabIndex = 0;
            btnAddAccount.Text = "Thêm";
            btnAddAccount.UseVisualStyleBackColor = true;
            // 
            // panel24
            // 
            panel24.Controls.Add(btnResetPassword);
            panel24.Controls.Add(panel26);
            panel24.Controls.Add(panel27);
            panel24.Controls.Add(panel28);
            panel24.Location = new Point(394, 70);
            panel24.Name = "panel24";
            panel24.Size = new Size(368, 322);
            panel24.TabIndex = 5;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(251, 129);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(111, 52);
            btnResetPassword.TabIndex = 4;
            btnResetPassword.Text = "Đặt lại mật khẩu";
            btnResetPassword.UseVisualStyleBackColor = true;
            // 
            // panel26
            // 
            panel26.Controls.Add(txbDisplayNameAccount);
            panel26.Controls.Add(label11);
            panel26.Location = new Point(3, 45);
            panel26.Name = "panel26";
            panel26.Size = new Size(362, 36);
            panel26.TabIndex = 2;
            // 
            // txbDisplayNameAccount
            // 
            txbDisplayNameAccount.Location = new Point(144, 7);
            txbDisplayNameAccount.Name = "txbDisplayNameAccount";
            txbDisplayNameAccount.Size = new Size(215, 23);
            txbDisplayNameAccount.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(16, 11);
            label11.Name = "label11";
            label11.Size = new Size(108, 19);
            label11.TabIndex = 0;
            label11.Text = "Tên hiển thị :";
            // 
            // panel27
            // 
            panel27.Controls.Add(cbxAccountType);
            panel27.Controls.Add(label12);
            panel27.Location = new Point(3, 87);
            panel27.Name = "panel27";
            panel27.Size = new Size(362, 36);
            panel27.TabIndex = 3;
            // 
            // cbxAccountType
            // 
            cbxAccountType.FormattingEnabled = true;
            cbxAccountType.Location = new Point(144, 7);
            cbxAccountType.Name = "cbxAccountType";
            cbxAccountType.Size = new Size(215, 23);
            cbxAccountType.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(16, 7);
            label12.Name = "label12";
            label12.Size = new Size(126, 19);
            label12.TabIndex = 0;
            label12.Text = "Loại tài khoản :";
            // 
            // panel28
            // 
            panel28.Controls.Add(txbUsserName);
            panel28.Controls.Add(label13);
            panel28.Location = new Point(3, 3);
            panel28.Name = "panel28";
            panel28.Size = new Size(362, 36);
            panel28.TabIndex = 1;
            // 
            // txbUsserName
            // 
            txbUsserName.Location = new Point(144, 7);
            txbUsserName.Name = "txbUsserName";
            txbUsserName.ReadOnly = true;
            txbUsserName.Size = new Size(215, 23);
            txbUsserName.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(16, 7);
            label13.Name = "label13";
            label13.Size = new Size(122, 19);
            label13.TabIndex = 0;
            label13.Text = "Tên tài khoản :";
            // 
            // panel29
            // 
            panel29.Controls.Add(dgvAccount);
            panel29.Location = new Point(6, 70);
            panel29.Name = "panel29";
            panel29.Size = new Size(382, 322);
            panel29.TabIndex = 3;
            // 
            // dgvAccount
            // 
            dgvAccount.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccount.Location = new Point(2, 1);
            dgvAccount.Name = "dgvAccount";
            dgvAccount.Size = new Size(377, 318);
            dgvAccount.TabIndex = 0;
            // 
            // fAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "fAdmin";
            Text = "fAdmin";
            tabControl1.ResumeLayout(false);
            tpBill.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBill).EndInit();
            tpFood.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFoodPrice).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFood).EndInit();
            tpCategory.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            tpFoodTable.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel21.ResumeLayout(false);
            panel21.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwFoodTable).EndInit();
            tpAccount.ResumeLayout(false);
            panel23.ResumeLayout(false);
            panel24.ResumeLayout(false);
            panel26.ResumeLayout(false);
            panel26.PerformLayout();
            panel27.ResumeLayout(false);
            panel27.PerformLayout();
            panel28.ResumeLayout(false);
            panel28.PerformLayout();
            panel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccount).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpBill;
        private TabPage tpFood;
        private TabPage tpCategory;
        private TabPage tpFoodTable;
        private TabPage tpAccount;
        private Panel panel2;
        private Button btnViewBill;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpFromDate;
        private Panel panel1;
        private DataGridView dgvBill;
        private Panel panel6;
        private Panel panel5;
        private Button btnSearchFood;
        private Button btnViewFood;
        private Button btnEditFood;
        private Button btnDeleteFood;
        private Button btnAddFood;
        private Panel panel4;
        private Panel panel3;
        private DataGridView dgvFood;
        private Panel panel9;
        private Label label3;
        private Panel panel8;
        private TextBox txbFoodName;
        private Label label2;
        private Panel panel10;
        private Label label4;
        private Panel panel7;
        private TextBox txbFoodId;
        private Label label1;
        private TextBox txbSearchFood;
        private NumericUpDown nudFoodPrice;
        private ComboBox cbxFoodCategory;
        private Panel panel12;
        private Button btnCategoryView;
        private Button btnEditCategory;
        private Button btnDeleteCategory;
        private Button btnAddCategory;
        private Panel panel13;
        private Panel panel15;
        private TextBox txbCategoryName;
        private Label label6;
        private Panel panel17;
        private TextBox txbCategoryId;
        private Label label8;
        private Panel panel18;
        private DataGridView dgvCategory;
        private Panel panel11;
        private Button btnViewFoodTable;
        private Button btnEditFoodTable;
        private Button btnDeteleFoodTable;
        private Button btnAddFoodTable;
        private Panel panel14;
        private Panel panel21;
        private Label label9;
        private Panel panel16;
        private TextBox txbFoodTableName;
        private Label label5;
        private Panel panel19;
        private TextBox txbFoodTableId;
        private Label label7;
        private Panel panel20;
        private DataGridView dgwFoodTable;
        private ComboBox cbxFoodTableStatus;
        private Panel panel23;
        private Button btnViewAccount;
        private Button btnEditAccount;
        private Button btnDeleteAccount;
        private Button btnAddAccount;
        private Panel panel24;
        private Panel panel25;
        private NumericUpDown numericUpDown1;
        private Label label10;
        private Panel panel26;
        private TextBox textBox2;
        private Label label11;
        private Panel panel27;
        private ComboBox comboBox1;
        private Label label12;
        private Panel panel28;
        private TextBox txbUsserName;
        private Label label13;
        private Panel panel29;
        private DataGridView dgvAccount;
        private Button btnResetPassword;
        private TextBox txbDisplayNameAccount;
        private ComboBox cbxAccountType;
    }
}