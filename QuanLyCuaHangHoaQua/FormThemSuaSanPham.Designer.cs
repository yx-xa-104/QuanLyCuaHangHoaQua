namespace QuanLyCuaHangHoaQua
{
    partial class FormThemSuaSanPham
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
            splitContainer1 = new SplitContainer();
            dgvDanhSachDieuHuong = new DataGridView();
            groupBox1 = new GroupBox();
            btnDong = new Button();
            numSoLuongTon = new NumericUpDown();
            label1 = new Label();
            txtMoTa = new TextBox();
            lbMoTa = new Label();
            txtTenHoaQua = new TextBox();
            picHinhAnh = new PictureBox();
            lbCharCount = new Label();
            btnLuu = new Button();
            lbDonViTinh = new Label();
            btnChonAnh = new Button();
            cbDonViTinh = new ComboBox();
            lbXuatXu = new Label();
            txtXuatXu = new TextBox();
            lbDonGia = new Label();
            numDonGia = new NumericUpDown();
            lbTen = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachDieuHuong).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuongTon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDanhSachDieuHuong);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1029, 530);
            splitContainer1.SplitterDistance = 497;
            splitContainer1.TabIndex = 0;
            // 
            // dgvDanhSachDieuHuong
            // 
            dgvDanhSachDieuHuong.AllowUserToAddRows = false;
            dgvDanhSachDieuHuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachDieuHuong.BackgroundColor = SystemColors.Control;
            dgvDanhSachDieuHuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachDieuHuong.Dock = DockStyle.Fill;
            dgvDanhSachDieuHuong.Location = new Point(0, 0);
            dgvDanhSachDieuHuong.Name = "dgvDanhSachDieuHuong";
            dgvDanhSachDieuHuong.ReadOnly = true;
            dgvDanhSachDieuHuong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSachDieuHuong.Size = new Size(497, 530);
            dgvDanhSachDieuHuong.TabIndex = 0;
            dgvDanhSachDieuHuong.CellClick += dgvDanhSachDieuHuong_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDong);
            groupBox1.Controls.Add(numSoLuongTon);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(lbMoTa);
            groupBox1.Controls.Add(txtTenHoaQua);
            groupBox1.Controls.Add(picHinhAnh);
            groupBox1.Controls.Add(lbCharCount);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(lbDonViTinh);
            groupBox1.Controls.Add(btnChonAnh);
            groupBox1.Controls.Add(cbDonViTinh);
            groupBox1.Controls.Add(lbXuatXu);
            groupBox1.Controls.Add(txtXuatXu);
            groupBox1.Controls.Add(lbDonGia);
            groupBox1.Controls.Add(numDonGia);
            groupBox1.Controls.Add(lbTen);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(528, 528);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thêm sản phẩm mới";
            // 
            // btnDong
            // 
            btnDong.BackColor = Color.Red;
            btnDong.Cursor = Cursors.No;
            btnDong.ForeColor = SystemColors.ButtonFace;
            btnDong.Location = new Point(482, 494);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(34, 34);
            btnDong.TabIndex = 16;
            btnDong.Text = "X";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // numSoLuongTon
            // 
            numSoLuongTon.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numSoLuongTon.Location = new Point(396, 75);
            numSoLuongTon.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numSoLuongTon.Name = "numSoLuongTon";
            numSoLuongTon.Size = new Size(101, 29);
            numSoLuongTon.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(396, 51);
            label1.Name = "label1";
            label1.Size = new Size(109, 21);
            label1.TabIndex = 14;
            label1.Text = "Số lượng tồn:";
            // 
            // txtMoTa
            // 
            txtMoTa.BorderStyle = BorderStyle.FixedSingle;
            txtMoTa.Location = new Point(348, 242);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(168, 167);
            txtMoTa.TabIndex = 13;
            // 
            // lbMoTa
            // 
            lbMoTa.AutoSize = true;
            lbMoTa.Location = new Point(348, 214);
            lbMoTa.Name = "lbMoTa";
            lbMoTa.Size = new Size(69, 25);
            lbMoTa.TabIndex = 12;
            lbMoTa.Text = "Mô tả:";
            // 
            // txtTenHoaQua
            // 
            txtTenHoaQua.BorderStyle = BorderStyle.FixedSingle;
            txtTenHoaQua.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenHoaQua.Location = new Point(6, 74);
            txtTenHoaQua.Name = "txtTenHoaQua";
            txtTenHoaQua.Size = new Size(101, 29);
            txtTenHoaQua.TabIndex = 1;
            // 
            // picHinhAnh
            // 
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.Location = new Point(6, 150);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(320, 259);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.TabIndex = 8;
            picHinhAnh.TabStop = false;
            // 
            // lbCharCount
            // 
            lbCharCount.AutoSize = true;
            lbCharCount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbCharCount.Location = new Point(49, 106);
            lbCharCount.Name = "lbCharCount";
            lbCharCount.Size = new Size(55, 21);
            lbCharCount.TabIndex = 11;
            lbCharCount.Text = "0 kí tự";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(251, 415);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 32);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // lbDonViTinh
            // 
            lbDonViTinh.AutoSize = true;
            lbDonViTinh.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDonViTinh.Location = new Point(136, 51);
            lbDonViTinh.Name = "lbDonViTinh";
            lbDonViTinh.Size = new Size(92, 21);
            lbDonViTinh.TabIndex = 2;
            lbDonViTinh.Text = "Đơn vị tính:";
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(107, 415);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(138, 32);
            btnChonAnh.TabIndex = 9;
            btnChonAnh.Text = "Chọn ảnh ...";
            btnChonAnh.UseVisualStyleBackColor = true;
            // 
            // cbDonViTinh
            // 
            cbDonViTinh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbDonViTinh.FormattingEnabled = true;
            cbDonViTinh.Items.AddRange(new object[] { "Kg", "Quả", "Bó", "Nải" });
            cbDonViTinh.Location = new Point(136, 74);
            cbDonViTinh.Name = "cbDonViTinh";
            cbDonViTinh.Size = new Size(101, 29);
            cbDonViTinh.TabIndex = 3;
            // 
            // lbXuatXu
            // 
            lbXuatXu.AutoSize = true;
            lbXuatXu.Location = new Point(348, 150);
            lbXuatXu.Name = "lbXuatXu";
            lbXuatXu.Size = new Size(88, 25);
            lbXuatXu.TabIndex = 6;
            lbXuatXu.Text = "Xuất Xứ:";
            // 
            // txtXuatXu
            // 
            txtXuatXu.BorderStyle = BorderStyle.FixedSingle;
            txtXuatXu.Location = new Point(348, 178);
            txtXuatXu.Name = "txtXuatXu";
            txtXuatXu.Size = new Size(149, 33);
            txtXuatXu.TabIndex = 7;
            // 
            // lbDonGia
            // 
            lbDonGia.AutoSize = true;
            lbDonGia.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDonGia.Location = new Point(266, 51);
            lbDonGia.Name = "lbDonGia";
            lbDonGia.Size = new Size(117, 21);
            lbDonGia.TabIndex = 4;
            lbDonGia.Text = "Đơn giá (VNĐ):";
            // 
            // numDonGia
            // 
            numDonGia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numDonGia.Location = new Point(266, 74);
            numDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(101, 29);
            numDonGia.TabIndex = 5;
            numDonGia.ThousandsSeparator = true;
            // 
            // lbTen
            // 
            lbTen.AutoSize = true;
            lbTen.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTen.Location = new Point(6, 51);
            lbTen.Name = "lbTen";
            lbTen.Size = new Size(101, 21);
            lbTen.TabIndex = 0;
            lbTen.Text = "Tên hoa quả:";
            // 
            // FormThemSuaSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 530);
            Controls.Add(splitContainer1);
            Name = "FormThemSuaSanPham";
            Text = "FormThemSuaSanPham";
            Load += FormThemSuaSanPham_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachDieuHuong).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuongTon).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvDanhSachDieuHuong;
        private GroupBox groupBox1;
        private NumericUpDown numSoLuongTon;
        private Label label1;
        private TextBox txtMoTa;
        private Label lbMoTa;
        private TextBox txtTenHoaQua;
        private PictureBox picHinhAnh;
        private Label lbCharCount;
        private Button btnLuu;
        private Label lbDonViTinh;
        private Button btnChonAnh;
        private ComboBox cbDonViTinh;
        private Label lbXuatXu;
        private TextBox txtXuatXu;
        private Label lbDonGia;
        private NumericUpDown numDonGia;
        private Label lbTen;
        private Button btnDong;
    }
}