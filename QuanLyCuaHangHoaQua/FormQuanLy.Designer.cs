﻿namespace QuanLyCuaHangHoaQua
{
    partial class FormQuanLy
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuanLy));
            dgvDanhSachSP = new DataGridView();
            btnThemMoi = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            picPreview = new PictureBox();
            lbPreview = new Label();
            groupBox2 = new GroupBox();
            lbDetailSoLuong = new Label();
            txtDetailMoTa = new TextBox();
            lbDetailMoTa = new Label();
            lbDetailDVT = new Label();
            lbDetailXuatXu = new Label();
            lbDetailGia = new Label();
            lbDetailTenSP = new Label();
            txtTimKiem = new TextBox();
            label1 = new Label();
            btnBaoCao = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDanhSachSP
            // 
            dgvDanhSachSP.AllowUserToAddRows = false;
            dgvDanhSachSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSP.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.MediumSeaGreen;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightGreen;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDanhSachSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDanhSachSP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSP.Location = new Point(67, 94);
            dgvDanhSachSP.Name = "dgvDanhSachSP";
            dgvDanhSachSP.ReadOnly = true;
            dgvDanhSachSP.Size = new Size(558, 445);
            dgvDanhSachSP.TabIndex = 15;
            dgvDanhSachSP.CellClick += dgvDanhSachSP_CellClick;
            dgvDanhSachSP.CellContentClick += dgvDanhSachSP_CellContentClick;
            dgvDanhSachSP.CellFormatting += dgvDanhSachSP_CellFormatting;
            dgvDanhSachSP.SelectionChanged += dgvDanhSachSP_SelectionChanged;
            // 
            // btnThemMoi
            // 
            btnThemMoi.BackColor = Color.DarkSeaGreen;
            btnThemMoi.FlatAppearance.BorderColor = Color.DarkGreen;
            btnThemMoi.FlatAppearance.MouseDownBackColor = Color.DarkGreen;
            btnThemMoi.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
            btnThemMoi.FlatStyle = FlatStyle.Flat;
            btnThemMoi.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnThemMoi.ForeColor = Color.Black;
            btnThemMoi.Image = (Image)resources.GetObject("btnThemMoi.Image");
            btnThemMoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemMoi.Location = new Point(67, 11);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(94, 37);
            btnThemMoi.TabIndex = 16;
            btnThemMoi.Text = "      Thêm";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.DarkSeaGreen;
            btnSua.FlatAppearance.BorderColor = Color.DarkGreen;
            btnSua.FlatAppearance.MouseDownBackColor = Color.DarkGreen;
            btnSua.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnSua.Image = (Image)resources.GetObject("btnSua.Image");
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(216, 12);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 37);
            btnSua.TabIndex = 17;
            btnSua.Text = "    Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.IndianRed;
            btnXoa.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            btnXoa.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 128);
            btnXoa.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnXoa.Image = (Image)resources.GetObject("btnXoa.Image");
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(365, 12);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(102, 37);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "     Trạng thái";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // picPreview
            // 
            picPreview.BackColor = Color.Transparent;
            picPreview.Location = new Point(680, 54);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(320, 180);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 19;
            picPreview.TabStop = false;
            // 
            // lbPreview
            // 
            lbPreview.AutoSize = true;
            lbPreview.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPreview.Location = new Point(749, 17);
            lbPreview.Name = "lbPreview";
            lbPreview.Size = new Size(195, 25);
            lbPreview.TabIndex = 20;
            lbPreview.Text = "Hình ảnh xem trước:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lbDetailSoLuong);
            groupBox2.Controls.Add(txtDetailMoTa);
            groupBox2.Controls.Add(lbDetailMoTa);
            groupBox2.Controls.Add(lbDetailDVT);
            groupBox2.Controls.Add(lbDetailXuatXu);
            groupBox2.Controls.Add(lbDetailGia);
            groupBox2.Controls.Add(lbDetailTenSP);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(680, 240);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(320, 299);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết:";
            // 
            // lbDetailSoLuong
            // 
            lbDetailSoLuong.AutoSize = true;
            lbDetailSoLuong.Location = new Point(6, 145);
            lbDetailSoLuong.Name = "lbDetailSoLuong";
            lbDetailSoLuong.Size = new Size(76, 21);
            lbDetailSoLuong.TabIndex = 6;
            lbDetailSoLuong.Text = "Tồn kho:";
            // 
            // txtDetailMoTa
            // 
            txtDetailMoTa.BackColor = Color.Honeydew;
            txtDetailMoTa.BorderStyle = BorderStyle.FixedSingle;
            txtDetailMoTa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDetailMoTa.Location = new Point(6, 199);
            txtDetailMoTa.Multiline = true;
            txtDetailMoTa.Name = "txtDetailMoTa";
            txtDetailMoTa.ReadOnly = true;
            txtDetailMoTa.ScrollBars = ScrollBars.Vertical;
            txtDetailMoTa.Size = new Size(299, 94);
            txtDetailMoTa.TabIndex = 5;
            txtDetailMoTa.TextChanged += txtMoTa_TextChanged;
            // 
            // lbDetailMoTa
            // 
            lbDetailMoTa.AutoSize = true;
            lbDetailMoTa.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailMoTa.Location = new Point(6, 175);
            lbDetailMoTa.Name = "lbDetailMoTa";
            lbDetailMoTa.Size = new Size(136, 21);
            lbDetailMoTa.TabIndex = 4;
            lbDetailMoTa.Text = "Mô tả sản phẩm:";
            // 
            // lbDetailDVT
            // 
            lbDetailDVT.AutoSize = true;
            lbDetailDVT.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailDVT.Location = new Point(6, 115);
            lbDetailDVT.Name = "lbDetailDVT";
            lbDetailDVT.Size = new Size(99, 21);
            lbDetailDVT.TabIndex = 3;
            lbDetailDVT.Text = "Đơn vị tính:";
            // 
            // lbDetailXuatXu
            // 
            lbDetailXuatXu.AutoSize = true;
            lbDetailXuatXu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailXuatXu.Location = new Point(6, 85);
            lbDetailXuatXu.Name = "lbDetailXuatXu";
            lbDetailXuatXu.Size = new Size(73, 21);
            lbDetailXuatXu.TabIndex = 2;
            lbDetailXuatXu.Text = "Xuất xứ:";
            // 
            // lbDetailGia
            // 
            lbDetailGia.AutoSize = true;
            lbDetailGia.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailGia.Location = new Point(6, 55);
            lbDetailGia.Name = "lbDetailGia";
            lbDetailGia.Size = new Size(39, 21);
            lbDetailGia.TabIndex = 1;
            lbDetailGia.Text = "Giá:";
            // 
            // lbDetailTenSP
            // 
            lbDetailTenSP.AutoSize = true;
            lbDetailTenSP.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailTenSP.Location = new Point(6, 25);
            lbDetailTenSP.Name = "lbDetailTenSP";
            lbDetailTenSP.Size = new Size(174, 21);
            lbDetailTenSP.TabIndex = 0;
            lbDetailTenSP.Text = "Chưa chọn sản phẩm:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.BackColor = Color.White;
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(209, 54);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(416, 33);
            txtTimKiem.TabIndex = 23;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(67, 54);
            label1.Name = "label1";
            label1.Size = new Size(136, 32);
            label1.TabIndex = 24;
            label1.Text = "     Tìm kiếm";
            // 
            // btnBaoCao
            // 
            btnBaoCao.BackColor = Color.DarkSeaGreen;
            btnBaoCao.FlatAppearance.BorderColor = Color.DarkGreen;
            btnBaoCao.FlatAppearance.MouseDownBackColor = Color.DarkGreen;
            btnBaoCao.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
            btnBaoCao.FlatStyle = FlatStyle.Flat;
            btnBaoCao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnBaoCao.Image = (Image)resources.GetObject("btnBaoCao.Image");
            btnBaoCao.ImageAlign = ContentAlignment.MiddleLeft;
            btnBaoCao.Location = new Point(514, 13);
            btnBaoCao.Name = "btnBaoCao";
            btnBaoCao.Size = new Size(111, 36);
            btnBaoCao.TabIndex = 25;
            btnBaoCao.Text = "      Doanh thu";
            btnBaoCao.UseVisualStyleBackColor = false;
            btnBaoCao.Click += btnBaoCao_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(1001, 534);
            button1.Name = "button1";
            button1.Size = new Size(32, 32);
            button1.TabIndex = 26;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormQuanLy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1045, 578);
            Controls.Add(button1);
            Controls.Add(btnBaoCao);
            Controls.Add(label1);
            Controls.Add(txtTimKiem);
            Controls.Add(groupBox2);
            Controls.Add(lbPreview);
            Controls.Add(picPreview);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThemMoi);
            Controls.Add(dgvDanhSachSP);
            Name = "FormQuanLy";
            Text = "FormQuanLy";
            FormClosing += FormQuanLy_FormClosing;
            Load += FormQuanLy_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSP).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDanhSachSP;
        private Button btnThemMoi;
        private Button btnSua;
        private Button btnXoa;
        private PictureBox picPreview;
        private Label lbPreview;
        private GroupBox groupBox2;
        private Label lbDetailGia;
        private Label lbDetailTenSP;
        private Label lbDetailMoTa;
        private Label lbDetailDVT;
        private Label lbDetailXuatXu;
        private TextBox txtDetailMoTa;
        private TextBox txtTimKiem;
        private Label label1;
        private Label lbDetailSoLuong;
        private Button btnBaoCao;
        private Button button1;
    }
}
