namespace QuanLyCuaHangHoaQua
{
    partial class FormBanHang
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
            txtTimKiemSP = new TextBox();
            dgvChonSP = new DataGridView();
            label1 = new Label();
            dgvGioHang = new DataGridView();
            label2 = new Label();
            numSoLuongMua = new NumericUpDown();
            btnThemVaoGio = new Button();
            btnXoaKhoiGio = new Button();
            label3 = new Label();
            cbGiamGia = new ComboBox();
            lbTongTien = new Label();
            btnThanhToan = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvChonSP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongMua).BeginInit();
            SuspendLayout();
            // 
            // txtTimKiemSP
            // 
            txtTimKiemSP.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiemSP.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTimKiemSP.Location = new Point(12, 12);
            txtTimKiemSP.Name = "txtTimKiemSP";
            txtTimKiemSP.Size = new Size(500, 29);
            txtTimKiemSP.TabIndex = 0;
            // 
            // dgvChonSP
            // 
            dgvChonSP.BackgroundColor = SystemColors.Control;
            dgvChonSP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChonSP.Location = new Point(12, 47);
            dgvChonSP.Name = "dgvChonSP";
            dgvChonSP.Size = new Size(500, 550);
            dgvChonSP.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(740, 14);
            label1.Name = "label1";
            label1.Size = new Size(98, 30);
            label1.TabIndex = 2;
            label1.Text = "Hoá đơn";
            // 
            // dgvGioHang
            // 
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Location = new Point(553, 47);
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.Size = new Size(456, 300);
            dgvGioHang.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(553, 364);
            label2.Name = "label2";
            label2.Size = new Size(83, 21);
            label2.TabIndex = 4;
            label2.Text = "Số lượng:";
            // 
            // numSoLuongMua
            // 
            numSoLuongMua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numSoLuongMua.Location = new Point(553, 388);
            numSoLuongMua.Name = "numSoLuongMua";
            numSoLuongMua.Size = new Size(74, 29);
            numSoLuongMua.TabIndex = 5;
            // 
            // btnThemVaoGio
            // 
            btnThemVaoGio.BackColor = SystemColors.ActiveCaption;
            btnThemVaoGio.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemVaoGio.Location = new Point(762, 370);
            btnThemVaoGio.Name = "btnThemVaoGio";
            btnThemVaoGio.Size = new Size(109, 58);
            btnThemVaoGio.TabIndex = 6;
            btnThemVaoGio.Text = "Thêm vào giỏ";
            btnThemVaoGio.UseVisualStyleBackColor = false;
            btnThemVaoGio.Click += btnThemVaoGio_Click;
            // 
            // btnXoaKhoiGio
            // 
            btnXoaKhoiGio.BackColor = Color.IndianRed;
            btnXoaKhoiGio.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaKhoiGio.Location = new Point(901, 370);
            btnXoaKhoiGio.Name = "btnXoaKhoiGio";
            btnXoaKhoiGio.Size = new Size(107, 58);
            btnXoaKhoiGio.TabIndex = 7;
            btnXoaKhoiGio.Text = "Xoá khỏi giỏ";
            btnXoaKhoiGio.UseVisualStyleBackColor = false;
            btnXoaKhoiGio.Click += btnXoaKhoiGio_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(654, 364);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 8;
            label3.Text = "Giảm giá";
            // 
            // cbGiamGia
            // 
            cbGiamGia.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbGiamGia.FormattingEnabled = true;
            cbGiamGia.Items.AddRange(new object[] { "5", "10", "15", "20", "25" });
            cbGiamGia.Location = new Point(657, 388);
            cbGiamGia.Name = "cbGiamGia";
            cbGiamGia.Size = new Size(75, 29);
            cbGiamGia.TabIndex = 9;
            cbGiamGia.SelectedIndexChanged += cbGiamGia_SelectedIndexChanged;
            // 
            // lbTongTien
            // 
            lbTongTien.AutoSize = true;
            lbTongTien.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTongTien.Location = new Point(762, 461);
            lbTongTien.Name = "lbTongTien";
            lbTongTien.Size = new Size(53, 32);
            lbTongTien.TabIndex = 10;
            lbTongTien.Text = "(...)";
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.Chartreuse;
            btnThanhToan.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThanhToan.Location = new Point(702, 558);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(136, 39);
            btnThanhToan.TabIndex = 11;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(553, 461);
            label4.Name = "label4";
            label4.Size = new Size(209, 32);
            label4.TabIndex = 12;
            label4.Text = "Tổng tiền (VNĐ):";
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 609);
            Controls.Add(label4);
            Controls.Add(btnThanhToan);
            Controls.Add(lbTongTien);
            Controls.Add(cbGiamGia);
            Controls.Add(label3);
            Controls.Add(btnXoaKhoiGio);
            Controls.Add(btnThemVaoGio);
            Controls.Add(numSoLuongMua);
            Controls.Add(label2);
            Controls.Add(dgvGioHang);
            Controls.Add(label1);
            Controls.Add(dgvChonSP);
            Controls.Add(txtTimKiemSP);
            Name = "FormBanHang";
            Text = "FormBanHang";
            Load += FormBanHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChonSP).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongMua).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTimKiemSP;
        private DataGridView dgvChonSP;
        private Label label1;
        private DataGridView dgvGioHang;
        private Label label2;
        private NumericUpDown numSoLuongMua;
        private Button btnThemVaoGio;
        private Button btnXoaKhoiGio;
        private Label label3;
        private ComboBox cbGiamGia;
        private Label lbTongTien;
        private Button btnThanhToan;
        private Label label4;
    }
}