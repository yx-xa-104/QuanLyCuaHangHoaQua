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
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSP).BeginInit();
            SuspendLayout();
            // 
            // dgvDanhSachSP
            // 
            dgvDanhSachSP.AllowUserToAddRows = false;
            dgvDanhSachSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachSP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSP.Location = new Point(56, 46);
            dgvDanhSachSP.Name = "dgvDanhSachSP";
            dgvDanhSachSP.ReadOnly = true;
            dgvDanhSachSP.Size = new Size(602, 218);
            dgvDanhSachSP.TabIndex = 15;
            // 
            // btnThemMoi
            // 
            btnThemMoi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemMoi.Location = new Point(56, 12);
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
            btnSua.Location = new Point(319, 12);
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
            btnXoa.Location = new Point(535, 12);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(122, 28);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xoá sản phẩm";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // FormQuanLy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 318);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThemMoi);
            Controls.Add(dgvDanhSachSP);
            Name = "FormQuanLy";
            Text = "FormQuanLy";
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSP).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDanhSachSP;
        private Button btnThemMoi;
        private Button btnSua;
        private Button btnXoa;
    }
}
