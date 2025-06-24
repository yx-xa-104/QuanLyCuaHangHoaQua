namespace QuanLyCuaHangHoaQua
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
            dgvDanhSachSP = new DataGridView();
            btnThemMoi = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            picPreview = new PictureBox();
            lbPreview = new Label();
            groupBox2 = new GroupBox();
            txtDetailMoTa = new TextBox();
            lbDetailMoTa = new Label();
            lbDetailDVT = new Label();
            lbDetailXuatXu = new Label();
            lbDetailGia = new Label();
            lbDetailTenSP = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDanhSachSP
            // 
            dgvDanhSachSP.AllowUserToAddRows = false;
            dgvDanhSachSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSP.Location = new Point(67, 59);
            dgvDanhSachSP.Name = "dgvDanhSachSP";
            dgvDanhSachSP.ReadOnly = true;
            dgvDanhSachSP.Size = new Size(536, 480);
            dgvDanhSachSP.TabIndex = 15;
            dgvDanhSachSP.SelectionChanged += dgvDanhSachSP_SelectionChanged;
            // 
            // btnThemMoi
            // 
            btnThemMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemMoi.Location = new Point(67, 12);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(166, 28);
            btnThemMoi.TabIndex = 16;
            btnThemMoi.Text = "Thêm sản phẩm mới";
            btnThemMoi.UseVisualStyleBackColor = true;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(297, 12);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(119, 28);
            btnSua.TabIndex = 17;
            btnSua.Text = "Sửa sản phẩm";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(480, 12);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(122, 28);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xoá sản phẩm";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // picPreview
            // 
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(680, 59);
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
            lbPreview.Location = new Point(750, 31);
            lbPreview.Name = "lbPreview";
            lbPreview.Size = new Size(195, 25);
            lbPreview.TabIndex = 20;
            lbPreview.Text = "Hình ảnh xem trước:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtDetailMoTa);
            groupBox2.Controls.Add(lbDetailMoTa);
            groupBox2.Controls.Add(lbDetailDVT);
            groupBox2.Controls.Add(lbDetailXuatXu);
            groupBox2.Controls.Add(lbDetailGia);
            groupBox2.Controls.Add(lbDetailTenSP);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(680, 271);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(311, 268);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết:";
            // 
            // txtDetailMoTa
            // 
            txtDetailMoTa.BackColor = SystemColors.Window;
            txtDetailMoTa.BorderStyle = BorderStyle.FixedSingle;
            txtDetailMoTa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDetailMoTa.Location = new Point(6, 190);
            txtDetailMoTa.Multiline = true;
            txtDetailMoTa.Name = "txtDetailMoTa";
            txtDetailMoTa.ReadOnly = true;
            txtDetailMoTa.ScrollBars = ScrollBars.Vertical;
            txtDetailMoTa.Size = new Size(299, 70);
            txtDetailMoTa.TabIndex = 5;
            txtDetailMoTa.TextChanged += txtMoTa_TextChanged;
            // 
            // lbDetailMoTa
            // 
            lbDetailMoTa.AutoSize = true;
            lbDetailMoTa.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailMoTa.Location = new Point(6, 166);
            lbDetailMoTa.Name = "lbDetailMoTa";
            lbDetailMoTa.Size = new Size(136, 21);
            lbDetailMoTa.TabIndex = 4;
            lbDetailMoTa.Text = "Mô tả sản phẩm:";
            // 
            // lbDetailDVT
            // 
            lbDetailDVT.AutoSize = true;
            lbDetailDVT.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailDVT.Location = new Point(6, 133);
            lbDetailDVT.Name = "lbDetailDVT";
            lbDetailDVT.Size = new Size(99, 21);
            lbDetailDVT.TabIndex = 3;
            lbDetailDVT.Text = "Đơn vị tính:";
            // 
            // lbDetailXuatXu
            // 
            lbDetailXuatXu.AutoSize = true;
            lbDetailXuatXu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailXuatXu.Location = new Point(6, 100);
            lbDetailXuatXu.Name = "lbDetailXuatXu";
            lbDetailXuatXu.Size = new Size(73, 21);
            lbDetailXuatXu.TabIndex = 2;
            lbDetailXuatXu.Text = "Xuất xứ:";
            // 
            // lbDetailGia
            // 
            lbDetailGia.AutoSize = true;
            lbDetailGia.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailGia.Location = new Point(6, 67);
            lbDetailGia.Name = "lbDetailGia";
            lbDetailGia.Size = new Size(39, 21);
            lbDetailGia.TabIndex = 1;
            lbDetailGia.Text = "Giá:";
            // 
            // lbDetailTenSP
            // 
            lbDetailTenSP.AutoSize = true;
            lbDetailTenSP.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDetailTenSP.Location = new Point(6, 34);
            lbDetailTenSP.Name = "lbDetailTenSP";
            lbDetailTenSP.Size = new Size(174, 21);
            lbDetailTenSP.TabIndex = 0;
            lbDetailTenSP.Text = "Chưa chọn sản phẩm:";
            // 
            // FormQuanLy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 594);
            Controls.Add(groupBox2);
            Controls.Add(lbPreview);
            Controls.Add(picPreview);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThemMoi);
            Controls.Add(dgvDanhSachSP);
            Name = "FormQuanLy";
            Text = "FormQuanLy";
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
    }
}
