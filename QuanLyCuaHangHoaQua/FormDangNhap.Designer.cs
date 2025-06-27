namespace QuanLyCuaHangHoaQua
{
    partial class FormDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            btnThoat = new Button();
            btnDangNhap = new Button();
            SuspendLayout();
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BackColor = Color.FromArgb(182, 200, 115);
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTenDangNhap.Location = new Point(100, 272);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(164, 29);
            txtTenDangNhap.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = Color.FromArgb(182, 200, 115);
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(100, 344);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(164, 29);
            txtMatKhau.TabIndex = 3;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(182, 200, 115);
            btnThoat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.ForeColor = Color.FromArgb(103, 138, 34);
            btnThoat.Location = new Point(140, 399);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(59, 29);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Exit";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.FromArgb(182, 200, 115);
            btnDangNhap.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = Color.FromArgb(103, 138, 34);
            btnDangNhap.Location = new Point(205, 399);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(59, 29);
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "Login";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(352, 605);
            Controls.Add(btnDangNhap);
            Controls.Add(btnThoat);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Name = "FormDangNhap";
            Text = "FormDangNhap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private Button btnThoat;
        private Button btnDangNhap;
    }
}