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
            groupBox1 = new GroupBox();
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
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
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
            groupBox1.Location = new Point(12, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(602, 271);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thêm sản phẩm mới";
            // 
            // txtTenHoaQua
            // 
            txtTenHoaQua.BorderStyle = BorderStyle.FixedSingle;
            txtTenHoaQua.Location = new Point(6, 37);
            txtTenHoaQua.Name = "txtTenHoaQua";
            txtTenHoaQua.Size = new Size(100, 23);
            txtTenHoaQua.TabIndex = 1;
            txtTenHoaQua.TextChanged += txtTenHoaQua_TextChanged;
            // 
            // picHinhAnh
            // 
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.Location = new Point(157, 73);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(288, 147);
            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 8;
            picHinhAnh.TabStop = false;
            // 
            // lbCharCount
            // 
            lbCharCount.AutoSize = true;
            lbCharCount.Location = new Point(6, 63);
            lbCharCount.Name = "lbCharCount";
            lbCharCount.Size = new Size(39, 15);
            lbCharCount.TabIndex = 11;
            lbCharCount.Text = "0 kí tự";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(370, 226);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 23);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // lbDonViTinh
            // 
            lbDonViTinh.AutoSize = true;
            lbDonViTinh.Location = new Point(153, 19);
            lbDonViTinh.Name = "lbDonViTinh";
            lbDonViTinh.Size = new Size(68, 15);
            lbDonViTinh.TabIndex = 2;
            lbDonViTinh.Text = "Đơn vị tính:";
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(263, 226);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(101, 23);
            btnChonAnh.TabIndex = 9;
            btnChonAnh.Text = "Chọn ảnh ...";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // cbDonViTinh
            // 
            cbDonViTinh.FormattingEnabled = true;
            cbDonViTinh.Items.AddRange(new object[] { "Kg", "Quả", "Bó", "Nải" });
            cbDonViTinh.Location = new Point(153, 36);
            cbDonViTinh.Name = "cbDonViTinh";
            cbDonViTinh.Size = new Size(121, 23);
            cbDonViTinh.TabIndex = 3;
            // 
            // lbXuatXu
            // 
            lbXuatXu.AutoSize = true;
            lbXuatXu.Location = new Point(488, 19);
            lbXuatXu.Name = "lbXuatXu";
            lbXuatXu.Size = new Size(51, 15);
            lbXuatXu.TabIndex = 6;
            lbXuatXu.Text = "Xuất Xứ:";
            // 
            // txtXuatXu
            // 
            txtXuatXu.BorderStyle = BorderStyle.FixedSingle;
            txtXuatXu.Location = new Point(488, 37);
            txtXuatXu.Name = "txtXuatXu";
            txtXuatXu.Size = new Size(100, 23);
            txtXuatXu.TabIndex = 7;
            // 
            // lbDonGia
            // 
            lbDonGia.AutoSize = true;
            lbDonGia.Location = new Point(321, 19);
            lbDonGia.Name = "lbDonGia";
            lbDonGia.Size = new Size(86, 15);
            lbDonGia.TabIndex = 4;
            lbDonGia.Text = "Đơn giá (VNĐ):";
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(321, 37);
            numDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(120, 23);
            numDonGia.TabIndex = 5;
            numDonGia.ThousandsSeparator = true;
            // 
            // lbTen
            // 
            lbTen.AutoSize = true;
            lbTen.Location = new Point(6, 19);
            lbTen.Name = "lbTen";
            lbTen.Size = new Size(75, 15);
            lbTen.TabIndex = 0;
            lbTen.Text = "Tên hoa quả:";
            // 
            // FormThemSuaSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 296);
            Controls.Add(groupBox1);
            Name = "FormThemSuaSanPham";
            Text = "FormThemSuaSanPham";
            FormClosing += FormThemSuaSanPham_FormClosing;
            Load += FormThemSuaSanPham_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
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
    }
}